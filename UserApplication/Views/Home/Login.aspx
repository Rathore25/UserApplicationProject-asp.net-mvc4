<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<UserApplication.Models.LoginModel>" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Login</title>
    <style type="text/css">
        #LoginBackground0
        {
            background-image: url("../../Content/Images/triangles_abstract_wallpaper.png");
        }
        #LoginBackground1
        {
            background-color: transparent;
                                            padding: 20px;
                                            width:300px;
                                            display: block;
                                            margin-left: auto;
                                            margin-right: auto;
        }
        #LoginTable
        {
            background-color: transparent;margin-left: auto;margin-right: auto;
        }
    </style>
</head>
<body>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <div id="Logo" style="text-align: center">
        <img src="../../Content/Images/tumblr_m8rakxnbAe1r85i4so1_500.gif" alt="Logo" style="width: 80px;
            height: 40px; margin-left: auto; margin-right: auto;" />
    </div>
    <div id="LoginBackground0" >
    <h1 style="text-align: center">Login Page</h1>
        <div id="LoginBackground1" >
            <table id="LoginTable" >
                <tr>
                    <td>
                        <%: Html.LabelFor(model => model.UserName) %>
                    </td>
                    <td>
                        <%: Html.EditorFor(model => model.UserName) %>
                    </td>
                    <td>
                        <%: Html.ValidationMessageFor(model => model.UserName) %>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%: Html.LabelFor(model => model.Password)%>
                    </td>
                    <td>
                        <%: Html.EditorFor(model => model.Password)%>
                    </td>
                    <td>
                        <%: Html.ValidationMessageFor(model => model.Password)%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="submit" value="Create" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <% } %>
    <div>
        <%: Html.ActionLink("New User", "Register","Home") %>
    </div>
</body>
</html>
