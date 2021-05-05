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
        private readonly DiscogsOrder _Result;
        public OrderDeserializationTest()
        {
            _Result = JsonConvert.DeserializeObject<DiscogsOrder>(_Order);
        }

        [Fact]
        public void DeserializeResult_IsNotNull()
        {
            _Result.Should().NotBeNull();
        }

        //[Fact]
        //public void DeserializeResult_Deserialize_most_recent_release()
        //{
        //    _Result.most_recent_release.Should().Be(13111150);
        //}

        //[Fact]
        //public void DeserializeResult_Deserialize_most_recent_release_url()
        //{
        //    _Result.most_recent_release_url.Should().Be("https://api.discogs.com/releases/13111150");
        //}

        //[Fact]
        //public void DeserializeResult_Deserialize_num_for_sale()
        //{
        //    _Result.num_for_sale.Should().Be(7);
        //}

        //[Fact]
        //public void DeserializeResult_Deserialize_lowest_price()
        //{
        //    _Result.lowest_price.Should().Be(13.51m);
        //}
    }
}
