/* Copyright (C) 2019 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;

namespace IB.Api.Client.Proprietary
{
    public class EClientException : Exception
    {
        public CodeMsgPair Err { get; }

        public EClientException(CodeMsgPair err)
        {
            this.Err = err;
        }

        public EClientException() : base()
        {
        }

        public EClientException(string message) : base(message)
        {
        }

        public EClientException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
