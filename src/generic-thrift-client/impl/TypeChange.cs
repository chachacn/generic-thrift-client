using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Protocol;

namespace generic_thrift_client.impl
{
    /// <summary>
    /// 类型转换
    /// by xie 2017.11.22
    /// QQ:229315679
    /// </summary>
    public class TypeChange
    {
        // 泛化对象的thriftType 和TType的映射关系

        static Dictionary<string, TType> _ttypeMap = new Dictionary<string, TType>();
        static Dictionary<string, Type> _TPParamsMap = new Dictionary<string, Type>();
        static Dictionary<string, string> _TPWriteMethodMap = new Dictionary<string, string>();
        static Dictionary<string, string> _TPReadMethodMap = new Dictionary<string, string>();

        static TypeChange()
        {
            _ttypeMap["BOOL"] = TType.Bool;
            _ttypeMap["SBYTE"] = TType.Byte;
            _ttypeMap["DOUBLE"] = TType.Double;
            _ttypeMap["I16"] = TType.I16;
            _ttypeMap["I32"] = TType.I32;
            _ttypeMap["I64"] = TType.I64;
            _ttypeMap["STRING"] = TType.String;
            _ttypeMap["MAP"] = TType.Map;
            _ttypeMap["SET"] = TType.Set;
            _ttypeMap["LIST"] = TType.List;
            _ttypeMap["STRUCT"] = TType.Struct;


            _TPParamsMap["BOOL"] = typeof(Boolean);
            _TPParamsMap["SBYTE"] = typeof(SByte);
            _TPParamsMap["DOUBLE"] = typeof(Double);
            _TPParamsMap["I16"] = typeof(short);
            _TPParamsMap["I32"] = typeof(int);
            _TPParamsMap["I64"] = typeof(long);
            _TPParamsMap["STRING"] = typeof(string);
            
            _TPWriteMethodMap["BOOL"] = "WriteBool";
            _TPWriteMethodMap["SBYTE"] = "WriteByte";
            _TPWriteMethodMap["DOUBLE"] = "WriteDouble";
            _TPWriteMethodMap["I16"] = "WriteI16";
            _TPWriteMethodMap["I32"] = "WriteI32";
            _TPWriteMethodMap["I64"] = "WriteI64";
            _TPWriteMethodMap["STRING"] = "WriteString";

            _TPReadMethodMap["BOOL"] = "ReadBool";
            _TPReadMethodMap["SBYTE"] = "ReadByte";
            _TPReadMethodMap["DOUBLE"] = "ReadDouble";
            _TPReadMethodMap["I16"] = "ReadI16";
            _TPReadMethodMap["I32"] = "ReadI32";
            _TPReadMethodMap["I64"] = "ReadI64";
            _TPReadMethodMap["STRING"] = "ReadString";
        }

        public static Dictionary<string, TType> TTypeMap
        {
            get { return _ttypeMap; }
        }
        // 泛化对象的thriftType 和TProtocol write方法参数类型的对应关系
        public static Dictionary<string, Type> TPParamsMap
        {
            get { return _TPParamsMap; }
        }

        // 泛化对象的thriftType 和TProtocol write方法名的对应关系 只定义了基本类型的映射关系
        public static Dictionary<String, String> TPWriteMethodMap
        {
            get { return _TPWriteMethodMap; }
        }

        // 泛化对象的thriftType 和TProtocol read方法名的对应关系 只定义了基本类型的映射关系
        public static Dictionary<String, String> TPReadMethodMap
        {
            get { return _TPReadMethodMap; }
        }
    }
}