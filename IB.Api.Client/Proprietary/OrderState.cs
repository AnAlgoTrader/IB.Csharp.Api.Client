/* Copyright (C) 2019 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;

namespace IB.Api.Client.Proprietary
{
    /**
     * @class OrderState
     * @brief Provides an active order's current state
     * @sa Order
     */
    public class OrderState
    {
        /**
         * @brief The order's current status
         */
        public string Status { get; set; }

        /**
         * @brief The account's current initial margin.
         */
        public double InitMarginBefore { get; set; }

        /**
        * @brief The account's current maintenance margin
        */
        public double MaintMarginBefore { get; set; }

        /**
        * @brief The account's current equity with loan
        */
        public double EquityWithLoanBefore { get; set; }

        /**
         * @brief The change of the account's initial margin.
         */
        public double InitMarginChange { get; set; }

        /**
        * @brief The change of the account's maintenance margin
        */
        public double MaintMarginChange { get; set; }

        /**
        * @brief The change of the account's equity with loan
        */
        public double EquityWithLoanChange { get; set; }

        /**
         * @brief The order's impact on the account's initial margin.
         */
        public double InitMarginAfter { get; set; }

        /**
        * @brief The order's impact on the account's maintenance margin
        */
        public double MaintMarginAfter { get; set; }

        /**
        * @brief Shows the impact the order would have on the account's equity with loan
        */
        public double EquityWithLoanAfter { get; set; }

        /**
          * @brief The order's generated commission.
          */
        public double Commission { get; set; }

        /**
        * @brief The execution's minimum commission.
        */
        public double MinCommission { get; set; }

        /**
        * @brief The executions maximum commission.
        */
        public double MaxCommission { get; set; }

        /**
         * @brief The generated commission currency
         * @sa CommissionReport
         */
        public string CommissionCurrency { get; set; }

        /**
         * @brief If the order is warranted, a descriptive message will be provided.
         */
        public string WarningText { get; set; }

        public string CompletedTime { get; set; }

        public string CompletedStatus { get; set; }

        public OrderState()
        {
            Status = null;
            InitMarginBefore = 0.0;
            MaintMarginBefore = 0.0;
            EquityWithLoanBefore = 0.0;
            InitMarginChange = 0.0;
            MaintMarginChange = 0.0;
            EquityWithLoanChange = 0.0;
            InitMarginAfter = 0.0;
            MaintMarginAfter = 0.0;
            EquityWithLoanAfter = 0.0;
            Commission = 0.0;
            MinCommission = 0.0;
            MaxCommission = 0.0;
            CommissionCurrency = null;
            WarningText = null;
            CompletedTime = null;
            CompletedStatus = null;
        }

        public OrderState(string status,
                double initMarginBefore, double maintMarginBefore, double equityWithLoanBefore,
                double initMarginChange, double maintMarginChange, double equityWithLoanChange,
                double initMarginAfter, double maintMarginAfter, double equityWithLoanAfter,
                double commission, double minCommission,
                double maxCommission, string commissionCurrency, string warningText,
                string completedTime, string completedStatus)
        {
            if (status == null)
                throw new ArgumentNullException(nameof(status));

            InitMarginBefore = initMarginBefore;
            MaintMarginBefore = maintMarginBefore;
            EquityWithLoanBefore = equityWithLoanBefore;
            InitMarginChange = initMarginChange;
            MaintMarginChange = maintMarginChange;
            EquityWithLoanChange = equityWithLoanChange;
            InitMarginAfter = initMarginAfter;
            MaintMarginAfter = maintMarginAfter;
            EquityWithLoanAfter = equityWithLoanAfter;
            Commission = commission;
            MinCommission = minCommission;
            MaxCommission = maxCommission;
            CommissionCurrency = commissionCurrency;
            WarningText = warningText;
            CompletedTime = completedTime;
            CompletedStatus = completedStatus;
        }

        public override bool Equals(Object other)
        {
            if (this == other)
                return true;

            if (other == null)
                return false;

            OrderState state = (OrderState)other;

            if (Commission != state.Commission ||
                MinCommission != state.MinCommission ||
                MaxCommission != state.MaxCommission)
            {
                return false;
            }

            if (Util.StringCompare(Status, state.Status) != 0 ||
                Util.StringCompare(CommissionCurrency, state.CommissionCurrency) != 0 ||
                Util.StringCompare(CompletedTime, state.CompletedTime) != 0 ||
                Util.StringCompare(CompletedStatus, state.CompletedStatus) != 0)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Status);
            hash.Add(InitMarginBefore);
            hash.Add(MaintMarginBefore);
            hash.Add(EquityWithLoanBefore);
            hash.Add(InitMarginChange);
            hash.Add(MaintMarginChange);
            hash.Add(EquityWithLoanChange);
            hash.Add(InitMarginAfter);
            hash.Add(MaintMarginAfter);
            hash.Add(EquityWithLoanAfter);
            hash.Add(Commission);
            hash.Add(MinCommission);
            hash.Add(MaxCommission);
            hash.Add(CommissionCurrency);
            hash.Add(WarningText);
            hash.Add(CompletedTime);
            hash.Add(CompletedStatus);
            hash.Add(Status);
            hash.Add(InitMarginBefore);
            hash.Add(MaintMarginBefore);
            hash.Add(EquityWithLoanBefore);
            hash.Add(InitMarginChange);
            hash.Add(MaintMarginChange);
            hash.Add(EquityWithLoanChange);
            hash.Add(InitMarginAfter);
            hash.Add(MaintMarginAfter);
            hash.Add(EquityWithLoanAfter);
            hash.Add(Commission);
            hash.Add(MinCommission);
            hash.Add(MaxCommission);
            hash.Add(CommissionCurrency);
            hash.Add(WarningText);
            hash.Add(CompletedTime);
            hash.Add(CompletedStatus);
            return hash.ToHashCode();
        }
    }
}
