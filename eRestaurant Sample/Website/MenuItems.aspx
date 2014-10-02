<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MenuItems.aspx.cs" Inherits="MenuItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <%--<asp:Repeater ID="MenuRepeater" runat="server" DataSourceID="MenuItemDatasource">
        <ItemTemplate>
            <%# ((decimal)Eval("CurrentPrice")).ToString("C") %>
        &mdash; <%# Eval("Description")%> &ndash; <%# Eval("MenuCategory.Description") %>
        &ndash; <%# Eval("Calories")%> Calories
        </ItemTemplate>
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
    </asp:Repeater>--%>

    <asp:Repeater ID="MenuItemRepeater" runat="server" DataSourceID="MenuItemDatasource">
        <ItemTemplate>
            <img src="http://placehold.it/150x100/" alt="" /> <%# Eval("Description")%>
            <asp:Repeater ID="ItemDetailRepeater" runat="server" DataSource='<%# Eval("MenuItems") %>' >
                <ItemTemplate>
                    <div>
                        <%# Eval("Description") %> &mdash; 
                        <%# Eval("Calories") %> &mdash;
                        <%# ((decimal)Eval("Price")).ToString("C") %>
                        <br />
                        <%# Eval("Comment") %>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource runat="server" ID="MenuItemDatasource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListCategorizedMenuItems" TypeName="eRestaurant.BLL.MenuController"></asp:ObjectDataSource>
</asp:Content>

