using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace HTTP5101B_N01352022_ChristopherJones_FinalAssignment
{
    public class PAGEDB
    {
        //the following database connection code was created by Christine Bittle and is being used for educational purposes only
        //the code is being used to connect to a MAMP hosted database
        
        //The following code sets private strings for the database connection information
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "cms"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        //The following ConnectionString code was created by Christine Bittle and is being used to connect
        private static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }

        //the following code is adapted from code created by Christine Bittle's SCHOOLDB class,
        //modified to return Page objects instead of Dictionary<String, String>
        //from a given query to the cms database, and return the resutls
        public List<_Page_> List_Query(string query)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);

     
            List<_Page_> ResultSet = new List<_Page_>();

            //try/catch is being used to handle any potential errors or crashes when parsing the database query result
            try
            {
                Debug.WriteLine("Connection Initialized...");
                Debug.WriteLine("Attempting to execute query " + query);
                //connect to the db, send the query, and grab the results set
                Connect.Open();
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                MySqlDataReader resultset = cmd.ExecuteReader();


                //read through every row, column by column
                while (resultset.Read())
                {
                    //create _page_ object for each row of data
                    _Page_ Row = new _Page_();
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        //set key value pairs to match column fields with the data returned
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);
                        //setup switch cases for the 4 columns of the database, and use the object operations to assign the values
                        switch (key)
                        {
                            case "pageid":
                                Row.SetPid(value);
                                break;
                            case "pagetitle":
                                Row.SetPtitle(value);
                                break;
                            case "pagebody":
                                Row.SetPbody(value);
                                break;
                            case "pageorder":
                                Row.SetOrderNumber(value);
                                break;
                            case "pagestyle":
                                Row.SetPagestyle(value);
                                break;

                        }
                    }

                    ResultSet.Add(Row);
                }//end row
                resultset.Close();


            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the List_Query method!");
                Debug.WriteLine(ex.ToString());

            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return ResultSet;
        }
        public _Page_ FindPage(int id)
        {
            //Code modified from code developed by Christine Bittle for CRUD essentials
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            //since the method returns a _page_ object, create a blank object to return in case of connection failure
            _Page_ page_ = new _Page_();

            //Use try/catch to handle any errors when retreiving the data
            try
            {
                //use where clause and primary key to pull 1 specific record with the query
                string query = "select * from pages where pageid = " + id;
                Debug.WriteLine("Connection Initialized...");
                Connect.Open();
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                MySqlDataReader resultset = cmd.ExecuteReader();

                //Create a list of _page_ objects despite only looking for 1 in case of database/connection error returning more than 1 entry
                List<_Page_> Pages = new List<_Page_>();

                while (resultset.Read())
                {
                    _Page_ Page_ = new _Page_();

                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);

                        switch (key)
                        {
                            case "pageid":
                                Page_.SetPid(value);
                                break;
                            case "pagetitle":
                                Page_.SetPtitle(value);
                                break;
                            case "pagebody":
                                Page_.SetPbody(value);
                                break;
                            case "pageorder":
                                Page_.SetOrderNumber(value);
                                break;
                            case "pagestyle":
                                Page_.SetPagestyle(value);
                                break;
                        }

                    }
                    Pages.Add(Page_);
                }

                page_ = Pages[0];

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the FindPage method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return page_;
        }
        //update page very similar to read functions, except the query uses update syntax, it is sent using .ExecuteNonQuery
        //and a dataset is not returned
        public void UpdatePage(int pageid, _Page_ new_page)
        {
            //use format to inject variables into string
            string query = "update pages set pagetitle='{0}', pagebody='{1}', pageorder='{2}', pagestyle='{3}' where pageid={4}";
            query = String.Format(query, new_page.GetPtitle(), new_page.GetPbody(), new_page.GetOrdernumber(), new_page.GetPagestyle(), pageid);

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + query);
            }
            //error handling catch, will output debug console lines
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the UpdatePage Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }
        //same as UpdatePage but with a insert query
        public void AddPage(_Page_ new_page)
        {
            string query = "insert into pages (pagetitle, pagebody, pageorder, pagestyle) values ('{0}','{1}','{2}','{3}')";
            query = String.Format(query, new_page.GetPtitle(), new_page.GetPbody(), new_page.GetOrdernumber(), new_page.GetPagestyle());

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the AddPage Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }
        //same as add and update, but with a delete query
        public void DeletePage(int pageid)
        {
            string query = "delete from pages where pageid = {0}";
            query = String.Format(query, pageid);
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { 
                Debug.WriteLine("Something went wrong in the DeletePage method!");
                Debug.WriteLine(ex.ToString());
            }
            Connect.Close();
        }

        //update the order of the pages, by increasing the order number of a set range by 1, allowing for new pages to be created
        //and inserted anywhere in the order of the pages, as well as handling when an existing page is changed from a higher order number
        //to a lower one, e.g. 5 -> 1
        public void UpdatePageOrder(int new_page_count, int new_page_order)
        {
            //for a given range of page order values, increment them all by one,
            //allowing for inserting pages before other pages, handled with a for loop
            for (int i = new_page_count; i >= new_page_order; i--)
            {
                string query = "update pages set pageorder='{0}' where pageorder={1}";
                query = String.Format(query, (i + 1).ToString(), (i).ToString());

                MySqlConnection Connect = new MySqlConnection(ConnectionString);
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                try
                {
                    Connect.Open();
                    cmd.ExecuteNonQuery();
                    Debug.WriteLine("Executed query " + query);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Something went wrong in the UpdatePageOrder Method!");
                    Debug.WriteLine(ex.ToString());
                }

                Connect.Close();
            }
        }
        //same as above, but will decrement all page order values in a given range by 1, for when pages are deleted,
        //or pages are moved from a lower order number to a higher number eg 1 -> 5 
        public void UpdateDeletePageOrder(int new_page_count, int new_page_order)
        {
            for (int i = (new_page_order + 1); i <= new_page_count; i++)
            {
                string query = "update pages set pageorder='{0}' where pageorder={1}";
                query = String.Format(query, (i - 1).ToString(), (i).ToString());

                MySqlConnection Connect = new MySqlConnection(ConnectionString);
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                try
                {
                    Connect.Open();
                    cmd.ExecuteNonQuery();
                    Debug.WriteLine("Executed query " + query);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Something went wrong in the UpdateDeletePageOrder Method!");
                    Debug.WriteLine(ex.ToString());
                }

                Connect.Close();
            }
        }
    }
}