﻿using System;
using System.IO;
using ikvm.runtime;
using java.lang;
using java.util;
using NUnit.Framework;
using org.apache.solr.client.solrj;
using org.apache.solr.client.solrj.beans;
using org.apache.solr.client.solrj.embedded;
using org.apache.solr.client.solrj.impl;
using org.apache.solr.common.@params;
using org.apache.solr.core;
using org.apache.solr.schema;
using org.apache.solr.servlet;
using org.mortbay.jetty;
using org.mortbay.jetty.servlet;
using org.slf4j;

namespace SolrIKVM {
    [TestFixture]
    public class Tests {
        [Test]
        public void Ping() {
            SolrServer solr = new CommonsHttpSolrServer("http://localhost:8983/solr");
            var response = solr.ping();
            Console.WriteLine(response.getQTime());
        }
        
        [Test]
        public void Embedded() {
            java.lang.System.setProperty("solr.solr.home", @"..\..");
            java.lang.System.setProperty("solr.data.dir", @"..\..\data");
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
            java.lang.System.setProperty("solr.solr.home", @"..\..");
            java.lang.System.setProperty("solr.data.dir", @"..\..\data");
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