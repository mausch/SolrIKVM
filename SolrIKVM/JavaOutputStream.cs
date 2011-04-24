using System;
using System.IO;
using java.io;

namespace SolrIKVM
{
    internal class JavaOutputStream : OutputStream
    {
        public Stream Wrapped;
        
        public JavaOutputStream(Stream s)
        {
            Wrapped = s;
        }

        protected override object clone()
        {
            throw new NotSupportedException();
        }

        public override void close()
        {
            Wrapped.Close();
        }
        protected override void finalize()
        {
            Wrapped.Dispose();
        }
        public override void flush()
        {
            Wrapped.Flush();
        }
        public override void write(byte[] b)
        {
            Wrapped.Write(b, 0, b.Length);
            Wrapped.Flush();
        }
        public override void write(byte[] b, int off, int len)
        {
            Wrapped.Write(b, off, len);
            Wrapped.Flush();
        }
        public override void write(int i)
        {
            Wrapped.WriteByte((byte)i);
            Wrapped.Flush();
        }
    }
}
