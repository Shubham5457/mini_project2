<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Item_Master.aspx.cs" Inherits="online_product_auction_system.Item_Master" %>


<!DOCTYPE html>
<html lang="en">
   <head>
      <!-- basic -->
      <meta charset="utf-8">
      <meta http-equiv="X-UA-Compatible" content="IE=edge">
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <!-- mobile metas -->
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <meta name="viewport" content="initial-scale=1, maximum-scale=1">
      <!-- site metas -->
      <title>Contact</title>
      <meta name="keywords" content="">
      <meta name="description" content="">
      <meta name="author" content="">
      <!-- bootstrap css -->
      <link rel="stylesheet" type="text/css" href="html/css/bootstrap.min.css">
      <!-- style css -->
      <link rel="stylesheet" type="text/css" href="html/css/style.css">
      <!-- Responsive-->
      <link rel="stylesheet" href="html/css/responsive.css">
      <!-- fevicon -->
      <link rel="icon" href="html/images/fevicon.png" type="image/gif" />
      <!-- Scrollbar Custom CSS -->
      <link rel="stylesheet" href="html/css/jquery.mCustomScrollbar.min.css">
      <!-- Tweaks for older IEs-->
      <link rel="stylesheet" href="https://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css">
      <!-- fonts -->
      <link href="https://fonts.googleapis.com/css?family=Open+Sans:400,700|Poppins:400,700&display=swap" rel="stylesheet">
      <!-- owl stylesheets --> 
      <link rel="stylesheet" href="html/css/owl.carousel.min.css">
      <link rel="stylesheet" href="html/css/owl.theme.default.min.css">
      <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/fancybox/2.1.5/jquery.fancybox.min.css" media="screen">


    <script type="text/javascript" language="javascript">

        function formValidator(){
            // Make quick references to our fields
            var name = document.getElementById("txt_item_nm");
            var rate = document.getElementById("txt_rate");
            var description = document.getElementById("txt_description");
           
            var stock= document.getElementById("txt_stock");
	
            // Check each input in the order that it appears in the form!
            if(notEmpty(name,"Name Must be given") && isAlphabet(name, "Please enter only letters for your name"))
            {
                if(notEmpty(rate,"Rate Must be given") && isNumeric(rate, "Please enter only digit for rate"))
                {
                    if(notEmpty(description ,"description Must be given")){
                    
                            if(notEmpty(stock ,"stock Must be given")){
                                return true;
                            }
                        }
                    }
                }
            
            return false;
        }
        function notEmpty(elem, helperMsg) {

            if (elem.value.length == 0) {
                alert(helperMsg);
                elem.focus(); // set the focus to this input
                return false;
            }
            return true;
        }


        function isNumeric(elem, helperMsg) {
            var numericExpression = /^[0-9]+$/;
            if (elem.value.match(numericExpression)) {
                return true;
            } else {
                elem.value = "";
                alert(helperMsg);
                elem.focus();
                return false;
            }
        }

        function isAlphabet(elem, helperMsg) {
            var alphaExp = /^[a-zA-Z ]+$/;
            if (elem.value.match(alphaExp)) {
                return true;
            } else {
                alert(helperMsg);
                elem.value = "";
                elem.focus();
                return false;
            }
        }

        function isAlphanumeric(elem, helperMsg) {
            var alphaExp = /^[0-9a-zA-Z ]+$/;
            if (elem.value.match(alphaExp)) {
                return true;
            } else {
                alert(helperMsg);
                elem.value = "";
                elem.focus();
                return false;
            }
        }

        function validmobile(elem) {
            var uInput = elem.value;
            if (uInput.length == 10) {
                return true;
            } else {
                alert("Please enter valid mobile Or Phone No");
                elem.value = "";
                elem.focus();
                return false;
            }
        }


        function lengthRestriction(elem, min, max) {
            var uInput = elem.value;
            if (uInput.length >= min && uInput.length <= max) {
                return true;
            } else {
                alert("Please enter between " + min + " and " + max + " characters");
                elem.value = "";
                elem.focus();
                return false;
            }
        }

        function madeSelection(elem, helperMsg) {
            if (elem.value == "Please Choose") {
                alert(helperMsg);
                elem.focus();
                return false;
            } else {
                return true;
            }
        }

        function emailValidator(elem, helperMsg) {
            var emailExp = /^[\w\-\.\+]+\@[a-zA-Z0-9\.\-]+\.[a-zA-z0-9]{2,4}$/;
            if (elem.value.match(emailExp)) {
                return true;
            } else {
                alert(helperMsg);
                elem.value = "";
                elem.focus();
                return false;
            }
        }
