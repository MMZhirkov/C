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
        String password = "1234";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text==user)
            {
                if (TextBox2.Text==password)
                {
                    Response.Redirect("/home.aspx");
                }
                else
                {
                    Label3.Text = "Password incorrect";
                }
                Response.Redirect("/home.aspx");
            }
            else
            {
                Label3.Text = "Login incorrect";
            }
        }
    }
}