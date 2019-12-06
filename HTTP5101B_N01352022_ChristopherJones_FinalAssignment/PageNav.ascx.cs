using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP5101B_N01352022_ChristopherJones_FinalAssignment
{
    //get the dataset of the existing pages, and create a nav element that will list the pages by their title, in their set
    //order, as links to the viewpage for each.
    public partial class PageNav : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PAGEDB db = new PAGEDB();
            ListPageLinks(db);
        }
        protected void ListPageLinks(PAGEDB db)
        {
            string query = "select * from pages order by pageorder";

            List<_Page_> rs = db.List_Query(query);
            foreach (_Page_ row in rs)
            {

                string pageid = row.GetPid();
                string pagetitle = row.GetPtitle();
                page_list.InnerHtml += "<li><a href='ShowPage.aspx?pageid=" + pageid + "'>" + pagetitle + "</a></li>";
            }
        }
    }
}