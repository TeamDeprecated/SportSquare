<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SportSquare.MVP.Search" %>

<%--<%@ Register Assembly="Artem.Google" Namespace="Artem.Google.UI" TagPrefix="artem" %>--%>
<%@ Register Assembly="GoogleMaps" Namespace="GoogleMaps" TagPrefix="artem" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="/content/search.css" type="text/css" />

    <div class="row pageContainer">
        <div class="col-md-6 listViewContainer">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:ListView runat="server" ID="FilteredVenues" DataSource="<%#this.Model.FilteredVenues %>" ItemType="SportSquareDTOs.VenueDTO">
                        <LayoutTemplate>
                            <span runat="server" id="itemPlaceholder" />
                            <div class="pagerLine">
                                <asp:DataPager ID="DataPagerCustomers" runat="server" PageSize="5">
                                    <Fields>
                                        <asp:NextPreviousPagerField ShowFirstPageButton="True"
                                            ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                        <asp:NumericPagerField />
                                        <asp:NextPreviousPagerField ShowLastPageButton="True"
                                            ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    </Fields>
                                </asp:DataPager>
                            </div>
                        </LayoutTemplate>

                        <EmptyDataTemplate>
                            <div>Няма намерени спортни центрове</div>
                        </EmptyDataTemplate>

                        <ItemTemplate>
                            <div class="row">
                                <div class="imageContainer col-md-3 col-sm-3 col-xs-4">
                                    <div class="photoContainer">
                                        <img class="img-responsive img-rounded" src="<%#:Item.Image %>" />
                                    </div>
                                </div>
                                <div class="infoContainer col-md-9 col-sm-3 col-xs-2">
                                    <div class="venueDetails">
                                        <div class="venueScore btnSpecial pull-right" title="Рейтинг: <%#:string.Format("{0:F1}",Item.RatingAvarage) %>"><%#:string.Format("{0:F1}",Item.RatingAvarage) %>/10 </div>
                                        <div class="venueName">
                                            <h2><span class="venueIndex"></span><%# Container.DataItemIndex+1 %>.
                                        <asp:HyperLink NavigateUrl='<%# string.Format("~/venuedetails.aspx?id={0}", Item.Id) %>' runat="server" Text='<%#:Item.Name %>' /></h2>
                                        </div>
                                        <div class="venueMeta">
                                            <div class="venueAddressData">
                                                <asp:ListView runat="server" ItemType="SportSquareDTOs.VenueTypeDTO" ID="VenueType" DataSource="<%#Item.VenueTypes %>">
                                                    <ItemTemplate>
                                                        <span class="venueData"><span class="venueDataItem"><span class="categoryName"><%#Item.Name %></span>,</span>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                                <div class="venueAddress"><%#:Item.Address %>, <%#: Item.City    %></div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="resultFooter">

                                        <asp:LoginView runat="server" ViewStateMode="Disabled">
                                            <AnonymousTemplate>
                                            </AnonymousTemplate>
                                            <LoggedInTemplate>
                                                <asp:Button Text="Save" CssClass="btn btn-success" runat="server" />
                                            </LoggedInTemplate>
                                        </asp:LoginView>
                                        <div class="buttons">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="col-md-6 mapContainer">
            <div class="affix">
                <map:GoogleMap ID="GoogleMap1" runat="server" MapType="Roadmap" ApiKey="AIzaSyAR4Ih_of4fsUSaLhDrfIUOUCQIaKPxn8k" Height="550px" Latitude="42.7" Longitude="23.33" Zoom="13">
                </map:GoogleMap>
                <map:GoogleMarkers ID="Markers" TargetControlID="GoogleMap1" runat="server">
                    <Markers>
                    </Markers>
                </map:GoogleMarkers>
            </div>

        </div>
    </div>
</asp:Content>
