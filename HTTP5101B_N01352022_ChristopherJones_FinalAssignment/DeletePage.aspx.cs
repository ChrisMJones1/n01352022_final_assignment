using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP5101B_N01352022_ChristopherJones_FinalAssignment
{
    public partial class DeletePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PAGEDB db = new PAGEDB();
            if (!Page.IsPostBack)
            {
                ShowPageInfo(db);
            }

        }
        protected void ShowPageInfo(PAGEDB db)
        {

            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            //We will attempt to get the record we need
            if (valid)
            {

                _Page_ page_record = db.FindPage(Int32.Parse(pageid));


                pagetitle.InnerHtml = page_record.GetPtitle();
                pagebody.InnerHtml = page_record.GetPbody();
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

        protected void Delete_Page(object sender, EventArgs e)
        {
            //todo: validation on these ids
            string pageid = Request.QueryString["pageid"];

            PAGEDB db = new PAGEDB();
            _Page_ page_record = db.FindPage(Int32.Parse(pageid));

            string query = "select * from pages";
            List<_Page_> rs = db.List_Query(query);
            int new_order_count = rs.Count;
            int new_page_order = Int32.Parse(page_record.GetOrdernumber());
            if (new_page_order != (new_order_count))
            {
                db.UpdateDeletePageOrder(new_order_count, new_page_order);
            }

            db.DeletePage(Int32.Parse(pageid));
            Response.Redirect("ListPages.aspx");

        }
    }
}