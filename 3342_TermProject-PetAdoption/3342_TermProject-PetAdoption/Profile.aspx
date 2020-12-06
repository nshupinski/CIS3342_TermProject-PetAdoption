<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="_3342_TermProject_PetAdoption.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Profile</title>
    <link href="CSS/Profile_Stylesheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5 mb-5 d-flex justify-content-center">
    <div class="card rounded">
        <div class=" d-block justify-content-center">
            <div class="area1 p-3 py-5"> </div>
            <div class="area2 p- text-center px-3">
                <div class="image mr-3"> <img src="images/default.png" class="rounded-circle" width="100"/>
                    <br />
                    <h4 id="lblUsername" class="name mt-3" runat="server"></h4><small><br />
                    <p><b>Account Type:</b> <asp:Label id="lblType" runat="server"></asp:Label></p>
                    <p><b>Email:</b> <asp:Label id="lblEmail" runat="server"></asp:Label></p>
                    <p><b>Phone Number:</b> <asp:Label id="lblPhone" runat="server"></asp:Label></p>
                    <p><b>Location:</b> <asp:Label id="lblLocation" runat="server"></asp:Label></p>
                </div>
                <div> </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
