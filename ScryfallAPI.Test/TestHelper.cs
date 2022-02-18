using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScryfallAPI.Test
{
    public static class TestHelper
    {
        private const string name = "ScryfallAPI";
        private static IScryfallClient client = null;

        public static IScryfallClient GetScryfallClient()
        {
            if (client.IsNullOrDefault()) client = new ScryfallClient(name);
            if (!client.IsNullOrDefault()) return client;

            Assert.Fail($"Failed to create a {nameof(ScryfallClient)}");

            return null;
        }
    }
}
