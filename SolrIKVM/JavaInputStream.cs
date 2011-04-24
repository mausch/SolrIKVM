using System;
using System.IO;
using java.io;

namespace SolrIKVM
{
    internal class JavaInputStream : InputStream
    {
        public Stream Wrapped;
        
        public JavaInputStream(Stream s)
        {
            Wrapped = s;
        }

        public override int read()
        {
            return Wrapped.ReadByte();
        }

        public override void close()
        {
            Wrapped.Close();
        }

        public override void reset()
        {
            Wrapped.Seek(0, SeekOrigin.Begin);
        }

        public override long skip(long n)
        {
            return Wrapped.Seek(n, SeekOrigin.Current);
        }

        public override bool markSupported()
        {
            return false;
        }

        protected override void  finalize()
        {
            Wrapped.Dispose();
        }

        public override void mark(int readlimit)
        {
            throw new NotSupportedException();
        }

        public override int read(byte[] b)
        {
            return Wrapped.Read(b, 0, b.Length);
        }

        public override int read(byte[] b, int off, int len)
        {
            return Wrapped.Read(b, 0, b.Length);
        }

        protected override object clone()
        {
            throw new NotSupportedException();            
        }
    }
}
