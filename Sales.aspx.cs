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
    public partial class Sales : System.Web.UI.Page
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
            txt_sale_id.Text = Convert.ToString(GetNewId());
            txt_sale_date.Text = System.DateTime.Now.ToString();
            txt_biding_amount.Text =Convert.ToString(Session["bamt"]);
            TextBox1.Text =Convert.ToString(Session["Bcnm"]);
            TextBox2.Text =Convert.ToString(Session["bid"]);

            txt_sale_id.CssClass = "form-control";
            txt_sale_date.CssClass = "form-control";
            txt_biding_amount.CssClass = "form-control";
            TextBox1.CssClass = "form-control";
            TextBox2.CssClass = "form-control";
           
        }
       
        //   public void SetDropDown()
        //{
        //    cmd = new SqlCommand();
        //    cmd.Connection = cn;
        //    cmd.CommandText = " select *from Customer";
        //    dr = cmd.ExecuteReader();
        //    DropDownList_customer_id.DataSource = dr;
        //    DropDownList_customer_id.DataTextField = "cust_nm";
        //    DropDownList_customer_id.DataValueField = "cust_id";
        //    DropDownList_customer_id.DataBind();
        //    dr.Close();

             
        //}
        //public void SetDropDown1()
        //{
        //    cmd = new SqlCommand();
        //    cmd.Connection = cn;
        //    cmd.CommandText = " select *from Customer_Bidding";
        //    dr = cmd.ExecuteReader();
        //    DropDownList_biding_id.DataSource = dr;
        //    DropDownList_biding_id.DataTextField = "bid_id";
        //    DropDownList_biding_id.DataValueField = "bid_id";
        //    DropDownList_biding_id.DataBind();
        //    dr.Close();
        //}
        public int GetNewId()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select max (sale_id) from Sales";

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
                cmd.CommandText = "insert into Sales values (" + txt_sale_id.Text + ",'" + txt_sale_date.Text + "',"  +Session["bcid"]+ "," + TextBox2.Text + "," + txt_biding_amount.Text + ")";
                Session["Saleid"] = txt_sale_id.Text;    
            int x = cmd.ExecuteNonQuery();
            if (x > 0)
            {
                MessageBox.Show(" Record is saved ");
                Response.Redirect("~/Final_bill.aspx");
            }
            else
                MessageBox.Show(" Record is not saved ");
               
            
                
           
        }

       


        
    }
}