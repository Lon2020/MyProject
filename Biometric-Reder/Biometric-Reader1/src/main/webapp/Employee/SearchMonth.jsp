<%-- 
    Document   : ListEmployee
    Created on : 25 Jun. 2021, 2:44:51 am
    Author     : sorak
--%>

<%@page import="java.util.ArrayList"%>
<%@page import="Model.Employee"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <script src="/Biometric-Reader/JavaScript/LocationReplace.js"></script>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <script src="https://code.jquery.com/jquery-3.1.1.min.js" crossorigin="anonymous"></script>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/semantic-ui@2.4.2/dist/semantic.min.css">
        <script src="https://cdn.jsdelivr.net/npm/semantic-ui@2.4.2/dist/semantic.min"></script>
        <script src="https://cdn.rawgit.com/mdehoog/Semantic-UI/6e6d051d47b598ebab05857545f242caf2b4b48c/dist/semantic.min.js"></script>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Please Provide Password</title>
    </head>
    <body>
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
    <center><h1 class="ui block header">Employee List</h1></center>
    <center>
        <div id="content" style="margin-left: 140px; margin-right:140px">
            <p>&nbsp;</p>

            <h3>Select Month & Year to process</h3>
            <!-- Search Servlet Form -->
            <form action="/Biometric-Reader/C202_SearchDate" method="GET">
                <div class="ui calendar" id="example7">
                    <div class="ui input left icon">
                        <i class="calendar icon"></i>
                        <input type="text" placeholder="Month and Year" name="calender">
                    </div>
                </div>
                <br>
                <input type="submit" id="clearBtn" onclick="clearFile()" class="ui button"  value="Clear"/>
                <button id="searchMonth" class="ui positive button" >Search</button>
            </form>  
        </div>
    </center>
</body>
</htmSl>
<script>
    $('#example7').calendar({
        type: 'month'
    });


</script>