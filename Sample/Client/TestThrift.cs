using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Protocol;
using Thrift.Transport;

using generic_thrift_client;
using generic_thrift_client.common;
using generic_thrift_client.impl;
using Thrift.Test;
using Thrift.Collections;

namespace Client
{
    public class TestThrift
    {
        public string SERVER_IP = "172.16.211.97";
        public int SERVER_PORT = 7911;
        public int TIMEOUT = 30000;
        public string SERVICE_NAME = "ThriftTest";

        GenericClient genericAnalyser = new TGenericClient();
        TTransport transport;
        TProtocol protocol;
        PoolManager pool;
        ThriftPool thriftpool;
        public TestThrift()
        {
            /*
            transport = new TFramedTransport(new TSocket(SERVER_IP, SERVER_PORT, TIMEOUT));
            // 协议要和服务端一致
            // TBinaryProtocol
            // TJSONProtocol

            protocol = new TBinaryProtocol(transport);
            */

            pool = new PoolManager(SERVER_IP, SERVER_PORT);
            thriftpool = pool.Get();
            transport = thriftpool.transport;
            protocol = thriftpool.protocol;


            SERVICE_NAME += ":";
        }
        public void Close()
        {
            pool.Return(thriftpool);
        }


        public void secondtestString()
        {
            //入参
            GenericTree input1 = new GenericTree();
            input1.setName("thing");
            input1.setParamType(TypeEnum.PRIMITIVE_TYPE);
            input1.setThrfitType("STRING");

            List<GenericTree> inputGenericTrees = new List<GenericTree>
            {
                input1
            };

            // 参数值
            List<Object> inputVals = new List<object>();
            inputVals.Add("xiejianjun");


            //出参
            GenericTree output = new GenericTree();
            output.setParamType(TypeEnum.PRIMITIVE_TYPE);
            output.setThrfitType("string");
            output.setName("returnModel");

            string method = "SecondService:secondtestString";

            GenericNode genericNode = new GenericNode();
            genericNode.setInputs(inputGenericTrees);
            genericNode.setMethodName(method);
            genericNode.setValues(inputVals);
            genericNode.setOutput(output);

            object obj = genericAnalyser.syncProcess(protocol, genericNode);

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }


        public void testBinary(byte[] thing)
        {
            GenericTree input1 = new GenericTree();
            input1.setName("thing");
            input1.setParamType(TypeEnum.PRIMITIVE_TYPE);
            input1.setThrfitType("STRING");

            List<GenericTree> inputGenericTrees = new List<GenericTree>
            {
                input1
            };

            // 参数值
            List<Object> inputVals = new List<object>();
            inputVals.Add(Encoding.UTF8.GetString(thing));

            //出参
            GenericTree output = new GenericTree();
            output.setParamType(TypeEnum.PRIMITIVE_TYPE);
            output.setThrfitType("STRING");
            output.setName("returnModel");

            string method = SERVICE_NAME + "testBinary";

            GenericNode genericNode = new GenericNode();
            genericNode.setInputs(inputGenericTrees);
            genericNode.setMethodName(method);
            genericNode.setValues(inputVals);
            genericNode.setOutput(output);

            object obj = genericAnalyser.syncProcess(protocol, genericNode);

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }

        public void testBool(bool thing)
        {
            GenericTree input1 = new GenericTree();
            input1.setName("thing");
            input1.setParamType(TypeEnum.PRIMITIVE_TYPE);
            input1.setThrfitType("BOOL");

            List<GenericTree> inputGenericTrees = new List<GenericTree>
            {
                input1
            };

            // 参数值
            List<Object> inputVals = new List<object>();
            inputVals.Add(thing);

            //出参
            GenericTree output = new GenericTree();
            output.setParamType(TypeEnum.PRIMITIVE_TYPE);
            output.setThrfitType("BOOL");
            output.setName("returnModel");

            string method = SERVICE_NAME + "testBool";

            GenericNode genericNode = new GenericNode();
            genericNode.setInputs(inputGenericTrees);
            genericNode.setMethodName(method);
            genericNode.setValues(inputVals);
            genericNode.setOutput(output);

            object obj = genericAnalyser.syncProcess(protocol, genericNode);

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }

