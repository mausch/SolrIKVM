using System;
using java.util;

namespace SolrIKVM {
    public class MapEntry : Map.Entry {
        private readonly object key;
        private readonly object value;

        public MapEntry(object key, object value) {
            this.key = key;
            this.value = value;
        }

        public object getKey() {
            return key;
        }

        public object getValue() {
            return value;
        }

        public object setValue(object obj) {
            throw new NotSupportedException();
        }

        public bool @equals(object obj) {
            return Equals(obj);
        }

        public int hashCode() {
            return GetHashCode();
        }
    }
}