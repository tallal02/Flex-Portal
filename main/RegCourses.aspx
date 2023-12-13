<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegCourses.aspx.cs" Inherits="RegCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

		<meta name="viewport" content="width=device-width, initial-scale=1" />
		<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
		<link href="Ad.css" rel="stylesheet" />
    <title>Flex|Register Courses</title>
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

				
		      <li class="nav-item rounded-1 " style="margin-left:10px;background-color:dodgerblue">
		          <a class="nav-link " href="/ADashBoard.aspx">
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
		        <a class="nav-link text-black-50" href="#">
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

		 

		<div class="container-fluid m-0 " style="background-image: url('https://wallpaperaccess.com/full/6802.jpg'); background-position: center; background-size: cover; background-repeat: no-repeat; height:auto">
		<br />
		<br />
						<div class="d-flex flex-column">

							     <div class="flex-grow-1">

								<h4 class="d-inline-block text-primary m-2" >Roll-number: * </h4>
								<input runat="server" class="d-inline-block m-4 bg-dark opacity-50 text-light border-1 border-white rounded-2" id="_rollnum" type="text" />
								<br />

								<h4 class="d-inline-block text-primary m-2" >Course code: * </h4>
								<input runat="server" class="d-inline-block m-4 bg-dark opacity-50 text-light border-1 border-white rounded-2" id="_ccode" type="text" />
								<br />

			

								<h4 class="d-inline-block text-primary m-2">Select year: * </h4>

							   <select runat="server"  class="d-inline-block m-4 bg-dark opacity-50 text-light border-1 border-white rounded-2" style="width:180px" id="_cyear">
								<option value="2021">2021</option>
								<option value="2022">2022</option>
								<option value="2023">2023</option>
							  </select>

						   </div>
					    
			
            
							<asp:Label ID="Label1" CssClass="container d-inline-block m-2 p-2 rounded-2 text-danger  " runat="server" Text="Label" Visible="False"></asp:Label>
							<div class ="d-flex flex-row">

								<br />
							<div class ="flex-grow-1 align-content-center ">
								<asp:Button runat="server" class="btn btn-outline-success my-2 my-sm-0 m-2" Text="Register" type="submit" ID="AddButton" OnClick="RegAccept"></asp:Button>
								
							</div>
							<br />
							<div class ="flex-grow-1 align-content-center ">
								<asp:Button runat="server" class="btn btn-outline-success my-2 my-sm-0 m-2" Text="Register all Pending" type="submit" ID="APending" OnClick="RegP"></asp:Button>
								
							</div>
							<br />
							<div class ="flex-grow-1 align-content-center ">
								<asp:Button runat="server" class="btn btn-outline-success my-2 my-sm-0 m-2" Text="Register all Non-Registered" type="submit" ID="ANReg" OnClick="RegN"></asp:Button>
								
							</div>

							</div>
							

				</div>

				<div class="container-fluid m-0 ">
				<br />
				<br />

					<div class="container-fluid d-flex bg-success p-2 rounded-2 justify-content-center" >
						<h2 style="color:white">Registered Students</h2>
					</div>




					<div class="container-fluid d-flex flex-column bg-dark bg-opacity-50 m-0">
					<br />
					<br />

					<div class="container-fluid m-0 " >

						<div class="container-fluid d-flex rounded-2" style="background-color:dodgerblue" >
						<h2 style="color:white">Batch 2021</h2>
						</div>
						
						<div class ="d-flex flex-column m-0 ">

							

							<asp:PlaceHolder runat="server" ID="_y1data"></asp:PlaceHolder>

						</div>
						

					</div>

					<br />
					<br />

					<div class="container-fluid m-0 " >

						<div class="container-fluid d-flex rounded-2" style="background-color:dodgerblue" >
						<h2 style="color:white">Batch 2022</h2>
						</div>
						
						<div class ="d-flex flex-column m-0 ">

							<asp:PlaceHolder runat="server" ID="_y2data"></asp:PlaceHolder>

						</div>
						

					</div>

					<br />
					<br />

					<div class="container-fluid m-0 " >

						<div class="container-fluid d-flex rounded-2" style="background-color:dodgerblue" >
						<h2 style="color:white">Batch 2023</h2>
						</div>
						
						<div class ="d-flex flex-column m-0 ">

							<asp:PlaceHolder runat="server" ID="_y3data"></asp:PlaceHolder>

						</div>
						

					</div>

					<br />
					<br />


					</div>

					
					
					<br />

			</div>


			<div class="container-fluid m-0 ">
				<br />
				<br />

					<div class="container-fluid d-flex bg-warning p-2 rounded-2 justify-content-center" >
						<h2 style="color:white">Pending Students</h2>
					</div>




					<div class="container-fluid d-flex flex-column bg-dark bg-opacity-50 m-0">
					<br />
					<br />

					<div class="container-fluid m-0 " >

						<div class="container-fluid d-flex rounded-2" style="background-color:dodgerblue" >
						<h2 style="color:white">Batch 2021</h2>
						</div>
					
						<div class ="d-flex flex-column m-0 ">

							

							<asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>

						</div>
						

					</div>

					<br />
					<br />

					<div class="container-fluid m-0 " >

						<div class="container-fluid d-flex rounded-2" style="background-color:dodgerblue" >
						<h2 style="color:white">Batch 2022</h2>
						</div>
						
						<div class ="d-flex flex-column m-0 ">

							<asp:PlaceHolder runat="server" ID="PlaceHolder2"></asp:PlaceHolder>

						</div>
						

					</div>

					<br />
					<br />

					<div class="container-fluid m-0 " >

						<div class="container-fluid d-flex rounded-2" style="background-color:dodgerblue" >
						<h2 style="color:white">Batch 2023</h2>
						</div>
					
						<div class ="d-flex flex-column m-0 ">

							<asp:PlaceHolder runat="server" ID="PlaceHolder3"></asp:PlaceHolder>

						</div>
						

					</div>

					<br />
					<br />


					</div>
					<br />

			</div>

						<div class="container-fluid m-0 ">
				<br />
				<br />

					<div class="container-fluid d-flex bg-danger p-2 rounded-2 justify-content-center" >
						<h2 style="color:white">Non-Registered Students</h2>
					</div>




					<div class="container-fluid d-flex flex-column bg-dark bg-opacity-50 m-0">
					<br />
					<br />

					<div class="container-fluid m-0 " >

						<div class="container-fluid d-flex rounded-2" style="background-color:dodgerblue" >
						<h2 style="color:white">Batch 2021</h2>
						</div>
					
						<div class ="d-flex flex-column m-0 ">

							

							<asp:PlaceHolder runat="server" ID="PlaceHolder4"></asp:PlaceHolder>

						</div>
						

					</div>

					<br />
					<br />

					<div class="container-fluid m-0 " >

						<div class="container-fluid d-flex rounded-2" style="background-color:dodgerblue" >
						<h2 style="color:white">Batch 2022</h2>
						</div>
						
						<div class ="d-flex flex-column m-0 ">

							<asp:PlaceHolder runat="server" ID="PlaceHolder5"></asp:PlaceHolder>

						</div>
						

					</div>

					<br />
					<br />

					<div class="container-fluid m-0 " >

						<div class="container-fluid d-flex rounded-2" style="background-color:dodgerblue" >
						<h2 style="color:white">Batch 2023</h2>
						</div>
					
						<div class ="d-flex flex-column m-0 ">

							<asp:PlaceHolder runat="server" ID="PlaceHolder6"></asp:PlaceHolder>

						</div>
						

					</div>

					<br />
					<br />


					</div>
					<br />

			</div>

		</div>


    </form>
</body>
</html>
<%--<div class="container-fluid d-flex flex-row justify-content-around bg-dark bg-opacity-50 text-primary " style="border:dashed">

								<div class="flex-grow-1 d-flex flex-column" >

								<div class="flex-grow-1"><h5 class="d-inline-block text-primary m-2">Roll-number:  </h5><p class="d-inline-block text-white m-2 p-1">i212487</p><br /></div>
								<div class="flex-grow-1"><h5 class="d-inline-block text-primary m-2">Name:  </h5><p class="d-inline-block text-white m-2 p-1">Kalsoom Tariq</p><br /></div>
								<div class="flex-grow-1"><h5 class="d-inline-block text-primary m-2">Course Code:  </h5><p class="d-inline-block text-white m-2 p-1">CL1002</p><br /></div>
								
									
								</div>
								 <div class="flex-grow-1 align-content-center justify-content-center">
									
									<asp:Button runat="server" class="btn btn-outline-success p-4 m-4" Text="Register"  OnClick="RegAccept"></asp:Button>
								 </div>

							</div>
							<br />--%>