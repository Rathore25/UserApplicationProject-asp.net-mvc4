<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>ErrorPage</title>
    <style type="text/css">
        #HeadingName
        {
            color: #3A5919;
            padding-top:30px;
        }
        #Div-Body
        {
            background-image: url("../../Content/Images/Polygon-final.jpg");
            text-align: center;
            color: #3A5919;
            padding-bottom:30px;
        }
    </style>
</head>
<body id="Body">
    <div id="Div-Body">
        <div id="Div-HeadingName">
            <h1 id="HeadingName">
                Error Page
            </h1>
        </div>
        <div id="Div-ErrorMessage">
            <%: ViewBag.ErrorMessage %>
        </div>
    </div>
    <div class="Return">
        <%: Html.ActionLink("Back to List", "Index","User") %>
    </div>
</body>
</html>
