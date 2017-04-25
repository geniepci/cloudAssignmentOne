<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="DeveloperPage.aspx.cs" Inherits="CloudAssignment.DeveloperPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class ="jumbotron">
    <h2>DEVELOPER MODE</h2>



</div>

        <table class="auto-style1">
            <tr>
                <td class="auto-style16"></td>
                <td class="auto-style10">CHOOSE OPTION</td>
                <td class="auto-style67">
                    <asp:Label ID="Label10" runat="server" Text="CHOOSE CATEGORY"></asp:Label>
                </td>
                <td class="auto-style47">
                    <asp:Label ID="Label12" runat="server" Text="CHOOSE CARD"></asp:Label>
                </td>
                <td class="auto-style55"></td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style11">
                    <asp:ListBox ID="optionList" runat="server" Height="60px" CssClass="auto-style61" Width="400px">
                        <asp:ListItem Value="1">Create Category</asp:ListItem>
                        <asp:ListItem Value="2">Create Card</asp:ListItem>
                        <asp:ListItem Value="3">Update Category</asp:ListItem>
<asp:ListItem Value="4">Update Card</asp:ListItem>
                        <asp:ListItem Value="5">Delete Category</asp:ListItem>
                        <asp:ListItem Value="6">Delete Card</asp:ListItem>
                    </asp:ListBox>
                </td>
                <td class="auto-style68">
                    <asp:ListBox ID="categoryList" runat="server" Height="60px" Width="400px"></asp:ListBox>
                </td>
                <td class="auto-style48">
                    <asp:ListBox ID="cardList" runat="server" Height="60px" Width="400px"></asp:ListBox>
                </td>
                <td class="auto-style56"></td>
            </tr>
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style20">
                    <asp:Button ID="chooseOption" runat="server" Text="SELECT" OnClick="chooseOption_Click" />
                </td>
                <td class="auto-style69">
                    <asp:Button ID="chooseCategory" runat="server" Text="SELECT" OnClick="chooseCategory_Click" />
                </td>
                <td class="auto-style66">
                    <asp:Button ID="chooseCard" runat="server" Text="SELECT" OnClick="chooseCard_Click" />
                </td>
                <td class="auto-style57"></td>
            </tr>
            
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style20">
                    &nbsp;</td>
                <td class="auto-style69">
                    <asp:Label ID="Label11" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td class="auto-style49">&nbsp;</td>
                <td class="auto-style57">&nbsp;</td>
            </tr>
            
            <tr>
                <td class="auto-style32"></td>
                <td class="auto-style33" style="text-align: right">
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
                <td class="auto-style70">
&nbsp;<asp:TextBox ID="nameTxtBox" runat="server" Width="400px"></asp:TextBox>
                </td>
                <td class="auto-style51" rowspan="5">
                    <asp:Image ID="blobImage" runat="server" Height="150px" Width="150px" />
                    </td>
                <td class="auto-style59"></td>
            </tr>
            
            <tr>
                <td class="auto-style38"></td>
                <td class="auto-style37" style="text-align: right">
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                    </td>
                <td class="auto-style71">
                    <asp:TextBox ID="attributeOneTxtBox" runat="server" Width="400px"></asp:TextBox>
                </td>
                <td class="auto-style60"></td>
            </tr>
            
            <tr>
                <td class="auto-style38">&nbsp;</td>
                <td class="auto-style37" style="text-align: right">
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                    </td>
                <td class="auto-style71">
                    <asp:TextBox ID="attributeTwoTxtBox" runat="server" Width="400px"></asp:TextBox>
                </td>
                <td class="auto-style60">&nbsp;</td>
            </tr>
            
            <tr>
                <td class="auto-style38">&nbsp;</td>
                <td class="auto-style37" style="text-align: right">
                    <asp:Label ID="Label6" runat="server"></asp:Label>
                    </td>
                <td class="auto-style71">
                    <asp:TextBox ID="attributeThreeTxtBox" runat="server" Width="400px"></asp:TextBox>
                </td>
                <td class="auto-style60">&nbsp;</td>
            </tr>
            
            <tr>
                <td class="auto-style38">&nbsp;</td>
                <td class="auto-style37" style="text-align: right">
                    <asp:Label ID="Label7" runat="server"></asp:Label>
                    </td>
                <td class="auto-style71">
                    <asp:TextBox ID="attributeFourTxtBox" runat="server" Width="400px"></asp:TextBox>
                </td>
                <td class="auto-style60">&nbsp;</td>
            </tr>
            
            <tr>
                <td class="auto-style38">&nbsp;</td>
                <td class="auto-style37" style="text-align: right">
                    <asp:Label ID="Label8" runat="server"></asp:Label>
                    </td>
                <td class="auto-style71">
                    <asp:TextBox ID="attributeFiveTxtBox" runat="server" Width="400px"></asp:TextBox>
                </td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style60">&nbsp;</td>
            </tr>
            
            <tr>
                <td class="auto-style38">&nbsp;</td>
                <td class="auto-style37" style="text-align: right">
                    <asp:Label ID="Label9" runat="server"></asp:Label>
                    </td>
                <td class="auto-style71">
                    <asp:FileUpload ID="blobUpload" runat="server" />
                </td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style60">&nbsp;</td>
            </tr>
            
            <tr>
                <td class="auto-style38">&nbsp;</td>
                <td class="auto-style37">
                    &nbsp;</td>
                <td class="auto-style71">
                    <asp:Label ID="Label13" runat="server" style="color: #0000FF"></asp:Label>
                </td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style60">&nbsp;</td>
            </tr>
            
            <tr>
                <td class="auto-style38">&nbsp;</td>
                <td class="auto-style37">
                    &nbsp;</td>
                <td class="auto-style71">
                    <asp:Button ID="deleteCategory" runat="server" OnClick="deleteCategory_Click" Text="DELETE CATEGORY" />
                    <asp:Button ID="deleteCard" runat="server" OnClick="deleteCard_Click" Text="DELETE CARD" />
                    <asp:Button ID="updateCategory" runat="server" OnClick="updateCategory_Click" Text="UPDATE CATEGORY" />
                    <asp:Button ID="updateCard" runat="server" OnClick="updateCard_Click" Text="UPDATE CARD" />
                    <asp:Button ID="createCard" runat="server" OnClick="createCard_Click" Text="CREATE CARD" />
                    <asp:Button ID="createCategory" runat="server" OnClick="createCategory_Click" Text="CREATE CATEGORY" />
                </td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style60">&nbsp;</td>
            </tr>
            
            <tr>
                <td class="auto-style38">&nbsp;</td>
                <td class="auto-style37">
                    &nbsp;</td>
                <td class="auto-style71">
                    &nbsp;</td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style60">&nbsp;</td>
            </tr>
        </table>
    <div>
    
    </div>
    </asp:Content>