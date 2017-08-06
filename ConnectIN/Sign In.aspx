<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sign In.aspx.cs" Inherits="ConnectIN.Sign_In" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Sign in | ConnectIN</title>
    <link rel="shortcut icon" href="http://icons.iconarchive.com/icons/yootheme/social-bookmark/32/social-linkedin-button-blue-icon.png" />
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <link rel="stylesheet" href="assests1/css/form-elements.css" />
    <link rel="stylesheet" href="assests1/css/style.css" />
    <style>

        body {
            background-image: url(connectin.jpg);
            background-size: 1400px 800px;
            background-repeat: no-repeat;
            background-position-x: 0;
            background-position-y: 0;
            background-position: center;
            overflow: hidden;
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
            font-size: 25px;
            background-color: #4db8ff;
        }
    </style>
</head>
<body>
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
                                 <label id="error_text" runat="server" class="p1">Your Password OR Email address is wrong</label>

<%--                                                                <asp:Panel ID="panelEducation" runat="server"></asp:Panel>--%>
                                <div class="form-top-left">
                                    <h3>Sign In</h3>
                                    <p>Fill in the form below to get instant access:</p>
                                </div>
                                <div class="form-top-right">
                                    <i class="fa fa-pencil"></i>
                                </div>
                            </div>
                            <div class="form-bottom">
                                <form role="form" method="post" class="registration-form" runat="server">
                                    <div class="form-group">
                                        <label class="sr-only" for="form-email">Email</label>
                                        <p>Email</p>
                                        <asp:TextBox ID="email_text" runat="server" Width="410px"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="sr-only" for="form-pssword">Password</label>
                                        <p>Password</p>
                                        
                                        <asp:TextBox ID="txtPassword" TextMode="password" runat="server" Width="410px"></asp:TextBox>

                                    </div>

                                    <asp:Button ID="Button1" runat="server" type="submit" Text="Sign In" Width="400px" class="btn color" Height="60px" OnClick="Button1_Click" />

                                    <div>
                                        <p>Not a member?<span><a href="Sign up.aspx"> Join Now</a></span></p>
                                    </div>

                                </form>
                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>

    </div>

</body>
</html>
