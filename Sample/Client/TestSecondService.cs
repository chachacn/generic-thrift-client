using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Protocol;
using Thrift.Transport;

using generic_thrift_client;
using generic_thrift_client.common;
using generic_thrift_client.impl;

namespace Client
{
    public class TestSecondService
    {
        public string SERVER_IP = "localhost";
        public int SERVER_PORT = 7911;
        public int TIMEOUT = 3000;

        GenericClient genericAnalyser = new TGenericClient();
        TTransport transport;
        TProtocol protocol;

        public TestSecondService()
        {
            transport = new TSocket(SERVER_IP, SERVER_PORT, TIMEOUT);
            // 协议要和服务端一致
            protocol = new TBinaryProtocol(transport);
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

            protocol.Transport.Open();

            object obj = genericAnalyser.syncProcess(protocol, genericNode);

            protocol.Transport.Close();

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }
    }
}