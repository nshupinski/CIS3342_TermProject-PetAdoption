<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Pet_Page.aspx.cs" Inherits="_3342_TermProject_PetAdoption.Pet_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/PetPage_Stylesheet.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="buttons">
        <asp:Button ID="btnLove" Text="Love" runat="server" OnClick="btnLove_Clicked"/>
        <asp:Button ID="btnAdopt" Text="Request Adoption" runat="server" style="margin-left: 2em;" OnClick="btnAdopt_Clicked"/>
    </div>

    <div id="container">
        <div id="content">
            <img ID="petPhoto" runat="server" src="" /><br />

            <asp:TextBox runat="server" id="txtName" type="text" Text=""></asp:TextBox><br /><br />

            <asp:Label ID="lblAnimal" runat="server" Text="Species: "></asp:Label>
            <asp:TextBox runat="server" id="txtAnimal" type="text" Text=""></asp:TextBox><br />

            <asp:Label ID="lblBreed" runat="server" Text="Breed: "></asp:Label>
            <asp:TextBox runat="server" id="txtBreed" type="text" Text=""></asp:TextBox><br />

            <asp:Label ID="lblShelter" runat="server" Text="Breed: "></asp:Label>
            <asp:TextBox runat="server" id="txtShelter" type="text" Text=""></asp:TextBox><br />

            <asp:Label ID="lblGWKids" runat="server" Text="Good With Kids: "></asp:Label>
            <asp:TextBox runat="server" id="txtGWKids" type="text" Text=""></asp:TextBox><br />

            <asp:Label ID="lblGWPets" runat="server" Text="Good With Pets: "></asp:Label>
            <asp:TextBox runat="server" id="txtGWPets" type="text" Text=""></asp:TextBox><br />

            <asp:Label ID="lblLocation" runat="server" Text="Location: "></asp:Label>
            <asp:TextBox runat="server" id="txtLocation" type="text" Text=""></asp:TextBox><br />

            <asp:Label ID="lblAge" runat="server" Text="Age Range: "></asp:Label>
            <asp:TextBox runat="server" id="txtAge" type="text" Text=""></asp:TextBox><br />
        </div>
    </div>

    <div id="modal" class="modal" tabindex="-1" role="dialog" style="display: block; visibility: hidden;" runat="server">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-body">
            <p>Your adoption request has been sent!</p>
          </div>
          <div class="modal-footer">
            <asp:Button type="button" class="btn btn-secondary" onclick="btnAdoptClose_Clicked" runat="server" Text="Close"></asp:Button>
          </div>
        </div>
      </div>
    </div>

</asp:Content>
