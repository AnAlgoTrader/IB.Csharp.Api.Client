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
        public void accountDownloadEnd(string account)
        {
            _accountUpdate.UpdatedOn = DateTime.Now;
            AccountUpdateReceived?.Invoke(this, _accountUpdate);
            Notify($"Account ({account}) updated");
        }        
        public void managedAccounts(string accountsList)
        {
            AccountIds = accountsList.Split(",").ToList();
            Notify($"Managed accounts ({accountsList})");
        }
        public void updateAccountTime(string timestamp)
        {
        }
        public void updateAccountValue(string key, string value, string currency, string accountName)
        {
            _accountUpdate.SetValue(key, value, currency);
        }
    }
}
