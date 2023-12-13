<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8" />
     <meta name="viewport" content="width=device-width, initial-scale=1" />
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" />
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
    
    <title>Continue As</title>
</head>
<body>
    
    <form >
        <div class="d-flex justify-content-center vh-100 bg-secondary" style="background-image: url('https://png.pngtree.com/thumb_back/fh260/background/20190221/ourmid/pngtree-green-education-blackboard-stereoscopic-image_20770.jpg'); background-position: center; background-size: cover; background-repeat: no-repeat;">
            <div class="d-flex justify-content-around align-items-center p-3 text-white" style="width: 80%; height:  100%;">
                


                 <div class="container d-flex flex-column align-items-center bg-transparent p-4 rounded-3" style="width:300px;">
                     
                    <img class="card-img-top" src="https://cdn-icons-png.flaticon.com/128/2784/2784445.png" alt="Card image" style="width:100%;" />
                     <br /> <br />
                    <div class="card-body d-flex align-items-center">
                      <a href="LogIn.aspx" class="btn btn-primary">Teacher</a>
                    </div>

                  </div>

                  <div class="container d-flex flex-column align-items-center bg-transparent p-4 rounded-3" style="width:300px">

                    <img class="card-img-top" src="https://cdn-icons-png.flaticon.com/128/2206/2206368.png" alt="Card image" style="width:100%" />
                    <br /> <br />
                    <div class="card-body">
                      <a id="AdminPage" href="LogIn.aspx" class="btn btn-primary">Admin</a>
                    </div>

                  </div>
                  <div class="container d-flex flex-column align-items-center bg-transparent p-4 rounded-3" style="width:300px">

                    <img class="card-img-top" src="https://cdn-icons-png.flaticon.com/128/2784/2784403.png" alt="Card image" style="width:100%" />
                     <br /> <br />
                     <div class="card-body">
                      <a href="LogIn.aspx" class="btn btn-primary">Student</a>
                    </div>

                  </div>

           
              
            </div>

        </div>
        
    </form>
  <%--<div class="container mt-3">

  <div class="card" style="width:400px">

    <img class="card-img-top" src="https://mdbcdn.b-cdn.net/img/new/avatars/5.webp" alt="Card image" style="width:100%">
    <div class="card-body">
      <h4 class="card-title">John Doe</h4>
      <p class="card-text">Some example text some example text. John Doe is an architect and engineer</p>
      <a href="#" class="btn btn-primary">See Profile</a>
    </div>
  </div>
  <br>
  
  <p>Image at the bottom (card-img-bottom):</p>
  <div class="card" style="width:400px">
    <div class="card-body">
      <h4 class="card-title">Jane Doe</h4>
      <p class="card-text">Some example text some example text. Jane Doe is an architect and engineer</p>
      <a href="#" class="btn btn-primary">See Profile</a>
    </div>
    <img class="card-img-bottom" src="../bootstrap4/img_avatar6.png" alt="Card image" style="width:100%">
  </div>
</div>--%>
</body>
</html>
