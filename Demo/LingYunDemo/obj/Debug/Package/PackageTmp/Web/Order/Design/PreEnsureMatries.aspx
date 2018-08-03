<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreEnsureMatries.aspx.cs" Inherits="LingYunDemo.Web.Order.Design.PreEnsureMatries" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            window.location = "EnsureMatries.aspx?PlanID=" + value;
        }
    </script>
</body>
</html>
