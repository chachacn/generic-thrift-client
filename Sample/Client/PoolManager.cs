using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using Thrift.Protocol;
using Thrift.Transport;

namespace Client
{
    public class PoolManager
    {
        static Pool<ThriftPool> pool = new Pool<ThriftPool>();

        string server_ip = "";
        int server_port = 0;
        public PoolManager(string ip, int port)
        {
            server_ip = ip;
            server_port = port;
            pool.Allocate = OnInit;
            pool.OnClose = OnClose;
        }

        private ThriftPool OnInit()
        {
            ThriftPool thriftpool = new ThriftPool(server_ip, server_port);
            thriftpool.transport.Open();
            
            return thriftpool;
        }

        public ThriftPool Get()
        {
            return pool.Fetch();
        }

        public void Return(ThriftPool ipro)
        {
            pool.Return(ipro);
        }
        public void OnClose(ThriftPool ipro)
        {
            ipro.transport.Close();
            ipro.transport.Dispose();
            ipro.protocol.Dispose();
            ipro = null;
        }
    }

    public class ThriftPool
    {
        public TTransport transport;
        public TProtocol protocol;

        public ThriftPool(string ip, int port, int timeout = 0)
        {
            transport = new TFramedTransport(new TSocket(ip, port, timeout));
            protocol = new TBinaryProtocol(transport);
        }
  
    }

    public class Pool<T>
    {
        public Func<T> Allocate = () => { return default(T); };
        public Action<T> OnFetch = (pItem) => { };
        public Action<T> OnReturn = (pItem) => { };
        public Action<T> OnClose= (pItem) => { };

        List<T> _freeItems = new List<T>();
        List<T> _usedItems = new List<T>();
        
        int _minThreadPool = 5;
        
        public int minThreadPool { get { return _minThreadPool; } set { _minThreadPool = value; } }

        public int free { get { return _freeItems.Count; } }
        public int size { get { return _freeItems.Count + _usedItems.Count; } }
        private int index { get { return _freeItems.Count - 1; } }

        public void ReturnAll()
        {
            for (int i = _usedItems.Count - 1; i >= 0; i--)
            {
                Return(_usedItems[i]);
            }
        }

        public void Warmup(int pAmount)
        {
            Expand(pAmount);
        }

        void Expand(int pAmount)
        {
            for (int i = 0; i < pAmount; i++)
            {
                T item = Allocate();
                Return(item);
            }
        }

        public T Fetch()
        {
            T item;
            lock (this)
            {
                // check if pool needs to expand
                if (index < 0)
                {
                    // expand
                    Expand(1);
                }

                // collect item
                item = _freeItems[index];

                // remove from list
                _freeItems.RemoveAt(index);

                // add to active
                _usedItems.Add(item);
            }

            // callback
            OnFetch(item);

            // return
            return item;
        }

        public void Return(T pItem)
        {
            lock (this)
            {
                // remove from used
                if (_usedItems.Contains(pItem))
                {
                    _usedItems.Remove(pItem);
                }
                
                if (size > minThreadPool && free >= minThreadPool)
                {
                    OnClose(pItem);
                }
                else {
                    // callback
                    OnReturn(pItem);
                    // add to free
                    _freeItems.Add(pItem);
                }
            }
        }
    }
}