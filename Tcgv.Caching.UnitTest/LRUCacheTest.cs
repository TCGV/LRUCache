using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tcgv.Caching.UnitTest
{
    [TestClass]
    public class LRUCacheTest
    {
        [TestMethod]
        public void GetNullItem_Test()
        {
            var cache = new LRUCache<string, string>(int.MaxValue);

            var value = cache.Get("key");

            Assert.IsNull(value);
        }

        [TestMethod]
        public void SetAndGetItem_Test()
        {
            var cache = new LRUCache<string, string>(int.MaxValue);

            cache.Set("key", "1234");
            var value = cache.Get("key");

            Assert.AreEqual("1234", value);
        }

        [TestMethod]
        public void SetItemTwice_Test()
        {
            var cache = new LRUCache<string, string>(int.MaxValue);

            cache.Set("key", "1234");
            cache.Set("key", "5678");
            var value = cache.Get("key");

            Assert.AreEqual("5678", value);
        }

        [TestMethod]
        public void Eviction_OnlySettingItems_Test()
        {
            var cache = new LRUCache<string, string>(3);

            cache.Set("one", "1");
            cache.Set("two", "2");
            cache.Set("three", "3");
            cache.Set("four", "4");

            Assert.IsNull(cache.Get("one"));
            Assert.AreEqual("2", cache.Get("two"));
            Assert.AreEqual("3", cache.Get("three"));
            Assert.AreEqual("4", cache.Get("four"));
        }

        [TestMethod]
        public void Eviction_WhenGettingItems_Test()
        {
            var cache = new LRUCache<string, string>(3);

            cache.Set("one", "1");
            cache.Set("two", "2");
            cache.Set("three", "3");
            cache.Get("one");
            cache.Set("four", "4");

            Assert.AreEqual("1", cache.Get("one"));
            Assert.IsNull(cache.Get("two"));
            Assert.AreEqual("3", cache.Get("three"));
            Assert.AreEqual("4", cache.Get("four"));
        }
    }
}
