﻿/* Copyright (C) 2019 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System.Collections.Generic;

namespace IBApi
{
    /**
     * @class CommissionReport
     * @brief class representing the commissions generated by an execution.
     * @sa Execution
     */
    public class CommissionReport
    {
        /**
        * @brief the execution's id this commission belongs to.
        */
        public string ExecId { get; set; }

        /**
         * @brief the commissions cost.
         */
        public double Commission { get; set; }

        /**
        * @brief the reporting currency.
        */
        public string Currency { get; set; }

        /**
        * @brief the realized profit and loss
        */
        public double RealizedPNL { get; set; }

        /**
         * @brief The income return.
         */
        public double Yield { get; set; }

        /**
         * @brief date expressed in yyyymmdd format.
         */
        public int YieldRedemptionDate { get; set; }

        public CommissionReport()
        {
            Commission = 0;
            RealizedPNL = 0;
            Yield = 0;
            YieldRedemptionDate = 0;
        }

        public override bool Equals(object p_other)
        {
            bool l_bRetVal;
            CommissionReport l_theOther = p_other as CommissionReport;

            if (l_theOther == null)
            {
                l_bRetVal = false;
            }
            else if (this == p_other)
            {
                l_bRetVal = true;
            }
            else
            {
                l_bRetVal = ExecId.Equals(l_theOther.ExecId);
            }
            return l_bRetVal;
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(ExecId, Commission, Currency, RealizedPNL, Yield, YieldRedemptionDate);
        }
    }
}
