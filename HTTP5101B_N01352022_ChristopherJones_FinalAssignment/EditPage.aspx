<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPage.aspx.cs" Inherits="HTTP5101B_N01352022_ChristopherJones_FinalAssignment.EditPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="E_Page" runat="server">
        <div class="viewnav">
            <a class="left" href="ShowPage.aspx?pageid=<%=Request.QueryString["pageid"] %>">Cancel</a>
        </div>
        <h2>Edit Page <span id="page_title" runat="server"></span></h2>
        
        <div class="formrow">
            <label>Page Title</label>
            <asp:TextBox runat="server" ID="Ptitle"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="Ptitle" runat="server" ErrorMessage="Please input a title"></asp:RequiredFieldValidator>
        </div>
        <div class="formrow">
            <label>Page Body</label>
            <asp:TextBox runat="server" ID="Pbody"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="Pbody" runat="server" ErrorMessage="Please enter some body text"></asp:RequiredFieldValidator>
        </div>
        <div class="formrow">
            <label>Page Order</label>
            <asp:DropDownList runat="server" ID="Porder"></asp:DropDownList>
        </div>
        <div class="formrow">
            <label>Page Style</label>
            <asp:DropDownList runat="server" ID="Pstyle"></asp:DropDownList>
        </div>

        <asp:Button Text="Update Page" OnClick="Update_Page" runat="server" />
        
        <div class="add_page_validation_summary">
        <section>
            <asp:ValidationSummary runat="server" ShowSummary="true" />
        </section>
    </div>
    </div>
</asp:Content>
