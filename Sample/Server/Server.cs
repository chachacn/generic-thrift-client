using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Server;
using Thrift.Transport;
using Server.Impl;
using Thrift.Test;
using Thrift.Protocol;


namespace Server
{
    public class Server
    {
        public void Start()
        {
            TServerSocket serverTransport = new TServerSocket(7911, 0, true);

            Thrift.Protocol.TMultiplexedProcessor processor = new Thrift.Protocol.TMultiplexedProcessor();

            processor.RegisterProcessor("SecondService", new SecondService.Processor(new SecondServiceImpl()));

            processor.RegisterProcessor("ThriftTest", new ThriftTest.Processor(new ThriftTestImpl()));
            
            //Impl.ThriftTestImpl handler = new ThriftTestImpl();
            //ThriftTest.Processor processor = new ThriftTest.Processor(handler);

            // TServer server = new TSimpleServer(processor, serverTransport);
            TServer server = new TThreadPoolServer(
           processor,
           serverTransport,
           new TFramedTransport.Factory(),
           new TBinaryProtocol.Factory());

            // TServer server = new TThreadPoolServer(processor, serverTransport);

            Console.WriteLine("Starting server on port 7911 ...");
            server.Serve();
        }
    }
}