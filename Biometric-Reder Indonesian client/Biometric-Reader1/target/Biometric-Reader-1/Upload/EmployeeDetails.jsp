
<%@page import="DAO.MongoDBManager"%>
<%@page import="Model.Employee"%>
<%@page import="java.util.ArrayList"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <script>
            var array = [];
        </script>
        <title>Employee List</title>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <script src="/Biometric-Reader/JavaScript/LocationReplace.js"></script>
        <script src="https://code.jquery.com/jquery-3.1.1.min.js" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/semantic-ui@2.4.2/dist/semantic.min"></script>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/semantic-ui@2.4.2/dist/semantic.min.css">
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
               width: 10%;">
                <i class="home icon"></i>
                Home
            </a>
        </div>
    <center><h1 class="ui block header">Employee List</h1></center>
    <br>
    <center>
        <div id="Content" style="margin-left: 140px;">
            <div class="container">
                <form class="ui form" action="/Biometric-Reader/C103_SaveToDatabase" method="post" id="saveToDatabase">
                    <div class="ui labeled input">
                        <div class="ui label"> Monthly Off</div>
                        <input type="text" id="monthlyOff" style="width: 10rem" name="monthlyOff">
                    </div>
                    <table class="ui celled fixed table">
                        <thead>
                            <tr>
                                <th>Employee Name</th>
                                <th>Department</th>
                                <th>Normal Wage</th>
                                <th>Bonus Wage</th>
                                <th>Sick</th> 
                                <th>Swap</th>
                                <th id="swapNameHeader" style="display: none">Swap Name</th>
                            </tr> 
                        <thead>
                        <datalist id="browsers">  </datalist> 
                            <%
                                ArrayList<Employee> employeeList = (ArrayList<Employee>) session.getAttribute("employeeList");
                                for (Employee e : employeeList) {
                            %>
                        <tr>
                            <td><p id="<%=e.getName()%>employeeName"><%=e.getName()%></p></td> 
                            <td><%=e.getDepartment()%></td>
                            <td><div class="ui small input"><input type="text" name="<%=e.getName()%>normalWage" value =<%=e.getNormalWage()%>></div></td> 
                            <td><div class="ui small input"><input type="text" name="<%=e.getName()%>bonusWage" value =<%=e.getBonusWage()%>></div></td>
                            <td><div class="ui small input"><input type="text" name="<%=e.getName()%>sick" value =""></div></td>
                            <td><div class="ui small input"><input type="text" id="<%=e.getName()%>swapNum" name="<%=e.getName()%>swapNum" value="" onChange="generate(this.value, '<%=e.getName()%>')"></div></td>
                            <td id="<%=e.getName()%>colSwap" class="swapNameData" style="display: none"></td>
                        </tr>
                        <script>
                            var dataList = document.getElementById("browsers");
                            array.push("<%=e.getName()%>");
                            dataList.innerHTML = dataList.innerHTML + "<option value=" + "<%=e.getName()%>" + ">"
                        </script>
                        <%}%>
                    </table>
                    <button class="big ui negative button" onClick="ToUploadFile()">Cancel</button>
                    <button class="big ui positive button" type="submit">Save</button>
                </form>
            </div>
        </div>
    </center>
</body>
</html>
<script>
    function generate(numSwap, employeeName) { //generate the textbox based on input
        var cSwap = document.getElementById(employeeName + "colSwap");
        
        document.getElementById("swapNameHeader").setAttribute("style", "");
        cSwap.setAttribute("style", "");
        
        while (cSwap.hasChildNodes()) {
            cSwap.removeChild(cSwap.firstChild);
        }
        for (i = 0; i < numSwap; i++) {
            var divInput = document.createElement("div");
            divInput.setAttribute("class", "ui small input");
            divInput.setAttribute("id", employeeName + "input" + i.toString());
            var input = document.createElement("input");
            input.setAttribute("type", "text");
            input.setAttribute("list", "browsers");
            input.setAttribute("id", employeeName + "employeeSelect" + i.toString());
            input.setAttribute("name", '' + employeeName + 'employeeSelect' + i.toString());
            input.setAttribute("value", "");
            var cfunction = "compareName('" + employeeName + "employeeSelect" + i.toString() + "','" + employeeName + "employeeName')";
            input.setAttribute("onChange", cfunction);
            cSwap.appendChild(divInput);
            var divInput = document.getElementById(employeeName + "input" + i.toString());
            divInput.appendChild(input);
        }
    }
    function compareName(thisId, employeeName) {
        var value = document.getElementById(thisId).value.toString();
        var name = document.getElementById(employeeName).innerHTML.toString();
        if (value === name) {
            alert("same");
            document.getElementById(thisId).value = "";
        } else if (!array.includes(value)) {
            alert("incorrect input");
            document.getElementById(thisId).value = "";
        }
    }
</script>

