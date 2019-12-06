using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP5101B_N01352022_ChristopherJones_FinalAssignment
{
    public partial class NewPage : System.Web.UI.Page
    {
        //Using modifications of code created by Christine Bittle, used for educational purposes only.
        protected void Page_Load(object sender, EventArgs e)
        {
            PAGEDB db = new PAGEDB();
            FillOrderOptions(db);
        }
        protected void FillOrderOptions(PAGEDB db)
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
            for (int i = 0; i <= order_count; i++)
            {
                string ordernumber = (i + 1).ToString();
                //create title for where the page will be inserted, handling for the beginning and end posistions as well
                string insertTitle = "After Page " + ordernumber;

                if (i == 0)
                {
                    insertTitle = "First Page";
                }
                else if(i == order_count)
                {
                    insertTitle = "Last Page";
                }
                
                ListItem orderoption = new ListItem(insertTitle, ordernumber);
                Porder.Items.Add(orderoption);

                if(!Page.IsPostBack)
                {
                    Porder.SelectedValue = (order_count + 1).ToString();
                }
                
            }
        }
        protected void Add_Page(object sender, EventArgs e)
        {
            PAGEDB db = new PAGEDB();

            _Page_ new_page = new _Page_();

            //set the values to the _page_ object
            new_page.SetPtitle(Ptitle.Text);
            new_page.SetPbody(Pbody.Text);
            new_page.SetOrderNumber(Porder.Text);
            new_page.SetPagestyle(Pstyle.Text);
            //get the full dataset of the cms database, get the length of the list to compare if
            //the new page is being inserted between existing pages in order
            string query = "select * from pages";
            List<_Page_> rs = db.List_Query(query);

            int new_order_count = rs.Count;
            int new_page_order = Int32.Parse(new_page.GetOrdernumber());
            //if the page is not getting inserted at the end of the order, run the UpdatePageOrder to adjust the page order accordingly
            if (new_page_order != (new_order_count + 1))
            {
                db.UpdatePageOrder(new_order_count, new_page_order);
            }

            db.AddPage(new_page);


            Response.Redirect("ListPages.aspx");
        }

    }
}