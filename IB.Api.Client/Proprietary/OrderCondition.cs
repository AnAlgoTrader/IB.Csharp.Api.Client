﻿/* Copyright (C) 2019 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace IB.Api.Client.Proprietary
{
    public enum OrderConditionType
    {
        Price = 1,
        Time = 3,
        Margin = 4,
        Execution = 5,
        Volume = 6,
        PercentCange = 7
    }

    [System.Runtime.InteropServices.ComVisible(true)]
    public abstract class OrderCondition
    {
        public OrderConditionType Type { get; private set; }
        public bool IsConjunctionConnection { get; set; }

        public static OrderCondition Create(OrderConditionType type)
        {
            OrderCondition rval = null;

            switch (type)
            {
                case OrderConditionType.Execution:
                    rval = new ExecutionCondition();
                    break;

                case OrderConditionType.Margin:
                    rval = new MarginCondition();
                    break;

                case OrderConditionType.PercentCange:
                    rval = new PercentChangeCondition();
                    break;

                case OrderConditionType.Price:
                    rval = new PriceCondition();
                    break;

                case OrderConditionType.Time:
                    rval = new TimeCondition();
                    break;

                case OrderConditionType.Volume:
                    rval = new VolumeCondition();
                    break;
            }

            if (rval != null)
                rval.Type = type;

            return rval;
        }

        public virtual void Serialize(BinaryWriter outStream)
        {
            outStream.AddParameter(IsConjunctionConnection ? "a" : "o");
        }

        public virtual void Deserialize(IDecoder inStream)
        {
            IsConjunctionConnection = inStream.ReadString() == "a";
        }

        virtual protected bool TryParse(string cond)
        {
            IsConjunctionConnection = cond == " and";

            return IsConjunctionConnection || cond == " or";
        }

        public static OrderCondition Parse(string cond)
        {
            var conditions = Enum.GetValues(typeof(OrderConditionType)).OfType<OrderConditionType>().Select(t => Create(t)).ToList();

            return conditions.Find(c => c.TryParse(cond));
        }

        public override bool Equals(object obj)
        {
            if (!(obj is OrderCondition other))
                return false;

            return this.IsConjunctionConnection == other.IsConjunctionConnection && this.Type == other.Type;
        }

        public override int GetHashCode()
        {
            return IsConjunctionConnection.GetHashCode() + Type.GetHashCode();
        }
    }

    class StringSuffixParser
    {
        string str;

        public StringSuffixParser(string str)
        {
            this.str = str;
        }

        string SkipSuffix(string perfix)
        {
            return str.Substring(str.IndexOf(perfix) + perfix.Length);
        }

        public string GetNextSuffixedValue(string perfix)
        {
            var rval = str.Substring(0, str.IndexOf(perfix));
            str = SkipSuffix(perfix);

            return rval;
        }

        public string Rest { get { return str; } }
    }
}
