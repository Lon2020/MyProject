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
    <%
        String NoDate = "" + (String) session.getAttribute("NoDate");
        if (!NoDate.equals("null")) {
            NoDate = (String) session.getAttribute("NoDate");
        } else {
            NoDate = "";
        }
    %>
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
    <div id="content" style="margin-left: 140px; margin-right:140px">
        <p>&nbsp;</p>
        <h3>Month and year</h3>

        <!-- Search Servlet Form -->
        <form action="/Biometric-Reader/C202_SearchDate" method="get">
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
        <p>&nbsp;</p>

        <!-- Save Employee Servlet Form-->
        <form >
            <table class="ui sortable grey celled  table">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Department</th>
                        <th>Normal Wages</th>
                        <th>Bonus Wages</th>
                        <th>BPJS</th>
                        <th>Beasiswa Sekolah</th>
                        <th>Monthly Bonus</th>
                    </tr>
                </thead>
                <tbody>
                    <%
                        ArrayList<Employee> employeeList = (ArrayList<Employee>) session.getAttribute("employeeList");
                        for (Employee e : employeeList) {
                    %>
                    <tr>
                        <td><%=e.getName()%></td>
                        <td><%=e.getDepartment()%></td>
                        <td><input type="text" name="<%=e.getName()%>normalWage" value =<%=e.getNormalWage()%>></td>
                        <td><input type="text" name="<%=e.getName()%>bonusWage" value =<%=e.getBonusWage()%>></td>
                        <td><input type="text" name="<%=e.getName()%>BPJS" value =<%=e.getBonusWage()%>></td> <!-- Need to add get in model -->
                        <td><input type="text" name="<%=e.getName()%>Beasiswa" value =<%=e.getBonusWage()%>></td> <!-- Need to add get in model -->
                        <td><input type="text" name="<%=e.getName()%>MBonus" value =""></td> <!-- Need to add get in model -->
                    </tr>
                    <%}%>
                </tbody>
            </table>
            <input type="submit" id="clearBtn" onclick="clearFile()" class="ui button"  value="Clear"/>
            <button id="saveEmployee" class="ui positive button" >Search</button>
        </form>
    </div>
</body>
</htmSl>
<script>
    $('#example7').calendar({
        type: 'month'
    });


</script>