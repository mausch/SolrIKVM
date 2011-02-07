using System;
using NUnit.Framework;
using org.apache.solr.client.solrj;
using org.apache.solr.client.solrj.beans;
using org.apache.solr.client.solrj.embedded;
using org.apache.solr.client.solrj.impl;
using org.apache.solr.core;
using org.apache.solr.servlet;
using org.mortbay.jetty;
using org.mortbay.jetty.servlet;

namespace SolrIKVM.Tests {
    [TestFixture]
    public class Tests {
        [TestFixtureSetUp]
        public void FixtureSetup() {
            java.lang.System.setProperty("solr.solr.home", @"..\..\SolrIKVM");
            java.lang.System.setProperty("solr.data.dir", @"..\..\SolrIKVM\data");
        }

        [Test]
        public void Ping() {
            SolrServer solr = new CommonsHttpSolrServer("http://localhost:8983/solr");
            var response = solr.ping();
            Console.WriteLine(response.getQTime());
        }

        [Test]
        public void Embedded() {
            var initializer = new CoreContainer.Initializer();
            var coreContainer = initializer.initialize();
            var solr = new EmbeddedSolrServer(coreContainer, "");
            solr.addBean(new Document {Id = "3"});
            var updateResponse = solr.commit();
            Console.WriteLine("qtime: {0}", updateResponse.getQTime());
            var response = solr.query(new SolrQuery("*:*"));
            response = solr.query(new SolrQuery("*:*"));
            Console.WriteLine("qtime: {0}", response.getQTime());
            Console.WriteLine("results: {0}", response.getResults().size());
        }

        [Test]
        public void Jetty() {
            var server = new Server(8983);
            var servletContext = new Context(server, "/solr");
            var servlet = new SolrServlet();
            servletContext.addServlet(new ServletHolder(servlet), "/*");
            server.start();
        }

        public class Document {
            [Field("id")] public string Id;
        }

        public static int Main(string[] args) {
            var t = new Tests();
            //t.Jetty();
            t.Embedded();
            return 0;
        }
    }
}