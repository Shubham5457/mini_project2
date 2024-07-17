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
    public partial class Final_bill : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        static string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = " Data Source=DESKTOP-T3V9JTK\\SQLEXPRESS;Initial Catalog=online_product_auction_system;Integrated Security=True ";
            cn.Open();


             id = Convert.ToString(Session["Saleid"]);


            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select cust_nm,cust_addr,cust_phone,cust_email,sale_id,sale_date,item_nm,rate,Sales.bid_amt from Customer, Item_master,Sales,Customer_Bidding where Sales.cust_id=Customer.cust_id and Sales.bid_id=Customer_Bidding.bid_id and Customer_bidding.item_id=Item_master.item_id and Customer_Bidding.cust_id=Customer.cust_id and Sales.sale_id=" + id;

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PlaceHolder1.Controls.Add(new LiteralControl("<table  align='center' height='700px' width='600px'  style='border-style: outset; padding: 5px; margin: 5px; color: #000000;'>" +
      "      <tr align='right'>"+
        "        <td style='text-align: left'>"+
        "            <img height='150px' width='150px' src='html/images/Auctionlogo1.jpg' /></td>"+
        "        <td class='auto-style1' colspan='3'>1234 &#39;D&#39; Ward Kagal ,Kolhapur<br />"+
         "           Mob-9088773590<br />"+
          "          <a href='Email:-Auction2023@gmail.com'>Email :Auction2023@gmail.com</a><br />"+
           "     </td>"+
         "   </tr>"+
         "   <tr>"+
         "       <td rowspan='3'><strong>Bill To:<br />"+
        "            </strong>"+dr[0]+""+
         "           <br />"+
             "       "+dr[1]+"<br />"+
            "        Mob : "+dr[2]+"<br />"+
           "         Email-"+dr[3]+"</td>"+
          "      <td  style='border-style: outset; border-width: 2px; text-align: center'>Bill ID</td>"+
         "       <td colspan='2'  style='border-style: outset; border-width: 2px; text-align: center'>"+dr[4]+"</td>"+
        "    </tr>"+
       "     <tr>"+
        "        <td  style='border-style: outset; border-width: 2px; text-align: center'>Bill Date</td>"+
        "        <td colspan='2'  style='border-style: outset; border-width: 2px; text-align: center'>"+dr[5]+"</td>"+
        "    </tr>"+
      "      <tr>"+
        "        <td>&nbsp;</td>"+
         "       <td>&nbsp;</td>"+
          "     <td>&nbsp;</td>"+
        "    </tr>"+
      "      <tr>"+
      "         <td colspan='4' style='text-align: center'><strong>*Invoice*</strong></td>"+
       "     </tr>"+
       "     <tr>"+
        "       <td colspan='2'  style='border-style: outset; border-width: 2px; text-align: center'>Desicription</td>"+
          "      <td style='border-style: outset; border-width: 2px; text-align: center'>&nbsp;&nbsp;&nbsp;&nbsp; Amount&nbsp;&nbsp;&nbsp;&nbsp; </td>"+
          "      <td  style='border-style: outset; border-width: 2px; text-align: center'>Bidding Amt.</td>"+
        "    </tr>"+
       "    <tr>"+
         "       <td colspan='2'  style='border-style: outset; border-width: 2px; text-align: center'>"+dr[6]+" </td>"+
         "       <td  style='border-style: outset; border-width: 2px; text-align: center'>"+dr[7]+"</td>"+
           "     <td  style='border-style: outset; border-width: 2px; text-align: center'>"+
            "        <br />"+
            "        "+dr[8]+"<br />"+
            "        <br />"+
            "    </td>"+
        "    </tr>"+
         "   <tr>"+
          "      <td colspan='2' style='text-align: center'>Total</td>"+
         "       <td>&nbsp;</td>"+
         "       <td  style='border-style: outset; border-width: 2px; text-align: center'>"+dr[8]+"</td>"+
         "   </tr>"+
        "    <tr align='center'>"+
         "       <td class='auto-style2' colspan='4'>"+
        "            <br />"+
          "          <strong>Thank You .......</strong><br />"+
        "        </td>"+
      "      </tr>"+
       "     </table>"));
               




                    }
            dr.Close();

        }
    }
}