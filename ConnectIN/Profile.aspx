<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" EnableSessionState="true" Inherits="ConnectIN.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <link rel="apple-touch-icon" sizes="76x76" href="../assets/img/apple-icon.png" />
    <link rel="icon" href="assests1/css/favicon.ico" />
    <%--    <link rel="icon" type="image/png" href="../assets/img/favicon.png" />--%>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />

    <title>Profile|ConnectIN</title>

    <meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0' name='viewport' />
    <meta name="viewport" content="width=device-width" />

    <!-- Bootstrap core CSS     -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />

    <!--  Material Dashboard CSS    -->
    <link href="assets/css/material-dashboard.css" rel="stylesheet" />

    <!--  CSS for Demo Purpose, don't include it in your project     -->
    <link href="assets/css/demo.css" rel="stylesheet" />

    <!--     Fonts and icons     -->
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css" rel="stylesheet"/>
    <link href='http://fonts.googleapis.com/css?family=Roboto:400,700,300|Material+Icons' rel='stylesheet' type='text/css'/>
</head>
<body>

    <div>

        <div class="wrapper">

            <div class="sidebar" data-color="red" data-image="assets/img/sidebar-2.jpg">
                <!--
		        Tip 1: You can change the color of the sidebar using: data-color="purple | blue | green | orange | red"

		        Tip 2: you can also add an image using data-image tag
		    -->

                <div class="logo">
                    <a href="http://www.creative-tim.com" class="simple-text">Connect IN
				</a>
                </div>

                <div class="sidebar-wrapper">
                    <ul class="nav">
                        <li id="home">
                            <a href="Home.aspx">
                                <i class="material-icons">dashboard</i>
                                <p>Home</p>
                            </a>
                        </li>
                        <li class="active">
                            <a href="Profile.aspx" id="_Profile">
                                <i class="material-icons">person</i>
                                <p>User Profile</p>
                            </a>
                        </li>
                        <li>
                            <a href="job.aspx">
                                <i class="material-icons">content_paste</i>
                                <p>Jobs</p>
                            </a>
                        </li>
                        <li>
                            <a href="Search.aspx">
                                <i class="material-icons">library_books</i>
                                <p>Search</p>
                            </a>
                        </li>
                        <li>
                            <a href="EditS.aspx">
                                <i class="material-icons">bubble_chart</i>
                                <p>Edit</p>
                            </a>
                        </li>
                        <li>
                            <a href="Map.aspx">
                                <i class="material-icons">location_on</i>
                                <p>Maps</p>
                            </a>
                        </li>
                        <li>
                            <a href="notification.aspx">
                                <i class="material-icons text-gray">notifications</i>
                                <p>Notifications</p>
                            </a>
                        </li>
                        <li>
                            <a href="Messages.aspx">
                                <i class="material-icons text-gray">message</i>
                                <p>Messages</p>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="main-panel">
                <nav class="navbar navbar-transparent navbar-absolute">
                    <div class="container-fluid">
                        <%--                        <div class="navbar-header">
                            <button type="button" class="navbar-toggle" data-toggle="collapse">
                                <span class="sr-only">Toggle navigation</span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                            <a class="navbar-brand" href="#">Material Dashboard</a>
                        </div>--%>
                        <div class="collapse navbar-collapse">
                            <ul class="nav navbar-nav navbar-right">
                                <li>
                                    <a href="Home.aspx" class="dropdown-toggle" data-toggle="dropdown">
                                        <i class="material-icons">dashboard</i>
                                        <p class="hidden-lg hidden-md">Dashboard</p>
                                    </a>
                                </li>
                                <li class="dropdown">
                                    <a href="notification.aspx" class="dropdown-toggle" data-toggle="dropdown">
                                        <i class="material-icons">notifications</i>
                                        <%--                                         <span class="notification">5</span>--%>
                                        <p class="hidden-lg hidden-md">Notifications</p>
                                    </a>
                                    <%--                                    <ul class="dropdown-menu">
                                        <li><a href="#">Mike John responded to your email</a></li>
                                        <li><a href="#">You have 5 new tasks</a></li>
                                        <li><a href="#">You're now friend with Andrew</a></li>
                                        <li><a href="#">Another Notification</a></li>
                                        <li><a href="#">Another One</a></li>
                                    </ul>--%>
                                </li>
                                <li>
                                    <a href="Sign In.aspx" class="dropdown-toggle" data-toggle="dropdown">
                                        <i class="material-icons">person</i>
                                        <%--                                        <p class="hidden-lg hidden-md">Profile</p>--%>
                                    </a>
                                </li>
                            </ul>


                            <form class="navbar-form navbar-right" role="search" runat="server">
                                <asp:TextBox ID="Search_txt" runat="server" placeholder="Search"></asp:TextBox>

                                <asp:ImageButton runat="server" ID="search" ImageUrl="assets/img/search1.png" OnClick="search_Click1" Width="30" Height="30" />
                                <%-- <div class="form-group  is-empty">
                                    <input type="text" class="form-control" placeholder="Search" />
                                    <span class="material-input"></span>
                                </div>
                                <button type="submit" class="btn btn-white btn-round btn-just-icon">
                                    <i class="material-icons">search</i><div class="ripple-container"></div>
                                </button>
                            </form>--%>
                        </div>
                    </div>
                </nav>
                <div class="content">
                    <div class="container-fluid">
                        <div class="row">
                            <%--                            //start code--%>
                            <%--                            <form runat="server">--%>
                            <asp:Label ID="label1" runat="server"></asp:Label>
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-10">
                                            <div class="card">
                                                <asp:Image ID="Image1" class="img-thumbnail" runat="server" Height="200" Width="200" />

                                                <asp:Label ID="label2" runat="server"></asp:Label>

                                                <asp:Panel ID="panel1" runat="server"></asp:Panel>
                                                <hr />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <%-- Summary Box --%>
                            <asp:Label ID="label5" runat="server"></asp:Label>
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-10">
                                            <div class="card">
                                                <div class="card-header" data-background-color="blue">
                                                    <h3 class="title">Summary</h3>
                                                    <div class="text-right">
                                                        <asp:Button Class="btn btn-primary btn-just-icon" ID="Edit" Text="Edit" Width="200" Height="50px" runat="server" OnClick="Edit_Click" />
                                                    </div>
                                                </div>
                                                <div class="card-content">
                                                    <asp:Panel ID="panelSummary" runat="server"></asp:Panel>
                                                    <hr />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>




                            <%-- Experience Box --%>
                            <asp:Label ID="label3" runat="server"></asp:Label>
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-10">
                                            <div class="card">
                                                <div class="card-header" data-background-color="blue">
                                                    <h3 class="title">Experience</h3>
                                                    <%--                                                        <div class="text-right">
                                                            <asp:Button Class="btn btn-primary btn-just-icon" ID="edit_experience" Text="Edit Experience" Width="200" Height="50px" runat="server" OnClick="edit_experience_Click" />
                                                        </div>--%>
                                                </div>
                                                <div class="card-content">
                                                    <asp:Panel ID="panelExperience" runat="server"></asp:Panel>
                                                    <hr />
                                                    <div align="center">
                                                        <asp:Button Class="btn btn-primary btn-round " ID="addExperience" runat="server" Width="150" Height="50px" Text="Add Experience" OnClick="addExperience_Click" />
                                                    </div>
                                                    <asp:Label class="label label-info" ID="label_addExperience_company" runat="server" Text="Company Name"></asp:Label>
                                                    <br />
                                                    <asp:TextBox ID="addExperience_company" runat="server" Width="300"></asp:TextBox>
                                                    <br />


                                                    <asp:Label class="label label-info" ID="label_addExperience_title" runat="server" Text="title"></asp:Label>
                                                    <br />
                                                    <asp:TextBox ID="addExperience_title" runat="server" Width="100"></asp:TextBox>
                                                    <br />

                                                    <asp:Label class="label label-info" ID="label_addExperience_Sdate" runat="server" Text="Start Date"></asp:Label>
                                                    <%--<br />--%>
                                                    <asp:TextBox ID="addExperience_Sdate" runat="server" Width="100"></asp:TextBox>

                                                    <asp:Calendar ID="Calendar3" runat="server" OnSelectionChanged="Calendar3_SelectionChanged"></asp:Calendar>
                                                    <br />

                                                    <asp:Label class="label label-info" ID="label_addExperience_Edate" runat="server" Text="End Date"></asp:Label>

                                                    <asp:TextBox ID="addExperience_Edate" runat="server" Width="100"></asp:TextBox>

                                                    <asp:Calendar ID="Calendar4" runat="server" OnSelectionChanged="Calendar4_SelectionChanged"></asp:Calendar>
                                                    <br />

                                                    <asp:Label class="label label-info" ID="label_addExperience_type" runat="server" Text="Type"></asp:Label>
                                                    <br />
                                                    <asp:TextBox ID="addExperience_type" runat="server" Width="100"></asp:TextBox>
                                                    <br />


                                                    <asp:Label class="label label-info" ID="label_addExperience_Description" runat="server" Text="Description"></asp:Label>
                                                    <br />
                                                    <asp:TextBox ID="addExperience_Description" TextMode="MultiLine" runat="server" Height="100" Width="700"></asp:TextBox>
                                                    <asp:Button Class="btn btn-primary btn-just-icon" ID="addExperiencebtn" Text="Save" Width="150" Height="50px" runat="server" OnClick="addExperiencebtn_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <%-- Education Box --%>
                            <asp:Label ID="label4" runat="server"></asp:Label>
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-10">
                                            <div class="card">
                                                <div class="card-header" data-background-color="blue">
                                                    <h3 class="title">Education</h3>
                                                    <%--                                                        <div class="text-right">
                                                            <asp:Button Class="btn btn-primary btn-just-icon" ID="edit_Education" Text="Edit Education" Width="200" Height="50px" runat="server" OnClick="edit_Education_Click" />
                                                        </div>--%>
                                                </div>
                                                <div class="card-content">
                                                    <asp:Panel ID="panelEducation" runat="server"></asp:Panel>
                                                    <hr />
                                                    <div align="center">
                                                        <asp:Button Class="btn btn-primary btn-round " ID="addEducation" runat="server" Width="150" Height="50px" Text="Add Education" OnClick="addEducation_Click" />
                                                    </div>
                                                    <asp:Label class="label label-info" ID="label_addEducation_school" runat="server" Text="School"></asp:Label>
                                                    <br />
                                                    <asp:TextBox ID="addEducation_school" runat="server" Width="300"></asp:TextBox>
                                                    <br />
                                                    <asp:Label class="label label-info" ID="label_addEducation_SDate" runat="server" Text="Start Date"></asp:Label>
                                                    <%--<br />--%>
                                                    <asp:TextBox ID="addEducation_SDate" runat="server" Width="100"></asp:TextBox>

                                                    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                                                    <br />

                                                    <asp:Label class="label label-info" ID="label_addEducation_EDate" runat="server" Text="End Date"></asp:Label>
                                                    <%--<br />--%>
                                                    <asp:TextBox ID="addEducation_EDate" runat="server" Width="100"></asp:TextBox>

                                                    <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged"></asp:Calendar>
                                                    <br />

                                                    <asp:Label class="label label-info" ID="label_addEducation_Field" runat="server" Text="Field of Study"></asp:Label>
                                                    <br />
                                                    <asp:TextBox ID="addEducation_Field" runat="server" Width="100"></asp:TextBox>
                                                    <br />


                                                    <asp:Label class="label label-info" ID="label_addEducation_Description" runat="server" Text="Description"></asp:Label>
                                                    <br />
                                                    <asp:TextBox ID="addEducation_Description" TextMode="MultiLine" runat="server" Height="100" Width="700"></asp:TextBox>
                                                    <asp:Button Class="btn btn-primary btn-just-icon" ID="addEducationbtn" Text="Save" Width="150" Height="50px" runat="server" OnClick="addEducationbtn_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <%-- Honors & Awards Box --%>
                            <asp:Label ID="label8" runat="server"></asp:Label>
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-10">
                                            <div class="card">
                                                <div class="card-header" data-background-color="blue">
                                                    <h3 class="title">Honors & Awards</h3>
                                                    <%--                                                        <div class="text-right">
                                                            <asp:Button Class="btn btn-primary btn-just-icon" ID="edit_Awards" Text="Edit Awards" Width="200" Height="50px" runat="server" OnClick="edit_Awards_Click" />
                                                        </div>--%>
                                                </div>
                                                <div class="card-content">
                                                    <asp:Panel ID="panelHonors" runat="server"></asp:Panel>
                                                    <hr />
                                                    <div align="center">
                                                        <asp:Button Class="btn btn-primary btn-round " ID="add_award" runat="server" Width="200" Height="50px" Text="Add Honors & Awards" OnClick="add_award_Click" />
                                                    </div>
                                                    <asp:Label class="label label-info" ID="label_addaward_occupation" runat="server" Text="Title"></asp:Label>
                                                    <br />
                                                    <asp:TextBox ID="addaward_occupation" runat="server" Width="300"></asp:TextBox>
                                                    <br />
                                                    <asp:Label class="label label-info" ID="label_addaward_Date" runat="server" Text="Date"></asp:Label>
                                                    <br />
                                                    <asp:TextBox ID="addaward_Date" runat="server" Width="100"></asp:TextBox>
                                                    <br />
                                                    <asp:Label class="label label-info" ID="label_addaward_Description" runat="server" Text="Description"></asp:Label>
                                                    <br />
                                                    <asp:TextBox ID="addaward_Description" TextMode="MultiLine" runat="server" Height="100" Width="700"></asp:TextBox>
                                                    <asp:Button Class="btn btn-primary btn-just-icon" ID="add_awardbtn" Text="Save" Width="150" Height="50px" runat="server" OnClick="add_awardbtn_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <%-- Skills & Endorsements Box --%>
                            <asp:Label ID="label6" runat="server"></asp:Label>
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-10">
                                            <div class="card">
                                                <div class="card-header" data-background-color="blue">
                                                    <h3 class="title">Skills</h3>
                                                    <%--                                                        <div class="text-right">
                                                            <asp:Button Class="btn btn-primary btn-just-icon" ID="edit_Skill" Text="Edit Skills" Width="200" Height="50px" runat="server" OnClick="edit_Skill_Click" />
                                                        </div>--%>
                                                </div>
                                                <div class="card-content">
                                                    <asp:Panel ID="panelSkills" runat="server"></asp:Panel>
                                                    <hr />
                                                    <div align="center">
                                                        <asp:Button Class="btn btn-primary btn-round " ID="add_skill" runat="server" Width="150" Height="50px" Text="Add Skill" OnClick="add_skill_Click" />
                                                    </div>
                                                    <asp:Label class="label label-info" ID="label_add_skill" runat="server" Text="Skill"></asp:Label>
                                                    <br />
                                                    <asp:TextBox ID="add_skill_text" runat="server" Width="200"></asp:TextBox>
                                                    <asp:Button Class="btn btn-primary btn-just-icon" ID="add_skillbtn" Text="Save" Width="150" Height="45px" runat="server" OnClick="add_skillbtn_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>



                            <%-- Languages Box --%>
                            <asp:Label ID="label7" runat="server"></asp:Label>
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-10">
                                            <div class="card">
                                                <div class="card-header" data-background-color="blue">
                                                    <h3 class="title">Language</h3>
                                                    <%--                                                        <div class="text-right">
                                                            <asp:Button Class="btn btn-primary btn-just-icon" ID="edit_Language" Text="Edit Languages" Width="200" Height="50px" runat="server" OnClick="edit_Language_Click" />
                                                        </div>--%>
                                                </div>
                                                <div class="card-content">
                                                    <asp:Panel ID="panelLanguages" runat="server"></asp:Panel>
                                                    <hr />
                                                    <div align="center">
                                                        <asp:Button Class="btn btn-primary btn-round" ID="add_Language" runat="server" Width="150" Height="50px" Text="Add Language" OnClick="add_Language_Click" />
                                                    </div>
                                                    <asp:Label class="label label-info" ID="label_add_Language" runat="server" Text="Language"></asp:Label>
                                                    <br />
                                                    <asp:TextBox ID="add_Language_text" runat="server" Width="300"></asp:TextBox>
                                                    <asp:Button Class="btn btn-primary btn-just-icon" ID="add_Languagebtn" Text="Save" Width="150" Height="50px" runat="server" OnClick="add_Languagebtn_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <%-- Project Box --%>
                            <asp:Label ID="labels1" runat="server"></asp:Label>
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-10">
                                            <div class="card">
                                                <div class="card-header" data-background-color="blue">
                                                    <h3 class="title">Project</h3>
                                                    <%--                                                        <div class="text-right">
                                                            <asp:Button Class="btn btn-primary btn-just-icon" ID="edit_projects" Text="Edit Projects" Width="200" Height="50px" runat="server" OnClick="edit_projects_Click" />
                                                        </div>--%>
                                                </div>
                                                <div class="card-content">
                                                    <asp:Panel ID="panelproject" runat="server"></asp:Panel>
                                                    <hr />
                                                    <div align="center">
                                                        <asp:Button Class="btn btn-primary btn-round " ID="addproject" runat="server" Width="150" Height="50px" Text="Add Project" OnClick="addproject_Click" />
                                                    </div>
                                                    <asp:Label class="label label-info" ID="label_addproject_title" runat="server" Text="Title"></asp:Label>
                                                    <br />
                                                    <asp:TextBox ID="addprojectext_title" runat="server" Width="300"></asp:TextBox>
                                                    <br />
                                                    <asp:Label class="label label-info" ID="label_addproject_Description" runat="server" Text="Description"></asp:Label>
                                                    <br />
                                                    <%--                            <asp:Panel ID="paneladdproject" runat="server"></asp:Panel>--%>
                                                    <asp:TextBox ID="addprojectext_Description" TextMode="MultiLine" runat="server" Height="100" Width="700"></asp:TextBox>
                                                    <asp:Button Class="btn btn-primary btn-just-icon" ID="addprojectbtn" Text="Save" Width="150" Height="50px" runat="server" OnClick="addprojectbtn_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            </form>


                            <%--                            //END code--%>
                            <footer class="footer">
                                <div class="container-fluid">
                                    <nav class="pull-left">
                                        <ul>
                                            <li>
                                                <a href="#">Home
								</a>
                                            </li>
                                            <li>
                                                <a href="#">Company
								</a>
                                            </li>
                                            <li>
                                                <a href="#">Portfolio
								</a>
                                            </li>
                                            <li>
                                                <a href="#">Blog
								</a>
                                            </li>
                                        </ul>
                                    </nav>
                                    <p class="copyright pull-right">
                                        &copy;
                            <script>document.write(new Date().getFullYear())</script>
                                        <a href="http://www.creative-tim.com">Creative Tim</a>, made with love for a better web
				
                                    </p>
                                </div>
                            </footer>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</body>
</html>
