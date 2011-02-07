using System.IO;
using System.Text;
using java.io;

namespace SolrIKVM {
    public class OutputStreamAdapter : OutputStream {
        private readonly Stream s;

        public OutputStreamAdapter(Stream s) {
            this.s = s;
        }

        public override void write(int i) {
            var buffer = Encoding.UTF8.GetBytes(char.ConvertFromUtf32(i));
            s.Write(buffer, 0, buffer.Length);
        }

        public override void close() {
            s.Close();
        }

        public override void flush() {
            s.Flush();
        }

        public override int hashCode() {
            return s.GetHashCode();
        }

        public override void write(byte[] b) {
            s.Write(b, 0, b.Length);
        }

        public override void write(byte[] b, int off, int len) {
            s.Write(b, off, len);
        }
    }
}