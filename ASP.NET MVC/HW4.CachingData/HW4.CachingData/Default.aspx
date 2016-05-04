<%@ Page Title="Home Page"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="HW4.CachingData._Default" %>

<%@ Register Src="~/Controls/CurrentDateTime.ascx" TagPrefix="ctrl" TagName="CurrentDateTime" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        <h1 class="text-center"><ctrl:CurrentDateTime runat="server" ID="ControlCurrentDateTime" /></h1>
        <h2 class="text-center">Current Date and time control cached for 20 sec</h2>
    </div>
</asp:Content>