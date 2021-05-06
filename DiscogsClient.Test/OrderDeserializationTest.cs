using DiscogsClient.Data.Result;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DiscogsClient.Test
{
    public class OrderDeserializationTest
    {
        private const string _Order = "{\"id\":\"1-1\",\"resource_url\":\"https://api.discogs.com/marketplace/orders/1-1\",\"messages_url\":\"https://api.discogs.com/marketplace/orders/1-1/messages\",\"uri\":\"http://www.discogs.com/sell/order/1-1\",\"status\":\"New Order\",\"next_status\":[\"New Order\",\"Buyer Contacted\",\"Invoice Sent\",\"Payment Pending\",\"Payment Received\",\"Shipped\",\"Refund Sent\",\"Cancelled (Non-Paying Buyer)\",\"Cancelled (Item Unavailable)\",\"Cancelled (Per Buyer's Request)\"],\"fee\":{\"currency\":\"USD\",\"value\":2.52},\"created\":\"2011-10-21T09:25:17-07:00\",\"items\":[{\"release\":{\"id\":1,\"description\":\"Persuader, The - Stockholm (2x12\\\")\"},\"price\":{\"currency\":\"USD\",\"value\":42},\"media_condition\":\"Mint (M)\",\"sleeve_condition\":\"Mint (M)\",\"id\":41578242}],\"shipping\":{\"currency\":\"USD\",\"method\":\"Standard\",\"value\":0},\"shipping_address\":\"Asdf Exampleton\n234 NE Asdf St.\nAsdf Town, Oregon, 14423\nUnited States\n\nPhone: 555-555-2733\nPaypal address: asdf@example.com\",\"additional_instructions\":\"please use sturdy packaging.\",\"archived\":false,\"seller\":{\"resource_url\":\"https://api.discogs.com/users/example_seller\",\"username\":\"example_seller\",\"id\":1},\"last_activity\":\"2011-10-21T09:25:17-07:00\",\"buyer\":{\"resource_url\":\"https://api.discogs.com/users/example_buyer\",\"username\":\"example_buyer\",\"id\":2},\"total\":{\"currency\":\"USD\",\"value\":42}}";
        private const string _Orders = "{\"pagination\":{\"per_page\":50,\"pages\":1,\"page\":1,\"items\":1,\"urls\":{}},\"orders\":[{\"status\":\"New Order\",\"fee\":{\"currency\":\"USD\",\"value\":2.52},\"created\":\"2011-10-21T09:25:17-07:00\",\"items\":[{\"release\":{\"id\":1,\"description\":\"Persuader, The - Stockholm (2x12\\\")\",\"resource_url\":\"https://api.discogs.com/releases/1\",\"thumbnail\":\"http://api-img.discogs.com/souG2t4I8ZFVK3kHVtD3zjGvd_Y=/fit-in/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-1-1193812031.jpeg.jpg\"},\"price\":{\"currency\":\"USD\",\"value\":42},\"id\":41578242}],\"shipping\":{\"currency\":\"USD\",\"method\":\"Standard\",\"value\":0},\"shipping_address\":\"Asdf Exampleton\n234 NE Asdf St.\nAsdf Town, Oregon, 14423\nUnited States\n\nPhone: 555-555-2733\nPaypal address: asdf@example.com\",\"additional_instructions\":\"please use sturdy packaging.\",\"archived\":false,\"seller\":{\"resource_url\":\"https://api.discogs.com/users/example_seller\",\"username\":\"example_seller\",\"id\":1},\"last_activity\":\"2011-10-21T09:25:17-07:00\",\"buyer\":{\"resource_url\":\"https://api.discogs.com/users/example_buyer\",\"username\":\"example_buyer\",\"id\":2},\"total\":{\"currency\":\"USD\",\"value\":42},\"id\":\"1-1\",\"resource_url\":\"https://api.discogs.com/marketplace/orders/1-1\",\"messages_url\":\"https://api.discogs.com/marketplace/orders/1-1/messages\",\"uri\":\"http://www.discogs.com/sell/order/1-1\",\"next_status\":[\"New Order\",\"Buyer Contacted\",\"Invoice Sent\",\"Payment Pending\",\"Payment Received\",\"Shipped\",\"Refund Sent\",\"Cancelled (Non-Paying Buyer)\",\"Cancelled (Item Unavailable)\",\"Cancelled (Per Buyer's Request)\"]}]}";
        private readonly DiscogsOrder _OrderResult;
        private readonly DiscogsOrders _OrdersResult;

        public OrderDeserializationTest()
        {
            _OrderResult = JsonConvert.DeserializeObject<DiscogsOrder>(_Order);
            _OrdersResult = JsonConvert.DeserializeObject<DiscogsOrders>(_Orders);
        }

        [Fact]
        public void DeserializeOrderResult_IsNotNull()
        {
            _OrderResult.Should().NotBeNull();
        }

        [Fact]
        public void DeserializeOrdersResult_IsNotNull()
        {
            _OrdersResult.Should().NotBeNull();
        }

        [Fact]
        public void DeserializeOrdersResult_PaginationPerPage()
        {
            _OrdersResult.pagination.per_page.Should().Be(50);
        }

        [Fact]
        public void DeserializeOrdersResult_PaginationPages()
        {
            _OrdersResult.pagination.pages.Should().Be(1);
        }

        [Fact]
        public void DeserializeOrdersResult_PaginationItems()
        {
            _OrdersResult.pagination.items.Should().Be(1);
        }

        [Fact]
        public void DeserializeOrdersResult_PaginationOrdersCount()
        {
            _OrdersResult.orders.Count.Should().Be(1);
        }

        [Fact]
        public void DeserializeOrdersResult_PaginationOrdersNotNull()
        {
            _OrdersResult.orders[0].Should().NotBeNull();
        }

        [Fact]
        public void DeserializeOrdersResult_PaginationOrdersType()
        {
            _OrdersResult.orders[0].Should().BeOfType<DiscogsOrder>();
        }

        [Fact]
        public void DeserializeOrderResult_Id()
        {
            _OrderResult.id.Should().Be("1-1");
        }

        [Fact]
        public void DeserializeOrderResult_Status()
        {
            _OrderResult.status.Should().Be("New Order");
        }

        [Fact]
        public void DeserializeOrderResult_TotalCurrency()
        {
            _OrderResult.total.currency.Should().Be("USD");
        }

        [Fact]
        public void DeserializeOrderResult_TotalValue()
        {
            _OrderResult.total.value.Should().Be(42);
        }

        [Fact]
        public void DeserializeOrderResult_ItemsCount()
        {
            _OrderResult.items.Count.Should().Be(1);
        }

        [Fact]
        public void DeserializeOrderResult_ItemPriceValue()
        {
            _OrderResult.items[0].price.value.Should().Be(42);
        }

        [Fact]
        public void DeserializeOrderResult_ItemId()
        {
            _OrderResult.items[0].id.Should().Be(41578242);
        }
    }
}
