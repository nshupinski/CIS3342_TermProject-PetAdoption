<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="_3342_TermProject_PetAdoption.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" href="CSS/Register_Stylesheet.css" />

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
                  Create an Account
              </header>
              <div class="card-body">
                    <asp:Label ID="lblErrors" runat="server" Text=""></asp:Label>
                  <fieldset class="form-group">
                    <div class="row">
                      <p class="col-form-label col-sm-6 pt-0"><small><b>Choose an Account Type</b></small></p>
                        <p class="description"><small>If you are browsing pets or interested in adopting, choose <b>Pet Adopter</b>. If you are a shelter, rescue or veterinary clinic who rehomes pets, choose <b>Shelters & Rescues</b>.</small></p>
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
                  <asp:TextBox runat="server" id="email_input" class="form-control col-md-11 input" type="text" Placeholder="Email"></asp:TextBox><br />
                  <asp:TextBox runat="server" id="username_input" class="form-control col-md-11 input" type="text" Placeholder="Username"></asp:TextBox><br />
                  <asp:TextBox runat="server" id="password_input" class="form-control col-md-11 input" type="text" Placeholder="Password"></asp:TextBox><br />
                  <asp:TextBox runat="server" id="phone_input" class="form-control col-md-11 input" type="text" Placeholder="Phone Number"></asp:TextBox><br />
                  <asp:TextBox runat="server" id="city_input" class="form-control col-md-11 input" type="text" Placeholder="City"></asp:TextBox><br />
                      <select id="inputState" class="form-control col-md-11 input">
                        <option selected>Choose...</option>
                        <option>...</option>
                      </select>
  
              <footer class="card-footer"><center>
                <asp:Button ID="btnSubmit_createAccount" class="btn btn-dark" runat="server" type="submit" Text="Create Account" onclick="btnCreateAccount_Clicked"></asp:Button>
              </center></footer>
            </div>
        </form>
    </div>
</body>
</html>
