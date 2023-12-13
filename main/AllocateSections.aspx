<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllocateSections.aspx.cs" Inherits="AllocateSections" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	 <meta name="viewport" content="width=device-width, initial-scale=1" />
	 <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
	 <link href="Ad.css" rel="stylesheet" />
    <title>Flex|Allocate Sections</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

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
		        <a class="nav-link " href="/AddCourse.aspx">
		         <i class="fa fa-slack"></i>
		          Add Courses
		        </a>
		      </li>


		      <li class="nav-item rounded-1" style="margin-left:10px;background-color:dodgerblue">
		        <a class="nav-link " href="#">
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
		        <a class="nav-link text-black-50" href="/AllocateSections.aspx">
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
        </div>


		<div class="container-fluid m-0 " style="background-image: url('https://wallpaperaccess.com/full/6802.jpg'); background-position: center; background-size: cover; background-repeat: no-repeat; height:auto">
		<br />
		<br />


			<div class="container-fluid d-flex bg-primary rounded-2" >
				<h2 style="color:white">Create New Section</h2>
			</div>

			<div class="d-flex flex-column">

					<div class="flex-grow-1">

						<h4 class="d-inline-block text-primary m-2" >Section ID: * </h4>
						<input runat="server" class="d-inline-block m-4 bg-dark opacity-50 text-light border-1 border-white rounded-2" id="_secid" type="text" />
						<br />

						<h4 class="d-inline-block text-primary m-2" >Section Name: * </h4>
						<input runat="server" class="d-inline-block m-4 bg-dark opacity-50 text-light border-1 border-white rounded-2" id="_name" type="text" />
						<br />

						<h4 class="d-inline-block text-primary m-2" >Batch: * </h4>
						<select runat="server"  class="d-inline-block m-4 bg-dark opacity-50 text-light border-1 border-white rounded-2" style="width:180px" id="_batch">
							<option value="2021">2021</option>
							<option value="2022">2022</option>
							<option value="2023">2023</option>
					    </select>
						<br />

						<h4 class="d-inline-block text-primary m-2" >Degree: * </h4>
						<select runat="server"  class="d-inline-block m-4 bg-dark opacity-50 text-light border-1 border-white rounded-2" style="width:180px" id="_deg">
							<option value="Computer Science">CS</option>		
					    </select>
						<br />

					</div>
					    
			
            
					<asp:Label ID="Label1" CssClass="container d-inline-block m-2 p-2 rounded-2 text-danger  " runat="server" Text="Label" Visible="False"></asp:Label>
					<br />
						<div class ="dflex flex-row align-content-center ">
							<asp:Button runat="server" class="btn btn-outline-success my-2 my-sm-0 m-2" Text=" Create +" ID="AddButton" OnClick="AddButton_Click"></asp:Button>
							
						</div>

				<br />
				<br />
			</div>


			<br />
		<br />


			<div class="container-fluid d-flex bg-primary rounded-2" >
				<h2 style="color:white">Allocate Section</h2>
			</div>

			<div class="d-flex flex-column">

					<div class="flex-grow-1">

						<h4 class="d-inline-block text-primary m-2" >Section ID: * </h4>
						<input runat="server" class="d-inline-block m-4 bg-dark opacity-50 text-light border-1 border-white rounded-2" id="_sec" type="text" />
						<br />

						<h4 class="d-inline-block text-primary m-2" >Roll Number: * </h4>
						<input runat="server" class="d-inline-block m-4 bg-dark opacity-50 text-light border-1 border-white rounded-2" id="_rnum" type="text" />
						<br />

					</div>
					    
			
            
					<asp:Label ID="Label2" CssClass="container d-inline-block m-2 p-2 rounded-2 text-danger  " runat="server" Text="Label" Visible="False"></asp:Label>
					<br />
						<div class ="dflex flex-row align-content-center ">
							<asp:Button runat="server" class="btn btn-outline-success my-2 my-sm-0 m-2" Text="Add Student +" type="submit" ID="Button1" OnClick="AddButton_Click"></asp:Button>
							
						</div>

				<br />
				<br />
			</div>

			<br />
			<br />
			<div class="container-fluid d-flex bg-primary rounded-2" >
				<h2 style="color:white">Current Sections Details</h2>
			</div>

			<div class="d-flex flex-row flex-nowrap  " style="overflow-x:scroll" >

			<asp:PlaceHolder runat="server" ID="_ydata"></asp:PlaceHolder>

<%--			<div class="container-fluid flex-grow-1 p-4 rounded-3 " style="width:1000px;">";
            <div class="container-fluid d-flex bg-primary rounded-2"><h2 style="color:white">SecID</h2></div>
           <div class="container-fluid d-flex bg-dark bg-opacity-50"><h5 class="d-inline-block text-primary m-2">Section Name:   </h5><p class="d-inline-block text-white m-2 p-1">Arts</p><br /></div>
            <div class="container-fluid d-flex  bg-dark bg-opacity-50"><h5 class="d-inline-block text-primary m-2">Batch:   </h5><p class="d-inline-block text-white m-2 p-1 ">5 hrs</p><br /></div>
            <div class="container-fluid d-flex  bg-dark bg-opacity-50"><h5 class="d-inline-block text-primary m-2">No of Students: </h5><p class="d-inline-block text-white m-2 p-1">Core</p><br /></div><br/><br/>
            </div>

			<div class="container-fluid flex-grow-2 p-4 rounded-3 " style="width:900px;">";
            <div class="container-fluid d-flex bg-primary rounded-2"><h2 style="color:white">a23fsf</h2></div>
           <div class="container-fluid d-flex bg-dark bg-opacity-50"><h5 class="d-inline-block text-primary m-2">Course Name:   </h5><p class="d-inline-block text-white m-2 p-1">Arts</p><br /></div>
            <div class="container-fluid d-flex  bg-dark bg-opacity-50"><h5 class="d-inline-block text-primary m-2">Credit Hours:   </h5><p class="d-inline-block text-white m-2 p-1 ">5 hrs</p><br /></div>
            <div class="container-fluid d-flex  bg-dark bg-opacity-50"><h5 class="d-inline-block text-primary m-2">Type: </h5><p class="d-inline-block text-white m-2 p-1">Core</p><br /></div><br/><br/>
            </div>--%>

			</div>

			<br />
					<br />

					<div class="container-fluid m-0 " >

						<div class="container-fluid d-flex rounded-2" style="background-color:dodgerblue" >
						<h2 style="color:white">View Students</h2>
						
						</div>
						
						<h4 class="d-inline-block text-primary">Section ID: </h4>
						<input runat="server" class="d-inline-block m-4 bg-dark opacity-50 text-light border-1 border-white rounded-2" id="_scID" type="text" />
						<asp:Button runat="server" class="btn btn-outline-success my-2 my-sm-0 m-2" Text="View" ID="ViewBtn" OnClick="ViewSt"></asp:Button>
						
						<br />
						<asp:Label ID="Label3" CssClass="container d-inline-block m-2 p-2 rounded-2 text-danger  " runat="server" Text="Label" Visible="False"></asp:Label>
						<br />

						<div class ="d-flex flex-column m-0 ">

							

							<asp:PlaceHolder runat="server" ID="_stdata"></asp:PlaceHolder>

						</div>
						

					</div>

					<br />
					<br />


			
		</div>




    </form>
</body>
</html>
