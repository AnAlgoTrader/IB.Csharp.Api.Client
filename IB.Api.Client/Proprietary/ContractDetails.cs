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
     * @class ContractDetails
     * @brief extended contract details.
     * @sa Contract
     */
    public class ContractDetails
    {
        /**
         * @brief A fully-defined Contract object.
         */
        public Contract Contract
        {
            get;
            set;
        }

        /**
        * @brief The market name for this product.
        */
        public string MarketName
        {
            get;
            set;
        }

        /**
        * @brief The minimum allowed price variation.
         * Note that many securities vary their minimum tick size according to their price. This value will only show the smallest of the different minimum tick sizes regardless of the product's price. Full information about the minimum increment price structure can be obtained with the reqMarketRule function or the IB Contract and Security Search site.
        */
        public double MinTick
        {
            get;
            set;
        }

        /**
        * @brief Allows execution and strike prices to be reported consistently with market data, historical data and the order price, i.e. Z on LIFFE is reported in Index points and not GBP.
		* In TWS versions prior to 972, the price magnifier is used in defining future option strike prices (e.g. in the API the strike is specified in dollars, but in TWS it is specified in cents).
		* In TWS versions 972 and higher, the price magnifier is not used in defining futures option strike prices so they are consistent in TWS and the API.
        */
        public int PriceMagnifier
        {
            get;
            set;
        }

        /**
        * @brief Supported order types for this product.
        */
        public string OrderTypes
        {
            get;
            set;
        }

        /**
        * @brief Valid exchange fields when placing an order for this contract.\n
		* The list of exchanges will is provided in the same order as the corresponding MarketRuleIds list.
        */
        public string ValidExchanges
        {
            get;
            set;
        }

        /**
        * @brief For derivatives, the contract ID (conID) of the underlying instrument
        */
        public int UnderConId
        {
            get;
            set;
        }

        /**
        * @brief Descriptive name of the product.
        */
        public string LongName
        {
            get;
            set;
        }

        /**
        * @brief Typically the contract month of the underlying for a Future contract.
        */
        public string ContractMonth
        {
            get;
            set;
        }

        /**
        * @brief The industry classification of the underlying/product. For example, Financial.
        */
        public string Industry
        {
            get;
            set;
        }

        /**
        * @brief The industry category of the underlying. For example, InvestmentSvc.
        */
        public string Category
        {
            get;
            set;
        }

        /**
        * @brief The industry subcategory of the underlying. For example, Brokerage.
        */
        public string Subcategory
        {
            get;
            set;
        }

        /**
        * @brief The time zone for the trading hours of the product. For example, EST.
        */
        public string TimeZoneId
        {
            get;
            set;
        }

        /**
        * @brief The trading hours of the product.
         * This value will contain the trading hours of the current day as well as the next's. For example, 20090507:0700-1830,1830-2330;20090508:CLOSED.
		 * In TWS versions 965+ there is an option in the Global Configuration API settings to return 1 month of trading hours.
		 * In TWS version 970+, the format includes the date of the closing time to clarify potential ambiguity, ex: 20180323:0400-20180323:2000;20180326:0400-20180326:2000
		 * The trading hours will correspond to the hours for the product on the associated exchange. The same instrument can have different hours on different exchanges.
        */
        public string TradingHours
        {
            get;
            set;
        }

        /**
        * @brief The liquid hours of the product.
        * This value will contain the liquid hours (regular trading hours) of the contract on the specified exchange. Format for TWS versions until 969: 20090507:0700-1830,1830-2330;20090508:CLOSED.
		* In TWS versions 965+ there is an option in the Global Configuration API settings to return 1 month of trading hours.
		* In TWS v970 and above, the format includes the date of the closing time to clarify potential ambiguity, e.g. 20180323:0930-20180323:1600;20180326:0930-20180326:1600
		*/
        public string LiquidHours
        {
            get;
            set;
        }

        /**
        * @brief Contains the Economic Value Rule name and the respective optional argument.
         * The two values should be separated by a colon. For example, aussieBond:YearsToExpiration=3. When the optional argument is not present, the first value will be followed by a colon.
        */
        public string EvRule
        {
            get;
            set;
        }

        /**
        * @brief Tells you approximately how much the market value of a contract would change if the price were to change by 1.
         * It cannot be used to get market value by multiplying the price by the approximate multiplier.
        */
        public double EvMultiplier
        {
            get;
            set;
        }

        /**
        * @brief MD Size Multiplier. Returns the size multiplier for values returned to tickSize from a market data request. Generally 100 for US stocks and 1 for other instruments.
        */
        public int MdSizeMultiplier
        {
            get;
            set;
        }

        /**
        * @brief Aggregated group
		* Indicates the smart-routing group to which a contract belongs.
		* contracts which cannot be smart-routed have aggGroup = -1
        */
        public int AggGroup
        {
            get;
            set;
        }

        /**
        * @brief A list of contract identifiers that the customer is allowed to view.
        * CUSIP/ISIN/etc. For US stocks, receiving the ISIN requires the CUSIP market data subscription.
		* For Bonds, the CUSIP or ISIN is input directly into the symbol field of the Contract class.
        */
        public List<TagValue> SecIdList
        {
            get;
            set;
        }

        /**
        * @brief For derivatives, the symbol of the underlying contract.
        */
        public string UnderSymbol
        {
            get;
            set;
        }

        /**
        * @brief For derivatives, returns the underlying security type.
        */
        public string UnderSecType
        {
            get;
            set;
        }

        /**
        * @brief The list of market rule IDs separated by comma
		* Market rule IDs can be used to determine the minimum price increment at a given price.
        */
        public string MarketRuleIds
        {
            get;
            set;
        }

        /**
        * @brief Real expiration date. Requires TWS 968+ and API v973.04+. Python API specifically requires API v973.06+.
        */
        public string RealExpirationDate
        {
            get;
            set;
        }

        /**
        * @brief Last trade time
        */
        public string LastTradeTime
        {
            get;
            set;
        }

        /**
        * @brief The nine-character bond CUSIP.
         * For Bonds only. Receiving CUSIPs requires a CUSIP market data subscription.
        */
        public string Cusip
        {
            get;
            set;
        }

        /**
        * @brief Identifies the credit rating of the issuer.
		* This field is not currently available from the TWS API.
        * For Bonds only. A higher credit rating generally indicates a less risky investment. Bond ratings are from Moody's and S&P respectively. Not currently implemented due to bond market data restrictions.
        */
        public string Ratings
        {
            get;
            set;
        }

        /**
        * @brief A description string containing further descriptive information about the bond.
         * For Bonds only.
        */
        public string DescAppend
        {
            get;
            set;
        }

        /**
        * @brief The type of bond, such as "CORP."
        */
        public string BondType
        {
            get;
            set;
        }

        /**
        * @brief The type of bond coupon.
		* This field is currently not available from the TWS API.
        * For Bonds only.
        */
        public string CouponType
        {
            get;
            set;
        }

        /**
        * @brief If true, the bond can be called by the issuer under certain conditions.
		* This field is currently not available from the TWS API.
        * For Bonds only.
        */
        public bool Callable
        {
            get;
            set;
        }

        /**
        * @brief Values are True or False. If true, the bond can be sold back to the issuer under certain conditions.
		* This field is currently not available from the TWS API.
        * For Bonds only.
        */
        public bool Putable
        {
            get;
            set;
        }

        /**
        * @brief The interest rate used to calculate the amount you will receive in interest payments over the course of the year.
        * This field is currently not available from the TWS API.
		* For Bonds only.
        */
        public double Coupon
        {
            get;
            set;
        } = 0;

        /**
        * @brief Values are True or False. If true, the bond can be converted to stock under certain conditions.
        * This field is currently not available from the TWS API.
		* For Bonds only.
        */
        public bool Convertible
        {
            get;
            set;
        }

        /**
        * @brief he date on which the issuer must repay the face value of the bond.
        * This field is currently not available from the TWS API.
		* For Bonds only. Not currently implemented due to bond market data restrictions.
        */
        public string Maturity
        {
            get;
            set;
        }

        /**
        * @brief The date the bond was issued.
        * This field is currently not available from the TWS API.
		* For Bonds only. Not currently implemented due to bond market data restrictions.
        */
        public string IssueDate
        {
            get;
            set;
        }

        /**
        * @brief Only if bond has embedded options.
		* This field is currently not available from the TWS API.
        * Refers to callable bonds and puttable bonds. Available in TWS description window for bonds.
        */
        public string NextOptionDate
        {
            get;
            set;
        }

        /**
        * @brief Type of embedded option.
		* This field is currently not available from the TWS API.
        * Only if bond has embedded options.
        */
        public string NextOptionType
        {
            get;
            set;
        }

        /**
       * @brief Only if bond has embedded options.
	   * This field is currently not available from the TWS API.
       * For Bonds only.
       */
        public bool NextOptionPartial { get; set; } = false;

        /**
        * @brief If populated for the bond in IB's database.
         * For Bonds only.
        */
        public string Notes { get; set; }

        public ContractDetails()
        {
            Contract = new Contract();
            MinTick = 0;
            UnderConId = 0;
            EvMultiplier = 0;
        }

        public ContractDetails(Contract summary, String marketName,
                double minTick, String orderTypes, String validExchanges, int underConId, String longName,
                String contractMonth, String industry, String category, String subcategory,
                String timeZoneId, String tradingHours, String liquidHours,
                String evRule, double evMultiplier, int aggGroup)
        {
            Contract = summary;
            MarketName = marketName;
            MinTick = minTick;
            OrderTypes = orderTypes;
            ValidExchanges = validExchanges;
            UnderConId = underConId;
            LongName = longName;
            ContractMonth = contractMonth;
            Industry = industry;
            Category = category;
            Subcategory = subcategory;
            TimeZoneId = timeZoneId;
            TradingHours = tradingHours;
            LiquidHours = liquidHours;
            EvRule = evRule;
            EvMultiplier = evMultiplier;
            AggGroup = aggGroup;
        }
    }
}
