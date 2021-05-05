using DiscogsClient.Data.Parameters;
using DiscogsClient.Data.Result;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xunit;

namespace DiscogsClient.Test
{
    public class DiscogsParametersTest
    {
        internal class TestParameters : DiscogsParametersBase
        {
            public OrderStatus? status { get; set; }
            public string message { get; set; }
            public int number { get; set; }
            public bool? is_true { get; set; }
        }

        [Fact]
        public void GetParameters_EnumValue_Exact()
        {
            TestParameters test = new TestParameters()
            {
                status = OrderStatus.All
            };

            Dictionary<string, string> parameters = test.GetParameters();

            Assert.Equal("All", parameters["status"]);
        }

        [Fact]
        public void GetParameters_StringValue_Exact()
        {
            TestParameters test = new TestParameters()
            {
                message = "Test Message"
            };

            Dictionary<string, string> parameters = test.GetParameters();

            Assert.Equal("Test Message", parameters["message"]);
        }

        [Fact]
        public void GetParameters_IntValue_Exact()
        {
            TestParameters test = new TestParameters()
            {
                number = 5
            };

            Dictionary<string, string> parameters = test.GetParameters();

            Assert.Equal("5", parameters["number"]);
        }

        [Fact]
        public void GetParameters_BoolValue_Exact()
        {
            TestParameters test = new TestParameters()
            {
                is_true = true
            };

            Dictionary<string, string> parameters = test.GetParameters();

            Assert.Equal("True", parameters["is_true"]);
        }

        [Fact]
        public void GetParameterValue_Value_Exact()
        {
            OrderStatus status = OrderStatus.CancelledNonPayingBuyer;
            string statusText = status.GetDiscogsParameterValue();

            Assert.Equal("Cancelled (Non-Paying Buyer)", statusText);
        }
    }
}
