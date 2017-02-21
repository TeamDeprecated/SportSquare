<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VenueDetails.aspx.cs" Inherits="SportSquare.MVP.VenueDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="GoogleMaps" Namespace="GoogleMaps" TagPrefix="artem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManagerProxy runat="server" />
    <link rel="stylesheet" href="/content/venueDetails.css" type="text/css" />
    <link rel="stylesheet" href="http://fontawesome.io/assets/font-awesome/css/font-awesome.css">


    <asp:FormView runat="server" ID="FormViewVenueDetails" ItemType="SportSquareDTOs.VenueDetailedDTO" SelectMethod="FormViewVenueDetails_GetItem">
        <ItemTemplate>
            <div class="row">Тук трябва да се визуализират снимките от фитнеса! Ако няма???</div>
            <div class="row info-container">
                <div class="col-md-2 image-cont" style="overflow: hidden">
                    <asp:Image ImageUrl="<%#:Item.Image %>" runat="server" />
                </div>
                <div class="col-md-6">
                    <div class="row item-name">
                        <h1><%#:Item.Name%></h1>
                    </div>
                    <div class="row">
                        <h3><a href="<%#:Item.WebAddress %><%#:Item.WebAddress %>"><%#:Item.WebAddress %></a></h3>
                    </div>
                    <div class="row">
                        <asp:ListView runat="server" DataSource="<%#Item.VenueTypes %>" ItemType="SportSquareDTOs.VenueTypeDTO">
                            <ItemTemplate><span><%#:Item.Name %>, </span></ItemTemplate>
                        </asp:ListView>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="row rating">
                        <div class="col-md-2"></div>
                        <asp:Button CssClass="btn btn-success col-md-4" ID="Save" runat="server" OnClick="Save_Click" Text="Save" />
                        <div class="col-md-4">

                            <%--<%#:Item.RatingAvarage %>--%>
                        </div>
                    </div>
                    <div class="row like">
                        айдееееее на лайковете
                    </div>
                </div>
            </div>
            <div class="row">
                <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Always">
                    <ContentTemplate>
                        <div class="col-md-8">
                            <div class="row">
                                <div class="widget-area no-padding blank">

                                    <%--<div class="status-upload">--%>
                                    <asp:TextBox ID="VenueComment" runat="server" Text="Кометари"></asp:TextBox>
                                     <%--<asp:TextBox runat="server" ID="TextBox1" />--%>
                                                <ajaxToolkit:HtmlEditorExtender ID="HtmlEditorExtender1"
                                                    TargetControlID="VenueComment" DisplaySourceTab="true" EnableSanitization="false"
                                                    runat="server" />
                                                <Toolbar>
                                                    <ajaxToolkit:Undo />
                                                    <ajaxToolkit:Redo />
                                                    <ajaxToolkit:Bold />
                                                    <ajaxToolkit:Italic />
                                                    <ajaxToolkit:Underline />
                                                    <ajaxToolkit:StrikeThrough />
                                                    <ajaxToolkit:Subscript />
                                                    <ajaxToolkit:Superscript />
                                                    <ajaxToolkit:JustifyLeft />
                                                    <ajaxToolkit:JustifyCenter />
                                                    <ajaxToolkit:JustifyRight />
                                                    <ajaxToolkit:JustifyFull />
                                                    <ajaxToolkit:InsertOrderedList />
                                                    <ajaxToolkit:InsertUnorderedList />
                                                    <ajaxToolkit:CreateLink />
                                                    <ajaxToolkit:UnLink />
                                                    <ajaxToolkit:RemoveFormat />
                                                    <ajaxToolkit:SelectAll />
                                                    <ajaxToolkit:UnSelect />
                                                    <ajaxToolkit:Delete />
                                                    <ajaxToolkit:Cut />
                                                    <ajaxToolkit:Copy />
                                                    <ajaxToolkit:Paste />
                                                    <ajaxToolkit:BackgroundColorSelector />
                                                    <ajaxToolkit:ForeColorSelector />
                                                    <ajaxToolkit:FontNameSelector />
                                                    <ajaxToolkit:FontSizeSelector />
                                                    <ajaxToolkit:Indent />
                                                    <ajaxToolkit:Outdent />
                                                    <ajaxToolkit:InsertHorizontalRule />
                                                    <ajaxToolkit:HorizontalSeparator />
                                                    <ajaxToolkit:InsertImage />
                                                </Toolbar>
                                            </ajaxToolkit:HtmlEditorExtender>
                                    <ul>
                                        <li><a title="" data-toggle="tooltip" data-placement="bottom" data-original-title="Picture"><i class="fa fa-picture-o"></i></a></li>
                                    </ul>
                                    <asp:Button ID="SaveComment" runat="server" class="fa fa-share"
                                        Text="Comment" OnClick="SaveComment_Click" />


                                    <%--</div>--%>
                                </div>
                            </div>
                            <div class="row">
                                <asp:ListView runat="server" ItemType="SportSquareDTOs.CommentDTO" ID="Comments" DataSource="<%#this.Model.Venue.Comments %>">
                                    <ItemTemplate>

                                        <div class="row">
                                            <div class="col-md-1">
                                                <div class="thumbnail">
                                                    <img class="img-responsive user-photo" src="https://ssl.gstatic.com/accounts/ui/avatar_2x.png">
                                                </div>
                                            </div>

                                            <div class="col-md-5">
                                                <div class="panel panel-default">
                                                    <div class="panel-heading">
                                                        <strong><%#: Item.User %></strong> <span class="text-muted">commented on <%# string.Format("{0:d MMM yyyy}",Item.Date)%></span>
                                                    </div>
                                                    <div class="panel-body">
                                                        <%#:Item.Description %>
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
                        <map:GoogleMap ID="GoogleMap1" runat="server" MapType="Roadmap" ApiKey="AIzaSyAR4Ih_of4fsUSaLhDrfIUOUCQIaKPxn8k" Height="150px" Width="300px" Latitude="42.7" Longitude="23.33" Zoom="13">
                        </map:GoogleMap>
                        <map:GoogleMarkers ID="Markers" TargetControlID="GoogleMap1" runat="server">
                            <Markers>
                            </Markers>
                        </map:GoogleMarkers>
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


    <ajaxToolkit:Rating ID="VenueRating" runat="server"
        CurrentRating="3"
        MaxRating="5"
        StarCssClass="ratingStar fa fa-star"
        WaitingStarCssClass="savedRatingStar fa fa-star-half-o"
        FilledStarCssClass="filledRatingStar fa fa-star"
        EmptyStarCssClass="emptyRatingStar  fa fa-star-o "
        OnChanged="VenueRating_Changed" />
</asp:Content>
