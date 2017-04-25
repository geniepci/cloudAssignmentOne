<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="GamePage2a.aspx.cs" Inherits="CloudAssignment.GamePage2a" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class ="jumbotron">
   <h2>
<asp:Label ID="Label1" runat="server" ></asp:Label>

</h2>
</div>


                  
                                

                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderStyle="None" CssClass="auto-style15" DataSourceID="playerData" GridLines="None" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" Width="900px" HorizontalAlign="Center">
                                        <Columns>
                                            <asp:CommandField ButtonType="Button" ShowSelectButton="True">
                                                <ControlStyle Height="40px" Width="75px" />
                                                <ItemStyle Height="150px" Width="250px" />
                                            </asp:CommandField>
                                            <asp:ImageField DataImageUrlField="ImageURI">
                                                <ControlStyle Height="150px" Width="150px" />
                                                <ItemStyle Height="200px" Width="250px" />
                                            </asp:ImageField>
                                            <asp:BoundField DataField="PlayerName" SortExpression="PlayerName">
                                             <ItemStyle Width="150px" Font-Size="Large" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PartitionKey" SortExpression="PartitionKey">
                                            <ControlStyle Width="1px" />
                                            <ItemStyle ForeColor="White" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RowKey" SortExpression="RowKey">
                                            <ControlStyle ForeColor="White" Width="1px" />
                                            <ItemStyle ForeColor="White" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                
                                <asp:ObjectDataSource ID="playerData" runat="server" SelectMethod="GetPlayers" TypeName="CloudAssignment.Players0"></asp:ObjectDataSource>
                              
    </asp:Content>