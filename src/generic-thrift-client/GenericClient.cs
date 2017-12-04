using generic_thrift_client.common;
using System;
using System.Collections.Generic;
using System.Text;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport;

namespace generic_thrift_client
{
    /// <summary>
    /// 泛化客户端抽象接口
    /// 定义了泛化类型和 Thrift类型的映射关系
    /// by xie 2017.11.22
    /// QQ:229315679
    /// </summary>
    public interface GenericClient
    {
        //泛化thrift客户端 同步调用方法
        object syncProcess(TProtocol oprot, GenericNode genericNode);

        //泛化thrift客户端 异步调用方法
        // void asyncProcess(GenericNode node, TProtocolFactory tProtocolFactory, TTransport transport, IAsyncResult callback);

        int sendMsg(TProtocol oprot, GenericNode genericNode);

        object recvMsg(TProtocol iprot, GenericTree genericTree, int seqid_);
    }
}