<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<UserApplication.Models.LoginModel>" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Login</title>
    <style type="text/css">
        #Body
        {
            background-image:url("../../Content/Images/BlackWhiteAbstract-Polygon-Background-02-1024.jpg");
            height:100%;
            width:100%;
        }
       #Logo
        {
            width: 100px; 
            height: 40px;
            margin-left: auto; 
            margin-right: auto;
        }
        #Div-Logo
        {
            text-align: center;
            width:150px;
            margin-right:auto;
            margin-left:auto;
        }
        #Background0
        {
            background-image: url("../../Content/Images/Polygon-final.jpg");            
            text-align: center;
            color: rgb(51,79,78);
        }
        #Background1
        {
            background-color: transparent;
            padding: 20px;
            width: 300px;
            display: block;
            margin-left: auto;
            margin-right: auto;
        }
        #Div-Form
        {
            text-align:left;
            background-color: transparent;
            margin-left: auto;
            margin-right: auto;
            padding-bottom:15px;
        }
        .Div-TextBox
        {
            padding-top:5px;
            padding-bottom:5px;
        }
        .TextBox
        {
            height:30px;
            font-size:15px;
            border-radius:9px;
            border-style:none;
            width:98%;
            margin-left: auto;
            margin-right: auto;
        }
        .Heading
        {
            font-family:'Segoe UI', Frutiger, 'Frutiger Linotype', 'Dejavu Sans', 'Helvetica Neue', Arial, sans-serif;
        }
        #SubmitButton:active, #SubmitButton:focus, #SubmitButton.active
        {
            background-image: none;
            outline: 0;
            -webkit-box-shadow: none;
            box-shadow: none;
        }
        #SubmitButton
        {
            box-shadow: rgb(245, 151, 142) 0px 0px 0px 0px inset;
            border-radius: 6px;
            border: 1px solid rgb(208, 39, 24);
            display: inline-block;
            cursor: pointer;
            color: rgb(255, 255, 255);
            font-size: 17px;
            font-weight: bolder;
            padding: 8px 32px;
            text-decoration: none;
            text-shadow: rgb(129, 14, 5) 1px 2px 4px;
            background :linear-gradient(rgb(217, 150, 80) 5%, rgb(180, 70, 30) 100%) rgb(217,133,59);
            -webkit-box-shadow: rgba(0,0,0,1) 0 1px 0;
            -moz-box-shadow: rgba(0,0,0,1) 0 1px 0;
            text-shadow: rgba(0,0,0,.4) 0 1px 0;
            font-family:'Segoe UI', Frutiger, 'Frutiger Linotype', 'Dejavu Sans', 'Helvetica Neue', Arial, sans-serif;
            
        }
        #SubmitButton:hover
        {
            background: linear-gradient(rgb(230, 160, 90) 5%, rgb(180, 70, 30) 100%) rgb(217,133,59);
        }
        #SubmitButton:active
        {
            background-color:rgb(230,140,70);
        }
        #Div-SubmitButton
        {
            width: 150px;
            margin-left: auto;
            margin-right: auto;
            text-align: center;
        }
        *:focus
        {
            outline: 0;
        }        
    </style>
</head>
<body id="Body">
    <div id="Div-Logo">
        <img id="Logo" src="../../Content/Images/oie_transparent.png" alt="Logo" />
    </div>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <div id="Background0">
        <h1 class="Heading">
            Login</h1>
        <div id="Background1">
            <div id="Div-Form">
                <div class="Div-TextBox">
                    <%: Html.TextBoxFor(model => model.UserName, new { @class="TextBox", @PlaceHolder="Username*"})%>
                </div>
                <div class="Div-TextBox">
                    <%: Html.PasswordFor(model => model.Password, new { @class = "TextBox", @PlaceHolder = "Password*" })%>
                </div>
            </div>
            <div id="Div-SubmitButton">
                <button id="SubmitButton" type="submit">
                    Login</button>
            </div>
        </div>
    </div>
    <% } %>
    <div>
        <%: Html.ActionLink("New User", "Register","Home") %>
    </div>
</body>
</html>
