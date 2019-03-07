using System.Collections.Generic;

namespace Tcgv.Caching
{
    public class LRUCache<TKey, TValue>
    {
        public LRUCache(int size)
        {
            this.size = size;
            this.accesses = new LinkedList<KeyValuePair<TKey, TValue>>();
            this.cache = new Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>>();
        }

        public TValue Get(TKey key)
        {
            if (cache.ContainsKey(key))
            {
                SetMostRecentlyAccessed(key);
                return cache[key].Value.Value;
            }

            return default(TValue);
        }

        public void Set(TKey key, TValue value)
        {
            if (ShouldEvict(key))
                EvictLeastRecentlyAccessed();

            if (cache.ContainsKey(key))
                Remove(cache[key]);

            var node = CreateNode(key, value);
            accesses.AddFirst(node);
            cache[key] = node;
        }

        private void SetMostRecentlyAccessed(TKey key)
        {
            var node = cache[key];
            accesses.Remove(node);
            accesses.AddFirst(node);
        }

        private bool ShouldEvict(TKey key)
        {
            return cache.Count == size && !cache.ContainsKey(key);
        }

        private void EvictLeastRecentlyAccessed()
        {
            var node = accesses.Last;
            Remove(node);
        }

        private void Remove(LinkedListNode<KeyValuePair<TKey, TValue>> node)
        {
            cache.Remove(node.Value.Key);
            accesses.Remove(node);
        }

        private LinkedListNode<KeyValuePair<TKey, TValue>> CreateNode(TKey key, TValue value)
        {
            return new LinkedListNode<KeyValuePair<TKey, TValue>>(new KeyValuePair<TKey, TValue>(key, value));
        }

        private int size;

        private LinkedList<KeyValuePair<TKey, TValue>> accesses;

        private Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>> cache;
    }
}
