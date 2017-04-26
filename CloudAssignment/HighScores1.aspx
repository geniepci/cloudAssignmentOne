<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="HighScores1.aspx.cs" Inherits="CloudAssignment.HighScores1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class ="jumbotron">
    <h2>HIGH SCORES TABLE</h2>



    <p>&nbsp;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/HighScores.aspx">All Scores</asp:HyperLink>
&nbsp;| Your Scores</p>



</div>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="playerData1" Width="900px" HorizontalAlign="Center">
                            <Columns>
                                <asp:ImageField DataImageUrlField="ImageURI" HeaderText="Picture">
                                    <ControlStyle Height="150px" Width="150px" />
                                </asp:ImageField>
                                <asp:BoundField DataField="PlayerName" HeaderText="PlayerName" SortExpression="PlayerName">
                                <ItemStyle Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Wins" HeaderText="Wins" SortExpression="Wins">
                                <ControlStyle Width="200px" />
                                <FooterStyle Width="200px" />
                                <HeaderStyle Width="200px" />
                                <ItemStyle Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Losses" HeaderText="Losses       " SortExpression="Losses">
                                <HeaderStyle Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Games" HeaderText="Games" SortExpression="Games">
                                <ControlStyle Width="200px" />
                                <ItemStyle Width="200px" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="playerData1" runat="server" SelectMethod="GetPlayerScores" TypeName="CloudAssignment.Players0"></asp:ObjectDataSource>
          
         
        
    
   
    </asp:Content>

