<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<UserApplication.Models.LoginModel>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Login</title>
</head>
<body>
    <script src="<%: Url.Content("~/Scripts/jquery-1.7.1.min.js") %>"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"></script>
    
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true) %>
        <p>
            <table id="LoginTable">
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
        </p>
        
    <% } %>
    
    <%--<div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>--%>
</body>
</html>
