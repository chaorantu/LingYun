<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrePlan.aspx.cs" Inherits="LingYunDemo.Web.Order.Plan.PrePlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   
    

</head>
<body>
    <%--<form id="form1" runat="server">--%>
    <h4  style="height:32px;line-height:32px;padding-left:20px; border-bottom:3px solid #F53C4A;color:#000;font-size:16px;">项目列表</h4>
    <div id="qq" runat="server">
<ul runat="server" id="list">
    <li style="margin-bottom:10px;padding:12px 15px;line-height:26px; background:#E5E3E4;"></li>
        </ul>
      
    </div>

     <div id="Div1" runat="server" >
     
<ul runat="server" id="listf" >
    
        </ul>
          <input type="hidden" runat="server" id="identify" />
    </div> 
<script type="text/javascript">
    function urlLocation(value) {
       var identify= document.getElementById("identify").value;
       if (identify == 1) {
           window.location = "EditPlan.aspx?PlanID=" + value;
       }
       else {
           window.location = "EnsurePlan.aspx?PlanID=" + value;
       }
    }
</script>
    <%--</form>--%>
</body>

</html>
