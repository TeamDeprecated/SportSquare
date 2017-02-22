<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VenueDetails.aspx.cs" Inherits="SportSquare.MVP.VenueDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="GoogleMaps" Namespace="GoogleMaps" TagPrefix="artem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManagerProxy runat="server" />
    <link rel="stylesheet" href="/content/venueDetails.css" type="text/css" />
    <link rel="stylesheet" href="http://fontawesome.io/assets/font-awesome/css/font-awesome.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.98.0/css/materialize.min.css">


    <asp:FormView runat="server" ID="FormViewVenueDetails" ItemType="SportSquareDTOs.VenueDetailedDTO" SelectMethod="FormViewVenueDetails_GetItem">
        <ItemTemplate>
            <div class="row info-container">
                <div class="col s2 image-cont">
                    <%--style="overflow: hidden"--%>
                    <asp:Image ImageUrl="<%#:Item.Image %>" runat="server" />
                </div>
                <div class="col s6">
                    <div class="row item-name">
                        <h3><%#:Item.Name%></h3>
                    </div>
                    <div class="row right">
                        <a href="<%#:Item.WebAddress %><%#:Item.WebAddress %>"><%#:Item.WebAddress %></a>
                    </div>
                    <div class="row">
                        <asp:ListView runat="server" DataSource="<%#Item.VenueTypes %>" ItemType="SportSquareDTOs.VenueTypeDTO">
                            <ItemTemplate>
                                <div class="chip">
                                    <%#:Item.Name %>
                                </div>

                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </div>
                <div class="col s4">
                    <div class="row rating">
                        <div class="row">
                            <div class="col s8 right">
                                <asp:Button CssClass="btn" ID="Save" runat="server" OnClick="Save_Click" Text="Save" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col s8 right">
                                <ajaxToolkit:Rating ID="VenueRating" runat="server"
                                    CurrentRating="<%#Item.RatingAvarage %>"
                                    MaxRating="5"
                                    StarCssClass="ratingStar fa fa-star"
                                    WaitingStarCssClass="savedRatingStar fa fa-star-half-o"
                                    FilledStarCssClass="filledRatingStar fa fa-star"
                                    EmptyStarCssClass="emptyRatingStar  fa fa-star-o "
                                    OnChanged="VenueRating_Changed" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Always">
                    <ContentTemplate>
                        <div class="col s8">
                            <div class="row">
                                <div class="widget-area no-padding blank">
                                    <asp:TextBox ID="VenueComment" runat="server"></asp:TextBox>
                                    <asp:Button ID="SaveComment" runat="server" class="btn waves-effect waves-light"
                                        Text="Коментар" OnClick="SaveComment_Click" />
                                </div>
                            </div>
                            <div class="row">
                                <asp:ListView runat="server" ItemType="SportSquareDTOs.CommentDTO" ID="Comments" DataSource="<%#this.Model.Venue.Comments %>">
                                    <ItemTemplate>

                                        <div class="row">
                                            <div class="col s1">
                                                <div class="thumbnail">
                                                    <img class="img-responsive user-photo" src="https://ssl.gstatic.com/accounts/ui/avatar_2x.png">
                                                </div>
                                            </div>

                                            <div class="col s10">
                                                <div class="panel panel-default">
                                                    <div class="panel-heading">
                                                        <strong><%#: Item.User %></strong> <span class="text-muted">commented on <%# string.Format("{0:d MMM yyyy HH:mm }",Item.Date)%></span>
                                                    </div>
                                                    <div class="panel-body">
                                                        <%#:Item.Description %>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <EmptyItemTemplate>
                                        Бъди първият коментирал това място!
                                    </EmptyItemTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="col-md-4 map-container">
                    <div class="row">
                        <map:GoogleMap ID="GoogleMap1" runat="server" MapType="Roadmap" ApiKey="AIzaSyAR4Ih_of4fsUSaLhDrfIUOUCQIaKPxn8k" Height="150px" Width="300px" Latitude="<%#Item.Latitude %>" Longitude="<%#Item.Longitude %>"  Zoom="20">
                        </map:GoogleMap>
                        <map:GoogleMarkers ID="Markers" TargetControlID="GoogleMap1" runat="server"  SelectMethod="FormViewVenueDetails_GetItem"  FitBounds="False">
                            <Markers>
                                <map:Marker  AutoOpen="False" Clickable="True"  Optimized="True" RaiseOnDrag="True"  Visible="True">
                                </map:Marker>

                            </Markers>
                        </map:GoogleMarkers>
                        <asp:ObjectDataSource runat="server" ID="ObjectDataSource1"></asp:ObjectDataSource>
                    </div>
                    <div class="row">
                        <h3><%#:Item.Name %></h3>
                        <%#:Item.Address %> <%#:Item.City %>
                    </div>
                    <div class="row">
                        <asp:HyperLink NavigateUrl="<%#:Item.WebAddress %>" Text="<%#:Item.WebAddress %>" runat="server" />
                    </div>
                </div>
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>
            Няма Намерен такъв обект    
        </EmptyDataTemplate>
    </asp:FormView>


</asp:Content>
