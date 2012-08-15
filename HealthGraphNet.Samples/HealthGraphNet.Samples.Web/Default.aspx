<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="HealthGraphNet.Samples.Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">    
    <ol>   
	    <li><strong>First, get an auth code from the HealthGraph authorization endpoint:</strong><br />
	    <a href="" runat="server" ID="AAuthAnchor" target="_blank"></a>
	    </li>
	    <li style="padding-top: 8px;"><strong>Then, to generate an access token and start using HealthGraphNet, hit your current url with the auth code:</strong><br />
	    /?Code=<em><%= string.IsNullOrEmpty(Code) ? "AUTH_CODE" : Code %></em></li>
    </ol>
    <hr />
    <asp:Panel ID="PnlTokenSamples" runat="server" Visible="false"> 
    	Access Token: <asp:Label ID="LblAccessToken" runat="server" /><br />
    </asp:Panel>
</asp:Content>