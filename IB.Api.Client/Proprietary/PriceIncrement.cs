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
     * @class PriceIncrement
     * @brief Class describing price increment
     * @sa EClient::reqMarketRule, EWrapper::marketRule
     */
    public class PriceIncrement
    {
        private decimal lowEdge;
        private decimal increment;

        /**
         * @brief The low edge
         */
        public decimal LowEdge
        {
            get { return lowEdge; }
            set { lowEdge = value; }
        }

        /**
         * @brief The increment
         */
        public decimal Increment
        {
            get { return increment; }
            set { increment = value; }
        }

        public PriceIncrement()
        {
        }

        public PriceIncrement(decimal lowEdge, decimal increment)
        {
            LowEdge = lowEdge;
            Increment = increment;
        }
    }
}
