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
    public partial class Item_cat : System.Web.UI.Page
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
            btn_delete.CssClass = "btn-primary";
            btn_new.CssClass = "btn-primary";
            btn_save.CssClass = "btn-primary";
            btn_update.CssClass = "btn-primary";
            txt_cat_id.CssClass = "form-control";
            txt_cat_nm.CssClass = "form-control";
        }

        public void cleartext()
        {
            txt_cat_id.Text = "";
            txt_cat_nm.Text = "";
        }
        public void enabledtext()
        {
            txt_cat_id.Enabled = true;
            txt_cat_nm.Enabled = true;
        }
        public void disabledtext()
        {
            txt_cat_id.Enabled = false;
            txt_cat_nm.Enabled = false;
            
        }
        public void setgrid()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = " select * from Item_Cat";
            dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
        }

        public int GetNewId()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select max (cat_id) from Item_Cat";

            object x = cmd.ExecuteScalar();
            if (Convert.ToString(x) == "")
                return 1;
            else
                return (Convert.ToInt32(x) + 1);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            flag = 1;
            enabledtext();
            btn_new.Enabled = false;
            btn_save.Enabled = true;

            txt_cat_id.Text = Convert.ToString(GetNewId());
            GetNewId();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into Item_Cat values(" + txt_cat_id.Text+",'" + txt_cat_nm.Text +"')";
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
                cmd.CommandText = " update Item_Cat set cat_nm= '" + txt_cat_nm.Text + "' where cat_id = " + txt_cat_id.Text;
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

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = " delete from Item_Cat where cat_id=" + txt_cat_id.Text;
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
            txt_cat_id.Text = GridView1.SelectedRow.Cells[1].Text;
            txt_cat_nm.Text = GridView1.SelectedRow.Cells[2].Text;
            btn_new.Enabled = false;
            btn_save.Enabled = false;
            btn_update.Enabled = true;
            btn_delete.Enabled = true;
        }
        

        
    }
}