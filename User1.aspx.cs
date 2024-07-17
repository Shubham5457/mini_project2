using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace online_product_auction_system
{
     
    public partial class User1 : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        static int flag = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = " Data Source=DESKTOP-T3V9JTK\\SQLEXPRESS;Initial Catalog=online_product_auction_system;Integrated Security=True ";
            cn.Open();
           // setgrid();
             txt_user_id.Text = Convert.ToString(GetNewId());
            txt_email.CssClass = "form-control";
            txt_pass.CssClass = "form-control";
            txt_phone.CssClass = "form-control";
            txt_user_addr.CssClass = "form-control";
            txt_user_id.CssClass = "form-control";
            txt_user_nm.CssClass = "form-control";
          
            btn_save.CssClass = "btn-primary";
           
        }
       

        public int GetNewId()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select max (user_id) from user1"; 

            object x = cmd.ExecuteScalar();
            if (Convert.ToString(x) == "")
                return 1;
            else
                return (Convert.ToInt32(x) + 1);

        }

      

        protected void btn_save_Click(object sender, EventArgs e)
        {
           
                cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into user1 values (" + txt_user_id.Text + ",'" +txt_user_nm.Text + "','" + txt_user_addr.Text +"','" + txt_phone.Text + "',' " +txt_email.Text + "','" + txt_pass.Text +"')";
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    MessageBox.Show(" Record is saved ");
                    Response.Redirect("~/User/UserLogin.aspx");
                }
                else
                    MessageBox.Show(" Record is not saved ");
                 
        }

      

     
      

        

    }
}