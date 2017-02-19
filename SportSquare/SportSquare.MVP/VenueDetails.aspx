<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VenueDetails.aspx.cs" Inherits="SportSquare.MVP.VenueDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="FormViewVenueDetails" ItemType="SportSquareDTOs.VenueDetailedDTO" SelectMethod="FormViewVenueDetails_GetItem">
        <ItemTemplate>
            <header>
                <h1><%#:Item.Name%></h1>
            </header>
            <div class="row">
                <asp:Image ImageUrl="<%#:Item.Image %>" runat="server" />
                <div><%#:Item.Address %></div>
                <div><%#:Item.Phone %></div>
                <div><%#:Item.WebAddress %></div>
                <div><%#:Item.RatingAvarage %></div>
<%--                <ajaxToolkit:Rating ID="VenueRating" runat="server"
                    CurrentRating="2"
                    MaxRating="5"
                    StarCssClass="ratingStar"
                    WaitingStarCssClass="savedRatingStar"
                    FilledStarCssClass="filledRatingStar"
                    EmptyStarCssClass="emptyRatingStar"
                    OnChanged="VenueRating_Changed" />--%>

                <asp:BulletedList ID="VenueTypesBuletList" runat="server" ItemType="SportSquareDTOs.VenueTypeDTO" DataSource="<%#Item.VenueTypes %>" DataValueField="Name" BulletStyle="Circle"></asp:BulletedList>
            </div>
            <div class="row">
                <asp:ListView runat="server" ItemType="SportSquareDTOs.CommentDTO" ID="Comments" DataSource="<%#Item.Comments %>">
                    <ItemTemplate>
                        <div class="row">
                            <div class="col-md-3">Comment by: <%#:Item.User %></div>
                            <div class="col-md-3"><%# string.Format("{0:d MMM yyyy}",Item.Date) %></div>
                        </div>

                        <div class="row"><%#Item.Description %></div>

                    </ItemTemplate>
                </asp:ListView>
            </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
