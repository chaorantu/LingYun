\<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="LingYunDemo.Web.UserLogin" %>

 <HTML>
<HEAD>
<TITLE>用户登录</TITLE>
<META http-equiv=Content-Type content="text/html; charset=utf-8">
<LINK 
href="images/public.css" type=text/css rel=stylesheet>
<LINK 
href="images/login.css" type=text/css rel=stylesheet>

<META content="MSHTML 6.00.2900.5848" name=GENERATOR>
<script type="text/javascript">
       function Validate() {
            var username = document.getElementById("TxtUserName").value;
            var psd = document.getElementById("TxtPassword").value;
            if (username == null || username == "") {
                alert("用户名不能为空");
                return false;
            }
            else if (psd == null || psd == "") {
                alert("密码不能为空");
                return false;
            }
            else {
                return true;
            }
           
        }

    </script>
</HEAD>
<BODY>
<DIV id=div1>
<form runat="server">
  <TABLE id=login height="100%" cellSpacing=0 cellPadding=0 width=800  
align=center>
    <TBODY>
      <TR id=main>
        <TD>
          <TABLE height="100%" cellSpacing=0 cellPadding=0 width="100%"  >
            <TBODY>
              <TR>
                <TD colSpan=4>&nbsp;</TD>
              </TR>
              <TR height=30>
                <TD width=380>&nbsp;</TD>
                <TD>&nbsp;</TD>
                <TD>凌云科技有限公司</TD>
                <TD>&nbsp;</TD>
              </TR>
              <TR height=40>
                <TD rowSpan=4>&nbsp;</TD>
                <TD>用户名：</TD>
                <TD>
                  <INPUT runat="server" class=textbox id="TxtUserName" name="TxtUserName" />
                </TD>
                <TD width=120>&nbsp;</TD>
              </TR>
              <TR height=40>
                <TD>密　码：</TD>
                <TD>
                  <INPUT  runat="server" class=textbox id="TxtPassword" type="password" 
            name="txtUserPassword" />
                </TD>
                <TD width=&nbsp;</TD>
              </TR>
              
              <TR height=40>
                <TD></TD>
                  
                <TD align="left">
                <asp:Button ID="btnLogin" OnClientClick=" return Validate()" runat="server" 
                        Text=" 登 录" onclick="btnLogin_Click1" />
                </TD>
                <TD width=120>&nbsp;</TD>
              </TR>
              <TR height=110>
                <TD colSpan=4>&nbsp;</TD>
              </TR>
            </TBODY>
          </TABLE>
        </TD>
      </TR>
      <TR id="root" height=104>
        <TD>&nbsp;</TD>
      </TR>
    </TBODY>
  </TABLE>
  </form>
</DIV>
<DIV id=div2 style="DISPLAY: none"></DIV>
</BODY>
</HTML>
