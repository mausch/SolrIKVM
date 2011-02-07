using System;
using System.Collections.Specialized;
using System.Linq;
using java.util;

namespace SolrIKVM {
    public class MapNameValueCollectionAdapter : Map {
        private readonly NameValueCollection c;

        public MapNameValueCollectionAdapter(NameValueCollection c) {
            this.c = c;
        }

        public object get(object obj) {
            return c.GetValues((string)obj);
        }

        public object put(object obj1, object obj2) {
            c[(string)obj1] = (string)obj2;
            return obj2;
        }

        public Set keySet() {
            var s = new HashSet();
            foreach (var k in c.AllKeys)
                s.add(k);
            return s;
        }

        public bool containsKey(object obj) {
            if (!(obj is string))
                return false;
            return c.AllKeys.Contains((string)obj);
        }

        public object remove(object obj) {
            c.Remove((string)obj);
            return obj;
        }

        public Collection values() {
            throw new NotImplementedException();
        }

        public void clear() {
            c.Clear();
        }

        public Set entrySet() {
            var s = new HashSet();
            foreach (string k in c) {
                var entry = new MapEntry(k, c.GetValues(k));
                s.add(entry);
            }
            return s;
        }

        public int size() {
            return c.Count;
        }

        public bool isEmpty() {
            return c.HasKeys();
        }

        public bool containsValue(object obj) {
            throw new NotImplementedException();
        }

        public void putAll(Map m) {
            throw new NotImplementedException();
        }

        public bool @equals(object obj) {
            return c.Equals(obj);
        }

        public int hashCode() {
            return c.GetHashCode();
        }
    }
}