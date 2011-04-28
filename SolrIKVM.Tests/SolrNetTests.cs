using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolrNet.Attributes;
using SolrNet;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;

namespace SolrIKVM.Tests
{
    [TestFixture]
    public class SolrNetTests
    {
        [Test]
        public void Add()
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

    }
}
