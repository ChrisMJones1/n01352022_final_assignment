using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP5101B_N01352022_ChristopherJones_FinalAssignment
{
    public partial class ListPages : System.Web.UI.Page
    {
        //Using modifications of code created by Christine Bittle, used for educational purposes only.
        protected void Page_Load(object sender, EventArgs e)
        {
            PAGEDB db = new PAGEDB();
            ListPagesInfo(db);
        }
        protected void ListPagesInfo(PAGEDB db)
        {
            pages_result.InnerHtml = "";



            string query = "select * from pages order by pageorder";

            List<_Page_> rs = db.List_Query(query);
            foreach (_Page_ row in rs)
            {
                pages_result.InnerHtml += "<div class=\"listitem\">";

                string pageid = row.GetPid();
                
                string pagetitle = row.GetPtitle();
                pages_result.InnerHtml += "<div class=\"col3\"><a href='ShowPage.aspx?pageid=" + pageid + "'>"+ pagetitle +"</a></div>";

                string pageorder = row.GetOrdernumber();
                pages_result.InnerHtml += "<div class=\"col3\">" + pageorder + "</div>";

                string modify = "<div class='col3last'><a href='EditPage.aspx?pageid=" + pageid + "'>Edit</a> <a href='DeletePage.aspx?pageid=" + pageid + "'>Delete</a></div>";
                pages_result.InnerHtml += modify;

                pages_result.InnerHtml += "</div>";
            }

        }

    }
            
    
}