</script>



</head>
   <body>
      <!-- header section start -->
      <div class="header_section">
         <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <a class="navbar-brand"><a href="html/index.html"><img  height="100px" width="100px"  src="html/images/Auctionlogo1.jpg"></a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
               <ul class="navbar-nav mr-auto">
                  <li class="nav-item active">
                     <a class="nav-link" href="html/index.html">Home</a>
                  </li>
                  <li class="nav-item">
                     <a class="nav-link" href="User/UserDashboard.aspx">DashBoard</a>
                  </li>
                 
               </ul>
            


            </div>
         </nav>
      </div>
      <!-- header section end -->
      <!-- contact section start -->
      <div class="contact_section layout_padding">
         <div class="container">
            <div class="contact_section_2">
               <div class="row">
                  <div class="col-md-12">
                     <div class="mail_section_1">
                        <h1 class="contact_taital">Item Master</h1>
    <form id="form1" runat="server">
        <div class="container">
               <div class="row">
                  <div class="col-md-6">
                        <asp:TextBox ID="txt_item_id" runat="server" class="form-control" placeholder="Item ID" Enabled="False"></asp:TextBox>
                 <asp:Label ID="Label8" runat="server" Font-Bold="False" Font-Size="Large" Text="User ID :"></asp:Label>
                
                    <asp:DropDownList ID="dropdownlist_id0" class="form-control"  runat="server">
                    </asp:DropDownList> <br>
                <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Size="Large" Text="Category ID :"></asp:Label>
                
                    <asp:DropDownList ID="dropdownlist_id" class="form-control" runat="server">
                    </asp:DropDownList> <br>
                
                    <asp:TextBox ID="txt_item_nm" runat="server" class="form-control" placeholder="Item Name " Enabled="False"></asp:TextBox>
                <br>
        </div>   <div class="col-md-6">
                          <asp:TextBox ID="txt_rate" runat="server" class="form-control" placeholder="Rate" Enabled="False"></asp:TextBox>
                <br>
                    <asp:TextBox ID="txt_description" runat="server" class="form-control" placeholder="Description" Enabled="False" Height="29px"></asp:TextBox>
                 <br>
                     <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="Button1" runat="server"   class="btn-primary"  Text="Upload" OnClick="Button1_Click1" /> <br>
            <asp:Image ID="Image1" Height="100px" Width="100px" runat="server" />

                 <br>
                    
               <asp:FileUpload ID="FileUpload2" runat="server" />
            <asp:Button ID="Button2" runat="server"   class="btn-primary"  Text="Upload" OnClick="Button2_Click" /> <br>
            <asp:Image ID="Image2" Height="100px" Width="100px" runat="server" />

 <br>
                    <asp:TextBox ID="txt_stock" runat="server" class="form-control" placeholder="Stock" Enabled="False"></asp:TextBox>
                <br></div></div></div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_new" runat="server"  class="btn-primary"  OnClick="Button1_Click" Text="New" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btn_save" runat="server" Enabled="False"  class="btn-primary"  Text="Save" OnClick="btn_save_Click" OnClientClick="return formValidator()" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_update" runat="server"  class="btn-primary"  Text="Update" Enabled="False" OnClick="btn_update_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_delete" runat="server"  class="btn-primary"  Text="Delete" Enabled="False" OnClick="btn_delete_Click" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" class="table" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
    </form>

                      
                     </div>
                  </div>
                
               </div>
            </div>
         </div>
      </div>
   
      <!-- copyright section end -->
      <!-- Javascript files-->
      <script src="html/js/jquery.min.js"></script>
      <script src="html/js/popper.min.js"></script>
      <script src="html/js/bootstrap.bundle.min.js"></script>
      <script src="html/js/jquery-3.0.0.min.js"></script>
     <!-- sidebar -->
      <script src="html/js/jquery.mCustomScrollbar.concat.min.js"></script>
      <script src="html/js/custom.js"></script>
      <!-- javascript --> 
      <script src="html/js/owl.carousel.js"></script>
      <script src="html/https:cdnjs.cloudflare.com/ajax/libs/fancybox/2.1.5/jquery.fancybox.min.js"></script>    
   </body>
</html>


