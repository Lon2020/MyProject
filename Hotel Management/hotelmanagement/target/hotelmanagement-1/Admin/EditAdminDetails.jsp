<%@page import="Model.*"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <script src="/hotelmanagement/JavaScript/LocationReplace.js"></script>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <script src="https://code.jquery.com/jquery-3.1.1.min.js" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/semantic-ui@2.4.2/dist/semantic.min"></script>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/semantic-ui@2.4.2/dist/semantic.min.css">
        <title>Edit Details</title>
    </head>
    <%
        String sesh = (String) session.getAttribute("passwordError");
        String usernameCheck = (String) session.getAttribute("UserErr");
        String samePassword = (String) session.getAttribute("PasswordErr");
        Admin user = (Admin) session.getAttribute("user");
        String adminLoginCheck = (String) session.getAttribute("adminLoginCheck");
    %>
    <body onload="passwordCheck()">
        <div class="ui middle aligned grid" 
             style="margin-top: 100px; margin-left: 20%; margin-right:20%">
            <div class="column">
                <h1>
                    <div class="content">
                        Edit Details
                    </div>
                </h1>
                <form class="ui form segment" action="/hotelmanagement/L112_AdminEditDetails" method="post">
                    <div class="field">
                        <label>Old Email</label>
                        <input value="<%=user.getUsername()%>" autocomplete="off" required name="oldEmail" type="email" readonly>
                        <p id="existingEmail"></p>      
                    </div>
                    <div class="field">
                        <label>Password</label>
                        <input value="<%=user.getPassword()%>" placeholder="Enter password" autocomplete="off" required name="password" type="password">
                    </div>
                    <div class="field">
                        <label>Confirm password</label>
                        <input placeholder="Re-enter Password" autocomplete="off" required name="confirmPassword" type="password">
                    </div>
                    <div id="differentPassword"><p><p></div>
                    <div class="two fields" style="margin-left: 1px">
                        <button type="submit" class="ui green medium submit button">Confirm Changes</button>
                        <button type="button" onClick="ToAdminAccount()" class="ui medium button">Cancel</button>
                    </div>
                </form>
            </div>
        </div>
        <script>
            function passwordCheck() {

                var checker = "" + "<%=sesh%>";
                const checkAdminLogin = "" + "<%=adminLoginCheck%>";
                if (checkAdminLogin === ("null")) {
                    setTimeout(() => {
                        ;
                    }, 0);
                    window.location.href = "http://localhost:8080/hotelmanagement/";
                } else if (checker !== ("null")) {//if password is not the same
                    alert("Password is not the same.");
                }
            }
            ;
        </script>
        <%
            session.removeAttribute("UserErr");
            session.removeAttribute("PasswordErr");
            session.removeAttribute("passwordError");
        %>
    </body>
</html>
