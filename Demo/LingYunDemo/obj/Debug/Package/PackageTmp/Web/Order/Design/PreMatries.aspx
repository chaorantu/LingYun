<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreMatries.aspx.cs" Inherits="LingYunDemo.Web.Order.Design.PreMatries" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ul runat="server" id="list">
    
        </ul>
    </div>
    </form>
    <script type="text/javascript">
        function urlLocation(value) {
            window.location = "UpLoadMatries.aspx?PlanID=" + value;
        }
    </script>
</body>
</html>
