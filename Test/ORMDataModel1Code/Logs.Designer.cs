﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace Test.NongNghiep {

    [Persistent(@"logs")]
    public partial class Logs : XPLiteObject {
        ulong _Id;
        [Key]
        [Persistent(@"id")]
        public ulong Id {
            get { return _Id; }
            set { SetPropertyValue<ulong>(nameof(Id), ref _Id, value); }
        }
        int _UserId;
        [Persistent(@"user_id")]
        public int UserId {
            get { return _UserId; }
            set { SetPropertyValue<int>(nameof(UserId), ref _UserId, value); }
        }
        string _StationId;
        [Size(16)]
        [Persistent(@"station_id")]
        public string StationId {
            get { return _StationId; }
            set { SetPropertyValue<string>(nameof(StationId), ref _StationId, value); }
        }
        string _Code;
        [Size(255)]
        [Persistent(@"code")]
        public string Code {
            get { return _Code; }
            set { SetPropertyValue<string>(nameof(Code), ref _Code, value); }
        }
        string _Data;
        [Size(SizeAttribute.Unlimited)]
        [Persistent(@"data")]
        public string Data {
            get { return _Data; }
            set { SetPropertyValue<string>(nameof(Data), ref _Data, value); }
        }
    }

}
