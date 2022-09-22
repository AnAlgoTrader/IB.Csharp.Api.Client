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
     * @class ExecutionFilter
     * @brief when requesting executions, a filter can be specified to receive only a subset of them
     * @sa Contract, Execution, CommissionReport
     */
    public class ExecutionFilter
    {
        /**
         * @brief The API client which placed the order
         */
        public int ClientId { get; set; }

        /**
        * @brief The account to which the order was allocated to
        */
        public string AcctCode { get; set; }

        /**
         * @brief Time from which the executions will be returned yyyymmdd hh:mm:ss
         * Only those executions reported after the specified time will be returned.
         */
        public string Time { get; set; }

        /**
        * @brief The instrument's symbol
        */
        public string Symbol { get; set; }

        /**
         * @brief The Contract's security's type (i.e. STK, OPT...)
         */
        public string SecType { get; set; }

        /**
         * @brief The exchange at which the execution was produced
         */
        public string Exchange { get; set; }

        /**
        * @brief The Contract's side (BUY or SELL)
        */
        public string Side { get; set; }

        public ExecutionFilter()
        {
            ClientId = 0;
        }

        public ExecutionFilter(int clientId, String acctCode, String time,
                String symbol, String secType, String exchange, String side)
        {
            ClientId = clientId;
            AcctCode = acctCode;
            Time = time;
            Symbol = symbol;
            SecType = secType;
            Exchange = exchange;
            Side = side;
        }

        public override bool Equals(Object other)
        {
            if (other == null)
            {
                return false;
            }
            else if (this == other)
            {
                return true;
            }
            else
            {
                ExecutionFilter l_theOther = (ExecutionFilter)other;
                return ClientId == l_theOther.ClientId &&
                    String.Compare(AcctCode, l_theOther.AcctCode, true) == 0 &&
                    String.Compare(Time, l_theOther.Time, true) == 0 &&
                    String.Compare(Symbol, l_theOther.Symbol, true) == 0 &&
                    String.Compare(SecType, l_theOther.SecType, true) == 0 &&
                    String.Compare(Exchange, l_theOther.Exchange, true) == 0 &&
                    String.Compare(Side, l_theOther.Side, true) == 0;
            }
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(ClientId);
            hash.Add(AcctCode);
            hash.Add(Time);
            hash.Add(Symbol);
            hash.Add(SecType);
            hash.Add(Exchange);
            hash.Add(Side);
            hash.Add(ClientId);
            hash.Add(AcctCode);
            hash.Add(Time);
            hash.Add(Symbol);
            hash.Add(SecType);
            hash.Add(Exchange);
            hash.Add(Side);
            return hash.ToHashCode();
        }
    }
}
