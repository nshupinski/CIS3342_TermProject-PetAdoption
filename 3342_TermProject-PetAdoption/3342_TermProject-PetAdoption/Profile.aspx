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
                <div class="image mr-3"> <img id="profileimg" src="images/default.png" class="rounded-circle" width="100" runat="server"/>
                    <br />
                    <h4 id="lblUsername" class="name mt-3" runat="server"></h4><small><br />
                    <p><b>Account Type:</b> <asp:Label id="lblType" runat="server"></asp:Label></p>
                    <p><b>Email:</b> <asp:Label id="lblEmail" runat="server"></asp:Label></p>
                    <p><b>Phone Number:</b> <asp:Label id="lblPhone" runat="server"></asp:Label></p>
                    <p><b>Location:</b> <asp:Label id="lblLocation" runat="server"></asp:Label></p>
                    <asp:Label ID="lblPetGV" runat="server"></asp:Label>
                    <br /><br />
                    <asp:GridView ID="gvShelter" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowCommand="gvShelter_RowCommand" Visible="false">
                        <Columns>
                 
                        <asp:BoundField DataField="adopterUserID" HeaderText="Username" />

                        <asp:BoundField DataField="phoneNum" HeaderText="Phone Number" />

                        <asp:BoundField DataField="petID" HeaderText="Pet ID" />

                        <asp:BoundField DataField="name" HeaderText="Pet Name" />

                        <asp:BoundField DataField="animal" HeaderText="Animal" />

                        <asp:BoundField DataField="requestDate" HeaderText="Date of Request" />

                        <asp:ButtonField ControlStyle-CssClass="btn btn-dark" CommandName="ApproveRequest" HeaderText="" Text="Approve"/>

                        <asp:ButtonField ControlStyle-CssClass="btn btn-dark" CommandName="DenyRequest" HeaderText="" Text="Deny"/>

                        </Columns>
                 </asp:GridView>
                 <asp:GridView ID="gvAdopter" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" Visible="false" OnRowCommand="gvAdopter_RowCommand">
                        <Columns>
                        <asp:BoundField DataField="petID" HeaderText="Pet ID" />
                 
                        <asp:BoundField DataField="name" HeaderText="Pet Name" />

                        <asp:BoundField DataField="animal" HeaderText="Animal" />

                        <asp:BoundField DataField="shelterID" HeaderText="Shelter Name" />

                        <asp:BoundField DataField="requestDate" HeaderText="Date of Request" />

                        <asp:BoundField DataField="result" HeaderText="Status" />

                        <asp:ButtonField ControlStyle-CssClass="btn btn-dark" CommandName="Cancel Request" HeaderText="" Text="Delete"/>

                        </Columns>
                 </asp:GridView>
                    <asp:Label runat="server" ID="lblGridView" Visible="false"></asp:Label>
                </div>
                <div> </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
