<%@ Page Title="Delete Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeletePage.aspx.cs" Inherits="HTTP5101B_N01352022_ChristopherJones_FinalAssignment.DeletePage" %>
<asp:Content ID="deletepage" ContentPlaceHolderID="MainContent" runat="server">
    <div id="page_" runat="server">
         <h3>Are you sure you want to delete <span runat="server" id="pagetitle"></span>?</h3>
        <p id="pagebody" runat="server"></p>
    
        <div class="viewnav thin">
            <a class="left" href="ShowPage.aspx?pageid=<%= Request.QueryString["pageid"] %>">No</a>
            <ASP:Button OnClick="Delete_Page" CssClass="right" Text="Yes" runat="server"/>   

        </div>
    </div>
</asp:Content>
