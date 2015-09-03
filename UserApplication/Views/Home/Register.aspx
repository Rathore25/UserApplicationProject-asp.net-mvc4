<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<UserApplication.Models.RegisterModel>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Register</title>
</head>
<body>    
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true) %>
            <table id="RegisterTable">
                <tr>
                    <td class="Label">
                        <%: Html.LabelFor(model => model.UserName) %>
                    </td>
                    <td>
                        <%: Html.EditorFor(model => model.UserName) %>
                    </td>
                    <td class="Validation">
                        <%: Html.ValidationMessageFor(model => model.UserName) %>
                    </td>
                </tr>
                <tr>
                    <td class="Label">
                        <%: Html.LabelFor(model => model.Password)%>
                    </td>
                    <td>
                        <%: Html.EditorFor(model => model.Password)%>
                    </td>
                    <td class="Validation">
                        <%: Html.ValidationMessageFor(model => model.Password)%>
                    </td>
                </tr>
                <tr>
                    <td class="Label">
                        <%: Html.LabelFor(model => model.ConfirmPassword)%>
                    </td>
                    <td>
                        <%: Html.EditorFor(model => model.ConfirmPassword)%>
                    </td>
                    <td class="Validation">
                        <%: Html.ValidationMessageFor(model => model.ConfirmPassword)%>
                    </td>
                </tr>
                <tr>
                    <td class="Label">
                        <%: Html.LabelFor(model => model.FullName)%>
                    </td>
                    <td>
                        <%: Html.EditorFor(model => model.FullName)%>
                    </td>
                    <td class="Validation">
                        <%: Html.ValidationMessageFor(model => model.FullName)%>
                    </td>
                </tr>
                <tr>
                    <td class="Label">
                        <%: Html.LabelFor(model => model.EmailId)%>
                    </td>
                    <td>
                        <%: Html.EditorFor(model => model.EmailId)%>
                    </td>
                    <td class="Validation">
                        <%: Html.ValidationMessageFor(model => model.EmailId)%>
                    </td>
                </tr>
                <tr>
                    <td class="Label">
                        <input type="submit" value="Create" />
                    </td>
                </tr>
            </table>
    <% } %>
    
    <div>
        <%: Html.ActionLink("Old User", "Login","Home") %>
    </div>
</body>
</html>
