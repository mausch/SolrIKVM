using System;
using System.Collections.Generic;
using java.util;
using javax.servlet;

namespace SolrIKVM {
    public class SolrFilterConfig : FilterConfig {
        private readonly IDictionary<string, string> parameters;

        public SolrFilterConfig(IDictionary<string, string> parameters) {
            this.parameters = parameters;
        }

        public string getFilterName() {
            throw new NotImplementedException();
        }

        public ServletContext getServletContext() {
            throw new NotImplementedException();
        }

        public string getInitParameter(string str) {
            return parameters[str];
        }

        public Enumeration getInitParameterNames() {
            throw new NotImplementedException();
        }
    }
}