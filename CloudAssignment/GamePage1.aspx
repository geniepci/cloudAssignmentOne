<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="GamePage1.aspx.cs" Inherits="CloudAssignment.GamePage1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class ="jumbotron">
    <h2>SELECT YOUR CATEGORY&nbsp; </h2>
            <h2>
                <asp:Label ID="Label1" runat="server" style="color: #FF0000"></asp:Label>
            </h2>



</div>


                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="auto-style3" DataSourceID="ObjectDataSource1" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="900px" HorizontalAlign="Center">
                            <Columns>
                                <asp:CommandField ButtonType="Button" ShowSelectButton="True">
                                    <ControlStyle Height="40px" Width="75px" />
                                    <ItemStyle Height="150px" Width="250px" />

                                </asp:CommandField>
                                <asp:ImageField DataImageUrlField="ImageURI">
                                    <ControlStyle Height="150px" Width="150px" />
                                    <ItemStyle Height="200px" Width="250px" />
                                </asp:ImageField>
                                <asp:BoundField DataField="Name" SortExpression="Name">
                                <ItemStyle Width="150px" Font-Size="Large" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PartitionKey" SortExpression="PartitionKey">
                                <ControlStyle Width="1px" />
                                <ItemStyle ForeColor="White" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RowKey" SortExpression="RowKey">
                                <ControlStyle Width="1px" />
                                <ItemStyle ForeColor="White" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                 
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetCategories" TypeName="CloudAssignment.DeveloperPage"></asp:ObjectDataSource>
    
      
    </asp:Content>