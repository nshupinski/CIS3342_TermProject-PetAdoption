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
                FELIX
            </a>
        </div>
    </nav>
            <br />
            <div class="card h-100">
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
                          <input class="form-check-input" type="radio" name="userType" id="userPet" value="PetAdopter" runat="server" checked/>
                          <label class="form-check-label" for="userPet">
                            Pet Adopter
                          </label>
                        </div>
                        <div class="form-check">
                          <input class="form-check-input" type="radio" name="userType" id="userShelter" value="SheltersRescues" runat="server"/>
                          <label class="form-check-label" for="userShelter">
                            Shelters & Rescues
                          </label>
                        </div>
                      </div>
                    </div>
                  </fieldset>
                  <label for="email_input"><small><b>Email</b></small></label>
                  <asp:TextBox runat="server" id="email_input" class="form-control col-md-11 input" type="text" Placeholder="Email" required></asp:TextBox><br />
                  <label for="username_input"><small><b>Username</b></small></label>
                  <asp:TextBox runat="server" id="username_input" class="form-control col-md-11 input" type="text" Placeholder="Username" required></asp:TextBox><br />
                  <label for="password_input"><small><b>Password</b></small></label>
                  <asp:TextBox runat="server" id="password_input" class="form-control col-md-11 input" type="text" Placeholder="Password" required></asp:TextBox><br />
                  <label for="password2_input"><small><b>Confirm Password</b></small></label>
                  <asp:TextBox runat="server" id="password2_input" class="form-control col-md-11 input" type="text" Placeholder="Confirm Password" required></asp:TextBox><br />
                  <label for="phone_input"><small><b>Phone Number</b></small></label>
                  <asp:TextBox runat="server" id="phone_input" class="form-control col-md-11 input" type="text" Placeholder="Phone Number" required></asp:TextBox><br />
                  <label for="city_input"><small><b>City</b></small></label>
                  <asp:TextBox runat="server" id="city_input" class="form-control col-md-11 input" type="text" Placeholder="City" required></asp:TextBox><br />
                  <label for="state_input"><small><b>State</b></small></label>
                      <asp:DropDownList id="state_input" class="form-control col-md-11 input" runat="server">
                              <asp:ListItem value="" selected="selected">Select a State</asp:ListItem>
                              <asp:ListItem value="AL">Alabama</asp:ListItem>
                              <asp:ListItem value="AK">Alaska</asp:ListItem>
                              <asp:ListItem value="AZ">Arizona</asp:ListItem>
                              <asp:ListItem value="AR">Arkansas</asp:ListItem>
                              <asp:ListItem value="CA">California</asp:ListItem>
                              <asp:ListItem value="CO">Colorado</asp:ListItem>
                              <asp:ListItem value="CT">Connecticut</asp:ListItem>
                              <asp:ListItem value="DE">Delaware</asp:ListItem>
                              <asp:ListItem value="DC">District Of Columbia</asp:ListItem>
                              <asp:ListItem value="FL">Florida</asp:ListItem>
                              <asp:ListItem value="GA">Georgia</asp:ListItem>
                              <asp:ListItem value="HI">Hawaii</asp:ListItem>
                              <asp:ListItem value="ID">Idaho</asp:ListItem>
                              <asp:ListItem value="IL">Illinois</asp:ListItem>
                              <asp:ListItem value="IN">Indiana</asp:ListItem>
                              <asp:ListItem value="IA">Iowa</asp:ListItem>
                              <asp:ListItem value="KS">Kansas</asp:ListItem>
                              <asp:ListItem value="KY">Kentucky</asp:ListItem>
                              <asp:ListItem value="LA">Louisiana</asp:ListItem>
                              <asp:ListItem value="ME">Maine</asp:ListItem>
                              <asp:ListItem value="MD">Maryland</asp:ListItem>
                              <asp:ListItem value="MA">Massachusetts</asp:ListItem>
                              <asp:ListItem value="MI">Michigan</asp:ListItem>
                              <asp:ListItem value="MN">Minnesota</asp:ListItem>
                              <asp:ListItem value="MS">Mississippi</asp:ListItem>
                              <asp:ListItem value="MO">Missouri</asp:ListItem>
                              <asp:ListItem value="MT">Montana</asp:ListItem>
                              <asp:ListItem value="NE">Nebraska</asp:ListItem>
                              <asp:ListItem value="NV">Nevada</asp:ListItem>
                              <asp:ListItem value="NH">New Hampshire</asp:ListItem>
                              <asp:ListItem value="NJ">New Jersey</asp:ListItem>
                              <asp:ListItem value="NM">New Mexico</asp:ListItem>
                              <asp:ListItem value="NY">New York</asp:ListItem>
                              <asp:ListItem value="NC">North Carolina</asp:ListItem>
                              <asp:ListItem value="ND">North Dakota</asp:ListItem>
                              <asp:ListItem value="OH">Ohio</asp:ListItem>
                              <asp:ListItem value="OK">Oklahoma</asp:ListItem>
                              <asp:ListItem value="OR">Oregon</asp:ListItem>
                              <asp:ListItem value="PA">Pennsylvania</asp:ListItem>
                              <asp:ListItem value="RI">Rhode Island</asp:ListItem>
                              <asp:ListItem value="SC">South Carolina</asp:ListItem>
                              <asp:ListItem value="SD">South Dakota</asp:ListItem>
                              <asp:ListItem value="TN">Tennessee</asp:ListItem>
                              <asp:ListItem value="TX">Texas</asp:ListItem>
                              <asp:ListItem value="UT">Utah</asp:ListItem>
                              <asp:ListItem value="VT">Vermont</asp:ListItem>
                              <asp:ListItem value="VA">Virginia</asp:ListItem>
                              <asp:ListItem value="WA">Washington</asp:ListItem>
                              <asp:ListItem value="WV">West Virginia</asp:ListItem>
                              <asp:ListItem value="WI">Wisconsin</asp:ListItem>
                              <asp:ListItem value="WY">Wyoming</asp:ListItem>
                      </asp:DropDownList>
                      <br />
                  <label for="secAnswer1"><small><b>Security Question #1</b></small></label>
                  <label class="question"><small>What was your childhood nickname?</small></label>
                  <asp:TextBox runat="server" id="secAnswer1" class="form-control col-md-11 input" type="text" Placeholder="Ex: Jenny" required></asp:TextBox><br />
                  <label for="secAnswer2"><small><b>Security Question #2</b></small></label>
                  <label class="question"><small>What was the last name of your third-grade teacher?</small></label>
                  <asp:TextBox runat="server" id="secAnswer2" class="form-control col-md-11 input" type="text" Placeholder="Ex: Smith" required></asp:TextBox><br />
                  <label for="secAnswer3"><small><b>Security Question #3</b></small></label>
                  <label class="question"><small>What is the name of your favorite pet?</small></label>
                  <asp:TextBox runat="server" id="secAnswer3" class="form-control col-md-11 input" type="text" Placeholder="Ex: Phil" required></asp:TextBox><br />

             </div>
                <footer class="card-footer"><center>
                <asp:Button ID="btnSubmit_createAccount" class="btn btn-dark" runat="server" type="submit" Text="Create Account" onclick="btnCreateAccount_Clicked"></asp:Button>
              </center></footer>
            </div>
        </form>
    </div>
</body>
</html>
