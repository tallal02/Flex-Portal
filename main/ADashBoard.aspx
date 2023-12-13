<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ADashBoard.aspx.cs" Inherits="AdHome" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta name="viewport" content="width=device-width, initial-scale=1" />
		<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
		<link href="Ad.css" rel="stylesheet" />
    
		<title>Flex|Dashboard</title>
    
</head>

<body>

	<form runat="server">

         <nav class="navbar p-4 navbar-icon-top navbar-expand-lg navbar-dark bg-dark">
		  <a class="navbar-brand" href="#">
          <img src="https://flex.nu.edu.pk/Content/Images/Flex-Login-3.png" alt="Logo" style="width:80px;height:80px;" />
          </a>
		  <a class="navbar-brand" style="font-size:30px;color:dodgerblue" href="#">Flex Admin</a>
		  
		  <asp:Button runat="server" class="navbar-toggler" type="button">
		  </asp:Button>

		  <div class="collapse navbar-collapse" id="navbarContent">
		    <ul class="navbar-nav me-auto align-content-between" >

				
		      <li class="nav-item rounded-1 " style="margin-left:10px;background-color:dodgerblue">
		          <a class="nav-link text-black-50" href="#">
		          <i class="fa fa-home"></i>
		          Dashboard
		          </a>
		      </li>
				

		      <li class="nav-item rounded-1" style="margin-left:10px;background-color:dodgerblue">
		        <a class="nav-link" href="/AddCourse.aspx">
		         <i class="fa fa-slack"></i>
		          Add Courses
		        </a>
		      </li>


		      <li class="nav-item rounded-1" style="margin-left:10px;background-color:dodgerblue">
		        <a class="nav-link" href="/OfferCourses.aspx">
		          <i class="fa fa-clipboard"></i>
		          Offer Courses
		        </a>
		      </li>

				<li class="nav-item rounded-1" style="margin-left:10px;background-color:dodgerblue">
		        <a class="nav-link" href="/RegCourses">
		         <i class="fa fa-stack-overflow"></i>
		          Register Courses
		        </a>
		      </li>


		      <li class="nav-item rounded-1" style="margin-left:10px;background-color:dodgerblue">
		        <a class="nav-link" href="/AllocateSections.aspx">
		          <i class="fa fa-book"></i>
		          Allocate Sections
		        </a>
		      </li>


		    </ul>



		    <div class="d-flex">
                <asp:Button runat="server" class="btn btn-outline-danger my-2 my-sm-0" Text="Logout" type="submit" OnClick="Unnamed2_Click"></asp:Button>
		    </div>
		  </div>
		</nav>
		
		<div class="container-fluid m-0" style="background-image: url('https://wallpaperaccess.com/full/6802.jpg'); background-position: center; background-size: cover; background-repeat: no-repeat; height:auto">
			
			<br />
			<br />
			<div class="container-fluid d-flex bg-primary rounded-2" >
				<h2 style="color:white">Personal Info</h2>
			</div>
			<div class="d-flex flex-row ">

				<div class="flex-grow-1 container p-5 bg-dark bg-opacity-50 text-white ">
					<h5 class="d-inline-block text-primary">Name:   </h5>
                    <asp:Label runat="server" class="d-inline-block m-4" Text="Label" ID="_name"></asp:Label>
					<br />
					<h5 class="d-inline-block text-primary">CNIC:   </h5>
					<asp:Label runat="server" class="d-inline-block m-4" Text="Label" ID="_cnic"></asp:Label>
					<br />
					<h5 class="d-inline-block text-primary">Gender:  </h5>
					<asp:Label runat="server" class="d-inline-block m-4" Text="Label" ID="_gender"></asp:Label>

				</div>

				<div class="flex-grow-2 container p-5 bg-dark bg-opacity-50 text-white ">
					<h5 class="d-inline-block text-primary">DOB: </h5>
					<asp:Label runat="server" class="d-inline-block m-4" Text="Label" ID="_dob"></asp:Label>
					<br />
					<h5 class="d-inline-block text-primary">Role: </h5>
					<asp:Label runat="server" class="d-inline-block m-4" Text="Label" ID="_role"></asp:Label>

				</div>

			</div>


			<br />
			<div class="container-fluid d-flex bg-primary rounded-2">
				<h2 style="color:white">Contact Details</h2>
			</div>
			<div class="d-flex flex-row ">

				<div class="flex-grow-1 container p-5 bg-dark bg-opacity-50 text-white ">
					<h5 class="d-inline-block text-primary">Address:   </h5>
					<asp:Label runat="server" class="d-inline-block m-4" Text="Label" ID="_address"></asp:Label>
					<br />
					<h5 class="d-inline-block text-primary">Email:   </h5>
					<asp:Label runat="server" class="d-inline-block m-4" Text="Label" ID="_email"></asp:Label>

				</div>

				<div class="flex-grow-2 container p-5 bg-dark bg-opacity-50 text-white ">
					<h5 class="d-inline-block text-primary">Phone: </h5>
					<asp:Label runat="server" class="d-inline-block m-4" Text="Label" ID="_phone"></asp:Label>
					<br />

				</div>

			</div>

			<br />
			<div class="container-fluid d-flex bg-primary rounded-2">
				<h2 style="color:white">Institution Details</h2>
			</div>
			<div class="d-flex flex-row ">

				<div class="flex-grow-1 container p-5 bg-dark bg-opacity-50 text-white ">
					<h5 class="d-inline-block text-primary">RegID:   </h5>
					<asp:Label runat="server" class="d-inline-block m-4" Text="Label" ID="_id"></asp:Label>
				</div>

				<div class="flex-grow-2 container p-5 bg-dark bg-opacity-50 text-white ">
					<h5 class="d-inline-block text-primary">Salary: </h5>
					<asp:Label runat="server" class="d-inline-block m-4" Text="Label" ID="_salary"></asp:Label>
				</div>

			
			</div>
			<br />
			<br />
				
	    </div>

	</form>

	
         


	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
	<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.min.js"></script>

</body>

</html>





<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdHome.aspx.cs" Inherits="AdHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="StyleSheet2.css" />
    <title>Sidebar Template</title>
    <link href="https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css" rel="stylesheet" />
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" />
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
    
</head>

<body>

        <div class="d-flex flex-row vh-100 bg-black" style="color:white;">
            <div class="flex-grow-1 container m-0 p-1 bg-dark text-white" style="width:80%">
                <div class="">
                    <h3>Admin-Flex</h3>
                </div>
                <div>

                    <ul>
                        <li>

                            <a href="#">
                                <i class="bx bx-grid="></i>
                            </a>

                        </li>
                    </ul>

                </div>
            </div>

             <div class="flex-grow-1 container m-0 p-5 bg-dark text-white" style="width:80%">
                <h1>my </h1>
            </div>

        </div>
        
</body>

</html>--%>
