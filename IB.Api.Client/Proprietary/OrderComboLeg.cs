/* Copyright (C) 2019 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;

namespace IB.Api.Client.Proprietary
{
    /**
     * @class OrderComboLeg
     * @brief Allows to specify a price on an order's leg
     * @sa Order, ComboLeg
     */
    public class OrderComboLeg
    {
        /**
         * @brief The order's leg's price
         */
        public double Price { get; set; }

        public OrderComboLeg()
        {
            Price = double.MaxValue;
        }

        public OrderComboLeg(double p_price)
        {
            Price = p_price;
        }

        public override bool Equals(Object other)
        {
            if (this == other)
            {
                return true;
            }
            else if (other == null)
            {
                return false;
            }

            OrderComboLeg theOther = (OrderComboLeg)other;

            return Price == theOther.Price;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Price, Price);
        }
    }
}
