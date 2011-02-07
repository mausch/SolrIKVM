using System;
using NUnit.Framework;
using org.apache.solr.client.solrj;
using org.apache.solr.client.solrj.beans;
using org.apache.solr.client.solrj.embedded;
using org.apache.solr.client.solrj.impl;
using org.apache.solr.core;

namespace SolrIKVM.Tests {
    [TestFixture]
    public class Tests {
        [TestFixtureSetUp]
        public void FixtureSetup() {
            Setup.SetHome(@"..\..\..\SolrIKVM");
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
            solr.addBean(new Document {
                Id = "3",
                SKU = "abcd",
            });
            var updateResponse = solr.commit();
            Console.WriteLine("qtime: {0}", updateResponse.getQTime());
            solr.query(new SolrQuery("*:*")); // warm up
            var response = solr.query(new SolrQuery("*:*"));
            Console.WriteLine("qtime: {0}", response.getQTime());
            Console.WriteLine("results: {0}", response.getResults().size());
        }

        public class Document {
            [Field("id")] 
            public string Id;

            [Field("sku")]
            public string SKU;
        }

        public static int Main(string[] args) {
            var t = new Tests();
            t.Embedded();
            return 0;
        }
    }
}