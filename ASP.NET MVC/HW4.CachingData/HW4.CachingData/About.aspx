<%@ Page Title="About" Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="About.aspx.cs" 
    Inherits="HW4.CachingData.About" %>

<%@ OutputCache Duration="3600" VaryByParam="*" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <h1 class="text-center">Time is cached on: <span id="currentTime" runat="server"></span></h1>
</asp:Content>