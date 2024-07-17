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
    public partial class Customer : System.Web.UI.Page
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
            txt_cust_id.CssClass = "form-control";
            txt_cust_nm.CssClass = "form-control";
            txt_cust_email.CssClass = "form-control";
            txt_cust_addr.CssClass = "form-control";
            txt_cust_password.CssClass = "form-control";
            txt_cust_phone.CssClass = "form-control";
            btn_delete.CssClass = "btn-primary";
            btn_new.CssClass = "btn-primary";
            btn_save.CssClass = "btn-primary";
            btn_update.CssClass = "btn-primary";

        }
        public void cleartext()
        {
            txt_cust_id.Text = "";
            txt_cust_nm.Text = "";
            txt_cust_addr.Text = "";
            txt_cust_phone.Text = "";
            txt_cust_email.Text = "";
            txt_cust_password.Text = "";
        }
        public void enabledtext()
        {
            txt_cust_id.Enabled = true;
            txt_cust_nm.Enabled = true;
            txt_cust_addr.Enabled = true;
            txt_cust_phone.Enabled = true;
            txt_cust_email.Enabled = true;
            txt_cust_password.Enabled = true;
        }
        public void disabledtext()
        {
            txt_cust_id.Enabled = false;
            txt_cust_nm.Enabled = false;
            txt_cust_addr.Enabled = false;
            txt_cust_phone.Enabled = false;
            txt_cust_email.Enabled = false;
            txt_cust_password.Enabled = false;
        }
        public void setgrid()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = " select * from customer" ;
            dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
        }
        
        public int GetNewId()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select max (cust_id) from customer";

            object x = cmd.ExecuteScalar();
            if (Convert.ToString(x) == "")
                return 1;
            else
                return (Convert.ToInt32(x) +1);

        }

        protected void btn_new_Click(object sender, EventArgs e)
        {
            flag = 1;
            enabledtext();
            btn_new.Enabled =false;
            btn_save.Enabled =true;

            txt_cust_id.Text= Convert.ToString(GetNewId());
            GetNewId();

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if(flag == 1)
            {
                cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into customer values (" + txt_cust_id.Text + ",'" + txt_cust_nm.Text +"','" + txt_cust_addr.Text +"','" + txt_cust_phone.Text + "','" + txt_cust_email.Text +"','" + txt_cust_password.Text + "')";
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
                cmd.CommandText = " update customer set cust_nm= '" + txt_cust_nm.Text + "', cust_addr='" + txt_cust_addr.Text + "', cust_phone= '" + txt_cust_phone.Text + "', cust_email= '" + txt_cust_email.Text + "', cust_password= '" + txt_cust_password.Text + "' where cust_id = " + txt_cust_id.Text;
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                    MessageBox.Show(" Record is updated ");
                else
                    MessageBox.Show(" Record is not updated ");
        }
            cleartext();
            setgrid();
            disabledtext();
            btn_new.Enabled=true;
            btn_save.Enabled=false;
            btn_update.Enabled=false;
            btn_delete.Enabled=false;
        }

        protected void txt_delete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = " delete from customer where cust_id=" + txt_cust_id.Text;
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
            txt_cust_id.Text = GridView1.SelectedRow.Cells[1].Text;
            txt_cust_nm.Text = GridView1.SelectedRow.Cells[2].Text;
            txt_cust_addr.Text = GridView1.SelectedRow.Cells[3].Text;
            txt_cust_phone.Text = GridView1.SelectedRow.Cells[4].Text;
            txt_cust_email.Text = GridView1.SelectedRow.Cells[5].Text;
            txt_cust_password.Text = GridView1.SelectedRow.Cells[6].Text;
            btn_new.Enabled = false;
            btn_save.Enabled = false;
            btn_update.Enabled = true;
            btn_delete.Enabled = true;
            
        }

        
        
    }
}