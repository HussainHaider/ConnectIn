<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sign up.aspx.cs" Inherits="ConnectIN.Sign_up" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up | ConnectIN</title>
    <link rel="shortcut icon" href="http://icons.iconarchive.com/icons/yootheme/social-bookmark/32/social-linkedin-button-blue-icon.png" />
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <script>
        function checkEmail() {

            var email = document.getElementById('TextBox7').value;
            alert('Email:' + email);
            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            var filter1 = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            if (!filter.test(email)) {
                alert('Please provide a valid email address');
                email.focus;
                return false;
            }
        }
        function check_Validity() {
            var v1 = document.getElementById('First_name').value;
            if (v1 == '') {
                alert("Please enter the FirstName");
            }

            var v1 = document.getElementById('Last_name').value;
            if (v1 == '') {
                alert("Please enter the LastName");
            }

            var v1 = document.getElementById('TextBox1').value;
            if (v1 == '') {
                alert("Please enter the Password");
            }
            var v1 = document.getElementById('email_text').value;
            if (v1 == '') {
                alert("Please enter the Email address");
            }
        }


    </script>

    <!-- CSS  -->
    <link rel="stylesheet" href="assests1/css/form-elements.css" />
    <link rel="stylesheet" href="assests1/css/style.css" />
    <style>
        body {
            background-color: #067FAA;
        }

        h1 {
            color: white;
        }

        p {
            color: white;
        }

        .p1 {
            color: red;
        }

        .color {
            font-family: "Arial Black", Gadget, sans-serif;
            font-size: 30px;
            background-color: #4db8ff;
        }
    </style>
</head>
<body>
    <img src="https://media.frankwatching.com/app/uploads/2010/02/connectin-logo.jpg" alt="Connect-IN" />

    <h1><b>Make the most of your professional life</b> </h1>
    <!-- Top content -->
    <div class="top-content">
        <div>
            <div class="container">
                <div class="row">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-1"></div>

                    <div class="col-sm-5">

                        <div class="form-box">
                            <div class="form-top">
                                                                <asp:Image runat="server" ImageUrl="assets/img/warning.png" Height="30" Width="30" ID="error_image" ForeColor="Red"/>
                                <label id="error_text" runat="server" class="p1">Fill the form completely</label>
                                <asp:Panel ID="panelEducation" runat="server"></asp:Panel>
                                <div class="form-top-left">
                                    <h3>Sign up now</h3>
                                    <p>Fill in the form below to get instant access:</p>
                                </div>
                                <div class="form-top-right">
                                    <i class="fa fa-pencil"></i>
                                </div>
                            </div>
                            <div class="form-bottom">
                                <form role="form" method="post" class="registration-form" runat="server">
                                    <div class="form-group">
                                        <label class="sr-only" for="form-first-name">First name</label>
                                        <p>First Name</p>
                                        <asp:TextBox ID="First_name" runat="server" Width="410px"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="sr-only" for="form-last-name">Last name</label>
                                        <p>Last Name</p>
                                        <asp:TextBox ID="Last_name" runat="server" Width="410px"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="sr-only" for="form-email">Email</label>
                                        <p>Email</p>
                                        <asp:TextBox ID="email_text" runat="server" Width="410px"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="sr-only" for="form-pssword">Password</label>
                                        <p>Password</p>
                                        <asp:TextBox ID="password_text" TextMode="password" runat="server" Width="410px"></asp:TextBox>
                                    </div>

                                    <div>
                                        <p>By clicking Join now, you agree to ConnectIn's User Agreement, Privacy Policy, and Cookie Policy</p>
                                    </div>
                                    <asp:Button ID="indb" runat="server" Width="400px" class="btn color" Height="60px" OnClientClick="Javascript:checkEmail();check_Validity()" Text="Join Now" OnClick="indb_Click" />
                                </form>
                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>

    </div>
    <p>
        ConnectIN Corporation © 2016
    </p>
</body>
</html>
