<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ListReservations.aspx.cs" Inherits="ListReservations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Reservations by Special Event</h1>
    <br />
    <asp:Label ID="Label1" runat="server" AssociatedControlID="SpecialEventDDL" >Special Event:</asp:Label> &nbsp;
    <asp:DropDownList ID="SpecialEventDDL" runat="server" DataSourceID="SpecialEventDataSource" DataTextField="Description" DataValueField="EventCode" AppendDataBoundItems="True" >
        <asp:ListItem Value="Select an Event">Select an Event</asp:ListItem>
        <asp:ListItem Value ="">No Event</asp:ListItem>
    </asp:DropDownList>
    <asp:LinkButton ID="ViewReservation" runat="server">View Reservations</asp:LinkButton>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" AssociatedControlID="ReservationsGrid" >Reservations</asp:Label>
    <br />
    <asp:GridView ID="ReservationsGrid" runat="server" DataSourceID="ReservationDataSource" AutoGenerateColumns="False" AllowPaging="True">
        <Columns>
            <asp:BoundField DataField="ReservationID" HeaderText="ReservationID" SortExpression="ReservationID"></asp:BoundField>
            <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" SortExpression="CustomerName"></asp:BoundField>
            <asp:BoundField DataField="ReservationDate" HeaderText="ReservationDate" SortExpression="ReservationDate"></asp:BoundField>
            <asp:BoundField DataField="NumberInParty" HeaderText="NumberInParty" SortExpression="NumberInParty"></asp:BoundField>
            <asp:BoundField DataField="ContactPhone" HeaderText="ContactPhone" SortExpression="ContactPhone"></asp:BoundField>
            <asp:BoundField DataField="ReservationStatus" HeaderText="ReservationStatus" SortExpression="ReservationStatus"></asp:BoundField>
            <asp:BoundField DataField="EventCode" HeaderText="EventCode" SortExpression="EventCode"></asp:BoundField>
        </Columns>
        <EmptyDataTemplate>
            No Data Selected
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="SpecialEventDataSource" runat="server" TypeName="eRestaurant.BLL.ReservationController" OldValuesParameterFormatString="original_{0}" SelectMethod="ListSpecialEvents" />
    <asp:ObjectDataSource ID="ReservationDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetReservationBySpecialEvent" TypeName="eRestaurant.BLL.ReservationController">
        <SelectParameters>
            <asp:ControlParameter ControlID="SpecialEventDDL" PropertyName="SelectedValue" Name="eventcode" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>