using System;
using System.Collections.Generic;
using IB.Api.Client.Proprietary;

namespace IB.Api.Client
{
    //Not implemented
    public partial class IBClient
    {
        public void bondContractDetails(int reqId, ContractDetails contract)
        {
            throw new NotImplementedException();
        }
        public void contractDetails(int reqId, ContractDetails contractDetails)
        {
            throw new NotImplementedException();
        }
        public void contractDetailsEnd(int reqId)
        {
            throw new NotImplementedException();
        }
        public void currentTime(long time)
        {
            throw new NotImplementedException();
        }
        public void deltaNeutralValidation(int reqId, DeltaNeutralContract deltaNeutralContract)
        {
            throw new NotImplementedException();
        }
        public void displayGroupList(int reqId, string groups)
        {
            throw new NotImplementedException();
        }
        public void displayGroupUpdated(int reqId, string contractInfo)
        {
            throw new NotImplementedException();
        }
        public void familyCodes(FamilyCode[] familyCodes)
        {
            throw new NotImplementedException();
        }
        public void fundamentalData(int reqId, string data)
        {
            throw new NotImplementedException();
        }
        public void headTimestamp(int reqId, string headTimestamp)
        {
            throw new NotImplementedException();
        }
        public void histogramData(int reqId, HistogramEntry[] data)
        {
            throw new NotImplementedException();
        }
        public void marketDataType(int reqId, int marketDataType)
        {
            throw new NotImplementedException();
        }
        public void marketRule(int marketRuleId, PriceIncrement[] priceIncrements)
        {
            throw new NotImplementedException();
        }
        public void mktDepthExchanges(DepthMktDataDescription[] depthMktDataDescriptions)
        {
            throw new NotImplementedException();
        }
        public void pnl(int reqId, double dailyPnL, double unrealizedPnL, double realizedPnL)
        {
            throw new NotImplementedException();
        }
        public void pnlSingle(int reqId, int pos, double dailyPnL, double unrealizedPnL, double realizedPnL, double value)
        {
            throw new NotImplementedException();
        }
        public void receiveFA(int faDataType, string faXmlData)
        {
            throw new NotImplementedException();
        }
        public void rerouteMktDataReq(int reqId, int conId, string exchange)
        {
            throw new NotImplementedException();
        }
        public void rerouteMktDepthReq(int reqId, int conId, string exchange)
        {
            throw new NotImplementedException();
        }
        public void scannerData(int reqId, int rank, ContractDetails contractDetails, string distance, string benchmark, string projection, string legsStr)
        {
            throw new NotImplementedException();
        }
        public void scannerDataEnd(int reqId)
        {
            throw new NotImplementedException();
        }
        public void scannerParameters(string xml)
        {
            throw new NotImplementedException();
        }
        public void securityDefinitionOptionParameter(int reqId, string exchange, int underlyingConId, string tradingClass, string multiplier, HashSet<string> expirations, HashSet<double> strikes)
        {
            throw new NotImplementedException();
        }
        public void securityDefinitionOptionParameterEnd(int reqId)
        {
            throw new NotImplementedException();
        }
        public void smartComponents(int reqId, Dictionary<int, KeyValuePair<string, char>> theMap)
        {
            throw new NotImplementedException();
        }
        public void softDollarTiers(int reqId, SoftDollarTier[] tiers)
        {
            throw new NotImplementedException();
        }
        public void symbolSamples(int reqId, ContractDescription[] contractDescriptions)
        {
            throw new NotImplementedException();
        }
        public void verifyAndAuthCompleted(bool isSuccessful, string errorText)
        {
            throw new NotImplementedException();
        }
        public void verifyAndAuthMessageAPI(string apiData, string xyzChallenge)
        {
            throw new NotImplementedException();
        }
        public void verifyCompleted(bool isSuccessful, string errorText)
        {
            throw new NotImplementedException();
        }
        public void verifyMessageAPI(string apiData)
        {
            throw new NotImplementedException();
        }
    }
}
