<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditVenues.aspx.cs" Inherits="SportSquare.MVP.AdminPanel.EditVenues" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="/content/search.css" type="text/css" />

    <div class="row pageContainer">


        <input id="filter" runat="server" class="form-control" style="display: inline-block" />
        <input id="location" runat="server" class="form-control" style="display: inline-block" />
        <asp:Button ID="search" Text="Намери" runat="server" class="btn btn-success" OnClick="Search_Click" />


        <asp:UpdatePanel runat="server" ID="SearchData">


            <ContentTemplate>
                <asp:UpdateProgress runat="server" DisplayAfter="1">
                    <ProgressTemplate>
                        <div class="progress">
                            <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="45" aria-valuemin="0" aria-valuemax="100" style="width: 45%">
                                <span class="sr-only">45% Complete</span>
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:ListView runat="server" ID="VenueList" ItemType="SportSquareDTOs.VenueDTO">
                    <LayoutTemplate>
                        <h3 class="text-center">Venues</h3>
                        <p></p>
                        <div class="panel panel-default">
                            <div class="panel-heading"></div>
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Title</th>
                                        <th>City</th>
                                        <th>Address</th>
                                        <th>Phone</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <span runat="server" id="itemPlaceholder" />
                                    <div class="pagerLine">
                                        <asp:DataPager ID="DataPagerCustomers" runat="server" PageSize="25" class="pagger">
                                            <Fields>
                                                <asp:NextPreviousPagerField ShowFirstPageButton="True"
                                                    ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                <asp:NumericPagerField />
                                                <asp:NextPreviousPagerField ShowLastPageButton="False"
                                                    ShowNextPageButton="True" ShowPreviousPageButton="False" />
                                            </Fields>
                                        </asp:DataPager>
                                    </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <th scope="row"><%# Container.DataItemIndex+1 %></th>
                            <td><%#:Item.Name %></td>
                            <td><%#: NormalizeString(Item.City) %></td>
                            <td><%#:Item.Address %></td>
                            <td><%#:Item.Phone %></td>
                            <td>
                                <asp:Button ID="Edit" Text="Edit" runat="server" class="btn btn-warning" OnClick="Edit_Click" />
                                <asp:Button ID="Delete" Text="Delete" runat="server" class="btn btn-danger" OnClick="Delete_Click" />
                            </td>
                    </ItemTemplate>
                </asp:ListView>
                </tbody>
                    </table>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="search" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
