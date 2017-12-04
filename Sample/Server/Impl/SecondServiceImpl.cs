using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Impl
{
    public class SecondServiceImpl : Thrift.Test.SecondService.Iface
    {
        public string secondtestString(string thing)
        {
            Console.WriteLine("thing:" + thing);
            return "hi " + thing;
        }
    }
}
