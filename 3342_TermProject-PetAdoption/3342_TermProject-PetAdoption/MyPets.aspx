<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MyPets.aspx.cs" Inherits="_3342_TermProject_PetAdoption.MyPets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link href="CSS/Home_Stylesheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <div class="container">
        <h2 runat="server">Welcome to My Pets!</h2>
        <p runat="server" id="description"></p>
    <div class="row">
    <asp:Repeater ID="rptPet" runat="server" OnItemCommand="rptPet_ItemCommand" >
        <ItemTemplate>
            <div class="col-sm-12 col-lg-3">
                <div class="card h-100" style="min-width: 300px;">
                     <img src="<%# Eval("imgFile") %>" class="card-img-top" alt="...">
                    <div class="card-body">
                <table style="margin-left: auto; margin-right: auto;">
                    <tr>

                        <td>
                            Name:
                            <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "name") %>'></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            Animal:
                            <asp:Label ID="lblAnimal" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "animal") %>'></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            Breed:
                            <asp:Label ID="lblBreed" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "breed") %>'></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <asp:Label ID="lblPetID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "petID") %>'></asp:Label>

                        </td>
                    </tr>
                    </table>
                        </div>
                        <div class="card-footer"><center>
                            <asp:Button ID="btnSelect" class="btn btn-dark" Text="View Pet" runat="server" /></center>
                            </div>
                        
                  </div>
                    </div>
            
        </ItemTemplate>
    </asp:Repeater>
        <br />
        </div>
        
        </div>

</asp:Content>
