<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="_3342_TermProject_PetAdoption.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script type="text/javascript" src="Javascript/Add_Pets.js"></script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="compatSection">
        <asp:Button ID="btnCompatTest" class="btn btn-light" runat="server" Text="Compatibility Test" OnClick="btnCompatTest_Clicked" />
    </div>

    <div class="container">
      <div class="row">
        <div id="col1" class="col-sm">
          
        </div>
        <div id="col2" class="col-sm">
          
        </div>
        <div id="col3" class="col-sm">
          
        </div>
      </div>
    </div>

</asp:Content>
