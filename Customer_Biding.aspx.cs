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
    public partial class Customer_Biding : System.Web.UI.Page
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
            setgrid();
            if (!IsPostBack)
            {
                SetDropDown1();
                SetDropDown2();
            }
            btn_delete.CssClass = "btn-primary";
            btn_new.CssClass = "btn-primary";
            btn_save.CssClass = "btn-primary";
            btn_update.CssClass = "btn-primary";
            txt_bid_id.CssClass = "form-control";
            txt_bid_date.CssClass = "form-control";
            txt_bid_amount.CssClass = "form-control";
            txt_approval.CssClass = "form-control";
            txt_bid_quantity.CssClass = "form-control";
            txt_bid_rate.CssClass = "form-control";

        }
        public void cleartext()
        {
            txt_bid_id.Text = "";
             

            txt_bid_rate.Text = "";
            txt_bid_quantity.Text = "";
            txt_bid_amount.Text = "";
            txt_bid_date.Text = "";
            txt_approval.Text = "";
            
        }
        public void enabledtext()
        {
            txt_bid_id.Enabled = true;
            txt_bid_rate.Enabled = true;
            txt_bid_quantity.Enabled = true;
            txt_bid_amount.Enabled = true;
            txt_bid_date.Enabled = true;
            txt_approval.Enabled = true;
           


        }
        public void disabledtext()
        {
            txt_bid_id.Enabled = false;
            txt_bid_rate.Enabled = false;
            txt_bid_quantity.Enabled = false;
            txt_bid_amount.Enabled = false;
            txt_bid_date.Enabled = false;
            txt_approval.Enabled = false;
        }
        public void setgrid()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = " select * from Customer_Bidding";
            dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();

        }
        public void SetDropDown2()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = " select *from Customer";
            dr = cmd.ExecuteReader();
            DropDownList2.DataSource = dr;
            DropDownList2.DataTextField = "cust_nm";
            DropDownList2.DataValueField = "cust_id";
            DropDownList2.DataBind();
            dr.Close();

             
        }
        public void SetDropDown1()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = " select *from Item_master";
            dr = cmd.ExecuteReader();
            DropDownList1.DataSource = dr;
            DropDownList1.DataTextField = "item_nm";
            DropDownList1.DataValueField = "item_id";
            DropDownList1.DataBind();
            dr.Close();


        }


        public int GetNewId()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select max (bid_id) from Customer_Bidding";

            object x = cmd.ExecuteScalar();
            if (Convert.ToString(x) == "")
                return 1;
            else
                return (Convert.ToInt32(x) + 1);

        }

        protected void btn_new_Click(object sender, EventArgs e)
        {
             flag = 1;
            enabledtext();
            btn_new.Enabled = false;
            btn_save.Enabled = true;

            txt_bid_id.Text = Convert.ToString(GetNewId());
            GetNewId();

        }

     

        protected void btn_delete_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = " delete from Customer_Bidding where bid_id=" + txt_bid_id.Text;
            int x = cmd.ExecuteNonQuery();
            if (x > 0)
                MessageBox.Show(" Record is deleted");
            else
                MessageBox.Show(" Record is not deleted ");

            disabledtext();
            setgrid();
            cleartext();
            btn_new.Enabled = true;
            btn_save.Enabled = false;
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            flag = 2;
            enabledtext();
            btn_new.Enabled = false;
            btn_save.Enabled = true;
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_bid_id.Text = GridView1.SelectedRow.Cells[1].Text;
            txt_bid_rate.Text = GridView1.SelectedRow.Cells[4].Text;
            txt_bid_quantity.Text = GridView1.SelectedRow.Cells[5].Text;
            txt_bid_amount.Text = GridView1.SelectedRow.Cells[6].Text;
            txt_bid_date.Text = GridView1.SelectedRow.Cells[7].Text;
            txt_approval.Text = GridView1.SelectedRow.Cells[8].Text;
            btn_new.Enabled = false;
            btn_save.Enabled = false;
            btn_update.Enabled = true;
            btn_delete.Enabled = true;
            
        }

        protected void btn_save_Click1(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into Customer_Bidding values (" + txt_bid_id.Text + "," + DropDownList1.SelectedValue + "," + DropDownList2.SelectedValue + "," + txt_bid_rate.Text + "," + txt_bid_quantity.Text + "," + txt_bid_amount.Text + ",'" + txt_bid_date.Text + "','" + txt_approval.Text + "')";
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                    MessageBox.Show(" Record is saved ");
                else
                    MessageBox.Show(" Record is not saved ");
            }
            if (flag == 2)
            {
                cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = " update Customer_Bidding set item_id= '" + DropDownList1.SelectedValue + "' , cust_id='" + DropDownList2.SelectedValue + "', bid_rate= '" + txt_bid_rate.Text + "', bid_qty= '" + txt_bid_quantity.Text + "', bid_amt= '" + txt_bid_amount.Text + "', bid_date='" + txt_bid_date.Text + "', approval='" + txt_approval.Text + "' where bid_id = " + txt_bid_id.Text;
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                    MessageBox.Show(" Record is updated ");
                else
                    MessageBox.Show(" Record is not updated ");
            }
            cleartext();
            setgrid();
            disabledtext();
            btn_new.Enabled = true;
            btn_save.Enabled = false;
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
        }

    }
}