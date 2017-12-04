using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Thrift.Protocol;
using Thrift.Transport;
using Thrift;
using System.Reflection;
using System.Linq;
using generic_thrift_client.common;

namespace generic_thrift_client.impl
{
    /// <summary>
    /// 根据GenericTree 构建thrift泛化服务
    /// by xie 2017.11.22
    /// QQ:229315679
    /// </summary>
    public class TGenericClient : GenericClient
    {
        public static String PARAMINFO_COLLECTION_INNER_KEY = "collection_inner_key";
        public static String PARAMINFO_COLLECTION_MAP_KEY = "collection_map_key";
        public static String PARAMINFO_COLLECTION_MAP_VALUE = "collection_map_value";
        private static String WRITE = "write";
        private static String READ = "read";


        public object syncProcess(TProtocol oprot, GenericNode genericNode)
        {
            // oprot.Transport.Open();
            int seqid_ = sendMsg(oprot, genericNode);
            Object result = recvMsg(oprot, genericNode.getOutput(), seqid_);
            // oprot.Transport.Close();
            return result;
        }

        /// <summary>
        /// 泛化thrift send操作 请求方法调用
        /// </summary>
        /// <param name="oprot"></param>
        /// <param name="genericNode"></param>
        /// <returns></returns>
        public int sendMsg(TProtocol oprot, GenericNode genericNode)
        {
            int seqid_ = 0;
            oprot.WriteMessageBegin(new TMessage(genericNode.getMethodName(), TMessageType.Call, ++seqid_));
            write(oprot, genericNode.getInputs(), genericNode.getMethodName(), genericNode.getValues());
            oprot.WriteMessageEnd();
            oprot.Transport.Flush();
            return seqid_;
        }

        public object recvMsg(TProtocol iprot, GenericTree genericTree, int seqid_)
        {
            TMessage msg = iprot.ReadMessageBegin();
            if (msg.Type == TMessageType.Exception)
            {
                TApplicationException x = TApplicationException.Read(iprot);
                iprot.ReadMessageEnd();
                throw x;
            }
            if (msg.SeqID != seqid_)
            {
                throw new TApplicationException(TApplicationException.ExceptionType.BadSequenceID, " failed: out of sequence response");
            }

            Dictionary<string, object> result = new Dictionary<string, object>();

            List<GenericTree> list = new List<GenericTree>();

            if (genericTree != null) list.Add(genericTree);

            read(iprot, list, result);
            iprot.ReadMessageEnd();
            //如果genericTree 是复杂类型则需要去掉Map的第一层 ex: 返回值是{a : {b:1,c:2}} 则真正的返回值应该是{b:1,c:2}
            //TODO:如果是集合情况也应该是这样处理
            if (genericTree != null && !isPrimitiveType(genericTree))
            {
                object obj = result[genericTree.getName()];
                return obj;
            }
            return result;
        }

        /**
         * 方法第一层参数写入protocol
         * TODO: value是List 本身是一个json转义来的 如果前端某个值为null 则json不会保存这个可以 转以后是否有这个可以，有的话其对应的value应该是null 如何处理
         *
         * @param oprot
         * @param genericTrees
         * @param methodName
         * @param values
         * @throws TException
         * @throws NoSuchMethodException
         * @throws IllegalAccessException
         * @throws java.lang.reflect.InvocationTargetException
         */
        private void write(TProtocol oprot, List<GenericTree> genericTrees, string methodName, List<object> values)
        {
            int index = 0;
            string method_args = methodName + "_args";
            TStruct STRUCT_DESC = new TStruct(method_args);
            oprot.IncrementRecursionDepth();
            try
            {
                oprot.WriteStructBegin(STRUCT_DESC); //TODO:不能写在这里
                short id = 1;
                foreach (GenericTree first in genericTrees)
                {
                    writeVal(oprot, first, values[index++], id++);
                }

                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }
            finally
            {
                oprot.DecrementRecursionDepth();
            }
        }


        // protocol写入具体数据 基本类型直接写入 非基本类型需要递归进行写入
        // ex:oprot.writeString()
        // TODO:存在多次JSON decode enocde 性能问题！
        // TODO:value 为null如何处理

