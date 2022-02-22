using System;
using IB.Api.Client.Proprietary;

namespace IB.Api.Client{

    //News
    public partial class IBClient
    {
        public event EventHandler<NewsProvider[]> NewsProvidersUpdateReceived;
        public void GetNewsProviders()
        {
            ClientSocket.reqNewsProviders();
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

        public void newsProviders(NewsProvider[] newsProviders)
        {
            NewsProvidersUpdateReceived?.Invoke(this, newsProviders);
        }
        public void updateNewsBulletin(int msgId, int msgType, string message, string origExchange)
        {
            throw new NotImplementedException();
        }
    }
}
