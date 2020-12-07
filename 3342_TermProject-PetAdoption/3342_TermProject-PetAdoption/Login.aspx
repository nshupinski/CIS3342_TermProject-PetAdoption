<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_3342_TermProject_PetAdoption.Login" MasterPageFile="~/Site1.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Log In</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" href="CSS/Login_Stylesheet.css" />
    <link href="https://fonts.googleapis.com/css2?family=Fredoka+One&display=swap" rel="stylesheet">

    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg">
            <div class="card">
              <header class="card-header">
                  Please Sign In
              </header>
              <div class="card-body">
                    <asp:Label ID="lblErrors" runat="server" Text=""></asp:Label>
                  <p><asp:TextBox runat="server" id="username_input" class="form-control" type="text" Placeholder="Username"></asp:TextBox></p>
                  <p>
                      <asp:Button ID="btnForgotPassword" class="btn btn-light col-md-4" style="float: right" runat="server" type="submit" Text="Forgot Password?" OnClick="btnForgotPassword_Click"></asp:Button>
                      <asp:TextBox runat="server" id="password_input" class="form-control col-md-7" type="text" Placeholder="Password"></asp:TextBox>
                  </p>
                  
                   <fieldset class="form-group" runat="server">
                    <div class="row">
                      <p class="col-form-label col-sm-5 pt-0">Account Type</p>
                      <div class="col-sm-5">
                        <div class="form-check">
                          <input class="form-check-input" type="radio" name="userType" id="userPet" value="PetAdopter" runat="server" checked/>
                          <label class="form-check-label" for="userPet" runat="server">
                            Pet Adopter
                          </label>
                        </div>
                        <div class="form-check">
                          <input class="form-check-input" type="radio" name="userType" id="userShelter" value="SheltersRescues" runat="server"/>
                          <label class="form-check-label" for="userShelter" runat="server">
                            Shelters & Rescues
                          </label>
                        </div>
                      </div>
                    </div>
                     </fieldset>
                  <div id="cookies">
                  
                        <input class="form-check-input" type="checkbox" value="" id="checkCookies" runat="server">
                        <label class="form-check-label" for="checkCookies">
                            <small><b>Faster login:</b> Store your login information in your browser for 12 hours*</small>
                        </label>
                  
                  </div>
                     <p><small>*If you uncheck the box when you login and a cookie already exists, it will delete the cookie from your browser upon next login visit.</small></label>
                  </p>
                </div>
              <footer class="card-footer"><center>
                <asp:Button ID="btnSubmit_login" class="btn btn-dark" runat="server" Text="Login" onclick="btnLogin_Clicked"></asp:Button>
                <asp:Button ID="btnSubmit_createAccount" class="btn btn-dark" runat="server" type="submit" Text="Create Account" onclick="btnCreateAccount_Clicked"></asp:Button>
               
              </center></footer>
            </div>
    </div>
</asp:Content>


