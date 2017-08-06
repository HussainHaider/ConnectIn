<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="ConnectIN.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--    <asp:ContentPlaceHolder ID="head" runat="server"></asp:ContentPlaceHolder>--%>
    <meta charset="utf-8" />
    <link rel="apple-touch-icon" sizes="76x76" href="../assets/img/apple-icon.png" />
    <link rel="icon" href="assests1/css/favicon.ico" />
    <%--    <link rel="icon" type="image/png" href="../assets/img/favicon.png" />--%>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />

    <title>Admin</title>

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

            <div class="sidebar" data-color="purple" data-image="assets/img/sidebar-2.jpg">
                <!--
		        Tip 1: You can change the color of the sidebar using: data-color="purple | blue | green | orange | red"

		        Tip 2: you can also add an image using data-image tag
		    -->

                <%--<div class="logo">
                    <a href="http://www.creative-tim.com" class="simple-text">Connect IN
                    </a>
                </div>

                <div class="sidebar-wrapper">
                    <ul class="nav">
                        <li class="active" id="home">
                            <a href="Home.aspx">
                                <i class="material-icons">dashboard</i>
                                <p>Home</p>
                            </a>
                        </li>
                        <li>
                            <a href="Profile.aspx" id="Profile">
                                <i class="material-icons">person</i>
                                <p>User Profile</p>
                            </a>
                        </li>
                        <li>
                            <a href="table.html">
                                <i class="material-icons">content_paste</i>
                                <p>Table List</p>
                            </a>
                        </li>
                        <li>
                            <a href="typography.html">
                                <i class="material-icons">library_books</i>
                                <p>Typography</p>
                            </a>
                        </li>
                        <li>
                            <a href="icons.html">
                                <i class="material-icons">bubble_chart</i>
                                <p>Icons</p>
                            </a>
                        </li>
                        <li>
                            <a href="maps.html">
                                <i class="material-icons">location_on</i>
                                <p>Maps</p>
                            </a>
                        </li>
                        <li>
                            <a href="notifications.html">
                                <i class="material-icons text-gray">notifications</i>
                                <p>Notifications</p>
                            </a>
                        </li>
                    </ul>
                </div>--%>
            </div>

            <div class="main-panel">

                <div class="content">
                    <div class="container-fluid">
                        <div class="row">
                            <%-- //start work--%>
                            <%--                            <asp:ContentPlaceHolder ID="ContentPlaceHolder1" runat="server"></asp:ContentPlaceHolder>--%>
                            <form runat="server">
                            <h3>Add Job</h3>
                            <br />
                            <asp:TextBox runat="server" ID="name" Height="36px" Width="190px" placeholder="Name of job"></asp:TextBox>
                            <br />
                            <asp:TextBox runat="server" ID="company" Height="36px" Width="190px" placeholder="Company Name"></asp:TextBox>
                            <br />
                            <asp:TextBox runat="server" ID="description" Height="67px" Width="626px" placeholder="Description of Company"></asp:TextBox>
                            <br />
                            <asp:TextBox runat="server" ID="skill1"  Height="36px" Width="190px" placeholder="skill Name"></asp:TextBox>
                            <br />
                            <asp:TextBox runat="server" ID="skill2"  Height="36px" Width="190px" placeholder="skill Name"></asp:TextBox>
                            <asp:Button runat="server" ID="add_job" Height="36px" Width="190px" OnClick="add_job_Click" Text="Add Job" />

                            <asp:Label ID="label17" runat="server"></asp:Label>
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-10">
                                            <div class="card">
                                                <div class="card-content">
                                                    <asp:Panel ID="notification_panel" runat="server"></asp:Panel>
                                                    <hr />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            </form>
                            <%-- //END work--%>
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
