<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListPages.aspx.cs" Inherits="HTTP5101B_N01352022_ChristopherJones_FinalAssignment.ListPages" %>
<asp:Content ID="page_view_content" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Manage Pages</h2>
    <div id="add_pages"><a href="NewPage.aspx">Add New Page</a></div>
    <div class="_table" runat="server">
        <div class="listitem">
            <div class="col3">Page Title</div>
            <div class="col3">Page Order</div>
            <div class="col3last">Modify</div>
        </div>
        <div id="pages_result" runat="server">

        </div>
    </div>
</asp:Content>
