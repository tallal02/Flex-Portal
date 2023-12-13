<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8" />
     <meta name="viewport" content="width=device-width, initial-scale=1" />
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" />
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
    
    <title>Flex Admin LogIN</title>
</head>
<body>
    <form id="Form1" runat="server">
<div class="d-flex flex-row vh-100">

    <div class=" flex-grow-1 container p-5 bg-dark text-white" >

                <div class="container-fluid col-md-6 mx-auto">
                     <a class="navbar-brand" href="#">
                     <img src="https://flex.nu.edu.pk/Content/Images/Flex-Login-3.png" alt="Logo" width="200" height="200" class="d-inline-block align-text-center" />
                     </a>
                </div>
                <br />

             <div class="container-fluid col-md-7 mx-auto">
                 
                 <asp:label runat="server"  Cssclass="form-label">Email:</asp:label>
                 <br />
                 <asp:TextBox runat="server" CssClass="flex-row rounded-1" ID="Email"  placeholder="abc@email"></asp:TextBox>
                
             </div>
                 <br />
             <div class="container-fluid col-md-7 mx-auto">
                 <br />
                 
                 <asp:label runat="server"  Cssclass="form-label">Password:</asp:label>
                 <br />
                 <asp:TextBox runat="server" CssClass="flex-row rounded-1" type="password" ID="Password" ></asp:TextBox>
          
             </div>
        <br />
        
             <div class="container-fluid col-md-7 mx-auto">
                 <label class="form-check-label"></label>
                  <input class="form-check-input " type="checkbox" name="remember" /> Remember me
             </div>
                 
            <br />
             <div class="container-fluid col-md-5 mx-auto ">      
                <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="Unnamed3_Click" ID="Submit"></asp:Button>
             </div>
    </div>

    <div class=" flex-grow-1 container text-white d-flex align-items-center justify-content-center" style="background-image: url('https://wallpaperaccess.com/full/922666.jpg'); background-position: center; background-size: cover; background-repeat: no-repeat;">
        <div class="container">
             <div class="h-100">
                    <h1 class="text-center">Welcome to Flex</h1>
             </div>
        </div>
    </div>  
</div>
         
</form>
</body>
</html>
