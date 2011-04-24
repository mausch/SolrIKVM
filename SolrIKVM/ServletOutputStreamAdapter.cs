using System;
using System.Text;
using java.io;
using javax.servlet;

namespace SolrIKVM {
    public class ServletOutputStreamAdapter : ServletOutputStream {
        
        readonly Encoding _encoding;
        readonly OutputStream _out;
        
        public ServletOutputStreamAdapter(OutputStream @out, Encoding encoding) {
            _out = @out;
            _encoding = encoding;
        }

        public override void write(int ch) {
            _out.write(ch);
        }

        public void write(byte[] b) {
            _out.write(b);
        }

        public void write(byte[] b, int o, int l) {
            _out.write(b, o, l);
        }

        public void flush() {
            _out.flush();
        }

        public void close() {
            base.close();
            _out.close();
        }

        public void disable() {
        }

        public void print(String s) {
            if (s != null) write(_encoding.GetBytes(s));
        }

        public void println(String s) {
            if (s != null) write(_encoding.GetBytes(s));
            write('\r');
            write('\n');
        }

    }
}