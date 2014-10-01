<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MenuItems.aspx.cs" Inherits="MenuItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Repeater ID="MenuRepeater" runat="server" DataSourceID="MenuItemDatasource">
        <ItemTemplate>
            <%# ((decimal)Eval("CurrentPrice")).ToString("C") %>
        &mdash; <%# Eval("Description")%> &ndash; <%# Eval("MenuCategory.Description") %>
        &ndash; <%# Eval("Calories")%> Calories
        </ItemTemplate>
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource runat="server" ID="MenuItemDatasource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListMenuItems" TypeName="eRestaurant.BLL.MenuController"></asp:ObjectDataSource>
</asp:Content>

