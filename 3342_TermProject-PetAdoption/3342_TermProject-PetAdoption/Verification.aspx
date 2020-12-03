<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Verification.aspx.cs" Inherits="_3342_TermProject_PetAdoption.Verification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" href="CSS/Login_Stylesheet.css" />

</head>
<body>
    <div class="bg">
        <form id="verification" runat="server">
            <nav class="navbar navbar-light bg-light fixed-top navbar-expand-md">
                <div id="navbar" class="navbar-collapse collapse">
                    <a class="navbar-brand">
                        APP NAME PENDING?
                    </a>
                </div>
            </nav>
            <br />
            <div class="card">
              <header class="card-header">
                  Verify Account
              </header>
              <div class="card-body">
                    <asp:Label ID="lblErrors" runat="server" Text=""></asp:Label>
                  <label>A verification code has been sent to your email. Enter it here to access the application!</label>
                  <p><asp:TextBox runat="server" id="verify_input" class="form-control" type="text" Placeholder="Verification Code"></asp:TextBox></p>
                </div>
              <footer class="card-footer"><center>
                <asp:Button ID="btnVerify" class="btn btn-dark" runat="server" Text="Verify Account" OnClick="btnVerify_Click"></asp:Button>
                
               
              </center></footer>
            </div>
        </form>
    </div>
</body>
</html>