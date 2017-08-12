using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPForm
{
    public partial class auth : System.Web.UI.Page
    {
        String user = "User1";
        String password = "Password";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

         protected void LoginButton_Click(object sender, AuthenticateEventArgs e)
        {
            if (Login1.UserName==user)
            {
                if (Login1.Password==password)
                {
                    Response.Redirect("/Home.aspx");
                }
                else
                {

                }
            }
        }
    }
}