<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditVenues.aspx.cs" Inherits="SportSquare.MVP.AdminPanel.EditVenues" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="/content/search.css" type="text/css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.98.0/css/materialize.min.css">

    <div>
        <div class="row">
            <div class="divider"></div>
            <div class="section">
                <input id="filter" runat="server" class="form-control" style="display: inline-block"/>
                <input id="location" runat="server" class="form-control" style="display: inline-block"/>
                <asp:Button ID="search" Text="Намери" runat="server" class="btn btn-success btn-large" OnClick="Search_Click"/>
            </div>
        </div>
        <div class="row">
            <div class="col s6">
                <asp:UpdatePanel runat="server" ID="SearchData">
                    <ContentTemplate>
                        <asp:UpdateProgress runat="server">
                            <ProgressTemplate>
                                <div class="progress">
                                    <div class="indeterminate"></div>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:ListView runat="server" ID="VenueList" ItemType="SportSquareDTOs.VenueDTO" AutoPostBack="false">
                            <LayoutTemplate>
                                <h3 class="text-center">Results</h3>
                                <div class="panel panel-default">
                                <div class="panel-heading">
                                    <span>
                                </div>
                                <table class="table">
                                <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Title</th>
                                    <th>City</th>
                                    <th>Address</th>
                                    <th></th>
                                </tr>
                                </thead>
                                <tbody>
                                <span runat="server" id="itemPlaceholder"/>
                                <div class="pagination">
                                    <asp:DataPager ID="DataPagerCustomers" runat="server" PageSize="5">
                                        <Fields>
                                            <asp:NextPreviousPagerField ShowFirstPageButton="false"
                                                                        ShowNextPageButton="False" ShowPreviousPageButton="true"/>
                                            <asp:NumericPagerField
                                                CurrentPageLabelCssClass="pagination active"
                                                NextPreviousButtonCssClass="pagination disabled"
                                                NumericButtonCssClass="pagination waves-effect"/>
                                            <asp:NextPreviousPagerField ShowLastPageButton="False"
                                                                        ShowNextPageButton="True" ShowPreviousPageButton="False" ButtonType="Button" ButtonCssClass=""/>
                                        </Fields>
                                    </asp:DataPager>
                                </div>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                <th scope="row"><%# Container.DataItemIndex + 1 %></th>
                                <td><%#:Item.Name %></td>
                                <td><%#: NormalizeString(Item.City) %></td>
                                <td><%#:Item.Address %></td>
                                <%--<td><%#:Item.Phone %></td>--%>
                                <td>
                                    <%--<asp:Button ID="Edit" Text="Edit" runat="server" class="btn btn-warning" OnClick="Edit_Click" />--%>

                                    <asp:Button runat="server" Text="Edit" class="btn btn-warning"
                                                ID="VenueIDButton"
                                                CommandName="InfoClick"
                                                CommandArgument="<%# Item.Id %>"
                                                OnClick="InfoClick"/>

                                    <asp:Button ID="Delete" Text="Delete" runat="server" class="btn btn-danger" OnClick="Delete_Click"/>

                                </td>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <div>Няма намерени спортни центрове</div>
                            </EmptyDataTemplate>
                        </asp:ListView>
                        </tbody>
                        </table>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="search" EventName="Click"/>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <div class="col s6">

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:FormView ID="VenueDetails" ItemType="SportSquareDTOs.VenueDTO" runat="server">
                            <ItemTemplate>
                                <div>
                                    <h3 class="text-center">Editing</h3>
                                </div>
                                <div class="form-horizontal">
                                    <hr/>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="VenueId" CssClass="col-md-2 control-label">Title</asp:Label>
                                        <div class="col-md-10">

                                            <asp:TextBox runat="server" ID="VenueId" Style="display: none" Text="<%#Item.Id %>" CssClass="form-control"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="VenueName" CssClass="col-md-2 control-label">Title</asp:Label>
                                        <div class="col-md-10">

                                            <asp:TextBox runat="server" ID="VenueName" Text="<%#Item.Name %>" CssClass="form-control"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="VenueCity" CssClass="col-md-2 control-label">City</asp:Label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="VenueCity" Text="<%#Item.City %>" CssClass="form-control"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="VenueAddress" T CssClass="col-md-2 control-label">Address</asp:Label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="VenueAddress" TextMode="MultiLine" Text="<%#Item.Address %>" CssClass="form-control"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="VenuePhone" CssClass="col-md-2 control-label">Phone</asp:Label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="VenuePhone" Text="<%#Item.Phone %>" CssClass="form-control"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="VenueWebAddress" CssClass="col-md-2 control-label">WebAddress</asp:Label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="VenueWebAddress" Text="<%#Item.WebAddress %>" CssClass="form-control" TextMode="Url"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="VenueLongitude" CssClass="col-md-2 control-label">Longitude</asp:Label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="VenueLongitude" Text="<%#Item.Longitude %>" TextMode="SingleLine" CssClass="form-control"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="VenueLatitude" CssClass="col-md-2 control-label">Latitude</asp:Label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="VenueLatitude" Text="<%#Item.Latitude %>" TextMode="SingleLine" CssClass="form-control"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-offset-2 col-md-10">
                                            <asp:Button runat="server" Text="Save Changes" OnClick="Save_Changes" CssClass="btn btn-default"/>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:FormView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.98.0/js/materialize.min.js"></script>
</asp:Content>