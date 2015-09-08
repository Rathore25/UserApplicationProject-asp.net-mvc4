<%@ Page Language="C#" MasterPageFile="~/Shared/UserCreateUpdate.Master" Inherits="System.Web.Mvc.ViewPage<UserApplication.Models.UserModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        $(document).ready(
      function () {
          $("#Dob").datepicker
          ({
              changeMonth: true,
              changeYear: true
          });
      }
    );
    </script>
    <style type="text/css">
        #Div-Form
        {
            text-align: left;
            background-color: transparent;
            margin-left: auto;
            margin-right: auto;
            padding-bottom: 15px;
        }
        .Div-TextBox
        {
            padding-top: 5px;
            padding-bottom: 5px;
        }
        .TextBox
        {
            padding-left: 5px;
            height: 30px;
            font-size: 15px;
            border-radius: 9px;
            border-style: none;
            width: 98%;
            margin-left: auto;
            margin-right: auto;
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
            background: linear-gradient(rgb(217, 150, 80) 5%, rgb(180, 70, 30) 100%) rgb(217,133,59);
            -webkit-box-shadow: rgba(0,0,0,1) 0 1px 0;
            -moz-box-shadow: rgba(0,0,0,1) 0 1px 0;
            text-shadow: rgba(0,0,0,.4) 0 1px 0;
            font-family: 'Segoe UI' , Frutiger, 'Frutiger Linotype' , 'Dejavu Sans' , 'Helvetica Neue' , Arial, sans-serif;
        }
        #SubmitButton:hover
        {
            background: linear-gradient(rgb(230, 160, 90) 5%, rgb(180, 70, 30) 100%) rgb(217,133,59);
        }
        #SubmitButton:active
        {
            background-color: rgb(230,140,70);
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
        #Background0
        {
            text-align: center;
            color: rgb(51,79,78);
            height:400px;
            width:1350;
        }
        @keyframes bounceIn 
        {
            0%
            {
                    transform: scale(0.5);
                    opacity: 0;
            }
            70% 
            {
                    transform: scale(1.1);
                    opacity: 1;
            }
            100%   
            {
                    transform: scale(1);
            }
        }
        #Background1
        {
            width:350px;
            height:350px;
            border-style: solid;
            border-width: 3px;
            border-color: rgb(217,133,59);
            background-image: url("../../Content/Images/Polygon-final.jpg");
            background-color: transparent;
            padding: 20px;
            display: block;
            margin-left: auto;
            margin-right: auto;
            animation-duration:.5s;
            animation-name: bounceIn;
            animation-timing-function: ease-in-out;
            font-family: 'Segoe UI' , Frutiger, 'Frutiger Linotype' , 'Dejavu Sans' , 'Helvetica Neue' , Arial, sans-serif;
        }
    </style>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <div id="Background0">
        <div id="Background1">
            <h1 style="font-size: 30px; text-align: center;">
                Update User Details
            </h1>
            <div id="Div-Form">
                <div class="editor-field">
                    <%: Html.HiddenFor(model => model.Uid)%>
                    <%: Html.ValidationMessageFor(model => model.Uid)%>
                </div>
                <div class="Div-TextBox">
                    <%: Html.TextBoxFor(model => model.Name, new { @class = "TextBox", @PlaceHolder = "Username*" })%>
                </div>
                <div class="Div-TextBox">
                    <%: Html.TextBoxFor(model => model.Dob, new { @class = "TextBox", @PlaceHolder = "01/01/1900" })%>
                </div>
                <div class="Div-TextBox">
                    <%: Html.TextBoxFor(model => model.City, new { @class = "TextBox", @PlaceHolder = "Confirm Password*" })%>
                </div>
                <div class="Div-TextBox">
                    <%: Html.TextBoxFor(model => model.PhoneNumber, new { @class = "TextBox", @PlaceHolder = "Full name" })%>
                </div>
                <div class="Div-TextBox">
                    <%: Html.TextBoxFor(model => model.EmailId, new { @class = "TextBox", @PlaceHolder = "Email Id*" })%>
                </div>
            </div>
            <div id="Div-SubmitButton">
                <button id="SubmitButton" onclick="return Validate()" type="submit">
                    Update</button>
            </div>
        </div>
    </div>
    <% } %>
    <div class="Return">
        <%: Html.ActionLink("Back to List", "Index", "User") %>
    </div>
</asp:Content>
