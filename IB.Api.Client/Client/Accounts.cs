using System;
using System.Collections.Generic;
using System.Linq;

namespace IB.Api.Client
{
    //Acounts
    public partial class IBClient
    {
        public List<string> AccountIds = new List<string>();
        public void accountDownloadEnd(string account)
        {
            throw new NotImplementedException();
        }
        public void accountSummary(int reqId, string account, string tag, string value, string currency)
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

        public void accountUpdateMultiEnd(int requestId)
        {
            throw new NotImplementedException();
        }
        public void managedAccounts(string accountsList)
        {
            AccountIds = accountsList.Split(",").ToList();
            Notify($"Managed accounts ({accountsList})");
        }
        public void updateAccountTime(string timestamp)
        {
            throw new NotImplementedException();
        }

        public void updateAccountValue(string key, string value, string currency, string accountName)
        {
            throw new NotImplementedException();
        }
    }
}
