<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_3342_TermProject_PetAdoption.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" href="CSS/Login_Stylesheet.css" />

</head>
<body>
    <div class="bg">
        <form id="loginForm" runat="server">
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
                  Please Sign In
              </header>
              <div class="card-body">
                    <asp:Label ID="lblErrors" runat="server" Text=""></asp:Label>
                  <p><asp:TextBox runat="server" id="username_input" class="form-control" type="text" Placeholder="Username"></asp:TextBox></p>
                  <p><asp:TextBox runat="server" id="password_input" class="form-control" type="text" Placeholder="Password"></asp:TextBox></p>
                   <fieldset class="form-group">
                    <div class="row">
                      <p class="col-form-label col-sm-5 pt-0">Account Type</p>
                      <div class="col-sm-5">
                        <div class="form-check">
                          <input class="form-check-input" type="radio" name="userType" id="userPet" value="PetAdopter" checked/>
                          <label class="form-check-label" for="userPet">
                            Pet Adopter
                          </label>
                        </div>
                        <div class="form-check">
                          <input class="form-check-input" type="radio" name="userType" id="userShelter" value="SheltersRescues"/>
                          <label class="form-check-label" for="userShelter">
                            Shelters & Rescues
                          </label>
                        </div>
                      </div>
                    </div>
                  </fieldset>
                </div>
              <footer class="card-footer"><center>
                <asp:Button ID="btnSubmit_login" class="btn btn-dark" runat="server" Text="Login" onclick="btnLogin_Clicked"></asp:Button>
                <asp:Button ID="btnSubmit_createAccount" class="btn btn-dark" runat="server" type="submit" Text="Create Account" onclick="btnCreateAccount_Clicked"></asp:Button>
              </center></footer>
            </div>
        </form>
    </div>
</body>
</html>
