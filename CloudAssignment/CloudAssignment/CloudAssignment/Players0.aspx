<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Players0.aspx.cs" Inherits="CloudAssignment.Players0" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class ="jumbotron">
    
           <h2>ADD A PLAYER</h2> </div>


     
                       
                <div id="divInputMessage"          
                    style="width: auto; padding: 5px; border-style: inset; border-width: medium; margin: 10px 0px 10px 0px; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
                    <table style="width: auto;">
                        <tr>
                            <td style="vertical-align: top; text-align: right">
                                <label>Player Name :</label>
                            </td>
                            <td>
                                <asp:TextBox 
                                        ID="txtPlayerName" 
                                        runat="server" Width="200px" MaxLength="20"/>
                            </td>
                        </tr>
                                            <tr>
                            <td>
                                <label for="PhotoUpload">Photo:</label>
                            </td>
                            <td>
                                <asp:FileUpload ID="PhotoUpload" runat="server" />
                            </td> 
                        </tr> 
                    </table>

                    <div class="text-left">
                        <asp:Button ID="addPlayer" runat="server" OnClick="addPlayer_Click" 
                            Text = "Add Player" />&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;
                        <br />
                        <br />
                        <asp:Label ID="Label1" runat="server" style="font-size: large"></asp:Label>
                    </div>  
                </div>

                <div style="width: auto; padding: 5px; background-color: lightsteelblue; " class="auto-style2">
                    Players</div>

                <asp:DataList 
                    ID="dataListPlayers" 
                    runat="server" 
                    DataSourceID="dsPlayers" CellPadding="4" 
                    ForeColor="#333333" GridLines="Both" style="margin-right: 0px; width: 600px;" RepeatDirection="Horizontal">
                    <AlternatingItemStyle BackColor="White" />
                    <FooterStyle BackColor="HotPink" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="LightSteelBlue" Font-Bold="True" ForeColor="White" />
                    <ItemStyle BackColor="White" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                    <ItemTemplate>
                        <div style="width:100%; display:table; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: smaller; ">
                            <div style="display:table-row; height: 125px;">
                                <div style="display:table-cell;">
                                    <img src="<%# Eval("ImageURI") %>" style="width: 125px; height: 125px;" /> 
                                </div>
                                <div style="display:table-cell; vertical-align:top; padding:10px; ">      
                                    &nbsp;<br />
                                    </div>
                            </div> 
                        </div>
                        <asp:Label ID="PlayerNameLabel" runat="server" Text='<%# Eval("PlayerName") %>' />
                        <br />
                        <div style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
                        <br />
                        <br />
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:DataList>

                <asp:ObjectDataSource 
                   ID="dsPlayers"
                   runat="server"
                   SelectMethod="GetPlayers" 
                   TypeName="CloudAssignment.Players0" 
                   OldValuesParameterFormatString="original_{0}">
                </asp:ObjectDataSource>

                <div style="text-align: right">
                    &nbsp;&nbsp;
                    </div> 

        </asp:Content>