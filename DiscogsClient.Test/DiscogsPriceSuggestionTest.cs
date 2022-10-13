using DiscogsClient.Data.Result;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DiscogsClient.Test
{
    public class DiscogsPriceSuggestionTest
    {
        private const string _PriceSuggestion = "{\"Mint (M)\": {\"currency\": \"EUR\", \"value\": 11.460325000000001}, \"Near Mint (NM or M-)\": {\"currency\": \"EUR\", \"value\": 10.253974999999999}, \"Very Good Plus (VG+)\": {\"currency\": \"EUR\", \"value\": 7.841275}, \"Very Good (VG)\": {\"currency\": \"EUR\", \"value\": 5.428575}, \"Good Plus (G+)\": {\"currency\": \"EUR\", \"value\": 3.015875}, \"Good (G)\": {\"currency\": \"EUR\", \"value\": 1.8095249999999998}, \"Fair (F)\": {\"currency\": \"EUR\", \"value\": 1.20635}, \"Poor (P)\": {\"currency\": \"EUR\", \"value\": 0.603175}}";
        private readonly DiscogsPriceSuggestion _Result;

        public DiscogsPriceSuggestionTest()
        {
            _Result = JsonConvert.DeserializeObject<DiscogsPriceSuggestion>(_PriceSuggestion);
        }

        [Fact]
        public void DeserializePriceResult_IsNotNull()
        {
            _Result.Should().NotBeNull();
        }

        [Fact]
        public void DeserializePriceResult_MintValue()
        {
            Math.Ceiling(_Result.Mint.value).Should().Be(12);
        }

        [Fact]
        public void DeserializePriceResult_MintCurrency()
        {
            _Result.Mint.currency.Should().Be("EUR");
        }
    }
}
