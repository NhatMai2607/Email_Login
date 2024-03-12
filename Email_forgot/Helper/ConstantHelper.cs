using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Email_forgot.Helper
{
    public class ConstantHelper
    {
        private string hostEmail = "smtp.gmail.com";
        public int portEmail = 587;
        public string emailSender = " ";
        public string passwordSender = " ";

        public string HostEmail { get => hostEmail; set => hostEmail = value; }
    }
}