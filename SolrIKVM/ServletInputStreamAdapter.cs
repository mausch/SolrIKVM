using System;
using System.IO;
using javax.servlet;

namespace SolrIKVM {
    public class ServletInputStreamAdapter : ServletInputStream {
        private readonly Stream stream;

        public ServletInputStreamAdapter(Stream stream) {
            this.stream = stream;
        }

        public override int read() {
            return stream.ReadByte();
        }
    }
}