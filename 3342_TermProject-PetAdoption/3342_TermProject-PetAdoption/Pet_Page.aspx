<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Pet_Page.aspx.cs" Inherits="_3342_TermProject_PetAdoption.Pet_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/PetPage_Stylesheet.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="container">
        <div id="picture">

        </div>
        <div id="content">
            <h5 id="name" runat="server"></h5>
            <asp:Label ID="lblAnimal" runat="server" Text="Species: "></asp:Label>
            <asp:TextBox runat="server" id="txtAnimal" type="text" Text=""></asp:TextBox><br />

            <asp:Label ID="lblBreed" runat="server" Text="Breed: "></asp:Label>
            <asp:TextBox runat="server" id="txtBreed" type="text" Text=""></asp:TextBox><br />

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

</asp:Content>
