<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<UserApplication.Models.UserModel>>" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <%--<link id="Link1" runat="server" rel="shortcut icon" href="C:\\Users\\Nitish Kumar\\Downloads\\favicon.ico" type="image/x-icon"/>
    <link id="Link2" runat="server" rel="icon" href="C:\\Users\\Nitish Kumar\\Downloads\\favicon.ico" type="image/ico"/>--%>
    <style type="text/css">
       #Body 
       {
            font-family: "Segoe UI" , Frutiger, "Frutiger Linotype" , "Dejavu Sans" , "Helvetica Neue" , Arial, sans-serif;
            background-image: url("../../Content/Images/BlackWhiteAbstract-Polygon-Background-02-1024.jpg");
            height: 100%;
            width: 100%;
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
            width: 150px;
            margin-right: auto;
            margin-left: auto;
        }
        #Div-Background 
        {
            color: rgb(51,79,78);
            margin-left: auto;
            margin-right: auto;
            width: 1200px;
            height: 100%;
        }
        #Div-TableHeading
        {
            background-color: transparent;
            text-align: center;
            font-weight: bold;
        }
        #Div-Header
        {
            background-color: transparent;
            /* float: right; */
            width: 1000px;
            text-align: right;
            margin-left: auto;
            margin-right: auto;
            padding-top: 10px;
            padding-bottom: 10px;
        }
        @keyframes fadeInDown 
        { 
        0% { 
            opacity: 0; 
            transform: translateY(-20px); 
            } 
        100% { 
            opacity: 1; 
            transform: translateY(0); 
            } 
        }
        #Div-Table
        {
            /*background-image: url("../../Content/Images/Polygon-final.jpg");*/
            display: block;
            margin-left: auto;
            margin-right: auto;
            width: 1000px;
            /* margin-top: 65px; */
            margin-bottom: 100px;
            animation-duration: 1s;
            animation-name: fadeInDown;
            animation-timing-function: ease-in-out;
        }
        #Table
        {
            /*padding: 30px;*/
            margin-left: auto;
            margin-right: auto;
            background-color: transparent;
            width: 1000px;
            text-align: left;
            border-style: solid;
            /*border-color: rgb(217,133,59);*/
        }
        #Table td
        {
            padding-top: 10px;
            padding-bottom: 10px;
            border-style: solid;
            border-width: thin;
            border-collapse: collapse;
            border-color: rgb(51,79,78);
        }
        #Table th
        {
            padding-top: 10px;
            padding-bottom: 10px;
            border-style: solid;
            border-width: thin;
            border-collapse: collapse;
            border-color: rgb(51,79,78);            
        }
        #Table tr:nth-child(even)
        {
            background-color: #ddd;
        }
        #Table tr:nth-child(odd)
        {
            background-color:White;
        }
        .Button
        {
            text-decoration: none;
            color: rgb(51,79,78);
        }
        .Button:hover
        {
            color: rgb(255, 90, 0);
        }
    </style>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
</head>
<body id="Body">
    <div id="Div-Logo">
        <img id="Logo" src="../../Content/Images/oie_transparent.png" alt="Logo" />
    </div>
    <div id="Div-Background">
        <div id="Div-TableHeading">
            <h1 id="Heading">
                User Table</h1>
        </div>
        <div id="Div-Header">
            <%: Html.ActionLink("Create", "Create", "User",   
                    null, //   Route args if needed; null if not.
                    new { @class= "Button"})%>
            <%: Html.ActionLink("Logout", "Logout", "Home",   
                    null, //   Route args if needed; null if not.
                    new { @class = "Button" })%>
        </div>
        <div id="Div-Table">
            <table id="Table">
                <tr class="TableHead" style="background-color:rgb(51,79,78); color:White;">
                    <th>
                        Name
                    </th>
                    <th>
                        Date of Birth
                    </th>
                    <th>
                        City
                    </th>
                    <th style="text-align: right">
                        Phone Number
                    </th>
                    <th>
                        Email Id
                    </th>
                    <th style="text-align: center">
                        Action
                    </th>
                </tr>
                <% foreach (var User in Model)
                   { %>
                <tr class="TableRow">
                    <td>
                        <%= User.Name %>
                    </td>
                    <td>
                        <%= User.Dob %>
                    </td>
                    <td>
                        <%= User.City %>
                    </td>
                    <td style="text-align: right">
                        <%= User.PhoneNumber %>
                    </td>
                    <td>
                        <%= User.EmailId %>
                    </td>
                    <td style="text-align: center">
                        <%: Html.ActionLink("Edit", "Edit", "User",
                                        new { id = User.Uid },
                                        new { @class = "Button" })%>
                        <%: Html.ActionLink("Delete", "Delete", "User",
                                        new { uid = User.Uid }, //   Route args if needed; null if not.
                                        new { @class = "Button", onclick = "return confirm('Are you sure you wish to delete this article?');" })%>
                    </td>
                </tr>
                <% } %>
            </table>
        </div>
    </div>
</body>
</html>
