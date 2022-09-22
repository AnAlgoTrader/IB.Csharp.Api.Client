﻿/* Copyright (C) 2019 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IB.Api.Client.Proprietary
{
    /**
     * @class ContractDescription
     * @brief contract data and list of derivative security types
     * @sa Contract, EClient::reqMatchingSymbols, EWrapper::symbolSamples
     */
    public class ContractDescription
    {
        /**
        * @brief A contract data
        */
        public Contract Contract { get; set; }

        /**
         * @brief A list of derivative security types
         */
        public string[] DerivativeSecTypes { get; set; }

        public ContractDescription()
        {
            Contract = new Contract();
        }

        public ContractDescription(Contract contract, string[] derivativeSecTypes)
        {
            Contract = contract;
            DerivativeSecTypes = derivativeSecTypes;
        }

        public override string ToString()
        {
            return Contract.ToString() + " derivativeSecTypes [" + String.Join(", ", DerivativeSecTypes) + "]";
        }
    }
}
