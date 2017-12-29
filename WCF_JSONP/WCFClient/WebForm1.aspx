<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WCFClient.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-3.2.1.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btn").click(function () {
                $.ajax({
                    type: "GET",
                    dataType: "jsonp",
                    url: "http://localhost:9090/GetAll",
                    success: function (data) {
                        console.log(data);
                    }
                });
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" id="btn" value="GetData" />
        </div>
    </form>
</body>
</html>
