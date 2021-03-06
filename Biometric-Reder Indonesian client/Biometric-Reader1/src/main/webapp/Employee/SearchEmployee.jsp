<!DOCTYPE html>
<html>
    <head>
        <title>Employee Page</title>
        <script src="/Biometric-Reader/JavaScript/LocationReplace.js"></script>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <script src="https://code.jquery.com/jquery-3.1.1.min.js" crossorigin="anonymous"></script>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/semantic-ui@2.4.2/dist/semantic.min.css">
        <script src="https://cdn.jsdelivr.net/npm/semantic-ui@2.4.2/dist/semantic.min"></script>
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

        <div id="Content">
            <center><h1 class="ui block header">Employee Page</h1></center>
            <p>&nbsp;</p>
            <p>&nbsp;</p>
            <p>&nbsp;</p>
        </div>
    </body>
</html>
