using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Collections;
using Thrift.Test;

namespace Server.Impl
{
    public class ThriftTestImpl : Thrift.Test.ThriftTest.Iface
    {
        public byte[] testBinary(byte[] thing)
        {
            Console.WriteLine("testBinary:" + thing.ToString());

            return thing;
        }

        public bool testBool(bool thing)
        {
            Console.WriteLine("testBool:" + thing.ToString());

            return thing;
        }

        public sbyte testByte(sbyte thing)
        {
            Console.WriteLine("testByte:" + thing.ToString());

            return thing;
        }

        public double testDouble(double thing)
        {
            Console.WriteLine("testDouble:" + thing.ToString());

            return thing;
        }

        public Numberz testEnum(Numberz thing)
        {
            Console.WriteLine("testEnum:" + thing.ToString());

            return thing;
        }

        public void testException(string arg)
        {
            Console.WriteLine("testException:" + arg);

            throw new Exception("Exception");
        }

        public int testI32(int thing)
        {
            Console.WriteLine("testI32:" + thing.ToString());

            return thing;
        }

        public long testI64(long thing)
        {
            Console.WriteLine("testI64:" + thing.ToString());

            return thing;
        }

        public Dictionary<long, Dictionary<Numberz, Insanity>> testInsanity(Insanity argument)
        {            
            Console.WriteLine("Dictionary:" + argument.ToString());

            Dictionary<long, Dictionary<Numberz, Insanity>> dict = new Dictionary<long, Dictionary<Numberz, Insanity>>();

            Dictionary<Numberz, Insanity> dict1 = new Dictionary<Numberz, Insanity>();
            dict1.Add(Numberz.FIVE, argument);

            dict.Add(1, dict1);

            return dict;
        }

        public List<int> testList(List<int> thing)
        {
            Console.WriteLine("testList:" + thing.ToString());

            return thing;
        }

        public Dictionary<int, int> testMap(Dictionary<int, int> thing)
        {
            // Console.WriteLine("testMap:" + thing.ToString());

            return thing;
        }

        public Dictionary<int, Dictionary<int, int>> testMapMap(int hello)
        {
            Console.WriteLine("double:" + hello.ToString());

            Dictionary<int, Dictionary<int, int>> dict = new Dictionary<int, Dictionary<int, int>>();

            for (int i = 0; i < 10; i++)
            {
                Dictionary<int, int> item = new Dictionary<int, int>();
                item.Add(i * 5, i * 10);

                dict.Add(i, item);
            }

            return dict;
        }

        public Xtruct testMulti(sbyte arg0, int arg1, long arg2, Dictionary<short, string> arg3, Numberz arg4, long arg5)
        {
           /* 
           Console.WriteLine("testMulti:"
                + arg0 + " "
                + arg1 + " "
                + arg2 + " "
                + arg3 + " "
                + arg4 + " "
                + arg5
                );
                */
            Xtruct info = new Xtruct()
            {
                Byte_thing = arg0,
                I32_thing = arg1,
                I64_thing = arg2,
                String_thing = arg3.ToString()
            };

            return info;
        }

        public Xtruct testMultiException(string arg0, string arg1)
        {
            Console.WriteLine("testMultiException:" + arg0 + " " + arg1 + " ");

            throw new Exception("testMultiException");
        }

        public Xtruct2 testNest(Xtruct2 thing)
        {
            Console.WriteLine("testNest:" + thing.ToString());

            return thing;
        }

        public void testOneway(int secondsToSleep)
        {
            Console.WriteLine("testOneway:" + secondsToSleep);

        }

        public THashSet<int> testSet(THashSet<int> thing)
        {
            Console.WriteLine("testSet:" + thing.ToString());

            return thing;
        }

        public string testString(string thing)
        {
            Console.WriteLine("testString:" + thing.ToString());

            return thing;
        }

        public Dictionary<string, string> testStringMap(Dictionary<string, string> thing)
        {
            Console.WriteLine("testStringMap:" + thing.ToString());

            return thing;
        }

        public Xtruct testStruct(Xtruct thing)
        {
            // Console.WriteLine("testStruct:" + thing.String_thing);

            return thing;
        }

        public long testTypedef(long thing)
        {
            Console.WriteLine("testTypedef:" + thing.ToString());

            return thing;
        }

        public void testVoid()
        {
            Console.WriteLine("testVoid:" + DateTime.Now);
        }
    }
}
