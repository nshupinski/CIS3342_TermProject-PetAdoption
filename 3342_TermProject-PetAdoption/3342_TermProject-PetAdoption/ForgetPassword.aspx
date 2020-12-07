<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="_3342_TermProject_PetAdoption.ForgetPassword" MasterPageFile="~/Site1.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Reset Password</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" href="CSS/Login_Stylesheet.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg">
            <div class="card" id ="securityDiv" runat="server">
              <header class="card-header">
                  Security Questions
              </header>
              <div class="card-body">
                    <asp:Label ID="lblErrors" runat="server" Text=""></asp:Label>
                  <label for="email_input"><small><b>Username</b></small></label>
                  <asp:TextBox runat="server" id="username_input" class="form-control col-md-11 input" type="text" Placeholder="Username" required></asp:TextBox><br />
                  <asp:Label ID="lblsecurityQuestion" runat="server" Text=""></asp:Label>
                  <p><asp:TextBox runat="server" id="security_input" class="form-control" type="text" Placeholder="Answer"></asp:TextBox></p>
                </div>
              <footer class="card-footer"><center>
                <asp:Button ID="btnSubmit" class="btn btn-dark" runat="server" Text="Submit" OnClick="btnSubmit_Click"></asp:Button>
                
               
              </center></footer>
            </div>

            <div class="card" id ="passwordDiv" visible="false" runat="server">
              <header class="card-header">
                  Reset Password
              </header>
              <div class="card-body">
                  <asp:Label ID="lblErrorsPassword" runat="server" Text=""></asp:Label><br />
                    <label for="password_input"><small><b>Password</b></small></label>
                  <asp:TextBox runat="server" id="password_input" class="form-control col-md-11 input" type="text" Placeholder="Password" required></asp:TextBox><br />
                  <label for="password2_input"><small><b>Confirm Password</b></small></label>
                  <asp:TextBox runat="server" id="password2_input" class="form-control col-md-11 input" type="text" Placeholder="Confirm Password" required></asp:TextBox><br />
                  
                </div>
              <footer class="card-footer"><center>
                <asp:Button ID="btnReset" class="btn btn-dark" runat="server" Text="Reset Password" OnClick="btnReset_Click"></asp:Button>
                
               
              </center></footer>
            </div>
    </div>
</asp:Content>