using DiscogsClient.Data.Query;
using DiscogsClient.Data.Result;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DiscogsClient
{
    public interface IDiscogsMarketplaceClient
    {
        // Orders

        Task<DiscogsOrder> GetOrderAsync(int orderId);

        Task<DiscogsOrder> GetOrderAsync(CancellationToken token, int orderId);

        Task<DiscogsOrders> GetOrdersAsync(DiscogsOrdersFilter filter = null);

        Task<DiscogsOrders> GetOrdersAsync(CancellationToken token, DiscogsOrdersFilter filter = null);

        // Listings

        Task<DiscogsNewListing> PostNewListingAsync(DiscogsNewListingQuery query);

        Task<DiscogsNewListing> PostNewListingAsync(CancellationToken token, DiscogsNewListingQuery query);

        Task<HttpStatusCode> DeleteListingAsync(int listingId);

        Task<HttpStatusCode> DeleteListingAsync(CancellationToken token, int listingId);

        // Inventory

        Task<DiscogsInventory> GetUsersInventoryAsync(string username, DiscogsInventoryQuery query);

        Task<DiscogsInventory> GetUsersInventoryAsync(CancellationToken token, string username, DiscogsInventoryQuery query);

        // Price Suggestion

        Task<DiscogsPriceSuggestion> GetPriceSuggestion(int releaseId);

        Task<DiscogsPriceSuggestion> GetPriceSuggestion(CancellationToken token, int releaseId);

        // edit order
        // orders messages
        // fee
        // statistic
    }
}
