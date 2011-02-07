using System;
using System.Collections;
using java.util;

namespace SolrIKVM {
    public class EnumerationAdapter : Enumeration {
        private readonly IEnumerator e;

        public EnumerationAdapter(IEnumerator e) {
            this.e = e;
        }

        public bool hasMoreElements() {
            return e.MoveNext(); // wrong
        }

        public object nextElement() {
            return e.Current; // wrong
        }
    }
}