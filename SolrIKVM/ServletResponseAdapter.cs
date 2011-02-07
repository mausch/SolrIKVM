using System;
using System.Web;
using java.io;
using java.util;
using javax.servlet;
using javax.servlet.http;

namespace SolrIKVM {
    public class ServletResponseAdapter : HttpServletResponse {
        private readonly HttpContextBase context;
        private readonly PrintWriter pw;

        public ServletResponseAdapter(HttpContextBase context) {
            this.context = context;
            pw = new CustomPrintWriter(new OutputStreamAdapter(context.Response.OutputStream));
        }

        public string getCharacterEncoding() {
            return context.Response.Charset;
        }

        public string getContentType() {
            return context.Response.ContentType;
        }

        public ServletOutputStream getOutputStream() {
            return new ServletOutputStreamAdapter(context.Response.OutputStream);
        }

        public PrintWriter getWriter() {
            return pw;
        }

        public void setCharacterEncoding(string str) {
            context.Response.Charset = str;
        }

        public void setContentLength(int i) {
            //throw new NotImplementedException();
        }

        public void setContentType(string str) {
            context.Response.ContentType = str;
        }

        public void setBufferSize(int i) {
            //throw new NotImplementedException();
        }

        public int getBufferSize() {
            return 1000; //?
        }

        public void flushBuffer() {
            context.Response.Flush();
        }

        public void resetBuffer() {
            context.Response.Clear();
        }

        public bool isCommitted() {
            return true; //?
        }

        public void reset() {
            context.Response.Clear();
        }

        public void setLocale(Locale l) {
            //throw new NotImplementedException();
        }

        public Locale getLocale() {
            return Locale.US; // ?
        }

        public void addCookie(Cookie c) {
            throw new NotImplementedException();
        }

        public bool containsHeader(string str) {
            throw new NotImplementedException();
        }

        public string encodeURL(string str) {
            throw new NotImplementedException();
        }

        public string encodeRedirectURL(string str) {
            throw new NotImplementedException();
        }

        public string encodeUrl(string str) {
            throw new NotImplementedException();
        }

        public string encodeRedirectUrl(string str) {
            throw new NotImplementedException();
        }

        public void sendError(int i, string str) {
            context.Response.Write("<pre>");
            context.Response.Write(str);
            context.Response.Write("</pre>");
            context.Response.StatusCode = i;
        }

        public void sendError(int i) {
            context.Response.StatusCode = i;
        }

        public void sendRedirect(string str) {
            throw new NotImplementedException();
        }

        public void setDateHeader(string str, long l) {
            var dt = new DateTime(l);
            context.Response.AddHeader(str, dt.ToString("R"));
        }

        public void addDateHeader(string str, long l) {
            throw new NotImplementedException();
        }

        public void setHeader(string str1, string str2) {
            context.Response.AddHeader(str1, str2);
        }

        public void addHeader(string str1, string str2) {
            throw new NotImplementedException();
        }

        public void setIntHeader(string str, int i) {
            throw new NotImplementedException();
        }

        public void addIntHeader(string str, int i) {
            throw new NotImplementedException();
        }

        public void setStatus(int i) {
            context.Response.StatusCode = i;
        }

        public void setStatus(int i, string str) {
            context.Response.Status = string.Format("{0} {1}", i, str);
        }
    }
}