using System;
using System.Collections;
using java.util;

namespace SolrIKVM {
    public class EnumerationAdapter : Enumeration {
        private readonly IEnumerator e;
        private bool next;

        public EnumerationAdapter(IEnumerator e) {
            this.e = e;
            next = e.MoveNext();
        }

        public bool hasMoreElements() {
            return next;
        }

        public object nextElement() {
            var o = e.Current;
            next = e.MoveNext();
            return o;
        }
    }
}