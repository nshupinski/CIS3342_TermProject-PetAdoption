<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Verification.aspx.cs" Inherits="_3342_TermProject_PetAdoption.Verification" MasterPageFile="~/Site1.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Log In</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" href="CSS/Login_Stylesheet.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg">
            <br />
            <div class="card">
              <header class="card-header">
                  Verify Account
              </header>
              <div class="card-body">
                    <asp:Label ID="lblErrors" runat="server" Text=""></asp:Label>
                  <center><label><small>A verification code has been sent to your email. Enter it here to access the application!</label></small><br /><br />
                  <p><asp:TextBox runat="server" id="verify_input" class="form-control col-sm-7" type="text" Placeholder="Verification Code"></asp:TextBox></p></center>
                </div>
              <footer class="card-footer"><center>
                <asp:Button ID="btnVerify" class="btn btn-dark" runat="server" Text="Verify Account" OnClick="btnVerify_Click"></asp:Button>
                
               
              </center></footer>
            </div>
    </div>
</asp:Content>