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
                  <label for="email_input"><small><b>Email</b></small></label>
                  <asp:TextBox runat="server" id="email_input" class="form-control col-md-11 input" type="text" Placeholder="Email"></asp:TextBox><br />
                  <label for="username_input"><small><b>Username</b></small></label>
                  <asp:TextBox runat="server" id="username_input" class="form-control col-md-11 input" type="text" Placeholder="Username"></asp:TextBox><br />
                  <label for="password_input"><small><b>Password</b></small></label>
                  <asp:TextBox runat="server" id="password_input" class="form-control col-md-11 input" type="text" Placeholder="Password"></asp:TextBox><br />
                  <label for="phone_input"><small><b>Phone Number</b></small></label>
                  <asp:TextBox runat="server" id="phone_input" class="form-control col-md-11 input" type="text" Placeholder="Phone Number"></asp:TextBox><br />
                  <label for="city_input"><small><b>City</b></small></label>
                  <asp:TextBox runat="server" id="city_input" class="form-control col-md-11 input" type="text" Placeholder="City"></asp:TextBox><br />
                  <label for="state_input"><small><b>State</b></small></label>
                      <select id="state_input" class="form-control col-md-11 input">
                              <option value="" selected="selected">Select a State</option>
                              <option value="AL">Alabama</option>
                              <option value="AK">Alaska</option>
                              <option value="AZ">Arizona</option>
                              <option value="AR">Arkansas</option>
                              <option value="CA">California</option>
                              <option value="CO">Colorado</option>
                              <option value="CT">Connecticut</option>
                              <option value="DE">Delaware</option>
                              <option value="DC">District Of Columbia</option>
                              <option value="FL">Florida</option>
                              <option value="GA">Georgia</option>
                              <option value="HI">Hawaii</option>
                              <option value="ID">Idaho</option>
                              <option value="IL">Illinois</option>
                              <option value="IN">Indiana</option>
                              <option value="IA">Iowa</option>
                              <option value="KS">Kansas</option>
                              <option value="KY">Kentucky</option>
                              <option value="LA">Louisiana</option>
                              <option value="ME">Maine</option>
                              <option value="MD">Maryland</option>
                              <option value="MA">Massachusetts</option>
                              <option value="MI">Michigan</option>
                              <option value="MN">Minnesota</option>
                              <option value="MS">Mississippi</option>
                              <option value="MO">Missouri</option>
                              <option value="MT">Montana</option>
                              <option value="NE">Nebraska</option>
                              <option value="NV">Nevada</option>
                              <option value="NH">New Hampshire</option>
                              <option value="NJ">New Jersey</option>
                              <option value="NM">New Mexico</option>
                              <option value="NY">New York</option>
                              <option value="NC">North Carolina</option>
                              <option value="ND">North Dakota</option>
                              <option value="OH">Ohio</option>
                              <option value="OK">Oklahoma</option>
                              <option value="OR">Oregon</option>
                              <option value="PA">Pennsylvania</option>
                              <option value="RI">Rhode Island</option>
                              <option value="SC">South Carolina</option>
                              <option value="SD">South Dakota</option>
                              <option value="TN">Tennessee</option>
                              <option value="TX">Texas</option>
                              <option value="UT">Utah</option>
                              <option value="VT">Vermont</option>
                              <option value="VA">Virginia</option>
                              <option value="WA">Washington</option>
                              <option value="WV">West Virginia</option>
                              <option value="WI">Wisconsin</option>
                              <option value="WY">Wyoming</option>
                      </select>
  
             </div>
                <footer class="card-footer"><center>
                <asp:Button ID="btnSubmit_createAccount" class="btn btn-dark" runat="server" type="submit" Text="Create Account" onclick="btnCreateAccount_Clicked"></asp:Button>
              </center></footer>
            </div>
        </form>
    </div>
</body>
</html>