        private void writeVal(TProtocol oprot, GenericTree genericTree, object value, short id)
        {
            String thriftType = genericTree.getThrfitType();
            if (value == null)
                return;
            if (isPrimitiveType(genericTree))
            {
                oprot.IncrementRecursionDepth();
                try
                {
                    TField tField = getTField(genericTree.getName(), thriftType, id);
                    oprot.WriteFieldBegin(tField);
                    doProtocolMethod(oprot, thriftType, value, WRITE);
                    oprot.WriteFieldEnd();
                }
                finally
                {
                    oprot.DecrementRecursionDepth();
                }
            }
            else if (isColletionType(genericTree))
            {
                TField tField = getTField(genericTree.getName(), thriftType, id);
                oprot.WriteFieldBegin(tField);
                //TODO:假设目前集合只有List类型
                // String json = Newtonsoft.Json.JsonConvert.SerializeObject(value);
                if (isColletionMap(genericTree))
                {
                    GenericTree k = genericTree.getChildren()[PARAMINFO_COLLECTION_MAP_KEY];
                    GenericTree v = genericTree.getChildren()[PARAMINFO_COLLECTION_MAP_VALUE];
                    if (k == null || v == null)
                    {
                        Console.WriteLine("key or value is not found in GenericNode !");
                    }
                    else
                    {
                        IDictionary map = value as IDictionary;

                        oprot.WriteMapBegin(new TMap(TypeChange.TTypeMap[k.getThrfitType().ToUpper()]
                            , TypeChange.TTypeMap[v.getThrfitType().ToUpper()], map.Count));

                        foreach (DictionaryEntry entry in map)
                        {
                            //TODO:只支持key是简单类型
                            doProtocolMethod(oprot, k.getThrfitType(), entry.Key, WRITE);
                            if (v.getParamType() == TypeEnum.PRIMITIVE_TYPE)
                                doProtocolMethod(oprot, v.getThrfitType(), entry.Value, WRITE);
                            else
                            {
                                writeVal(oprot, v, entry.Value, id);
                            }
                        }
                        oprot.WriteMapEnd();
                    }
                }
                else
                {

                    // List<object> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<object>>(json);
                    IEnumerable list = value as IEnumerable;

                    int count = 0;
                    foreach (var item in list) count++;

                    GenericTree child = genericTree.getChildren()[PARAMINFO_COLLECTION_INNER_KEY];
                    String childThriftType = child.getThrfitType();
                    oprot.WriteListBegin(new TList(TypeChange.TTypeMap[childThriftType.ToUpper()], count));
                    //获取容器的孩子节点，如果集合是基础类型的 本次遍历就到这里
                    if (isPrimitiveType(child))
                    {
                        foreach (object obj in list)
                        {
                            string childThrfitType = child.getThrfitType();
                            doProtocolMethod(oprot, childThrfitType, obj, WRITE);
                        }
                    }
                    else
                    {
                        foreach (object obj in list)
                        {
                            short ids = 1;
                            writeVal(oprot, child, obj, ids);
                        }
                    }
                    oprot.WriteListEnd();
                }

                oprot.WriteFieldEnd();
            }
            else
            {
                oprot.IncrementRecursionDepth();
                try
                {
                    TField field = new TField();
                    field.Name = genericTree.getName();
                    field.Type = TType.Struct;
                    field.ID = id;
                    oprot.WriteFieldBegin(field);

                    String structName = genericTree.getType();
                    TStruct STRUCT_DESC = new TStruct(structName);
                    oprot.WriteStructBegin(STRUCT_DESC);

                    //TODO:这个map是有序的
                    Dictionary<String, GenericTree> children = genericTree.getChildren();

                    Dictionary<string, object> map = value as Dictionary<string, object>;

                    short ids = 1;
                    foreach (GenericTree child in children.Values)
                    {
                        //if (map.ContainsKey(child.getName()))
                        //{
                        writeVal(oprot, child, map[child.getName()], ids++);
                        //}
                    }
                    oprot.WriteFieldStop();
                    oprot.WriteStructEnd();

                    oprot.WriteFieldEnd();
                }
                finally
                {
                    oprot.DecrementRecursionDepth();
                }
            }
        }

