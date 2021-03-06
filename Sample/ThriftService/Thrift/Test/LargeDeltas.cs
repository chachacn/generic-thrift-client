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
  public partial class LargeDeltas : TBase
  {
    private Bools _b1;
    private Bools _b10;
    private Bools _b100;
    private bool _check_true;
    private Bools _b1000;
    private bool _check_false;
    private VersioningTestV2 _vertwo2000;
    private THashSet<string> _a_set2500;
    private VersioningTestV2 _vertwo3000;
    private List<int> _big_numbers;

    public Bools B1
    {
      get
      {
        return _b1;
      }
      set
      {
        __isset.b1 = true;
        this._b1 = value;
      }
    }

    public Bools B10
    {
      get
      {
        return _b10;
      }
      set
      {
        __isset.b10 = true;
        this._b10 = value;
      }
    }

    public Bools B100
    {
      get
      {
        return _b100;
      }
      set
      {
        __isset.b100 = true;
        this._b100 = value;
      }
    }

    public bool Check_true
    {
      get
      {
        return _check_true;
      }
      set
      {
        __isset.check_true = true;
        this._check_true = value;
      }
    }

    public Bools B1000
    {
      get
      {
        return _b1000;
      }
      set
      {
        __isset.b1000 = true;
        this._b1000 = value;
      }
    }

    public bool Check_false
    {
      get
      {
        return _check_false;
      }
      set
      {
        __isset.check_false = true;
        this._check_false = value;
      }
    }

    public VersioningTestV2 Vertwo2000
    {
      get
      {
        return _vertwo2000;
      }
      set
      {
        __isset.vertwo2000 = true;
        this._vertwo2000 = value;
      }
    }

    public THashSet<string> A_set2500
    {
      get
      {
        return _a_set2500;
      }
      set
      {
        __isset.a_set2500 = true;
        this._a_set2500 = value;
      }
    }

    public VersioningTestV2 Vertwo3000
    {
      get
      {
        return _vertwo3000;
      }
      set
      {
        __isset.vertwo3000 = true;
        this._vertwo3000 = value;
      }
    }

    public List<int> Big_numbers
    {
      get
      {
        return _big_numbers;
      }
      set
      {
        __isset.big_numbers = true;
        this._big_numbers = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool b1;
      public bool b10;
      public bool b100;
      public bool check_true;
      public bool b1000;
      public bool check_false;
      public bool vertwo2000;
      public bool a_set2500;
      public bool vertwo3000;
      public bool big_numbers;
    }

    public LargeDeltas() {
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
              if (field.Type == TType.Struct) {
                B1 = new Bools();
                B1.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 10:
              if (field.Type == TType.Struct) {
                B10 = new Bools();
                B10.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 100:
              if (field.Type == TType.Struct) {
                B100 = new Bools();
                B100.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 500:
              if (field.Type == TType.Bool) {
                Check_true = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 1000:
              if (field.Type == TType.Struct) {
                B1000 = new Bools();
                B1000.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 1500:
              if (field.Type == TType.Bool) {
                Check_false = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2000:
              if (field.Type == TType.Struct) {
                Vertwo2000 = new VersioningTestV2();
                Vertwo2000.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2500:
              if (field.Type == TType.Set) {
                {
                  A_set2500 = new THashSet<string>();
                  TSet _set75 = iprot.ReadSetBegin();
                  for( int _i76 = 0; _i76 < _set75.Count; ++_i76)
                  {
                    string _elem77;
                    _elem77 = iprot.ReadString();
                    A_set2500.Add(_elem77);
                  }
                  iprot.ReadSetEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3000:
              if (field.Type == TType.Struct) {
                Vertwo3000 = new VersioningTestV2();
                Vertwo3000.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4000:
              if (field.Type == TType.List) {
                {
                  Big_numbers = new List<int>();
                  TList _list78 = iprot.ReadListBegin();
                  for( int _i79 = 0; _i79 < _list78.Count; ++_i79)
                  {
                    int _elem80;
                    _elem80 = iprot.ReadI32();
                    Big_numbers.Add(_elem80);
                  }
                  iprot.ReadListEnd();
                }
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
        TStruct struc = new TStruct("LargeDeltas");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (B1 != null && __isset.b1) {
          field.Name = "b1";
          field.Type = TType.Struct;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          B1.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (B10 != null && __isset.b10) {
          field.Name = "b10";
          field.Type = TType.Struct;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          B10.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (B100 != null && __isset.b100) {
          field.Name = "b100";
          field.Type = TType.Struct;
          field.ID = 100;
          oprot.WriteFieldBegin(field);
          B100.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (__isset.check_true) {
          field.Name = "check_true";
          field.Type = TType.Bool;
          field.ID = 500;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(Check_true);
          oprot.WriteFieldEnd();
        }
        if (B1000 != null && __isset.b1000) {
          field.Name = "b1000";
          field.Type = TType.Struct;
          field.ID = 1000;
          oprot.WriteFieldBegin(field);
          B1000.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (__isset.check_false) {
          field.Name = "check_false";
          field.Type = TType.Bool;
          field.ID = 1500;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(Check_false);
          oprot.WriteFieldEnd();
        }
        if (Vertwo2000 != null && __isset.vertwo2000) {
          field.Name = "vertwo2000";
          field.Type = TType.Struct;
          field.ID = 2000;
          oprot.WriteFieldBegin(field);
          Vertwo2000.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (A_set2500 != null && __isset.a_set2500) {
          field.Name = "a_set2500";
          field.Type = TType.Set;
          field.ID = 2500;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteSetBegin(new TSet(TType.String, A_set2500.Count));
            foreach (string _iter81 in A_set2500)
            {
              oprot.WriteString(_iter81);
            }
            oprot.WriteSetEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (Vertwo3000 != null && __isset.vertwo3000) {
          field.Name = "vertwo3000";
          field.Type = TType.Struct;
          field.ID = 3000;
          oprot.WriteFieldBegin(field);
          Vertwo3000.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (Big_numbers != null && __isset.big_numbers) {
          field.Name = "big_numbers";
          field.Type = TType.List;
          field.ID = 4000;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.I32, Big_numbers.Count));
            foreach (int _iter82 in Big_numbers)
            {
              oprot.WriteI32(_iter82);
            }
            oprot.WriteListEnd();
          }
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
      StringBuilder __sb = new StringBuilder("LargeDeltas(");
      bool __first = true;
      if (B1 != null && __isset.b1) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("B1: ");
        __sb.Append(B1== null ? "<null>" : B1.ToString());
      }
      if (B10 != null && __isset.b10) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("B10: ");
        __sb.Append(B10== null ? "<null>" : B10.ToString());
      }
      if (B100 != null && __isset.b100) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("B100: ");
        __sb.Append(B100== null ? "<null>" : B100.ToString());
      }
      if (__isset.check_true) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Check_true: ");
        __sb.Append(Check_true);
      }
      if (B1000 != null && __isset.b1000) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("B1000: ");
        __sb.Append(B1000== null ? "<null>" : B1000.ToString());
      }
      if (__isset.check_false) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Check_false: ");
        __sb.Append(Check_false);
      }
      if (Vertwo2000 != null && __isset.vertwo2000) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Vertwo2000: ");
        __sb.Append(Vertwo2000== null ? "<null>" : Vertwo2000.ToString());
      }
      if (A_set2500 != null && __isset.a_set2500) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("A_set2500: ");
        __sb.Append(A_set2500);
      }
      if (Vertwo3000 != null && __isset.vertwo3000) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Vertwo3000: ");
        __sb.Append(Vertwo3000== null ? "<null>" : Vertwo3000.ToString());
      }
      if (Big_numbers != null && __isset.big_numbers) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Big_numbers: ");
        __sb.Append(Big_numbers);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
