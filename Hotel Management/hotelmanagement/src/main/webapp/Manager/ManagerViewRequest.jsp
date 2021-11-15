<%-- 
    Document   : StaffViewRequest
    Created on : Oct 22, 2021, 1:25:08 AM
    Author     : leeki
--%>
<%@page import="DAO.MongoDBManager"%>
<%@page import="Model.Booking"%>
<%@page import="java.util.ArrayList"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <script src="/hotelmanagement/JavaScript/LocationReplace.js"></script>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <script src="https://code.jquery.com/jquery-3.1.1.min.js" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/semantic-ui@2.4.2/dist/semantic.min"></script>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/semantic-ui@2.4.2/dist/semantic.min.css">

        <title>All Bookings</title>
    </head>
    <%
        Booking b = (Booking) session.getAttribute("bookingRequest");
    %>
        <body onload="checkLogin()">
        <div>
            <!-- Top menu bar !-->
            <div class="ui inverted vertical center aligned segment">
                <div class="ui container">
                    <div class="ui large secondary inverted pointing menu">
                        <a onClick="ToManagerIndex()" class="item">
                            HOME
                        </a>
                        <a onClick="ToManagerRoom()" class="item">
                            ROOMS
                        </a>
                        <a onClick="ToManagerRoomManage()" class="item">
                            ROOM MANAGEMENT
                        </a>
                        <a onClick="ToManagerDining()" class="item">
                            DINING 
                        </a>
                        <a onClick="ToManagerAbout()" class="item">
                            ABOUT US
                        </a>
                        <a onClick="ToManagerContact()" class="item">
                            CONTACT 
                        </a>
                        <a onClick="ToManagerBooking()" class="active item">
                            VIEW BOOKINGS
                        </a>
                        <a onClick="ToManagerAccountsList()" class="item">
                            VIEW ACCOUNTS
                        </a>
                        <a onClick="ToManagerRegister()" class="item">
                            CREATE AN ACCOUNT
                        </a>

                        <div class="right item">
                            <a onClick="ToManagerAccount()" class="ui right floated inverted button" style="margin-right: 10px">My Account</a>
                            <a onClick="ToHome()" class="ui right floated inverted button">Log Out</a>
                        </div>
                    </div>
                </div>   
            </div>
        </div> 
    <center>
        <div style="margin-top: 90px">
            <h1>
                <div class="content">
                    Requested Items/Service
                </div>
            </h1>
            <div style="margin-top: 50px; margin-left: 600px; margin-right:600px">
                <table class="ui large black table" >
                    <tbody>
                    <thead>
                        <tr><th>Pillow</th>
                            <td><%=b.getPillow()%></td> 
                        </tr>
                        <tr><th>Blanket</th>
                            <td> <%=b.getBlanket()%></td>
                        </tr>
                        <tr><th>Slippers</th>
                            <td> <%=b.getSlippers()%></td>
                        </tr>
                        <tr><th>Towel</th>
                            <td> <%=b.getTowel()%></td>
                        </tr>
                        <tr><th>Others</th>
                            <td> <%=b.getOthers()%></td>
                        </tr>
                        <tr><th>Pick up service</th>
                            <td> <%=b.isPickUpService()%></td>
                        </tr>
                    </thead>
                    </tbody>
                </table>
            </div> 
        </div> 
    </center>
</body>
</html>


