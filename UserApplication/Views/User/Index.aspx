<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<UserApplication.Models.UserModel>>" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">

    <%--<link id="Link1" runat="server" rel="shortcut icon" href="C:\\Users\\Nitish Kumar\\Downloads\\favicon.ico" type="image/x-icon"/>
    <link id="Link2" runat="server" rel="icon" href="C:\\Users\\Nitish Kumar\\Downloads\\favicon.ico" type="image/ico"/>--%>
    
    <style type="text/css">
        p.Create
        {
            margin : 5px;
            float :right;
            text-align:center;
            background-color:#fff;
            font-size : 20px;
            color:Black;
            width: 80px;
            border-style : outset;
        }
        table td
        {
             padding-top: 10px;
             padding-bottom : 10px;
            }
        table tr:nth-child(even)
        {
            background-color: #eee;
        }
        table tr:nth-child(odd)
        {
            background-color:#fff;
        }
        table th
        {
            padding-top: 10px;
            padding-bottom : 10px;
        }
        table
        {
            font-family: "Segoe UI", Frutiger, "Frutiger Linotype", "Dejavu Sans", "Helvetica Neue", Arial, sans-serif;
            }
    </style>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
</head>
<body>
    <div style=" background-color:#eee;padding-bottom:10px;">
    <div><h2 style="margin-bottom: 5px; text-align:center; font-size : 35px;">User Table</h2></div>

    <p class="Create"><%: Html.ActionLink("Create","Create","User") %></p>

        <table border="1" style="width:100% ; padding: 20px 20px; background-color :#fff;">
            <tr style="background: linear-gradient(gray, white); text-align :left; ">
                <th>Name</th>
                <th>Date of Birth</th>
                <th>City</th>
                <th style="text-align:right">Phone Number</th>
                <th>Email Id</th>
                <th style="text-align:center">Action</th>
            </tr>
            <% foreach( var User in Model) { %>
            <tr>
                <td><%= User.Name %></td>
                <td><%= User.Dob %></td>
                <td><%= User.City %></td>
                <td style="text-align :right"><%= User.PhoneNumber %></td>
                <td><%= User.EmailId %></td>
                <td style="text-align:center"><%: Html.ActionLink("Edit", "Edit", "User",new { id = User.Uid }, new { id = User.Uid })%> 
                    <%: Html.ActionLink("Delete", "Delete", "User", new { uid = User.Uid }, new { onclick = "return confirm('Are you sure you wish to delete this article?');" })%>
                </td>
            </tr>
            <% } %>
        </table>  
    </div>
    <div>
        <%: Html.ActionLink("Logout", "Logout","Home") %>
    </div>
</body>
</html>