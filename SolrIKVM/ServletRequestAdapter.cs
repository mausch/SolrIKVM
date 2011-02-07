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
            throw new NotImplementedException();
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
            return 80; // ?
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
            throw new NotImplementedException();
        }

        public void removeAttribute(string str) {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public string getHeader(string str) {
            throw new NotImplementedException();
        }

        public Enumeration getHeaders(string str) {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public string getPathTranslated() {
            throw new NotImplementedException();
        }

        public string getContextPath() {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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