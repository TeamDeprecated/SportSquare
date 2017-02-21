<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SportSquare.MVP.Home" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="home">
        <h1>SportSquare</h1>
        <p>
        Намери най-доброто място за спорт близо до теб.
        По твой критерии.
        </p>
        <asp:Localize runat="server"></asp:Localize>
        <input id="filter" runat="server" class="form-control" style="display:inline-block"/>
        <input id="location" runat="server" class="form-control" style="display:inline-block" />
        <asp:Button ID="search" Text="Намери" runat="server" class="btn btn-success" OnClick="Search_Click"/>
    </div>
</asp:Content>
