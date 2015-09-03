<%@ Page Language="C#"  MasterPageFile="~/Shared/UserCreateUpdate.Master" Inherits="System.Web.Mvc.ViewPage<UserApplication.Models.UserModel>" %>


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
    
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <h1 style="font-size: 30px; text-align: center;">
        Create User Form
    </h1>
    <div style="background-color: #eee;
         padding: 20px;
         width:300px;
         display: block;
         margin-left: auto;
         margin-right: auto;">
        <table id="CreateUser" style="margin-left: auto; margin-right: auto;">
            <tr>
                <td class="editor-label">
                    <%: Html.LabelFor(model => model.Name) %>
                </td>
                <td class="editor-field">
                    <%: Html.EditorFor(model => model.Name) %>
                </td>
                <td class="validation-field">
                    <%: Html.ValidationMessageFor(model => model.Name) %>
                </td>
            </tr>
            <tr>
                <td class="editor-label">
                    <%: Html.LabelFor(model => model.Dob) %>
                </td>
                <td class="editor-field">
                    <%: Html.EditorFor(model => model.Dob)%>
                </td>
                <td class="validation-field">
                    <%: Html.ValidationMessageFor(model => model.Dob)%>
                </td>
            </tr>
            <tr>
                <td class="editor-label">
                    <%: Html.LabelFor(model => model.City)%>
                </td>
                <td class="editor-field">
                    <%: Html.EditorFor(model => model.City)%>
                </td>
                <td class="validation-field">
                    <%: Html.ValidationMessageFor(model => model.City)%>
                </td>
            </tr>
            <tr>
                <td class="editor-label">
                    <%: Html.LabelFor(model => model.PhoneNumber)%>
                </td>
                <td class="editor-field">
                    <%: Html.EditorFor(model => model.PhoneNumber)%>
                </td>
                <td class="validation-field">
                    <%: Html.ValidationMessageFor(model => model.PhoneNumber)%>
                </td>
            </tr>
            <tr>
                <td class="editor-label">
                    <%: Html.LabelFor(model => model.EmailId)%>
                </td>
                <td class="editor-field">
                    <%: Html.EditorFor(model => model.EmailId)%>
                </td>
                <td class="validation-field">
                    <%: Html.ValidationMessageFor(model => model.EmailId)%>
                </td>
            </tr>
            <tr>
                <td>
                    <input type="submit" value="Create" />
                </td>
            </tr>
        </table>
        
    </div>
    <% } %>
    <div class="Return">
        <%: Html.ActionLink("Back to List", "Index", "User") %>
    </div>
</asp:Content>