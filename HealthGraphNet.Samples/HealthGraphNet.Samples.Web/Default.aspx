<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="HealthGraphNet.Samples.Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">    
    <ol>   
	    <li>Create an application in the <a href="http://runkeeper.com/partner/applications" target="_blank">HealthGraph Applications Portal</a>.  
        Add the application's ClientId, ClientSecret and RequestUri to the Web.config.</li>
        <li style="padding-top: 8px;">Next, get an auth code from the <a href="" runat="server" ID="AAuthAnchor" target="_blank">HealthGraph Authorization Endpoint</a>.</li>
	    <li style="padding-top: 8px;">Then, to generate an access token and start using HealthGraphNet, hit your current url with the auth code from step 1 (<em>/?Code=AUTH_CODE</em>)</li>
    </ol>
    <hr />
    <asp:Panel ID="PnlTokenSamples" runat="server" Visible="false"> 
    	AccessType|Access Token => <asp:Label ID="LblAccessType" runat="server" />|<asp:Label ID="LblAccessToken" runat="server" /><br /><br />
        User =><ul>
            <li>User Id: <asp:Label ID="LblUserId" runat="server" /></li>
            <li>Strength Training Activities: <asp:Label ID="LblUserStrengthTrainingActivities" runat="server" /></li>
            <li>Weight: <asp:Label ID="LblUserWeight" runat="server" /></li>
            <li>Settings: <asp:Label ID="LblUserSettings" runat="server" /></li>
            <li>Diabetes: <asp:Label ID="LblUserDiabetes" runat="server" /></li>
            <li>Team: <asp:Label ID="LblUserTeam" runat="server" /></li>
            <li>Sleep: <asp:Label ID="LblUserSleep" runat="server" /></li>
            <li>Fitness Activities: <asp:Label ID="LblUserFitnessActivities" runat="server" /></li>
            <li>Nutrition: <asp:Label ID="LblUserNutrition" runat="server" /></li>
            <li>General Measurements: <asp:Label ID="LblUserGeneralMeasurements" runat="server" /></li>
            <li>Background Activities: <asp:Label ID="LblUserBackgroundActivities" runat="server" /></li>
            <li>Records: <asp:Label ID="LblUserRecords" runat="server" /></li>
            <li>Profile: <asp:Label ID="LblUserProfile" runat="server" /></li>        
        </ul>
    </asp:Panel>
</asp:Content>