        private void read(TProtocol iprot, List<GenericTree> genericTrees, Dictionary<string, object> result)
        {
            TField schemeField;
            iprot.ReadStructBegin();
            //每一层的参数 按顺序逐个进行遍历 读取二进制序列返回值
            bool isStop = false;
            foreach (GenericTree genericTreeTmp in genericTrees)
            {
                GenericTree genericTree = new GenericTree();
                schemeField = iprot.ReadFieldBegin();
                if (schemeField.Type == TType.Stop)
                {
                    Console.WriteLine("返回结果参数个数不对！ type : stop 返回值可能为null");
                    isStop = true;
                    break;
                }
                if (genericTrees.Count > 1)
                {
                    genericTree = genericTrees[schemeField.ID - 1];
                }
                else
                {
                    genericTree = genericTreeTmp;
                }


                if (isPrimitiveType(genericTree))
                {
                    String key = genericTree.getName();
                    String thriftType = genericTree.getThrfitType();
                    Object obj = doProtocolMethod(iprot, thriftType, null, READ);
                    result.Add(key, obj);
                }
                else if (isColletionType(genericTree))
                {
                    if (schemeField.Type != TType.List && schemeField.Type != TType.Set && schemeField.Type != TType.Map)
                    {
                        Console.WriteLine("返回结果参数类型不是集合类型！ ： " + schemeField.Type);
                        break;
                        //TODO:若类型不匹配则跳过这段数据报文   TProtocolUtil.skip(iprot, schemeField.type);
                    }

                    //MAP单独处理
                    if (schemeField.Type == TType.Map)
                    {
                        TMap _map0 = iprot.ReadMapBegin();
                        GenericTree key = genericTree.getChildren()[PARAMINFO_COLLECTION_MAP_KEY];
                        GenericTree value = genericTree.getChildren()[PARAMINFO_COLLECTION_MAP_VALUE];
                        if (key == null || value == null)
                        {
                            Console.WriteLine("key or value is not found in GenericNode !");
                            break;
                        }
                        Dictionary<object, object> map = new Dictionary<object, object>(2 * _map0.Count);
                        //TODO:默认key是简单类型
                        for (int i = 0; i < _map0.Count; ++i)
                        {
                            object obj_key = doProtocolMethod(iprot, key.getThrfitType(), null, READ);
                            if (value.getParamType() == TypeEnum.PRIMITIVE_TYPE)
                            {
                                Object obj_value = doProtocolMethod(iprot, key.getThrfitType(), null, READ);
                                map.Add(obj_key, obj_value);
                            }
                            else if (value.getThrfitType() == "MAP")
                            {
                                Dictionary<object, object> map_value = new Dictionary<object, object>();
                                readMap(iprot, value.getChildren(), map_value);

                                map.Add(obj_key, map_value);
                            }
                            else
                            {
                                Dictionary<string, object> map_value = new Dictionary<string, object>();

                                List<GenericTree> children = value.getChildren().Values.ToList();

                                read(iprot, children, map_value);

                                map.Add(obj_key, map_value);
                            }
                        }
                        result.Add(genericTree.getName(), map);
                        iprot.ReadMapEnd();
                        iprot.ReadFieldEnd();
                        break;
                    }

                    TList _list0 = iprot.ReadListBegin();
                    //获取容器的孩子节点，如果集合是基础类型的 本次遍历就到这里
                    GenericTree child = genericTree.getChildren()[PARAMINFO_COLLECTION_INNER_KEY];

                    List<object> list = new List<object>();
                    if (isPrimitiveType(child))
                    {
                        for (int _i2 = 0; _i2 < _list0.Count; ++_i2)
                        {
                            string childThrfitType = child.getThrfitType();
                            list.Add(doProtocolMethod(iprot, childThrfitType, null, READ));
                        }
                        iprot.ReadListEnd();
                    }
                    else
                    {
                        //如果发现集合内部是复杂类型 则遍历_list0 内部就是复杂类型的结构参数
                        for (int _i2 = 0; _i2 < _list0.Count; ++_i2)
                        {
                            Dictionary<string, object> childResult = new Dictionary<string, object>();
                            //这里的child是复杂类型说明，应该直接拿到它的children 即它的子参数类型
                            List<GenericTree> children = child.getChildren().Values.ToList();
                            read(iprot, children, childResult);
                            list.Add(childResult);
                        }
                        iprot.ReadListEnd();
                    }
                    result[genericTree.getName()] = list;

                }
                else
                {
                    if (schemeField.Type != TType.Struct)
                    {
                        Console.WriteLine("返回结果参数类型不是复杂类型！ ： " + schemeField.Type);
                        break;
                        //TODO:若类型不匹配则跳过这段二进制序列   TProtocolUtil.skip(iprot, schemeField.type);
                    }
                    List<GenericTree> children = genericTree.getChildren().Values.ToList();
                    Dictionary<string, object> childResult = new Dictionary<string, object>();
                    //如果是第一层 即返回值类型本身，则本身没有key，应该直接将map传入下一层。通过map size是否为0判断是否未第一层
                    result[genericTree.getName()] = childResult;
                    read(iprot, children, childResult);
                }
                iprot.ReadFieldEnd();
            }

            if (!isStop)
            {
                schemeField = iprot.ReadFieldBegin();
                if (schemeField.Type != TType.Stop)
                {
                    Console.WriteLine("type is not stop : " + schemeField.Type);
                }
            }

            iprot.ReadStructEnd();
        }

