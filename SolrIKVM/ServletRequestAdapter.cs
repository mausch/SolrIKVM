using System;
using System.Web;
using java.io;
using java.lang;
using java.security;
using java.util;
using javax.servlet;
using javax.servlet.http;

namespace SolrIKVM {
    public class ServletRequestAdapter : HttpServletRequest {
        private readonly HttpContextBase context;

        public ServletRequestAdapter(HttpContextBase context) {
            this.context = context;
        }

        public object getAttribute(string str) {
            return context.Items[str];
        }

        public Enumeration getAttributeNames() {
            throw new NotImplementedException();
        }

        public string getCharacterEncoding() {
            return context.Request.ContentEncoding.WebName;
        }

        public void setCharacterEncoding(string str) {
            //throw new NotImplementedException();
        }

        public int getContentLength() {
            return context.Request.ContentLength;
        }

        public string getContentType() {
            return context.Request.ContentType;
        }

        public ServletInputStream getInputStream() {
            return new ServletInputStreamAdapter(context.Request.InputStream);
        }

        public string getParameter(string str) {
            return context.Request.Params[str];
        }

        public Enumeration getParameterNames() {
            return new EnumerationAdapter(context.Request.Params.GetEnumerator());
        }

        public string[] getParameterValues(string str) {
            return context.Request.Params.GetValues(str);
        }

        public Map getParameterMap() {
            return new MapNameValueCollectionAdapter(context.Request.QueryString);
        }

        public string getProtocol() {
            return "HTTP/1.1";
        }

        public string getScheme() {
            return context.Request.Url.Scheme;
        }

        public string getServerName() {
            return "";
        }

        public int getServerPort() {
            return context.Request.Url.Port;
        }

        public BufferedReader getReader() {
            throw new NotImplementedException();
        }

        public string getRemoteAddr() {
            return context.Request.UserHostAddress;
        }

        public string getRemoteHost() {
            return context.Request.UserHostName;
        }

        public void setAttribute(string str, object obj) {
            context.Items[str] = obj;
        }

        public void removeAttribute(string str) {
            context.Items.Remove(str);
        }

        public Locale getLocale() {
            throw new NotImplementedException();
        }

        public Enumeration getLocales() {
            throw new NotImplementedException();
        }

        public bool isSecure() {
            return context.Request.IsSecureConnection;
        }

        public RequestDispatcher getRequestDispatcher(string str) {
            return new RequestDispatcherAdapter();
        }

        public string getRealPath(string str) {
            throw new NotImplementedException();
        }

        public int getRemotePort() {
            return 80; //?
        }

        public string getLocalName() {
            throw new NotImplementedException();
        }

        public string getLocalAddr() {
            throw new NotImplementedException();
        }

        public int getLocalPort() {
            throw new NotImplementedException();
        }

        public string getAuthType() {
            throw new NotImplementedException();
        }

        public Cookie[] getCookies() {
            throw new NotImplementedException();
        }

        public long getDateHeader(string str) {
            var h = context.Request.Headers[str];
            if (h == null)
                return -1;
            try {
                return DateTime.Parse(h).Ticks;                
            } catch (System.Exception e) {
                throw new java.lang.IllegalArgumentException("Can't get date header " + str, e);
            }
        }

        public string getHeader(string str) {
            throw new NotImplementedException();
        }

        public Enumeration getHeaders(string str) {
            var headers = context.Request.Headers.GetValues(str) ?? new string[0];
            return new EnumerationAdapter(headers.GetEnumerator());
        }

        public Enumeration getHeaderNames() {
            throw new NotImplementedException();
        }

        public int getIntHeader(string str) {
            throw new NotImplementedException();
        }

        public string getMethod() {
            return context.Request.HttpMethod;
        }

        public string getPathInfo() {
            return null;
        }

        public string getPathTranslated() {
            return null;
        }

        public string getContextPath() {
            return "";
        }

        public string getQueryString() {
            var q = context.Request.RawUrl.Split('?');
            return q.Length == 1 ? null : q[1];
        }

        public string getRemoteUser() {
            throw new NotImplementedException();
        }

        public bool isUserInRole(string str) {
            throw new NotImplementedException();
        }

        public Principal getUserPrincipal() {
            throw new NotImplementedException();
        }

        public string getRequestedSessionId() {
            throw new NotImplementedException();
        }

        public string getRequestURI() {
            throw new NotImplementedException();
        }

        public StringBuffer getRequestURL() {
            throw new NotImplementedException();
        }

        public string getServletPath() {
            return context.Request.Url.AbsolutePath;
        }

        public HttpSession getSession(bool b) {
            throw new NotImplementedException();
        }

        public HttpSession getSession() {
            throw new NotImplementedException();
        }

        public bool isRequestedSessionIdValid() {
            throw new NotImplementedException();
        }

        public bool isRequestedSessionIdFromCookie() {
            throw new NotImplementedException();
        }

        public bool isRequestedSessionIdFromURL() {
            throw new NotImplementedException();
        }

        public bool isRequestedSessionIdFromUrl() {
            throw new NotImplementedException();
        }
    }
}