using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTTP5101B_N01352022_ChristopherJones_FinalAssignment
{
    public class _Page_
    {
        /*
        The design for encapsulation of the fields as private, accessed and 
        get/set by public methods was directly inspired by the student.cs class created by 
        Christine Bittle in her HTTP5101_School_System
        */
        private string Pid;
        private string Ptitle;
        private string Pbody;
        private string Ordernumber;
        private string Pagestyle;

        //The following public methods allow access to the information contained in the private fields
        public string GetPid()
        {
            return Pid;
        }
        public string GetPtitle()
        {
            return Ptitle;
        }
        public string GetPbody()
        {
            return Pbody;
        }
        public string GetOrdernumber()
        {
            return Ordernumber;
        }
        public string GetPagestyle()
        {
            return Pagestyle;
        }


        //the following methods allow the data in the private fields to be changed by public methods
        public void SetPid(string value)
        {
            Pid = value;
        }
        public void SetPtitle(string value)
        {
            Ptitle = value;
        }
        public void SetPbody(string value)
        {
            Pbody = value;
        }
        public void SetOrderNumber(string value)
        {
            Ordernumber = value;
        }
        public void SetPagestyle(string value)
        {
            Pagestyle = value;
        }
    }
}