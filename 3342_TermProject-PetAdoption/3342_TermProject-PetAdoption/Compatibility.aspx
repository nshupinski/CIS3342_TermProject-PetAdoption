<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Compatibility.aspx.cs" Inherits="_3342_TermProject_PetAdoption.Compatibility" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Compatibility</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" href="CSS/AddPet_Stylesheet.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg">
            <br />
            <div class="card h-100">
              <header class="card-header">
                  Add a Pet
              </header>
              <div class="card-body">
                    <asp:Label ID="lblErrors" runat="server" Text=""></asp:Label>
                  <h3>I want a(n)...</h3>
                  <label for="animal_input"><small><b>Animal</b></small></label>
                      <asp:DropDownList id="ddlAnimal" class="form-control col-md-11 input" runat="server">
                              <asp:ListItem value="" selected="selected">Select an Animal Type</asp:ListItem>
                              <asp:ListItem value="Cat">Cat</asp:ListItem>
                              <asp:ListItem value="Dog">Dog</asp:ListItem>
                              <asp:ListItem value="Rabbit">Rabbit</asp:ListItem>
                              <asp:ListItem value="Small">Small Animals (Hamsters, Guinea Pigs, etc.)</asp:ListItem>
                              <asp:ListItem value="Aquatic">Aquatic Animals</asp:ListItem>
                      </asp:DropDownList><br />
                  <h3>Whose age is...</h3>
                  <label for="animal_input"><small><b>Age Range</b></small></label>
                      <asp:DropDownList id="age_input" class="form-control col-md-11 input" runat="server">
                              <asp:ListItem value="" selected="selected">Select the Age Range</asp:ListItem>
                              <asp:ListItem value="Baby">Baby</asp:ListItem>
                              <asp:ListItem value="Young">Young</asp:ListItem>
                              <asp:ListItem value="Rabbit">Adult</asp:ListItem>
                              <asp:ListItem value="Senior">Senior</asp:ListItem>
                      </asp:DropDownList><br />
                  
                  <h3>In this state...</h3>
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
                  
                  <div class="form-check" runat="server">
                      <input class="form-check-input" type="checkbox" value="GoodWithKids" id="checkGoodWithKids" runat="server">
                      <label class="form-check-label" for="checkGoodWithKids" runat="server">
                        This pet should be good with pets.
                      </label>
                  </div>
                  <div class="form-check" runat="server">
                      <input class="form-check-input" type="checkbox" value="GoodWithPets" id="checkGoodWithPets" runat="server">
                      <label class="form-check-label" for="checkGoodWithPets" runat="server">
                        This pet should be good with other pets.
                      </label>
                  </div>
             </div>
                <footer class="card-footer"><center>
                <asp:Button ID="btnFindMatch" class="btn btn-dark" runat="server" type="submit" Text="Find Match" OnClick="btnFindMatch_Click"></asp:Button>
</asp:Content>
