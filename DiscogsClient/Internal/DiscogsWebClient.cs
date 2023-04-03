using RateLimiter;
using RestSharp;
using System;
using RestSharpHelper;
using RestSharpHelper.OAuth1;

namespace DiscogsClient.Internal
{
    internal class DiscogsWebClient : RestSharpWebClient, IDiscogsWebClient
    {
        private const string _SearchUrl = "database/search";
        private const string _ReleaseUrl = "releases/{releaseId}";
        private const string _MasterUrl = "masters/{masterId}";
        private const string _MasterReleaseVersionUrl = "masters/{masterId}/versions";
        private const string _ArtistUrl = "artists/{artistId}";
        private const string _ArtistReleaseUrl = "artists/{artistId}/releases";
        private const string _AllLabelReleasesUrl = "labels/{labelId}/releases";
        private const string _LabeltUrl = "labels/{labelId}";
        private const string _ReleaseRatingByUserUrl = "releases/{releaseId}/rating/{userName}";
        private const string _CommunityReleaseRatingUrl = "releases/{releaseId}/rating";
        private const string _IdendityUrl = "oauth/identity";
        private const string _MarketplaceOrderUrl = "marketplace/orders/{orderId}";
        private const string _MarketplaceOrdersUrl = "marketplace/orders";
        private const string _UserInventoryUrl = "users/{username}/inventory";
        private const string _MarketplaceListingsUrl = "marketplace/listings";
        private const string _MarketplaceListingUrl = "marketplace/listings/{listingId}";
        private const string _MarketplacePriceSuggestionUrl = "marketplace/price_suggestions/{releaseId}";
        private readonly OAuthCompleteInformation _OAuthCompleteInformation;
        private readonly TokenAuthenticationInformation _TokenAuthenticationInformation;

        protected override string UrlBase => "https://api.discogs.com";
        protected override string UserAgentFallBack => @"DiscogsClient https://github.com/David-Desmaisons/DiscogsClient";
        protected override TimeLimiter TimeLimiter => SharedTimeLimiter;

        private static TimeLimiter SharedTimeLimiter { get; }

        public DiscogsWebClient(OAuthCompleteInformation oAuthCompleteInformation, string userAgent, int timeOut = 10000):
            base(userAgent, timeOut)
        {
            _OAuthCompleteInformation = oAuthCompleteInformation;
        }

        public DiscogsWebClient(TokenAuthenticationInformation tokenAuthenticationInformation, string userAgent, int timeOut = 10000)
            : base(userAgent, timeOut)
        {
            _TokenAuthenticationInformation = tokenAuthenticationInformation;
        }

        static DiscogsWebClient()
        {
            SharedTimeLimiter = TimeLimiter.GetFromMaxCountByInterval(25, TimeSpan.FromMinutes(1));
        }

        protected override IRestClient Mature(IRestClient client) 
        {
            Authenticator = _OAuthCompleteInformation?.GetAuthenticatorForProtectedResource();

            return client;
        }

        public RestRequest GetUserIdentityRequest()
        {
            return GetRequest(_IdendityUrl);
        }

        public RestRequest GetSearchRequest()
        {
            return GetRequest(_SearchUrl);
        }

        public RestRequest GetReleaseRequest(int releaseId)
        {       
            return GetRequest(_ReleaseUrl).AddUrlSegment(nameof(releaseId), releaseId.ToString());
        }

        public RestRequest GetMasterRequest(int masterId) 
        {
            return GetRequest(_MasterUrl).AddUrlSegment(nameof(masterId), masterId.ToString());
        }

        public RestRequest GetMasterReleaseVersionRequest(int masterId)
        {
            return GetRequest(_MasterReleaseVersionUrl).AddUrlSegment(nameof(masterId), masterId.ToString());
        }

        public RestRequest GetArtistRequest(int artistId) 
        {
            return GetRequest(_ArtistUrl).AddUrlSegment(nameof(artistId), artistId.ToString());
        }

        public RestRequest GetLabelRequest(int labelId) 
        {
            return GetRequest(_LabeltUrl).AddUrlSegment(nameof(labelId), labelId.ToString());
        }

        public RestRequest GetArtistReleaseVersionRequest(int artistId) 
        {
            return GetRequest(_ArtistReleaseUrl).AddUrlSegment(nameof(artistId), artistId.ToString());
        }

        public RestRequest GetAllLabelReleasesRequest(int labelId)
        {
            return GetRequest(_AllLabelReleasesUrl).AddUrlSegment(nameof(labelId), labelId.ToString());
        }

        public RestRequest GetGetUserReleaseRatingRequest(string userName, int releaseId)
        {
            return GetUserReleaseRatingRequestRaw(userName, releaseId, Method.Get);
        }

        public RestRequest GetPutUserReleaseRatingRequest(string userName, int releaseId)
        {
            return GetUserReleaseRatingRequestRaw(userName, releaseId, Method.Put);
        }

        public RestRequest GetDeleteUserReleaseRatingRequest(string userName, int releaseId)
        {
            return GetUserReleaseRatingRequestRaw(userName, releaseId, Method.Delete);
        }

        private RestRequest GetUserReleaseRatingRequestRaw(string userName, int releaseId, Method method)
        {
            return GetRequest(_ReleaseRatingByUserUrl, method)
                       .AddUrlSegment(nameof(userName), userName)
                       .AddUrlSegment(nameof(releaseId), releaseId.ToString());
        }

        public RestRequest GetCommunityReleaseRatingRequest(int releaseId)
        {
            return GetRequest(_CommunityReleaseRatingUrl).AddUrlSegment(nameof(releaseId), releaseId.ToString());
        }

        private RestRequest GetRequest(string url, Method method = Method.Get)
        {
            var request = new RestRequest(url, method).AddHeader("Accept-Encoding", "gzip");
            if (_TokenAuthenticationInformation != null)
                request.AddHeader("Authorization", _TokenAuthenticationInformation.GetDiscogsSecretToken());

            return request;
        }

        public RestRequest GetMarketplaceOrder(int orderId)
        {
            return GetRequest(_MarketplaceOrderUrl).AddUrlSegment(nameof(orderId), orderId.ToString());
        }

        public RestRequest GetMarketplaceOrders()
        {
            var request = GetRequest(_MarketplaceOrdersUrl);
            request.AddHeader("Content-Type", "application/json");

            return request;
        }

        public RestRequest PostMarketplaceNewListing()
        {
            RestRequest request = GetRequest(_MarketplaceListingsUrl, Method.Post);
            request.AddHeader("Content-Type", "application/json");

            return request;
        }

        public RestRequest PostMarketplaceListing(long listingId)
        {
            RestRequest request = GetRequest(_MarketplaceListingUrl, Method.Post).AddUrlSegment(nameof(listingId), listingId.ToString());
            request.AddHeader("Content-Type", "application/json");

            return request;
        }

        public RestRequest DeleteMarketplaceListing(long listingId)
        {
            RestRequest request = GetRequest(_MarketplaceListingUrl, Method.Delete).AddUrlSegment(nameof(listingId), listingId.ToString());
            request.AddHeader("Content-Type", "application/json");

            return request;
        }

        public RestRequest GetUserInventory(string username)
        {
            return GetRequest(_UserInventoryUrl, Method.Post).AddUrlSegment(nameof(username), username);
        }

        public RestRequest GetPriceSuggestion(int releaseId)
        {
            return GetRequest(_MarketplacePriceSuggestionUrl, Method.Get).AddUrlSegment(nameof(releaseId), releaseId.ToString());
        }
    }
}
