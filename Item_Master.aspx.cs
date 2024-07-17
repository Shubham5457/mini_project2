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
    public partial class Item_Master : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        static int flag = 0;
        static string filenm1;
        static string filenm;

        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = " Data Source=DESKTOP-T3V9JTK\\SQLEXPRESS;Initial Catalog=online_product_auction_system;Integrated Security=True ";
            cn.Open();
            setgrid();
            if (!IsPostBack)
            {
                SetDropDown();
                SetDropDown1();
            }
            txt_item_id.CssClass = "form-control";
            txt_item_nm.CssClass = "form-control";
            //txt_item_photo1.CssClass = "form-control";
            //txt_item_photo2.CssClass = "form-control";
            txt_rate.CssClass = "form-control";
            txt_stock.CssClass = "form-control";
            txt_description.CssClass = "form-control";
            btn_delete.CssClass = "btn-primary";
            btn_new.CssClass = "btn-primary";
            btn_save.CssClass = "btn-primary";
            btn_update.CssClass = "btn-primary";
        }
        public void cleartext()
        {
            txt_item_id.Text = "";
           // txt_user_id.Text = " ";
             
            txt_item_nm.Text = "";
            txt_rate.Text = "";
            txt_description.Text = "";
           // txt_item_photo1.Text= " ";
//txt_item_photo2.Text = " ";
            txt_stock.Text = "";
        }
        public void enabledtext()
        {
            txt_item_id.Enabled = true;
           // txt_user_id.Enabled = true;
            txt_item_nm.Enabled = true;
            txt_rate.Enabled = true;
            txt_description.Enabled = true;
            //.Enabled = true;
           // txt_item_photo2.Enabled = true;
            txt_stock.Enabled = true;


        }
        public void disabledtext()
        {
            txt_item_id.Enabled = false;
          //  txt_user_id.Enabled = false;
            txt_item_nm.Enabled = false;
            txt_rate.Enabled = false;
            txt_description.Enabled = false;
           // txt_item_photo1.Enabled = false;
           // txt_item_photo2.Enabled = false;
            txt_stock.Enabled = false;
        }
        public void setgrid()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = " select * from Item_master";
            dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
        }
        public void SetDropDown()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = " select *from Item_Cat";
            dr = cmd.ExecuteReader();
            dropdownlist_id.DataSource = dr;
            dropdownlist_id.DataTextField = "cat_nm";
            dropdownlist_id.DataValueField = "cat_id";
            dropdownlist_id.DataBind();
            dr.Close();


        }
        public void SetDropDown1()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = " select *from User1";
            dr = cmd.ExecuteReader();
            dropdownlist_id0.DataSource = dr;
            dropdownlist_id0.DataTextField = "user_nm";
            dropdownlist_id0.DataValueField = "user_id";
            dropdownlist_id0.DataBind();
            dr.Close();


        }

        public int GetNewId()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select max (item_id) from Item_master";

            object x = cmd.ExecuteScalar();
            if (Convert.ToString(x) == "")
                return 1;
            else
                return (Convert.ToInt32(x) + 1);

        }

        
        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into Item_master values (" + txt_item_id.Text + "," + dropdownlist_id0.SelectedValue + "," + dropdownlist_id.SelectedValue + ",'" + txt_item_nm.Text + "','" + txt_rate.Text + "','" + txt_description.Text +"','" + filenm +"','" + filenm1 + "'," + txt_stock.Text +")";
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
                cmd.CommandText = " update Item_master set user_id= " + dropdownlist_id0.SelectedValue + " , cat_id=" + dropdownlist_id.SelectedValue + ", item_nm= '" + txt_item_nm.Text + "', rate= " + txt_rate.Text + ", description= '" + txt_description.Text + "', item_photo1='" + filenm + "', item_photo2='" + filenm1 + "', stock=" + txt_stock.Text + " where item_id = " + txt_item_id.Text;
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
            cmd.CommandText = " delete from Item_master where item_id=" + txt_item_id.Text;
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
            txt_item_id.Text = GridView1.SelectedRow.Cells[1].Text;
            //txt_user_id.Text = GridView1.SelectedRow.Cells[2].Text;                
            txt_item_nm.Text= GridView1.SelectedRow.Cells[4].Text;
            txt_rate.Text= GridView1.SelectedRow.Cells[5].Text;
            txt_description.Text = GridView1.SelectedRow.Cells[6].Text;
          //  txt_item_photo1.Text = GridView1.SelectedRow.Cells[7].Text;
           // txt_item_photo2.Text= GridView1.SelectedRow.Cells[8].Text;
            txt_stock.Text = GridView1.SelectedRow.Cells[9].Text;
            btn_new.Enabled = false;
            btn_save.Enabled = false;
            btn_update.Enabled = true;
            btn_delete.Enabled = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            flag = 1;
            enabledtext();
            btn_new.Enabled = false;
            btn_save.Enabled = true;

            txt_item_id.Text = Convert.ToString(GetNewId());
            GetNewId();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile == true)
            {
                string basedir = Server.MapPath("~/upload/");
                filenm = FileUpload1.FileName;
                FileUpload1.SaveAs(basedir + FileUpload1.FileName);
                Image1.ImageUrl = "~/upload//" + FileUpload1.FileName;

            }
            else
            {
                MessageBox.Show("You Must Select Photos");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (FileUpload2.HasFile == true)
            {
                string basedir = Server.MapPath("~/upload/");
                filenm1 = FileUpload2.FileName;
                FileUpload2.SaveAs(basedir + FileUpload2.FileName);
                Image2.ImageUrl = "~/upload//" + FileUpload2.FileName;

            }
            else
            {
                MessageBox.Show("You Must Select Photos");
            }
        }

        
    }
}