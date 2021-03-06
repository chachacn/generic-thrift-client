/**
 * Autogenerated by Thrift Compiler (0.10.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace Thrift.Test
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class VersioningTestV2 : TBase
  {
    private int _begin_in_both;
    private int _newint;
    private sbyte _newbyte;
    private short _newshort;
    private long _newlong;
    private double _newdouble;
    private Bonk _newstruct;
    private List<int> _newlist;
    private THashSet<int> _newset;
    private Dictionary<int, int> _newmap;
    private string _newstring;
    private int _end_in_both;

    public int Begin_in_both
    {
      get
      {
        return _begin_in_both;
      }
      set
      {
        __isset.begin_in_both = true;
        this._begin_in_both = value;
      }
    }

    public int Newint
    {
      get
      {
        return _newint;
      }
      set
      {
        __isset.newint = true;
        this._newint = value;
      }
    }

    public sbyte Newbyte
    {
      get
      {
        return _newbyte;
      }
      set
      {
        __isset.newbyte = true;
        this._newbyte = value;
      }
    }

    public short Newshort
    {
      get
      {
        return _newshort;
      }
      set
      {
        __isset.newshort = true;
        this._newshort = value;
      }
    }

    public long Newlong
    {
      get
      {
        return _newlong;
      }
      set
      {
        __isset.newlong = true;
        this._newlong = value;
      }
    }

    public double Newdouble
    {
      get
      {
        return _newdouble;
      }
      set
      {
        __isset.newdouble = true;
        this._newdouble = value;
      }
    }

    public Bonk Newstruct
    {
      get
      {
        return _newstruct;
      }
      set
      {
        __isset.newstruct = true;
        this._newstruct = value;
      }
    }

    public List<int> Newlist
    {
      get
      {
        return _newlist;
      }
      set
      {
        __isset.newlist = true;
        this._newlist = value;
      }
    }

    public THashSet<int> Newset
    {
      get
      {
        return _newset;
      }
      set
      {
        __isset.newset = true;
        this._newset = value;
      }
    }

    public Dictionary<int, int> Newmap
    {
      get
      {
        return _newmap;
      }
      set
      {
        __isset.newmap = true;
        this._newmap = value;
      }
    }

    public string Newstring
    {
      get
      {
        return _newstring;
      }
      set
      {
        __isset.newstring = true;
        this._newstring = value;
      }
    }

    public int End_in_both
    {
      get
      {
        return _end_in_both;
      }
      set
      {
        __isset.end_in_both = true;
        this._end_in_both = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool begin_in_both;
      public bool newint;
      public bool newbyte;
      public bool newshort;
      public bool newlong;
      public bool newdouble;
      public bool newstruct;
      public bool newlist;
      public bool newset;
      public bool newmap;
      public bool newstring;
      public bool end_in_both;
    }

    public VersioningTestV2() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.I32) {
                Begin_in_both = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.I32) {
                Newint = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.Byte) {
                Newbyte = iprot.ReadByte();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.I16) {
                Newshort = iprot.ReadI16();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 5:
              if (field.Type == TType.I64) {
                Newlong = iprot.ReadI64();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 6:
              if (field.Type == TType.Double) {
                Newdouble = iprot.ReadDouble();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 7:
              if (field.Type == TType.Struct) {
                Newstruct = new Bonk();
                Newstruct.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 8:
              if (field.Type == TType.List) {
                {
                  Newlist = new List<int>();
                  TList _list49 = iprot.ReadListBegin();
                  for( int _i50 = 0; _i50 < _list49.Count; ++_i50)
                  {
                    int _elem51;
                    _elem51 = iprot.ReadI32();
                    Newlist.Add(_elem51);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 9:
              if (field.Type == TType.Set) {
                {
                  Newset = new THashSet<int>();
                  TSet _set52 = iprot.ReadSetBegin();
                  for( int _i53 = 0; _i53 < _set52.Count; ++_i53)
                  {
                    int _elem54;
                    _elem54 = iprot.ReadI32();
                    Newset.Add(_elem54);
                  }
                  iprot.ReadSetEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 10:
              if (field.Type == TType.Map) {
                {
                  Newmap = new Dictionary<int, int>();
                  TMap _map55 = iprot.ReadMapBegin();
                  for( int _i56 = 0; _i56 < _map55.Count; ++_i56)
                  {
                    int _key57;
                    int _val58;
                    _key57 = iprot.ReadI32();
                    _val58 = iprot.ReadI32();
                    Newmap[_key57] = _val58;
                  }
                  iprot.ReadMapEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 11:
              if (field.Type == TType.String) {
                Newstring = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 12:
              if (field.Type == TType.I32) {
                End_in_both = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("VersioningTestV2");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.begin_in_both) {
          field.Name = "begin_in_both";
          field.Type = TType.I32;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Begin_in_both);
          oprot.WriteFieldEnd();
        }
        if (__isset.newint) {
          field.Name = "newint";
          field.Type = TType.I32;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Newint);
          oprot.WriteFieldEnd();
        }
        if (__isset.newbyte) {
          field.Name = "newbyte";
          field.Type = TType.Byte;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteByte(Newbyte);
          oprot.WriteFieldEnd();
        }
        if (__isset.newshort) {
          field.Name = "newshort";
          field.Type = TType.I16;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteI16(Newshort);
          oprot.WriteFieldEnd();
        }
        if (__isset.newlong) {
          field.Name = "newlong";
          field.Type = TType.I64;
          field.ID = 5;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(Newlong);
          oprot.WriteFieldEnd();
        }
        if (__isset.newdouble) {
          field.Name = "newdouble";
          field.Type = TType.Double;
          field.ID = 6;
          oprot.WriteFieldBegin(field);
          oprot.WriteDouble(Newdouble);
          oprot.WriteFieldEnd();
        }
        if (Newstruct != null && __isset.newstruct) {
          field.Name = "newstruct";
          field.Type = TType.Struct;
          field.ID = 7;
          oprot.WriteFieldBegin(field);
          Newstruct.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (Newlist != null && __isset.newlist) {
          field.Name = "newlist";
          field.Type = TType.List;
          field.ID = 8;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.I32, Newlist.Count));
            foreach (int _iter59 in Newlist)
            {
              oprot.WriteI32(_iter59);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (Newset != null && __isset.newset) {
          field.Name = "newset";
          field.Type = TType.Set;
          field.ID = 9;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteSetBegin(new TSet(TType.I32, Newset.Count));
            foreach (int _iter60 in Newset)
            {
              oprot.WriteI32(_iter60);
            }
            oprot.WriteSetEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (Newmap != null && __isset.newmap) {
          field.Name = "newmap";
          field.Type = TType.Map;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteMapBegin(new TMap(TType.I32, TType.I32, Newmap.Count));
            foreach (int _iter61 in Newmap.Keys)
            {
              oprot.WriteI32(_iter61);
              oprot.WriteI32(Newmap[_iter61]);
            }
            oprot.WriteMapEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (Newstring != null && __isset.newstring) {
          field.Name = "newstring";
          field.Type = TType.String;
          field.ID = 11;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Newstring);
          oprot.WriteFieldEnd();
        }
        if (__isset.end_in_both) {
          field.Name = "end_in_both";
          field.Type = TType.I32;
          field.ID = 12;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(End_in_both);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("VersioningTestV2(");
      bool __first = true;
      if (__isset.begin_in_both) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Begin_in_both: ");
        __sb.Append(Begin_in_both);
      }
      if (__isset.newint) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Newint: ");
        __sb.Append(Newint);
      }
      if (__isset.newbyte) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Newbyte: ");
        __sb.Append(Newbyte);
      }
      if (__isset.newshort) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Newshort: ");
        __sb.Append(Newshort);
      }
      if (__isset.newlong) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Newlong: ");
        __sb.Append(Newlong);
      }
      if (__isset.newdouble) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Newdouble: ");
        __sb.Append(Newdouble);
      }
      if (Newstruct != null && __isset.newstruct) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Newstruct: ");
        __sb.Append(Newstruct== null ? "<null>" : Newstruct.ToString());
      }
      if (Newlist != null && __isset.newlist) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Newlist: ");
        __sb.Append(Newlist);
      }
      if (Newset != null && __isset.newset) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Newset: ");
        __sb.Append(Newset);
      }
      if (Newmap != null && __isset.newmap) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Newmap: ");
        __sb.Append(Newmap);
      }
      if (Newstring != null && __isset.newstring) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Newstring: ");
        __sb.Append(Newstring);
      }
      if (__isset.end_in_both) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("End_in_both: ");
        __sb.Append(End_in_both);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
