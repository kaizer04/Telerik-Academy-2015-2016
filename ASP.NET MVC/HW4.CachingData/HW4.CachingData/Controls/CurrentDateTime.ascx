<%@ Control Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="CurrentDateTime.ascx.cs" 
    Inherits="HW4.CachingData.Controls.CurrentDateTime" %>

<%@ OutputCache Duration="20" VaryByParam="*" %>

<div id="ctrlCurrentDateTime" runat="server"></div>