        public void testByte(sbyte thing)
        {
            GenericTree input1 = new GenericTree();
            input1.setName("thing");
            input1.setParamType(TypeEnum.PRIMITIVE_TYPE);
            input1.setThrfitType("SBYTE");

            List<GenericTree> inputGenericTrees = new List<GenericTree>
            {
                input1
            };

            // 参数值
            List<Object> inputVals = new List<object>();
            inputVals.Add(thing);

            //出参
            GenericTree output = new GenericTree();
            output.setParamType(TypeEnum.PRIMITIVE_TYPE);
            output.setThrfitType("SBYTE");
            output.setName("returnModel");

            string method = SERVICE_NAME + "testByte";

            GenericNode genericNode = new GenericNode();
            genericNode.setInputs(inputGenericTrees);
            genericNode.setMethodName(method);
            genericNode.setValues(inputVals);
            genericNode.setOutput(output);

            object obj = genericAnalyser.syncProcess(protocol, genericNode);

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));

        }

        public void testDouble(double thing)
        {
            GenericTree input1 = new GenericTree();
            input1.setName("thing");
            input1.setParamType(TypeEnum.PRIMITIVE_TYPE);
            input1.setThrfitType("DOUBLE");

            List<GenericTree> inputGenericTrees = new List<GenericTree>
            {
                input1
            };

            // 参数值
            List<Object> inputVals = new List<object>();
            inputVals.Add(thing);

            //出参
            GenericTree output = new GenericTree();
            output.setParamType(TypeEnum.PRIMITIVE_TYPE);
            output.setThrfitType("DOUBLE");
            output.setName("returnModel");

            string method = SERVICE_NAME + "testDouble";

            GenericNode genericNode = new GenericNode();
            genericNode.setInputs(inputGenericTrees);
            genericNode.setMethodName(method);
            genericNode.setValues(inputVals);
            genericNode.setOutput(output);

            object obj = genericAnalyser.syncProcess(protocol, genericNode);

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }

        public void testEnum(int thing)
        {
            GenericTree input1 = new GenericTree();
            input1.setName("thing");
            input1.setParamType(TypeEnum.PRIMITIVE_TYPE);
            input1.setThrfitType("I32");

            List<GenericTree> inputGenericTrees = new List<GenericTree>
            {
                input1
            };

            // 参数值
            List<Object> inputVals = new List<object>();
            inputVals.Add(thing);

            //出参
            GenericTree output = new GenericTree();
            output.setParamType(TypeEnum.PRIMITIVE_TYPE);
            output.setThrfitType("I32");
            output.setName("returnModel");

            string method = SERVICE_NAME + "testEnum";

            GenericNode genericNode = new GenericNode();
            genericNode.setInputs(inputGenericTrees);
            genericNode.setMethodName(method);
            genericNode.setValues(inputVals);
            genericNode.setOutput(output);

            object obj = genericAnalyser.syncProcess(protocol, genericNode);

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }

        public void testException(string arg)
        {
            GenericTree input1 = new GenericTree();
            input1.setName("thing");
            input1.setParamType(TypeEnum.PRIMITIVE_TYPE);
            input1.setThrfitType("STRING");

            List<GenericTree> inputGenericTrees = new List<GenericTree>
            {
                input1
            };

            // 参数值
            List<Object> inputVals = new List<object>();
            inputVals.Add(arg);

            //出参
            GenericTree output = null;

            string method = SERVICE_NAME + "testException";

            GenericNode genericNode = new GenericNode();
            genericNode.setInputs(inputGenericTrees);
            genericNode.setMethodName(method);
            genericNode.setValues(inputVals);
            genericNode.setOutput(output);


            object obj = genericAnalyser.syncProcess(protocol, genericNode);

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }

        public void testI32(int thing)
        {
            GenericTree input1 = new GenericTree();
            input1.setName("thing");
            input1.setParamType(TypeEnum.PRIMITIVE_TYPE);
            input1.setThrfitType("I32");

            List<GenericTree> inputGenericTrees = new List<GenericTree>
            {
                input1
            };

            // 参数值
            List<Object> inputVals = new List<object>();
            inputVals.Add(thing);

            //出参
            GenericTree output = new GenericTree();
            output.setParamType(TypeEnum.PRIMITIVE_TYPE);
            output.setThrfitType("I32");
            output.setName("returnModel");

            string method = SERVICE_NAME + "testI32";

            GenericNode genericNode = new GenericNode();
            genericNode.setInputs(inputGenericTrees);
            genericNode.setMethodName(method);
            genericNode.setValues(inputVals);
            genericNode.setOutput(output);

            object obj = genericAnalyser.syncProcess(protocol, genericNode);

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));

        }

        public void testI64(long thing)
        {
            GenericTree input1 = new GenericTree();
            input1.setName("thing");
            input1.setParamType(TypeEnum.PRIMITIVE_TYPE);
            input1.setThrfitType("I64");

            List<GenericTree> inputGenericTrees = new List<GenericTree>
            {
                input1
            };

            // 参数值
            List<Object> inputVals = new List<object>();
            inputVals.Add(thing);

            //出参
            GenericTree output = new GenericTree();
            output.setParamType(TypeEnum.PRIMITIVE_TYPE);
            output.setThrfitType("I64");
            output.setName("returnModel");

            string method = SERVICE_NAME + "testI64";

            GenericNode genericNode = new GenericNode();
            genericNode.setInputs(inputGenericTrees);
            genericNode.setMethodName(method);
            genericNode.setValues(inputVals);
            genericNode.setOutput(output);

            object obj = genericAnalyser.syncProcess(protocol, genericNode);

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }

        public void testInsanity(string argument)
        {
            // Dictionary<long, Dictionary<Numberz, Insanity>>

            GenericTree input1 = new GenericTree();
            input1.setName("argument");
            input1.setParamType(TypeEnum.SYNTHETIC_TYPE);
            input1.setThrfitType("STRUCT");

            Dictionary<string, GenericTree> insanity = new Dictionary<string, GenericTree>();

            GenericTree userMap = new GenericTree();
            userMap.setName("userMap");
            userMap.setParamType(TypeEnum.COLLECTION_TYPE);
            userMap.setThrfitType("MAP");

            GenericTree xtructs = new GenericTree();
            xtructs.setName("xtructs");
            xtructs.setParamType(TypeEnum.COLLECTION_TYPE);
            xtructs.setThrfitType("LIST");

            insanity.Add("userMap", userMap);
            insanity.Add("xtructs", xtructs);


            input1.setChildren(insanity);


            List<GenericTree> inputGenericTrees = new List<GenericTree>
            {
                input1
            };

            // 参数值
            List<Object> inputVals = new List<object>();
            inputVals.Add(argument);

            //出参
            GenericTree output = new GenericTree();
            output.setParamType(TypeEnum.PRIMITIVE_TYPE);
            output.setThrfitType("STRING");
            output.setName("returnModel");

            string method = SERVICE_NAME + "testInsanity";

            GenericNode genericNode = new GenericNode();
            genericNode.setInputs(inputGenericTrees);
            genericNode.setMethodName(method);
            genericNode.setValues(inputVals);
            genericNode.setOutput(output);

            object obj = genericAnalyser.syncProcess(protocol, genericNode);

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }

        public void testList(List<int> thing)
        {
            GenericTree input1 = new GenericTree();
            input1.setName("thing");
            input1.setParamType(TypeEnum.COLLECTION_TYPE);
            input1.setThrfitType("LIST");

            GenericTree innerKey = new GenericTree();
            innerKey.setName("thing");
            innerKey.setParamType(TypeEnum.PRIMITIVE_TYPE);
            innerKey.setThrfitType("I32");

            Dictionary<string, GenericTree> children = new Dictionary<string, GenericTree>();

            children.Add(TGenericClient.PARAMINFO_COLLECTION_INNER_KEY, innerKey);

            input1.setChildren(children);

            List<GenericTree> inputGenericTrees = new List<GenericTree>
            {
                input1
            };

            // 参数值
            List<Object> inputVals = new List<object>();
            inputVals.Add(thing);

            //出参
            GenericTree output = new GenericTree();
            output.setParamType(TypeEnum.COLLECTION_TYPE);
            output.setThrfitType("LIST");
            output.setName("returnModel");

            GenericTree outKey = new GenericTree();
            outKey.setName("thing");
            outKey.setParamType(TypeEnum.PRIMITIVE_TYPE);
            outKey.setThrfitType("I32");

            Dictionary<string, GenericTree> outputChildren = new Dictionary<string, GenericTree>();

            outputChildren.Add(TGenericClient.PARAMINFO_COLLECTION_INNER_KEY, outKey);

            output.setChildren(outputChildren);

            string method = SERVICE_NAME + "testList";

            GenericNode genericNode = new GenericNode();
            genericNode.setInputs(inputGenericTrees);
            genericNode.setMethodName(method);
            genericNode.setValues(inputVals);
            genericNode.setOutput(output);

            object obj = genericAnalyser.syncProcess(protocol, genericNode);

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));

        }

        public void testMap(Dictionary<int, int> thing)
        {
            GenericTree input1 = new GenericTree();
            input1.setName("thing");
            input1.setParamType(TypeEnum.COLLECTION_TYPE);
            input1.setThrfitType("MAP");

            GenericTree innerKey = new GenericTree();
            innerKey.setName("thing");
            innerKey.setParamType(TypeEnum.PRIMITIVE_TYPE);
            innerKey.setThrfitType("I32");

            Dictionary<string, GenericTree> children = new Dictionary<string, GenericTree>();

            children.Add(TGenericClient.PARAMINFO_COLLECTION_MAP_KEY, innerKey);
            children.Add(TGenericClient.PARAMINFO_COLLECTION_MAP_VALUE, innerKey);

            input1.setChildren(children);

            List<GenericTree> inputGenericTrees = new List<GenericTree>
            {
                input1
            };

            // 参数值
            List<Object> inputVals = new List<object>();
            inputVals.Add(thing);

            //出参
            GenericTree output = new GenericTree();
            output.setParamType(TypeEnum.COLLECTION_TYPE);
            output.setThrfitType("MAP");
            output.setName("returnModel");

            GenericTree outKey = new GenericTree();
            outKey.setName("thing");
            outKey.setParamType(TypeEnum.PRIMITIVE_TYPE);
            outKey.setThrfitType("I32");

            Dictionary<string, GenericTree> outputChildren = new Dictionary<string, GenericTree>();

            outputChildren.Add(TGenericClient.PARAMINFO_COLLECTION_MAP_KEY, outKey);
            outputChildren.Add(TGenericClient.PARAMINFO_COLLECTION_MAP_VALUE, outKey);

            output.setChildren(outputChildren);

            string method = SERVICE_NAME + "testMap";

            GenericNode genericNode = new GenericNode();
            genericNode.setInputs(inputGenericTrees);
            genericNode.setMethodName(method);
            genericNode.setValues(inputVals);
            genericNode.setOutput(output);

            object obj = genericAnalyser.syncProcess(protocol, genericNode);

            // Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));

        }

        public void testMapMap(int hello)
        {
            GenericTree input1 = new GenericTree();
            input1.setName("thing");
            input1.setParamType(TypeEnum.COLLECTION_TYPE);
            input1.setThrfitType("MAP");

            GenericTree innerKey = new GenericTree();
            innerKey.setName("thing1");
            innerKey.setParamType(TypeEnum.PRIMITIVE_TYPE);
            innerKey.setThrfitType("I32");

            GenericTree innerValue = new GenericTree();
            innerValue.setName("thing2");
            innerValue.setParamType(TypeEnum.COLLECTION_TYPE);
            innerValue.setThrfitType("MAP");

            Dictionary<string, GenericTree> valueChildren = new Dictionary<string, GenericTree>();
            valueChildren.Add(TGenericClient.PARAMINFO_COLLECTION_MAP_KEY, innerKey);
            valueChildren.Add(TGenericClient.PARAMINFO_COLLECTION_MAP_VALUE, innerKey);

            innerValue.setChildren(valueChildren);

            Dictionary<string, GenericTree> children = new Dictionary<string, GenericTree>();

            children.Add(TGenericClient.PARAMINFO_COLLECTION_MAP_KEY, innerKey);
            children.Add(TGenericClient.PARAMINFO_COLLECTION_MAP_VALUE, innerValue);

            input1.setChildren(children);

            List<GenericTree> inputGenericTrees = new List<GenericTree>
            {
                innerKey
            };

            // 参数值
            List<Object> inputVals = new List<object>();
            inputVals.Add(hello);

            //出参
            GenericTree output = new GenericTree();
            output.setParamType(TypeEnum.COLLECTION_TYPE);
            output.setThrfitType("MAP");
            output.setName("returnModel");

            GenericTree outKey = new GenericTree();
            outKey.setName("thing");
            outKey.setParamType(TypeEnum.PRIMITIVE_TYPE);
            outKey.setThrfitType("I32");

            GenericTree outValue = new GenericTree();
            outValue.setName("thing");
            outValue.setParamType(TypeEnum.COLLECTION_TYPE);
            outValue.setThrfitType("MAP");

            Dictionary<string, GenericTree> outValueChildren = new Dictionary<string, GenericTree>();
            outValueChildren.Add(TGenericClient.PARAMINFO_COLLECTION_MAP_KEY, outKey);
            outValueChildren.Add(TGenericClient.PARAMINFO_COLLECTION_MAP_VALUE, outKey);

            outValue.setChildren(outValueChildren);

            Dictionary<string, GenericTree> outputChildren = new Dictionary<string, GenericTree>();

            outputChildren.Add(TGenericClient.PARAMINFO_COLLECTION_MAP_KEY, outKey);
            outputChildren.Add(TGenericClient.PARAMINFO_COLLECTION_MAP_VALUE, outValue);

            output.setChildren(outputChildren);

            string method = SERVICE_NAME + "testMapMap";

            GenericNode genericNode = new GenericNode();
            genericNode.setInputs(inputGenericTrees);
            genericNode.setMethodName(method);
            genericNode.setValues(inputVals);
            genericNode.setOutput(output);

            object obj = genericAnalyser.syncProcess(protocol, genericNode);

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }

        public void testMulti(sbyte arg0, int arg1, long arg2, Dictionary<short, string> arg3, Numberz arg4, long arg5)
        {
            // 返回 Xtruct

            GenericTree _arg0 = new GenericTree();
            _arg0.setName("arg0");
            _arg0.setParamType(TypeEnum.PRIMITIVE_TYPE);
            _arg0.setThrfitType("SBYTE");

            GenericTree _arg1 = new GenericTree();
            _arg1.setName("_arg1");
            _arg1.setParamType(TypeEnum.PRIMITIVE_TYPE);
            _arg1.setThrfitType("I32");

            GenericTree _arg2 = new GenericTree();
            _arg2.setName("_arg2");
            _arg2.setParamType(TypeEnum.PRIMITIVE_TYPE);
            _arg2.setThrfitType("I64");

            GenericTree _arg3 = new GenericTree();
            _arg3.setName("_arg3");
            _arg3.setParamType(TypeEnum.COLLECTION_TYPE);
            _arg3.setThrfitType("MAP");


            GenericTree innerKey = new GenericTree();
            innerKey.setName("innerKey");
            innerKey.setParamType(TypeEnum.PRIMITIVE_TYPE);
            innerKey.setThrfitType("I16");

            GenericTree innerValue = new GenericTree();
            innerValue.setName("innerValue");
            innerValue.setParamType(TypeEnum.PRIMITIVE_TYPE);
            innerValue.setThrfitType("STRING");

            Dictionary<string, GenericTree> children = new Dictionary<string, GenericTree>();

            children.Add(TGenericClient.PARAMINFO_COLLECTION_MAP_KEY, innerKey);
            children.Add(TGenericClient.PARAMINFO_COLLECTION_MAP_VALUE, innerValue);

            _arg3.setChildren(children);



            GenericTree _arg4 = new GenericTree();
            _arg4.setName("_arg4");
            _arg4.setParamType(TypeEnum.PRIMITIVE_TYPE);
            _arg4.setThrfitType("I32");

            GenericTree _arg5 = new GenericTree();
            _arg5.setName("_arg5");
            _arg5.setParamType(TypeEnum.PRIMITIVE_TYPE);
            _arg5.setThrfitType("I64");

            List<GenericTree> inputGenericTrees = new List<GenericTree>
            {
                _arg0,_arg1, _arg2, _arg3,_arg4,_arg5
            };

            GenericTree input2 = new GenericTree();
            input2.setName("thing");
            input2.setParamType(TypeEnum.SYNTHETIC_TYPE);
            input2.setThrfitType("STRUCT");
            input2.setType("Xtruct");

            GenericTree prop11 = new GenericTree();
            prop11.setName("String_thing");
            prop11.setParamType(TypeEnum.PRIMITIVE_TYPE);
            prop11.setThrfitType("STRING");
            prop11.setParent(input2);


            GenericTree prop12 = new GenericTree();
            prop12.setName("Byte_thing");
            prop12.setParamType(TypeEnum.PRIMITIVE_TYPE);
            prop12.setThrfitType("SBYTE");
            prop12.setParent(input2);

            GenericTree prop13 = new GenericTree();
            prop13.setName("I32_thing");
            prop13.setParamType(TypeEnum.PRIMITIVE_TYPE);
            prop13.setThrfitType("I32");
            prop13.setParent(input2);

            GenericTree prop14 = new GenericTree();
            prop14.setName("I64_thing");
            prop14.setParamType(TypeEnum.PRIMITIVE_TYPE);
            prop14.setThrfitType("I64");
            prop14.setParent(input2);


            // 参数值
            List<Object> inputVals = new List<object>();


            inputVals.Add(arg0);
            inputVals.Add(arg1);
            inputVals.Add(arg2);
            inputVals.Add(arg3);
            inputVals.Add(arg4);
            inputVals.Add(arg5);

            //出参


            string method = SERVICE_NAME + "testMulti";

            GenericNode genericNode = new GenericNode();
            genericNode.setInputs(inputGenericTrees);
            genericNode.setMethodName(method);
            genericNode.setValues(inputVals);
            genericNode.setOutput(input2);

            object obj = genericAnalyser.syncProcess(protocol, genericNode);

             Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));

        }

        //public Xtruct testMultiException(string arg0, string arg1)
        //{
        //    Console.WriteLine("testMultiException:" + arg0 + " " + arg1 + " ");

        //    Xtruct info = new Xtruct()
        //    {
        //        String_thing = arg0 + arg1
        //    };

        //    return info;
        //}

        public void testNest(Xtruct2 thing)
        {
            GenericTree input1 = new GenericTree();
            input1.setName("thing");
            input1.setParamType(TypeEnum.SYNTHETIC_TYPE);
            input1.setThrfitType("STRUCT");
            input1.setType("XStruct2");

            GenericTree prop1 = new GenericTree();
            prop1.setName("Byte_thing");
            prop1.setParamType(TypeEnum.PRIMITIVE_TYPE);
            prop1.setThrfitType("SBYTE");
            prop1.setParent(input1);

            GenericTree prop2 = new GenericTree();
            prop2.setName("Xstruct_thing");
            prop2.setParamType(TypeEnum.SYNTHETIC_TYPE);
            prop2.setThrfitType("STRUCT");
            prop2.setType("XStruct");


            GenericTree prop31 = new GenericTree();
            prop31.setName("String_thing");
            prop31.setParamType(TypeEnum.PRIMITIVE_TYPE);
            prop31.setThrfitType("STRING");
            prop31.setParent(prop2);

            GenericTree prop32 = new GenericTree();
            prop32.setName("Byte_thing");
            prop32.setParamType(TypeEnum.PRIMITIVE_TYPE);
            prop32.setThrfitType("SBYTE");
            prop32.setParent(prop2);

            GenericTree prop33 = new GenericTree();
            prop33.setName("I32_thing");
            prop33.setParamType(TypeEnum.PRIMITIVE_TYPE);
            prop33.setThrfitType("I32");
            prop33.setParent(prop2);

            GenericTree prop34 = new GenericTree();
            prop34.setName("I64_thing");
            prop34.setParamType(TypeEnum.PRIMITIVE_TYPE);
            prop34.setThrfitType("I64");
            prop34.setParent(prop2);

            prop2.setParent(input1);


            GenericTree prop3 = new GenericTree();
            prop3.setName("I32_thing");
            prop3.setParamType(TypeEnum.PRIMITIVE_TYPE);
            prop3.setThrfitType("I32");
            prop3.setParent(input1);


            List<GenericTree> inputGenericTrees = new List<GenericTree>
            {
                input1
            };

            // 参数值
            List<Object> inputVals = new List<object>();


            Dictionary<string, object> xstruct2 = new Dictionary<string, object>();

            xstruct2["Byte_thing"] = thing.Byte_thing;
            xstruct2["I32_thing"] = thing.I32_thing;
            xstruct2["Xstruct_thing"] = new Dictionary<string, object> {
                { "Byte_thing", thing.Struct_thing.Byte_thing }
                ,{ "String_thing", thing.Struct_thing.String_thing }
                ,{ "I32_thing", thing.Struct_thing.I32_thing }
                ,{ "I64_thing",thing.Struct_thing.I64_thing }};

            inputVals.Add(xstruct2);


            string method = SERVICE_NAME + "testNest";

            GenericNode genericNode = new GenericNode();
            genericNode.setInputs(inputGenericTrees);
            genericNode.setMethodName(method);
            genericNode.setValues(inputVals);
            genericNode.setOutput(input1);

            object obj = genericAnalyser.syncProcess(protocol, genericNode);

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }

        /*
        public THashSet<int> testSet(THashSet<int> thing)
        {
            Console.WriteLine("testSet:" + thing.ToString());

            return thing;
        }
        */

        public void testStruct()
        {
            GenericTree input1 = new GenericTree();
            input1.setName("thing");
            input1.setParamType(TypeEnum.SYNTHETIC_TYPE);
            input1.setThrfitType("STRUCT");
            input1.setType("Xtruct");

            GenericTree prop1 = new GenericTree();
            prop1.setName("String_thing");
            prop1.setParamType(TypeEnum.PRIMITIVE_TYPE);
            prop1.setThrfitType("STRING");

            GenericTree prop2 = new GenericTree();
            prop2.setName("Byte_thing");
            prop2.setParamType(TypeEnum.PRIMITIVE_TYPE);
            prop2.setThrfitType("SBYTE");

            GenericTree prop3 = new GenericTree();
            prop3.setName("I32_thing");
            prop3.setParamType(TypeEnum.PRIMITIVE_TYPE);
            prop3.setThrfitType("I32");

            GenericTree prop4 = new GenericTree();
            prop4.setName("I64_thing");
            prop4.setParamType(TypeEnum.PRIMITIVE_TYPE);
            prop4.setThrfitType("I64");

            Dictionary<string, GenericTree> children = new Dictionary<string, GenericTree>();

            children.Add("String_thing", prop1);
            children.Add("Byte_thing", prop2);
            children.Add("I32_thing", prop3);
            children.Add("I64_thing", prop4);

            input1.setChildren(children);

            List<GenericTree> inputGenericTrees = new List<GenericTree>
            {
                input1
            };

            GenericTree input2 = new GenericTree();
            input2.setName("thing");
            input2.setParamType(TypeEnum.SYNTHETIC_TYPE);
            input2.setThrfitType("STRUCT");
            input2.setType("Xtruct");

            GenericTree prop11 = new GenericTree();
            prop11.setName("String_thing");
            prop11.setParamType(TypeEnum.PRIMITIVE_TYPE);
            prop11.setThrfitType("STRING");
            prop11.setParent(input2);


            GenericTree prop12 = new GenericTree();
            prop12.setName("Byte_thing");
            prop12.setParamType(TypeEnum.PRIMITIVE_TYPE);
            prop12.setThrfitType("SBYTE");

            GenericTree prop13 = new GenericTree();
            prop13.setName("I32_thing");
            prop13.setParamType(TypeEnum.PRIMITIVE_TYPE);
            prop13.setThrfitType("I32");

            GenericTree prop14 = new GenericTree();
            prop14.setName("I64_thing");
            prop14.setParamType(TypeEnum.PRIMITIVE_TYPE);
            prop14.setThrfitType("I64");

            Dictionary<string, GenericTree> children2 = new Dictionary<string, GenericTree>();

            children2.Add("String_thing", prop11);
            children2.Add("Byte_thing", prop12);
            children2.Add("I32_thing", prop13);
            children2.Add("I64_thing", prop14);

            input2.setChildren(children2);


            // 参数值
            List<Object> inputVals = new List<object>();



            Dictionary<string, object> row = new Dictionary<string, object>();

            row.Add("String_thing", "stringValue3");
            row.Add("Byte_thing", Convert.ToSByte(127));
            row.Add("I32_thing", 99999);
            row.Add("I64_thing", 9999900001111);

            inputVals.Add(row);

            //出参


            string method = SERVICE_NAME + "testStruct";

            GenericNode genericNode = new GenericNode();
            genericNode.setInputs(inputGenericTrees);
            genericNode.setMethodName(method);
            genericNode.setValues(inputVals);
            genericNode.setOutput(input2);

            object obj = genericAnalyser.syncProcess(protocol, genericNode);

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }


    }
}