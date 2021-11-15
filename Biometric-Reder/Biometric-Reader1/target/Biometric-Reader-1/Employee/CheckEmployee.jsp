<%-- 
    Document   : CheckEmployee
    Created on : 24 Jun. 2021, 2:44:38 pm
    Author     : sorak
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head><script src="/Biometric-Reader/JavaScript/LocationReplace.js"></script>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <script src="https://code.jquery.com/jquery-3.1.1.min.js" crossorigin="anonymous"></script>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/semantic-ui@2.4.2/dist/semantic.min.css">
        <script src="https://cdn.jsdelivr.net/npm/semantic-ui@2.4.2/dist/semantic.min"></script>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Please Provide Password</title>
    </head>
    <%
        String ErrorMsg = "" + (String) session.getAttribute("ErrorMsg");
        if (!ErrorMsg.equals("null")) {
            ErrorMsg = (String) session.getAttribute("ErrorMsg");
        } else {
            ErrorMsg = "";
        }
    %>
    <body onload="loginDialog()">
        <!-- Clean up code press Shift+Alt+F -->
        <div class="ui left demo visible vertical inverted sidebar labeled icon menu">
            <a onClick="ToUploadFile()" class="item">
                <i class="upload icon"></i>
                Upload File
            </a> 
            <a onClick="ToEmployee()" class="item">
                <i class="address card icon"></i>
                Check Employee
            </a>
            <a onClick="ToExport()" class="item">
                <i class="file alternate outline icon"></i>
                Export File
            </a>
            <a onClick="ToHome()" class="item" 
               style="position: fixed;
               bottom: 0;
               width: 100%;">
                <i class="home icon"></i>
                Home
            </a>
        </div>
    <center><h1 class="ui block header">Employee Page</h1></center>
    <div id="Content" style="margin-left: 140px; margin-right:140px">
        <p>&nbsp;</p>
        <p>&nbsp;</p>
        <p>&nbsp;</p>
        <center>
            <form action="/Biometric-Reader/C201_ValidatePassword" method="post" id="PasswordForm">
                <div class="ui labeled input" id="passwordDiv">
                    <div class="ui label">
                        Password:
                    </div>
                    <input type="password" id="passwordIn" name="passwordIn" placeholder="Enter your password" required>
                </div>
                <p>&nbsp;</p>
                <div class="ui buttons">
                    <input type="submit" id="clearBtn" onclick="clearFile()" class="ui button"  value="Clear"/>
                    <button id="uploadPassword" class="ui positive button" >Submit</button>
                </div>
            </form>
        </center>
    </div>
</body>
<%
    session.removeAttribute("ErrorMsg");
%>
</html>
<script>
    var PasswordForm = Document.getElementById("PasswordForm");
    var div = Document.getElementById("passwordDiv");
    var passwordInput = Document.getElementById("passwordIn");
    function clearFile() {

        document.getElementById("PasswordForm").reset();
        div.innerHTML = "  ";
    }

    function loginDialog()
    {
        Message = " ";
        var Message = "" + "<%=ErrorMsg%>";
        if (Message === (""))
        {
        } else {
            window.alert(Message);
        }

    }

</script>