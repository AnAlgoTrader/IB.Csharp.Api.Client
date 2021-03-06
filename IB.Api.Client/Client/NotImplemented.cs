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
        public void accountSummaryEnd(int reqId)
        {
            throw new NotImplementedException();
        }
        public void accountUpdateMulti(int requestId, string account, string modelCode, string key, string value, string currency)
        {
            throw new NotImplementedException();
        }
        public void accountSummary(int reqId, string account, string tag, string value, string currency)
        {
            throw new NotImplementedException();
        }
        public void accountUpdateMultiEnd(int requestId)
        {
            throw new NotImplementedException();
        }
        public virtual void tickSize(int tickerId, int field, int size)
        {
            throw new NotImplementedException();
        }
        public virtual void tickString(int tickerId, int tickType, string value)
        {
            throw new NotImplementedException();
        }
        public virtual void tickGeneric(int tickerId, int field, double value)
        {
            throw new NotImplementedException();
        }
        public void tickByTickAllLast(int reqId, int tickType, long time, double price, int size, TickAttribLast tickAttriblast, string exchange, string specialConditions)
        {
            throw new NotImplementedException();
        }        
        public void tickByTickMidPoint(int reqId, long time, double midPoint)
        {
            throw new NotImplementedException();
        }
        public void tickEFP(int tickerId, int tickType, double basisPoints, string formattedBasisPoints, double impliedFuture, int holdDays, string futureLastTradeDate, double dividendImpact, double dividendsToLastTradeDate)
        {
            throw new NotImplementedException();
        }
        public void tickOptionComputation(int tickerId, int field, double impliedVolatility, double delta, double optPrice, double pvDividend, double gamma, double vega, double theta, double undPrice)
        {
            throw new NotImplementedException();
        }
        public void tickSnapshotEnd(int tickerId)
        {
            throw new NotImplementedException();
        }
        public void updateMktDepthL2(int tickerId, int position, string marketMaker, int operation, int side, double price, int size, bool isSmartDepth)
        {
            throw new NotImplementedException();
        }
        public void tickReqParams(int tickerId, double minTick, string bboExchange, int snapshotPermissions)
        {
            throw new NotImplementedException();
        }
        public void position(string account, Contract contract, double pos, double avgCost)
        {
            throw new NotImplementedException();
        }
        public void positionEnd()
        {
            throw new NotImplementedException();
        }
        public void positionMulti(int requestId, string account, string modelCode, Contract contract, double pos, double avgCost)
        {
            throw new NotImplementedException();
        }
        public void positionMultiEnd(int requestId)
        {
            throw new NotImplementedException();
        }
        public void orderBound(long orderId, int apiClientId, int apiOrderId)
        {
            throw new NotImplementedException();
        }
        public void historicalNews(int requestId, string time, string providerCode, string articleId, string headline)
        {
            throw new NotImplementedException();
        }
        public void historicalNewsEnd(int requestId, bool hasMore)
        {
            throw new NotImplementedException();
        }
        public void newsArticle(int requestId, int articleType, string articleText)
        {
            throw new NotImplementedException();
        }
        public void realtimeBar(int reqId, long date, double open, double high, double low, double close, long volume, double WAP, int count)
        {
            throw new NotImplementedException();
        }
    }
}
