using DiscogsClient.Data.Query;
using DiscogsClient.Data.Result;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xunit;

namespace DiscogsClient.Test
{
    public class DiscogsOrderQueryTest
    {
        private DiscogsOrdersFilter _Filter;

        public DiscogsOrderQueryTest()
        {
            _Filter = new DiscogsOrdersFilter()
            {
                status = DiscogsOrderStatusType.CancelledNonPayingBuyer,
                archived = true,
                sort = DiscogsOrderSortType.Created,
                sort_order = DiscogsSortOrderType.asc,
                created_after = new DateTime(2000, 1, 1).ToString("s"),
                created_before = new DateTime(2000, 12, 31).ToString("s")
            };
        }

        [Fact]
        public void OrdersFilter_Status()
        {
            _Filter.status.GetDescription().Should().Be("Cancelled (Non-Paying Buyer)");
        }

        [Fact]
        public void OrdersFilter_Archived()
        {
            _Filter.archived.Should().Be(true);
        }

        [Fact]
        public void OrdersFilter_Sort()
        {
            _Filter.sort.GetDescription().Should().Be("created");
        }

        [Fact]
        public void GOrdersFilter_SortOrder()
        {
            _Filter.sort_order.ToString().Should().Be("asc");
        }

        [Fact]
        public void OrdersFilter_CreatedAfter()
        {
            _Filter.created_after.Should().Be("2000-01-01T00:00:00");
        }

        [Fact]
        public void OrdersFilter_CreatedBefore()
        {
            _Filter.created_before.Should().Be("2000-12-31T00:00:00");
        }

        [Fact]
        public void OrdersFilter_CreatedAfter_Parse()
        {
            DateTime parsed = DateTime.Parse(_Filter.created_after);
            parsed.Should().Be(new DateTime(2000, 1, 1));
        }

        [Fact]
        public void OrdersFilter_CreatedBefore_Parse()
        {
            DateTime parsed = DateTime.Parse(_Filter.created_before);
            parsed.Should().Be(new DateTime(2000, 12, 31));
        }

    }
}
