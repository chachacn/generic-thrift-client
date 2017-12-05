using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Thrift.Protocol;
using Thrift.Transport;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            object value = new Dictionary<int, int>() { { 1, 3 }, { 3, 5 } };

            var list = value as IDictionary;

            foreach (DictionaryEntry item in list)
            {
                
                Console.WriteLine(item.Value);

                Console.WriteLine(item);
            }
                        
            Console.ReadLine();
            return;
            */


            #region 原生
            /*
            TTransport transport = new TFramedTransport(new TSocket("172.16.211.97", 7911));
            TProtocol protocol = new TJSONProtocol(transport);

            Thrift.Test.ThriftTest.Client service = new Thrift.Test.ThriftTest.Client(protocol);

            // TMultiplexedProtocol mp1 = new TMultiplexedProtocol(protocol, "ThriftTest");
            // Thrift.Test.ThriftTest.Client service = new Thrift.Test.ThriftTest.Client(mp1);

            // TMultiplexedProtocol mp2 = new TMultiplexedProtocol(protocol, "NewsService");

            transport.Open();

            // service.testStruct(new Thrift.Test.Xtruct { String_thing = "stringValue", Byte_thing = Convert.ToSByte(127), I32_thing = 99999, I64_thing = 9999900001111 });
            service.testNest(new Thrift.Test.Xtruct2 { Byte_thing = -127, I32_thing = 332, Struct_thing = new Thrift.Test.Xtruct { I64_thing = 33 } });

            transport.Close();
            */
            #endregion

            //TestSecondService test2 = new TestSecondService();

            //test2.secondtestString();


            TestThrift test = new TestThrift();

            // test.testBinary(System.Text.Encoding.UTF8.GetBytes("xiejianjun"));

            //test.testBool(true);

            //test.testByte(127);

            //test.testDouble(3.33);

            //test.testEnum(3);
            //try
            //{
            //    test.testException("xie");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}


            //test.testI32(333);

            //test.testI64(33300000000);

            /*
            Thrift.Test.Insanity insanity = new Thrift.Test.Insanity();

            test.testInsanity(Newtonsoft.Json.JsonConvert.SerializeObject(insanity));

             */

            // test.testList(new List<int> { 3, 5, 7 });

            // test.testMap(new Dictionary<int, int> { { 1, 3 }, { 3, 5 } });

            //  test.testStruct();

            //  test.testMapMap(new Dictionary<int, Dictionary<int, int>> { { 1, new Dictionary<int, int> { { 1, 3 }, { 3, 5 } } }, { 2, new Dictionary<int, int> { { 8, 8 }, { 9, 9 } } } });

            // test.testMapMap(11);

            // test.testNest(new Thrift.Test.Xtruct2 { Byte_thing=-127, I32_thing=332, Struct_thing= new Thrift.Test.Xtruct { I64_thing=33 , String_thing="" } });


            Dictionary<short, string> row = new Dictionary<short, string>();

            row.Add(1, "test1");
            row.Add(2, "test2");
            row.Add(3, "test3");

            test.testMulti(0, 1, 2, row, Thrift.Test.Numberz.FIVE, 5);


            /*
            for (int j = 0; j < 10; j++)
            {

                DateTime dt = DateTime.Now;
                for (int i = 0; i < 10000; i++)
                {
                    // test.testI32(33);
                    // test.testMap(new Dictionary<int, int> { { 1, 3 }, { 3, 5 } });
                    // test.testStruct();

                    TestThrift test2 = new TestThrift();

                    test2.testMulti(0, 1, 2, row, Thrift.Test.Numberz.FIVE, 5);

                    test2.Close();

                }
                Console.WriteLine("Use:" + (DateTime.Now - dt).TotalMilliseconds);
            }
            */




            test.Close();

            /*
            for (int i = 0; i < 1000; i++) {

                ThreadPool.QueueUserWorkItem(new WaitCallback(run), 1);

            }
            */

            Console.ReadLine();
        }

        private static void run(object arg)
        {

            Dictionary<short, string> row = new Dictionary<short, string>();

            row.Add(1, "test1");
            row.Add(2, "test2");
            row.Add(3, "test3");

            for (int j = 0; j < 1; j++)
            {
                DateTime dt = DateTime.Now;
                for (int i = 0; i < 10000; i++)
                {
                    // test.testI32(33);
                    // test.testMap(new Dictionary<int, int> { { 1, 3 }, { 3, 5 } });
                    // test.testStruct();

                    TestThrift test2 = new TestThrift();

                    test2.testMulti(0, 1, 2, row, Thrift.Test.Numberz.FIVE, 5);
                    // test2.testI32(33);
                    test2.Close();

                }
                Console.WriteLine("Use:" + (DateTime.Now - dt).TotalMilliseconds);
            }
        }

    }
}
