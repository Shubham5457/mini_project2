using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace online_product_auction_system
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_login_Click(object sender, EventArgs e)
        {
            if (Txt_nm.Text == "admin" && Txt_pass.Text == "12345")
            {
                MessageBox.Show("login successfully");
                Response.Redirect("~/Admin_dashboard.aspx");
            }
            else
            {
                MessageBox.Show("Enter correct password");
            }
        }
    }
}