        private void readMap(TProtocol iprot, Dictionary<string, GenericTree> genericTreeDict, Dictionary<object, object> result)
        {
            TMap _map0 = iprot.ReadMapBegin();

            GenericTree key = genericTreeDict[PARAMINFO_COLLECTION_MAP_KEY];
            GenericTree value = genericTreeDict[PARAMINFO_COLLECTION_MAP_VALUE];
            if (key == null || value == null)
            {
                Console.WriteLine("key or value is not found in GenericNode !");
                iprot.ReadMapEnd();
                return;
            }

            //TODO:默认key是简单类型
            for (int i = 0; i < _map0.Count; ++i)
            {
                object obj_key = doProtocolMethod(iprot, key.getThrfitType(), null, READ);
                if (value.getParamType() == TypeEnum.PRIMITIVE_TYPE)
                {
                    Object obj_value = doProtocolMethod(iprot, key.getThrfitType(), null, READ);
                    result.Add(obj_key, obj_value);
                }
                else if (value.getThrfitType() == "MAP")
                {
                    Dictionary<object, object> map_value = new Dictionary<object, object>();
                    readMap(iprot, value.getChildren(), map_value);

                    result.Add(obj_key, map_value);
                }
                else
                {
                    Dictionary<string, object> map_value = new Dictionary<string, object>();

                    List<GenericTree> children = value.getChildren().Values.ToList();

                    read(iprot, children, map_value);

                    result.Add(obj_key, map_value);
                }
            }
            iprot.ReadMapEnd();
        }


        private bool isPrimitiveType(GenericTree genericTree)
        {
            return genericTree.getParamType().GetHashCode() == TypeEnum.PRIMITIVE_TYPE.GetHashCode();
        }


        private bool isColletionType(GenericTree genericTree)
        {
            return genericTree.getParamType().GetHashCode() == TypeEnum.COLLECTION_TYPE.GetHashCode();
        }

        private bool isColletionMap(GenericTree genericTree)
        {
            return genericTree.getThrfitType().ToUpper().Equals("MAP");
        }


        private TField getTField(String paramName, String thriftType, short id)
        {
            return new TField(paramName, TypeChange.TTypeMap[thriftType.ToUpper()], id);
        }

        private object doProtocolMethod(TProtocol oprot, string type, object obj, string wr)
        {
            string methodName = null;
            MethodInfo method = null;
            Object result = null;
            if (wr.Equals(WRITE))
            {
                methodName = TypeChange.TPWriteMethodMap[type.ToUpper()];
                Type clazz = TypeChange.TPParamsMap[type.ToUpper()];
                method = oprot.GetType().GetMethod(methodName, new Type[] { clazz });

                method.Invoke(oprot, new object[] { obj });

                return result;
            }
            if (wr.Equals(READ))
            {
                methodName = TypeChange.TPReadMethodMap[type.ToUpper()];
                method = oprot.GetType().GetMethod(methodName);
                result = method.Invoke(oprot, null);
                return result;
            }
            Console.WriteLine("protocol method : " + method.Name);
            return result;
        }
    }
}