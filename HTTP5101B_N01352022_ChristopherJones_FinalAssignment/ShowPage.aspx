<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowPage.aspx.cs" Inherits="HTTP5101B_N01352022_ChristopherJones_FinalAssignment.ShowPage" %>
<asp:Content ID="page_view_content" ContentPlaceHolderID="MainContent" runat="server">
    <div id="style_wrapper" runat="server">
        <div class="viewnav">
            <a class="left" href="ListPages.aspx">Back To List</a>
            <a class="right" href="EditPage.aspx?pageid=<%=Request.QueryString["pageid"] %>">Edit</a>
        </div>
        <div id="page_" runat="server">
            <h2 id="page_title" runat="server"></h2>
            <p id="page_body" runat="server"></p>
        </div>
    </div>
</asp:Content>
