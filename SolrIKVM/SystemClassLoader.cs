using ikvm.runtime;
using java.lang;

namespace SolrIKVM {
    // from http://blogs.dovetailsoftware.com/blogs/kmiller/archive/2010/07/02/using-the-tika-java-library-in-your-net-application-with-ikvm
    public class SystemClassLoader : ClassLoader {
        public SystemClassLoader(ClassLoader parent) : base(new AppDomainAssemblyClassLoader(typeof(SystemClassLoader).Assembly)) { }
    }
}
