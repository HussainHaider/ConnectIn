﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" EnableSessionState="true" Inherits="ConnectIN.Messages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <link rel="apple-touch-icon" sizes="76x76" href="../assets/img/apple-icon.png" />
    <link rel="icon" href="assests1/css/favicon.ico" />
    <%--    <link rel="icon" type="image/png" href="../assets/img/favicon.png" />--%>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />

    <title>Messages|ConnectIN</title>




    <meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0' name='viewport' />
    <meta name="viewport" content="width=device-width" />

    <!-- Bootstrap core CSS     -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />

    <!--  Material Dashboard CSS    -->
    <link href="assets/css/material-dashboard.css" rel="stylesheet" />

    <!--  CSS for Demo Purpose, don't include it in your project     -->
    <link href="assets/css/demo.css" rel="stylesheet" />

    <!--     Fonts and icons     -->
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Roboto:400,700,300|Material+Icons' rel='stylesheet' type='text/css' />
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
                        <li>
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
                        <li class="active">
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
                        <%--                   <div class="navbar-header">
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
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                        <i class="material-icons">dashboard</i>
                                        <p class="hidden-lg hidden-md">Dashboard</p>
                                    </a>
                                </li>
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                        <i class="material-icons">notifications</i>
                                        <%--                                                                                 <span class="notification">5</span>--%>
                                        <p class="hidden-lg hidden-md">Notifications</p>
                                    </a>
                                    <%--                                                                        <ul class="dropdown-menu">
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
                                        <%--                                                                                <p class="hidden-lg hidden-md">Profile</p>--%>
                                    </a>
                                </li>
                            </ul>
                            <form id="Form1" class="navbar-form navbar-right" role="search" runat="server">
                                <asp:TextBox ID="Search_txt" runat="server" placeholder="Search"></asp:TextBox>

                                <asp:ImageButton runat="server" ID="search" ImageUrl="assets/img/find.png" OnClick="search_Click1" />

                                <%--</form>--%>
                        </div>
                    </div>
                </nav>
                <div class="content">
                    <div class="container-fluid">
                        <div class="row">
                            <%--                           //start work--%>

                            <%--                            <form runat="server">--%>
                            <div class="container">
                                <div class="row">

                                    <div class="col-sm-3">
                                        <div class="panel panel-success">
                                            <div class="panel-heading">
                                                <h3 class="panel-title">Messages</h3>
                                            </div>
                                            <div class="panel-body">
                                                <asp:Panel runat="server" ID="panel"></asp:Panel>


                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-sm-7">
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <div class="panel panel-primary">
                                                    <div class="panel-heading">
                                                        <h3 class="panel-title">Write Message</h3>
                                                    </div>
                                                    <div class="panel-body">

                                                        <asp:TextBox ID="txtmessage" Font-Size="Medium" TextMode="MultiLine" Height="150" Width="600" runat="server"></asp:TextBox>
                                                        <br />
                                                        <hr />
                                                        <asp:Button Class="btn btn-primary btn-just-icon" ID="messagebtn" Text="Send" Width="150" Height="50px" runat="server" OnClick="messagebtn_Click" />
                                                        <asp:Panel runat="server" ID="txt"></asp:Panel>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            </form>



                            <%-- //end work--%>
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
