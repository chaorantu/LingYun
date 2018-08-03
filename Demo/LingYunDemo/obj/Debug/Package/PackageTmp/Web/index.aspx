<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LingYunDemo.Web.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="JS/jquery-1.6.1.js" type="text/javascript"></script>
    <script language="javascript" src="../includes/AdminIndex.js" type="text/javascript"></script>
    <script language="javascript" src="../includes/CommonCode.js" type="text/javascript"></script>
    <script language="javascript" src="../includes/FrameTab.js" type="text/javascript"></script>
    <script src="../includes/jquery.pack.js" type="text/javascript"></script>
    <link href="../includes/Guide.css" type="text/css" rel="stylesheet" />
    <link href="../includes/index.css" type="text/css" rel="stylesheet" />
    <link href="../includes/MasterPage.css" type="text/css" rel="stylesheet" />
</head>

  <frameset border="0" frameSpacing="0" rows="90, *" frameBorder="0">
<frame name="header" src="Header.aspx" frameBorder="0"  scrolling="no" />
<frameset cols="170,*">

<frame name="menu" src="Menu.aspx" frameBorder="0" noResize scrolling="yes"  />

  <frameset border="0" frameSpacing="0" rows="250, *" frameBorder="0">
  <frame name="Status" src="Status3.aspx" frameBorder="0" noResize />
<frame name="Data" src="" frameBorder="0" noResize />
</frameset>
</frameset>
</frameset>
<noframes>
</noframes>

</html>
