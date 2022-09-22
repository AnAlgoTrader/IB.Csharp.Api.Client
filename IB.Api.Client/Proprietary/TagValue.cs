/* Copyright (C) 2019 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IB.Api.Client.Proprietary
{
    /**
    * @class TagValue
    * @brief Convenience class to define key-value pairs
    */
    public class TagValue
    {
        public string Tag { get; set; }

        public string Value { get; set; }

        public TagValue()
        {
        }

        public TagValue(string p_tag, string p_value)
        {
            Tag = p_tag;
            Value = p_value;
        }

        public override bool Equals(Object other)
        {
            if (this == other)
                return true;

            if (other == null)
                return false;

            TagValue l_theOther = (TagValue)other;

            return Util.StringCompare(Tag, l_theOther.Tag) == 0 &&
                Util.StringCompare(Value, l_theOther.Value) == 0;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Tag, Value, Tag, Value);
        }
    }
}
