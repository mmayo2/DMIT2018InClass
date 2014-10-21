<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReportCategoryMenuItems.aspx.cs" Inherits="Reports_ReportCategoryMenuItems" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ODSCategoryMenuItems" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetReportCategoryMenuItems" TypeName="eRestaurant.BLL.ReportsController"></asp:ObjectDataSource>
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Height="800px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
    <LocalReport ReportPath="Reports\CategoryMenuItems.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="ODSCategoryMenuItems" Name="CategoryMenuItemDS" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
</asp:Content>

