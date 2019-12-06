using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP5101B_N01352022_ChristopherJones_FinalAssignment
{
    //modified from code created by Christine Bittle, for educational purposes only
    public partial class ShowPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PAGEDB db = new PAGEDB();
            ShowPageInfo(db);
        }

        protected void ShowPageInfo(PAGEDB db)
        {

            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            if (valid)
            {

                _Page_ page_record = db.FindPage(Int32.Parse(pageid));


                page_title.InnerHtml = page_record.GetPtitle();
                page_body.InnerHtml = page_record.GetPbody();
                string pageTheme = page_record.GetPagestyle();
                switch(pageTheme)
                {
                    case "1":
                        page_.Style.Add("background-color", "#333");
                        page_title.Style.Add("color", "#F00");
                        page_body.Style.Add("color", "#fefefe");
                        break;

                    case "2":
                        page_.Style.Add("background-color", "#fefefe");
                        page_title.Style.Add("color", "#00F");
                        page_body.Style.Add("color", "#333");
                        break;

                    case "3":
                        page_.Style.Add("background-color", "#000");
                        page_title.Style.Add("color", "#FF6EFF");
                        page_body.Style.Add("color", "#50BFE6");
                        break;
                }
            }
            else
            {
                valid = false;
            }


            if (!valid)
            {
                page_.InnerHtml = "There was an error finding that page.";
            }
        }
    }
}