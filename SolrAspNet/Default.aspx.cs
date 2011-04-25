using System;
using System.Web.UI;
using Microsoft.Practices.ServiceLocation;
using SolrNet;

namespace SolrAspNet
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                return;
            }

            string query = Request.QueryString["q"];

            if(string.IsNullOrEmpty(query))
            {
                return;
            }

            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<SearchResultItem>>();
            var results = solr.Query(new SolrQuery(query));

            lvResult.DataSource = results;
            lvResult.DataBind();
        }

        protected void Search(object sender, EventArgs e)
        {
            string url = string.Format("/Default.aspx?q={0}", txtSearch.Text);
            Response.Redirect(url);
        }
    }
}