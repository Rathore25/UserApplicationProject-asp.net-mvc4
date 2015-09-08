﻿<%@ Page Language="C#" MasterPageFile="~/Shared/UserCreateUpdate.Master" Inherits="System.Web.Mvc.ViewPage<UserApplication.Models.UserModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        $(document).ready(
        function () {
            $("#Dob").datepicker({
                changeMonth: true,
                changeYear: true
            });
        }
        );
    </script>
    <script language="javascript" type="text/javascript">
        var nameLabel, dobLabel, cityLabel, phoneNumberLabel, emailIdLabel;
        function init() {
            nameLabel = document.getElementById('nameLabel');
            dobLabel = document.getElementById('dobLabel');
            cityLabel = document.getElementById('cityLabel');
            phoneNumberLabel = document.getElementById('phoneNumberLabel');
            emailIdLabel = document.getElementById('emailIdLabel');
        }
        function ClearValidation() {
            nameLabel.innerHTML = "&nbsp;";
            dobLabel.innerHTML = "&nbsp;";
            cityLabel.innerHTML = "&nbsp;";
            phoneNumberLabel.innerHTML = "&nbsp;";
            emailIdLabel.innerHTML = "&nbsp;";
            return true;
        }
        function Validate() {
            ClearValidation();
            var flag = true;
            var name = document.getElementById('Name');
            var dob = document.getElementById('Dob');
            var city = document.getElementById('City');
            var phoneNumber = document.getElementById('PhoneNumber');
            var emailId = document.getElementById('EmailId');
            var lengthOfPhoneNumber = ((phoneNumber.value).toString()).length;
            if (name.value == "") {
                nameLabel.innerHTML = "*Please enter a Name";
                flag = false;
                name.focus();
                return false;
            }
            if (dob.value == "") {
                dobLabel.innerHTML = "*Please enter date of birth";
                flag = false;
                dob.focus();
                return false;
            }
            if (lengthOfPhoneNumber == 0) {
                phoneNumberLabel.innerHTML = "*Please enter the phone number";
            }
            if (lengthOfPhoneNumber !=10) {
                phoneNumberLabel.innerHTML = "*Please enter a 10 digit phone number";
                flag = false;
                phoneNumber.focus();
                return false;
            }
            if (city.value == "") {
                cityLabel.innerHTML = "*Please enter city";
                flag = false;
                city.focus();
                return false;
            }
            if (emailId.value == "") {
                emailIdLabel.innerHTML = "*Please enter your EmailId";
                flag = false;
                emailId.focus();
                return false;
            }
            var emailPattern = "[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}"
            if ((emailId.value).match(emailPattern) == null) {
                emailIdLabel.innerHTML = "*Please enter a valid email id";
                flag = false;
                emailId.focus();
                return false;
            }
            return flag;
        }
    </script>

    <style type="text/css">
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
        #Div-Footer
        {
            background-color:transparent;
            margin-left:auto;
            margin-right:auto;
            width:300px;
            padding-top:10px;
            text-align: right;
        }
        .ChangeViewButton
        {
            text-decoration:none;
            color:rgb(51,79,78);
        }
        .ChangeViewButton:hover
        {
            color:rgb(255, 90, 0);
        }
        .ErrorLabel
        {
            font-size:12px;
            color:Red;
        }
    </style>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <div id="Div-Logo">
        <img id="Logo" src="../../Content/Images/oie_transparent.png" alt="Logo" />
    </div>
    <div id="Background0">
        <div id="Background1">
            <h1 style="font-size: 30px; text-align: center;">
                Create User
            </h1>
            <div id="Div-Form">
                <div class="Div-TextBox">
                    <%: Html.TextBoxFor(model => model.Name, new { @class = "TextBox", @PlaceHolder = "Name*" })%>
                    <label id="nameLabel" class="ErrorLabel">&nbsp;</label>
                </div>
                <div class="Div-TextBox">
                    <%: Html.TextBoxFor(model => model.Dob, new { @class = "TextBox", @PlaceHolder = "01/01/1900" })%>
                    <label id="dobLabel" class="ErrorLabel">&nbsp;</label>
                </div>
                <div class="Div-TextBox">
                    <%: Html.TextBoxFor(model => model.City, new { @class = "TextBox", @PlaceHolder = "City*" })%>
                    <label id="cityLabel" class="ErrorLabel">&nbsp;</label>
                </div>
                <div class="Div-TextBox">
                    <%: Html.TextBoxFor(model => model.PhoneNumber, new { @class = "TextBox", @PlaceHolder = "PhoneNumber" })%>
                    <label id="phoneNumberLabel" class="ErrorLabel">&nbsp;</label>
                </div>
                <div class="Div-TextBox">
                    <%: Html.TextBoxFor(model => model.EmailId, new { @class = "TextBox", @PlaceHolder = "Email Id*" })%>
                    <label id="emailIdLabel" class="ErrorLabel">&nbsp;</label>
                </div>
            </div>
            <div id="Div-SubmitButton">
                <button id="SubmitButton" onclick="return Validate()" type="submit">
                    Create</button>
            </div>
            <div id="Div-Footer">
                <%: Html.ActionLink("Back to List", "Index", "User",   
                    null, //   Route args if needed; null if not.
                    new { @class="ChangeViewButton"})%>
            </div>
        </div>
    </div>
    <% } %>
</asp:Content>
