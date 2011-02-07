using System;
using System.IO;
using javax.servlet;

namespace SolrIKVM {
    public class ServletOutputStreamAdapter : ServletOutputStream {
        private readonly Stream stream;

        public ServletOutputStreamAdapter(Stream stream) {
            this.stream = stream;
        }

        public override void write(int i) {
            stream.WriteByte((byte)i);
        }

        public override void write(byte[] b, int off, int len) {
            stream.Write(b, off, len);
        }

        public override void write(byte[] b) {
            stream.Write(b, 0, b.Length);
        }
    }
}