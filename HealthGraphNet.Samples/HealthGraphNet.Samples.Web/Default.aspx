<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="HealthGraphNet.Samples.Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">    
    <ol>
    <li><strong>First, get an auth code from the HealthGraph authorization endpoint:</strong><br />
    https://runkeeper.com/apps/authorize?client_id=<em>CLIENT_ID</em>&redirect_uri=<em>URL_ENCODED_REDIRECT_URI</em>&response_type=code
    </li>
    <li style="padding-top: 4px;"><strong>Then, to generate an access token and start using HealthGraphNet, hit this url with your auth code:</strong><br />
    <%= Request.Url.ToString() %>?Code=<em>AUTH_CODE</em></li>
    </ol>
    <hr />
    Access Token: <asp:Label ID="LblAccessToken" runat="server" /><br />
</asp:Content>
