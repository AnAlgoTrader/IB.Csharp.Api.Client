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
            ClientSocket.ReqAccountUpdates(true, accountId);
        }
        public void SubscribeToDefaultAccountUpdates()
        {
            _accountUpdate = new AccountUpdate();
            ClientSocket.ReqAccountUpdates(true, null);
        }
        public void AccountDownloadEnd(string account)
        {
        }
        public void ManagedAccounts(string accountsList)
        {
            AccountIds = accountsList.Split(',').ToList();
            Notify($"Managed accounts ({accountsList})");
        }
        public void UpdateAccountTime(string timestamp)
        {
            _accountUpdate.UpdatedOn = DateTime.Now;
            AccountUpdateReceived?.Invoke(this, _accountUpdate);
        }
        public void UpdateAccountValue(string key, string value, string currency, string accountName)
        {
            _accountUpdate.SetValue(key, value, currency);
        }
    }
}
