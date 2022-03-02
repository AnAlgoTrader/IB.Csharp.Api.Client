using System;
using System.Collections.Generic;
using System.Linq;
using IB.Api.Client.Model;

namespace IB.Api.Client
{
    //Acounts
    public partial class IBClient
    {
        public List<string> AccountIds = new List<string>();
        private AccountUpdate _accountUpdate;
        public event EventHandler<AccountUpdate> AccountUpdateReceived;
        public void SubscribeToAccountUpdates(string accountId)
        {
            _accountUpdate = new AccountUpdate();
            ClientSocket.reqAccountUpdates(true, accountId);
        }
        public void SubscribeToDefaultAccountUpdates()
        {
            _accountUpdate = new AccountUpdate();
            ClientSocket.reqAccountUpdates(true, null);
        }
        public void accountDownloadEnd(string account)
        {            
        }        
        public void managedAccounts(string accountsList)
        {
            AccountIds = accountsList.Split(",").ToList();
            Notify($"Managed accounts ({accountsList})");
        }
        public void updateAccountTime(string timestamp)
        {
            _accountUpdate.UpdatedOn = DateTime.Now;
            AccountUpdateReceived?.Invoke(this, _accountUpdate);
        }
        public void updateAccountValue(string key, string value, string currency, string accountName)
        {
            _accountUpdate.SetValue(key, value, currency);
        }
    }
}
