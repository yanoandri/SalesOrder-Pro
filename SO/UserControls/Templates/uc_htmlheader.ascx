<%@ Control Language="c#" AutoEventWireup="false" Inherits="Admin_UserControl_uc_htmlheader"
    CodeBehind="uc_htmlheader.ascx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ANZ - Product Suitability Checking</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <script language="javascript" type="text/javascript">

        var isSubmitted = false;

        function isClickedTwice() {
            if (Page_IsValid) {
                // Clicked once only
                if (!isSubmitted) {
                    isSubmitted = true;
                    return false;
                }
                // Clicked twice or more
                else {
                    alert('Your application is being processed');
                    return true;
                }
            }
        }
    </script>
</head>
<body class="MasterBody">
</body>
</html>
