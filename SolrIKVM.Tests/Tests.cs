using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;
using org.apache.solr.client.solrj;
using org.apache.solr.client.solrj.beans;
using org.apache.solr.client.solrj.embedded;
using org.apache.solr.client.solrj.impl;
using org.apache.solr.core;
using SolrNet;
using SolrNet.Attributes;
using SolrQuery = org.apache.solr.client.solrj.SolrQuery;

namespace SolrIKVM.Tests {
    [TestFixture]
    public class Tests {
        const string solrUrl = "http://localhost:8794/solr.axd";

        [TestFixtureSetUp]
        public void FixtureSetup() {
            Setup.SetHome(@"..\..\..\SolrAspNet");
        }

        [Test]
        public void Ping() {
            SolrServer solr = new CommonsHttpSolrServer(solrUrl);
            var response = solr.ping();
            Console.WriteLine(response.getQTime());
        }

        [Test]
        public void Add() {
            SolrServer solr = new CommonsHttpSolrServer(solrUrl);
            solr.addBean(new Document {
                Id = "3",
                SKU = "abcde",
            });
            solr.commit();
        }

        [Test]
        public void AddWithSolrNet()
        {
            Startup.Init<Product>("http://localhost:8794/solr.axd");

            var p = new Product
            {
                Id = "100",
                Manufacturer = "Some hard drive",
                Categories = new[]
                                                 {
                                                     "electronics",
                                                     "hard drive",
                                                 },
                Price = 92,
                InStock = true,
            };


            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<Product>>();
            solr.Add(p);
            solr.Commit();

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

        public class Product
        {
            [SolrUniqueKey("id")]
            public string Id { get; set; }

            [SolrField("manu_exact")]
            public string Manufacturer { get; set; }

            [SolrField("cat")]
            public ICollection<string> Categories { get; set; }

            [SolrField("price")]
            public decimal Price { get; set; }

            [SolrField("inStock")]
            public bool InStock { get; set; }

        }
        public class Document {
            [Field("Id")] 
            public string Id;

            [Field("sku")]
            public string SKU;
        }

        public static int Main(string[] args) {
            var t = new Tests();
            //t.Embedded();
            //t.Ping();
            t.Add();
            return 0;
        }
    }
}