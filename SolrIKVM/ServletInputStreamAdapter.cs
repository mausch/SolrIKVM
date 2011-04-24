using java.io;
using javax.servlet;

namespace SolrIKVM {
    public class ServletInputStreamAdapter : ServletInputStream {
        readonly InputStream _in;

        public ServletInputStreamAdapter(InputStream @in) {
            _in = @in;
        }

        public override int read() {
            return _in.read();
        }

        public int read(byte[] b) {
            return _in.read(b);
        }

        public int read(byte[] b, int off, int len) {
            return _in.read(b, off, len);
        }

        public long skip(long len) {
            return _in.skip(len);
        }

        public int available() {
            return _in.available();
        }

        public void close() {
            _in.close();
        }

        public bool markSupported() {
            return _in.markSupported();
        }

        public void reset() {
            _in.reset();
        }

        public void mark(int readlimit) {
            _in.mark(readlimit);
        }
    }
}