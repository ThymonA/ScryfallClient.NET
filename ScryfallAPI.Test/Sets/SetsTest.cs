namespace ScryfallAPI.Test.Sets
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class SetsTest
    {
        [TestMethod]
        public void GetAllSetsTest()
        {
            var client = TestHelper.GetScryfallClient();
            var sets = client.Sets.GetAll;

            Assert.IsFalse(sets.IsNullOrDefault(), $"{nameof(IReadOnlyList<ScryfallAPI.Sets>)} is null");
            Assert.AreNotEqual(sets.Count, default, $"number of {nameof(Set)} in {nameof(IReadOnlyList<ScryfallAPI.Sets>)} is {default(int)}");
        }
    }
}
