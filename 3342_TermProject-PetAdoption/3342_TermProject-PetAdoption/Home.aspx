<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="_3342_TermProject_PetAdoption.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bulma@0.9.1/css/bulma.min.css">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="compatSection">
        <asp:Button ID="btnCompatTest" class="btn btn-light" runat="server" Text="Compatibility Test" OnClick="btnCompatTest_Clicked" />
    </div>


    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" style="width: 70%; margin: auto; margin-top: 3em;">
        <ItemTemplate>
            <div class="petCard">
                <table style="margin-left: auto; margin-right: auto;">
                    <tr><img id="image" src="images/bacon.jpg"/></tr>
                    <tr><th id="petName"><%#Eval("name") %></th></tr>
                    <tr><td><%#Eval("breed") %> - <%#Eval("ageRange") %></td></tr>
                    <tr><td> - <%#Eval("location") %></td></tr>
                </table>
                <asp:Button ID='"btnView_" + <%#Eval("petID") %>' runat="server" Text="View" style="margin-top: 20px; margin-bottom: 10px;" OnClick="btnView_Clicked"/>
            </div>
        </ItemTemplate>
    </asp:DataList>


    <div class="container">
      <div class="row">
        <div id="col1" class="col-sm">
          
        </div>
        <div id="col2" class="col-sm">
            
        </div>
        <div id="col3" class="col-sm">
          <a class="level-item" aria-label="like">
            
          </a>
        </div>
      </div>
    </div>

</asp:Content>
