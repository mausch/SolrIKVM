using System.Collections.Generic;
using System.IO;
using System.Linq;
using javax.servlet;

namespace SolrIKVM {
    public class ServletInputStreamAdapter : ServletInputStream {
        private readonly Stream stream;

        public ServletInputStreamAdapter(Stream stream) {
            this.stream = stream;
        }

        public override int read(byte[] b) {
            return stream.Read(b, 0, b.Length);
        }

        public override int read(byte[] b, int off, int len) {
            var r = stream.Read(b, off, len);
            return r;
        }

        public override int read() {
            return stream.ReadByte();
        }

        public override void close() {
            stream.Close();
        }

        public override long skip(long n) {
            return stream.Seek(n, SeekOrigin.Current);
        }

        private IEnumerable<byte> GetBytes() {
            while (true) {
                var b = stream.ReadByte();
                if (b == -1)
                    break;
                yield return (byte)b;
            }
        }

        public override int readLine(byte[] buffer, int off, int len) {
            stream.Seek(off, SeekOrigin.Begin);
            var bytes = GetBytes().TakeWhile((c,i) => c != '\n' && i <= len).ToArray();
            bytes.CopyTo(buffer, 0);
            return bytes.Length;
        }
    }
}