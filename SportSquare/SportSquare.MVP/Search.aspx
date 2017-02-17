<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SportSquare.MVP.Search" %>

<%--<%@ Register Src="~/GoogleMapsForASPNet.ascx" TagPrefix="uc1" TagName="GoogleMapsForASPNet" %>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="/content/search.css" type="text/css" />

    <div class="row">
        <div class="col-md-8 listViewContainer">
            <asp:ListView runat="server" ID="FilteredVenues" ItemType="SportSquareDTOs.VenueDTO">
                <LayoutTemplate>
                    <span runat="server" id="itemPlaceholder" />
                    <div class="pagerLine">
                        <asp:DataPager ID="DataPagerCustomers" runat="server" PageSize="6">
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
                        <div class="imageContainer col-md-2 col-sm-3 col-xs-4">
                            <div class="photoContainer">
                                <img class="img-responsive img-rounded" src="<%#:Item.Image %>" />
                            </div>
                        </div>
                        <div class="infoContainer col-md-6 col-sm-3 col-xs-2">
                            <div class="venueDetails">
                                <div class="venueScore btnSpecial pull-right" title="Рейтинг: <%#:string.Format("{0:F1}",Item.RatingAvarage) %>"><%#:string.Format("{0:F1}",Item.RatingAvarage) %>/10 </div>
                                <div class="venueName">
                                    <h2><span class="venueIndex"></span><%# Container.DataItemIndex+1 %>. <a href="venue" target="_blank"><%#: Item.Name %></a></h2>
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
                                <div class="buttons">
                                    <%--TODO Check if loged in, if not hide--%>
                                    <%--TODO make above with AJAXS--%>
                                    <asp:Button Text="Save" class="btn" ID="SaveButton" OnClick="SaveButton_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                        <%--<div class="detail tips ">
                                    <ul class="tips">
                                        <li class="tip">
                                            <div class="avatar">
                                                <img src="https://igx.4sqi.net/img/user/64x64/11962673-EB3GNJ42SCWEY0UN.jpg" alt="Elena K." class="avatar " width="64" height="64" title="Elena K." data-retina-url="https://igx.4sqi.net/img/user/128x128/11962673-EB3GNJ42SCWEY0UN.jpg">
                                            </div>
                                            <p class="tipText"><span class="tipAuthor "><a class="userName" href="/user/11962673" target="_blank">Elena K.</a> • April 8, 2016</span>The <span class="entity tip_taste_match">staff</span> is really <span class="entity tip_taste_match">friendly</span> and treat you like a family especially when you are one of the regulars. Lovely <span class="entity tip_taste_match">organic</span> <span class="entity tip_taste_match">cocktails</span> and <span class="entity tip_taste_match">lemonade</span>. The <span class="entity tip_taste_match">garden</span> works until 10pm which is a bit of disadvantage.</p>
                                        </li>
                                    </ul>
                                </div>--%>
                    </div>
                </ItemTemplate>
            </asp:ListView>

        </div>

        <div class="col-md-4 mapContainer">
        </div>
    </div>
</asp:Content>
