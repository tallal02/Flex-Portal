<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCourse.aspx.cs" Inherits="AddCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	 <meta name="viewport" content="width=device-width, initial-scale=1" />
	 <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
	 <link href="Ad.css" rel="stylesheet" />
    <title>Flex|Add Course</title>
</head>
<body>
    <form id="form1" runat="server">
         <nav class="navbar p-4 navbar-icon-top navbar-expand-lg navbar-dark bg-dark">
		  <a class="navbar-brand" href="#">
          <img src="https://flex.nu.edu.pk/Content/Images/Flex-Login-3.png" alt="Logo" style="width:80px;height:80px;" />
          </a>
		  <a class="navbar-brand" style="font-size:30px;color:dodgerblue" href="#">Flex Admin</a>
		  
		  <asp:Button runat="server" class="navbar-toggler" type="button">
		  </asp:Button>

		  <div class="collapse navbar-collapse" id="navbarContent">
		    <ul class="navbar-nav me-auto align-content-between" >

				
		      <li class="nav-item text-white rounded-1 " style="margin-left:10px;background-color:dodgerblue">
		          <a class="nav-link" href="/ADashBoard.aspx">
		          <i class="fa fa-home"></i>
		          Dashboard
		          </a>
		      </li>
				

		      <li class="nav-item rounded-1" style="margin-left:10px;background-color:dodgerblue">
		        <a class="nav-link text-black-50" href="#">
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
		        <a class="nav-link" href="/RegCourses.aspx">
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
                <asp:Button runat="server" class="btn btn-outline-danger my-2 my-sm-0" Text="Logout" type="submit" ID="LogOut"></asp:Button>
            </div>
		  </div>
		</nav>



		<div class="container-fluid m-0 " style="background-image: url('https://wallpaperaccess.com/full/6802.jpg'); background-position: center; background-size: cover; background-repeat: no-repeat; height:auto">
			<br />
			<br />
			<div class="container-fluid d-flex bg-primary rounded-2" >
				<h2 style="color:white">Add New Course</h2>
			</div>

			<div class="d-flex flex-row">

				<div class="flex-grow-1 container p-5 bg-dark bg-opacity-50 rounded-2 text-white ">

					<h4 class="d-inline-block text-primary">Course Name: * </h4>
                    <input runat="server"  class="d-inline-block m-4 bg-dark opacity-50 text-light border-1 border-white rounded-2" ID="_cname" type="text" />
					<br />

					<h4 class="d-inline-block text-primary" >Course Code: * </h4>
					<input runat="server" class="d-inline-block m-4 bg-dark opacity-50 text-light border-1 border-white rounded-2" ID="_ccode" type="text" />
					<br />

					<h4 class="d-inline-block text-primary">Type (Core/Elec): </h4>
					<select runat="server"  class="d-inline-block m-4 bg-dark opacity-50 text-light border-1 border-white rounded-2" style="width:180px" id="_ctype">
					  <option value="Core">Core</option>
					  <option value="Elective">Elective</option>
					</select>
				
					<br />




				</div>

				<div class="flex-grow-2 container p-5 bg-dark bg-opacity-50 text-white ">

					<h4 class="d-inline-block text-primary">Credit Hours: * </h4>
					<input runat="server" class="d-inline-block m-4 bg-dark opacity-50 text-light border-1 border-white rounded-2" ID="_crd" type="number" />
					<br />

					<h4 class="d-inline-block text-primary">Pre-Requisite: </h4>
					<input runat="server" class="d-inline-block m-4 bg-dark opacity-50 text-light border-1 border-white rounded-2" ID="_pre_req" type="text"/>
					<br />

					<h4 class="d-inline-block text-primary">Coordinator ID: * </h4>
					<input runat="server" class="d-inline-block m-4 bg-dark opacity-50 text-light border-1 border-white rounded-2" ID="_CID" type="text" />
					<br />
					<asp:Label ID="Label1" CssClass="container d-inline-block m-2 p-2 rounded-2 text-danger  " runat="server" Text="Label" Visible="False"></asp:Label>
                    <br />
					<asp:Button runat="server" class="btn btn-outline-success my-2 my-sm-0" Text="Add Course" type="submit" ID="button" OnClick="button_Click1"></asp:Button>

					<div class="d-flex">

                        
                 
				   </div>

				</div>

			</div>

			
			<br />
			<br />
			<div class="container-fluid d-flex bg-primary rounded-2" >
				<h2 style="color:white">Course Details</h2>
			</div>

			<div class="d-flex flex-row flex-nowrap  " style="overflow-x:scroll" >

			<asp:PlaceHolder runat="server" ID="_cdata"></asp:PlaceHolder>

<%--			<div class="container-fluid flex-grow-1 p-4 rounded-3 " style="width:1000px;">";
            <div class="container-fluid d-flex bg-primary rounded-2"><h2 style="color:white">a23fsf</h2></div>
           <div class="container-fluid d-flex bg-dark bg-opacity-50"><h5 class="d-inline-block text-primary m-2">Course Name:   </h5><p class="d-inline-block text-white m-2 p-1">Arts</p><br /></div>
            <div class="container-fluid d-flex  bg-dark bg-opacity-50"><h5 class="d-inline-block text-primary m-2">Credit Hours:   </h5><p class="d-inline-block text-white m-2 p-1 ">5 hrs</p><br /></div>
            <div class="container-fluid d-flex  bg-dark bg-opacity-50"><h5 class="d-inline-block text-primary m-2">Type: </h5><p class="d-inline-block text-white m-2 p-1">Core</p><br /></div><br/><br/>
            </div>

			<div class="container-fluid flex-grow-2 p-4 rounded-3 " style="width:900px;">";
            <div class="container-fluid d-flex bg-primary rounded-2"><h2 style="color:white">a23fsf</h2></div>
           <div class="container-fluid d-flex bg-dark bg-opacity-50"><h5 class="d-inline-block text-primary m-2">Course Name:   </h5><p class="d-inline-block text-white m-2 p-1">Arts</p><br /></div>
            <div class="container-fluid d-flex  bg-dark bg-opacity-50"><h5 class="d-inline-block text-primary m-2">Credit Hours:   </h5><p class="d-inline-block text-white m-2 p-1 ">5 hrs</p><br /></div>
            <div class="container-fluid d-flex  bg-dark bg-opacity-50"><h5 class="d-inline-block text-primary m-2">Type: </h5><p class="d-inline-block text-white m-2 p-1">Core</p><br /></div><br/><br/>
            </div>--%>

			</div>

		</div>


    </form>
</body>
</html>
