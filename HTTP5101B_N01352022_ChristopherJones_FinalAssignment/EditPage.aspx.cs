using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP5101B_N01352022_ChristopherJones_FinalAssignment
{
    public partial class EditPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PAGEDB db = new PAGEDB();
                ShowPageInfo(db);
            }

        }
        protected void ShowPageInfo(PAGEDB db)
        {

            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            if (valid)
            {

                _Page_ page_record = db.FindPage(Int32.Parse(pageid));


                Ptitle.Text = page_record.GetPtitle();
                Pbody.Text = page_record.GetPbody();
                int page_order = Int32.Parse(page_record.GetOrdernumber());
                FillOrderOptions(db,page_order);
            }
            else
            {
                valid = false;
            }


            if (!valid)
            {
                E_Page.InnerHtml = "There was an error finding that page.";
            }
        }
        protected void FillOrderOptions(PAGEDB db, int page_order)
        {
            ListItem styleoption1 = new ListItem("Dark Theme", "1");
            ListItem styleoption2 = new ListItem("Light Theme", "2");
            ListItem styleoption3 = new ListItem("Neon Theme", "3");
            Pstyle.Items.Add(styleoption1);
            Pstyle.Items.Add(styleoption2);
            Pstyle.Items.Add(styleoption3);
            if (!Page.IsPostBack)
            {
                Pstyle.SelectedValue = "1";
            }

            string query = "select * from pages";
            List<_Page_> rs = db.List_Query(query);
            int order_count = rs.Count;
            for (int i = 0; i < order_count; i++)
            {
                string ordernumber = (i + 1).ToString();
                string insertTitle = "After Page " + (i).ToString();

                if (i == 0)
                {
                    insertTitle = "First Page";
                }
                else if (i == (order_count - 1))
                {
                    insertTitle = "Last Page";
                }
                ListItem orderoption = new ListItem(insertTitle, ordernumber);
                Porder.Items.Add(orderoption);
                if (!Page.IsPostBack)
                {
                    Porder.SelectedValue = (page_order).ToString();
                }

            }
        }
        protected void Update_Page(object sender, EventArgs e)
        {

            PAGEDB db = new PAGEDB();

            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;
            if (valid)
            {
                _Page_ new_page = new _Page_();

                new_page.SetPtitle(Ptitle.Text);
                new_page.SetPbody(Pbody.Text);
                new_page.SetOrderNumber(Porder.Text);
                new_page.SetPagestyle(Pstyle.Text);
                _Page_ old_page_record = db.FindPage(Int32.Parse(pageid));

                int old_page_order = Int32.Parse(old_page_record.GetOrdernumber());

                int new_page_order = Int32.Parse(new_page.GetOrdernumber());

                //if the page order is being moved lower, shift the other affected pages up
                if (new_page_order < old_page_order)
                {
                    db.UpdatePageOrder(old_page_order, new_page_order);
                }
                //else if the page order is being moved higher, shift the other pages affected down
                else if (new_page_order > old_page_order)
                {
                    db.UpdateDeletePageOrder(new_page_order, old_page_order);
                }

                try
                {
                    db.UpdatePage(Int32.Parse(pageid), new_page);
                    Response.Redirect("ShowPage.aspx?pageid=" + pageid);
                }
                catch
                {
                    valid = false;
                }

            }

            if (!valid)
            {
                E_Page.InnerHtml = "There was an error updating that student.";
            }

        }
    }
}