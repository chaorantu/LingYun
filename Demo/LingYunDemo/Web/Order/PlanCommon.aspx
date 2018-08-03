<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanCommon.aspx.cs" Inherits="LingYunDemo.Web.Order.PlanCommon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<h4  style="height:32px;line-height:32px;padding-left:20px; border-bottom:3px solid #F53C4A;color:#000;font-size:16px;">用户导航：所有项目</h4>
    <form id="form1" runat="server">
    <div>
    <ul runat="server" id="list">
    
        </ul>
    </div>
    </form>
    <script type="text/javascript">
        function urlLocation(value, value2) {
            window.location = "MatriesCommon.aspx?PlanID=" + value+"&Type="+value2;
        }
    </script>
</body>
</html>
