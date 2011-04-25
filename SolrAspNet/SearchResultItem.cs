using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SolrNet.Attributes;

namespace SolrAspNet
{
    public class SearchResultItem
    {
        [SolrUniqueKey("id")]
        public string Id { get; set; }

        [SolrField("name")]
        public string Name { get; set; }
    }
}