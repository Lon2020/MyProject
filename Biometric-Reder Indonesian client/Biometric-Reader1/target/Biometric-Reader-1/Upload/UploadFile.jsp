<%-- 
    Document   : UploadFile
    Created on : 11 Jun. 2021, 2:21:29 am
    Author     : sorak
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <script src="/Biometric-Reader/JavaScript/LocationReplace.js"></script>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <script src="https://code.jquery.com/jquery-3.1.1.min.js" crossorigin="anonymous"></script>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/semantic-ui@2.4.2/dist/semantic.min.css">
        <script src="https://cdn.jsdelivr.net/npm/semantic-ui@2.4.2/dist/semantic.min"></script>
        <title>Upload File Page</title>
    </head>
    <body>
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
    <center><h1 class="ui block header">Upload XLS</h1></center>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <center>
        <div style="margin-left: 140px; margin-right:140px">
            <div class="ui card">
                <div class="content">
                    <p>&nbsp;</p>
                    <div class="header">Please Select Your File</div>
                    <p>&nbsp;</p>
                    <p>&nbsp;</p>

                    <div class="meta">

                        <form action="/Biometric-Reader/C101_UploadFile" method="post" enctype="multipart/form-data" id="uploadFile">   
                            <div id="abId0.6486735230760385">
                                <label for="XSLfile" class="ui teal large labeled icon button label">
                                    <i class="upload icon"></i> 
                                    Choose XLS File:
                                    <div class="detail" id="uploadDetails">No file Selected</div>
                                </label>                      
                                <!-- Accept only excel file 2003. For excel file 2007+ -> accept="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"  -->
                                <input type="file" id="XSLfile" name = "XSLfile" required size = "100" accept="application/vnd.ms-excel" onchange="CheckFileFormat(event)" style="display:none"/>
                                <h2>&nbsp;</h2>
                            </div>
                            <div class="ui buttons">
                                <input type="submit" id="clearBtn" onclick="clearFile()" class="ui button" disabled value="Clear"/>
                                <button id="uploadBtn" class="ui positive button" disabled>Upload</button>
                            </div>
                        </form>

                    </div>

                </div>
            </div>
        </div>
    </center>

    <script>
        var xslElement = document.getElementById('XSLfile');
        var uploadDetails = document.getElementById('uploadDetails');
        function CheckFileFormat() {
            var fileName = event.target.files[0].name;
            const lastDot = fileName.lastIndexOf('.');
            const ext = (fileName.substring(lastDot + 1)).toUpperCase();

            uploadDetails.innerHTML = fileName;

            if (ext !== 'XLS') {
                alert('Accept only excel file version 2003');
                uploadDetails.innerHTML = "No file selected";
                clearFile();
            }
            ;

            toggleButton();
        }
        ;

        function clearFile() {
            document.getElementById("uploadFile").reset();
            uploadDetails.innerHTML = " No file selected ";
            toggleButton();
        }

        function toggleButton() {
            if (xslElement.value !== "") {
                document.getElementById('uploadBtn').disabled = false;
                document.getElementById('clearBtn').disabled = false;
            } else {
                document.getElementById('uploadBtn').disabled = true;
                document.getElementById('clearBtn').disabled = true;
            }
        }
    </script>
</body>
</html>


<!--
 check file name XSl if not reset the type file
 the submit button will be disabled --> 
