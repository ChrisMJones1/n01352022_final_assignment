<%@ Page Title="New Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewPage.aspx.cs" Inherits="HTTP5101B_N01352022_ChristopherJones_FinalAssignment.NewPage" %>
<asp:Content ID="newpage" ContentPlaceHolderID="MainContent" runat="server">
    <h2>New Page</h2>
    <div class="formrow">
        <label>Page Title</label>
        <asp:TextBox runat="server" ID="Ptitle" placeholder="e.g. page 6"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="Ptitle" runat="server" ErrorMessage="Please input a title"></asp:RequiredFieldValidator>
    </div>
    <div class="formrow">
        <label>Page Body</label>
        <asp:TextBox runat="server" textmode="MultiLine" ID="Pbody"></asp:TextBox>
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

    <asp:Button OnClick="Add_Page" Text="Add Page" runat="server" />
    <div class="add_page_validation_summary">
        <section>
            <asp:ValidationSummary runat="server" ShowSummary="true" />
        </section>
    </div>
</asp:Content>
