using System;
using java.io;

namespace SolrIKVM {
    public class CustomPrintWriter : PrintWriter {
        public CustomPrintWriter(OutputStream @out) : base(@out, true) {}

        public override void write(string s, int off, int len) {
            @out.write(s, off, len);
            @out.flush();
        }

        public override void write(char[] buf, int off, int len) {
            @out.write(buf, off, len);
            @out.flush();
        }

        public override void write(int c) {            
            @out.write(c);
            @out.flush();
        }
    }
}