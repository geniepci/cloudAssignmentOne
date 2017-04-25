<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="GamePage.aspx.cs" Inherits="CloudAssignment.GamePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        



    <style>
  
        .auto-style1 {
            width: 100%;
            background-color: #FFFFFF;
        }
        .auto-style9 {
            width: 236px;
            background-color: #FFFFFF;
        }
        .auto-style10 {
            height: 26px;
            width: 236px;
            background-color: #FFFFFF;
        }
        .auto-style17 {
            width: 274px;
            text-align: center;
        }
        .auto-style18 {
            height: 26px;
            width: 274px;
            text-align: center;
        }
        .auto-style19 {
            height: 4px;
            width: 274px;
            text-align: center;
        }
        .auto-style25 {
            width: 144px;
        }
        .auto-style26 {
            height: 26px;
            width: 144px;
        }
        .auto-style27 {
            height: 4px;
            width: 144px;
        }
        .auto-style33 {
            width: 144px;
            height: 33px;
        }
        .auto-style35 {
            width: 274px;
            height: 33px;
            text-align: center;
        }
        .auto-style36 {
            width: 236px;
            height: 33px;
            background-color: #FFFFFF;
        }
        .auto-style37 {
            height: 33px;
        }
        .auto-style38 {
            width: 295px;
            background-color: #FFFFFF;
            text-align: center;
        }
        .auto-style39 {
            width: 295px;
            height: 33px;
            background-color: #FFFFFF;
            text-align: center;
        }
        .auto-style40 {
            height: 26px;
            width: 295px;
            background-color: #FFFFFF;
            text-align: center;
        }
        .auto-style41 {
            height: 4px;
            width: 295px;
            background-color: #FFFFFF;
            text-align: center;
        }
        .auto-style43 {
            width: 304px;
            background-color: #FFFFFF;
            text-align: center;
        }
        .auto-style44 {
            width: 304px;
            height: 33px;
            background-color: #FFFFFF;
            text-align: center;
        }
        .auto-style45 {
            height: 26px;
            width: 304px;
            background-color: #FFFFFF;
            text-align: center;
        }
        .auto-style46 {
            height: 4px;
            width: 304px;
            background-color: #FFFFFF;
            text-align: center;
        }
        .auto-style47 {
            font-size: x-large;
        }
        </style>



        <table class="auto-style1">
            <tr>
                <td class="auto-style25">
                                <asp:Image ID="Image5" runat="server" Height="80px" Width="80px" />
                            </td>
                <td class="auto-style38">
                                &nbsp;</td>
                <td class="auto-style17">
                    &nbsp;</td>
                <td class="auto-style43">
                                &nbsp;</td>
                <td>
                                <asp:Image ID="Image6" runat="server" Height="80px" Width="80px" />
                            </td>
            </tr>
            <tr>
                <td class="auto-style25">&nbsp;</td>
                <td class="auto-style38">
                                &nbsp;</td>
                <td class="auto-style17">
                    &nbsp;</td>
                <td class="auto-style43">
                                &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style25">
                    <asp:ListBox ID="ListBox1" runat="server" Width="163px" Height="213px"></asp:ListBox>
                </td>
                <td class="auto-style38">
                    <asp:Image ID="Image1" runat="server" Height="225px" Width="225px" />
                </td>
                <td class="auto-style17">
                    <asp:Label ID="Label1" runat="server" CssClass="auto-style47" ForeColor="Red" Text="Select An Attribute"></asp:Label>
                    <asp:Label ID="resultLabel" runat="server" Font-Size="X-Large" ForeColor="Red"></asp:Label>
                    <asp:Label ID="victoryLabel" runat="server" Font-Size="X-Large" ForeColor="Red"></asp:Label>
                </td>
                <td class="auto-style43">
                    <asp:Image ID="Image2" runat="server" Height="225px" Width="225px" />
                </td>
                <td>
                    <asp:ListBox ID="ListBox2" runat="server" Width="145px" Height="204px"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style25">&nbsp;</td>
                <td class="auto-style38">
                    <asp:Label ID="cardNamePlayerOne" runat="server"></asp:Label>
                </td>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style43">
                    <asp:Label ID="cardNamePlayerTwo" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style25">&nbsp;</td>
                <td class="auto-style38">&nbsp;</td>
                <td class="auto-style17">
                    <br />
                </td>
                <td class="auto-style43">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style33">
                    &nbsp;</td>
                <td class="auto-style39">
                    <asp:Button ID="playerOneButtonOne" runat="server" Text="Button" Height="40px" Width="250px" OnClick="playerOneButtonOne_Click" />
                </td>
                <td class="auto-style35">
                    &nbsp;</td>
                <td class="auto-style44">
                    <asp:Button ID="playerTwoButtonOne" runat="server" Height="40px" Text="Button" Width="250px" OnClick="playerTwoButtonOne_Click" />
                </td>
                <td class="auto-style37">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style25">
                    &nbsp;</td>
                <td class="auto-style38">
                    &nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style43">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style25">
                    &nbsp;</td>
                <td class="auto-style38">
                    <asp:Button ID="playerOneButtonTwo" runat="server" Height="40px" Text="Button" Width="250px" OnClick="playerOneButtonTwo_Click" />
                </td>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style43">
                    <asp:Button ID="playerTwoButtonTwo" runat="server" Height="40px" Text="Button" Width="250px" OnClick="playerTwoButtonTwo_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style25">
                    &nbsp;</td>
                <td class="auto-style38">
                    &nbsp;</td>
                <td class="auto-style17">
                    &nbsp;</td>
                <td class="auto-style43">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style25">&nbsp;</td>
                <td class="auto-style38">
                    <asp:Button ID="playerOneButtonThree" runat="server" Height="40px" Text="Button" Width="250px" OnClick="playerOneButtonThree_Click" />
                </td>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style43">
                    <asp:Button ID="playerTwoButtonThree" runat="server" Height="40px" Text="Button" Width="250px" OnClick="playerTwoButtonThree_Click" />
                </td>
                <td class="auto-style36">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style25">&nbsp;</td>
                <td class="auto-style38">&nbsp;</td>
                <td class="auto-style17">
                    &nbsp;</td>
                <td class="auto-style43">&nbsp;</td>
                <td class="auto-style9">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style26">
                    &nbsp;</td>
                <td class="auto-style40">
                    <asp:Button ID="playerOneButtonFour" runat="server" Height="40px" Text="Button" Width="250px" OnClick="playerOneButtonFour_Click" />
                </td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style45">
                    <asp:Button ID="playerTwoButtonFour" runat="server" Height="40px" Text="Button" Width="250px" OnClick="playerTwoButtonFour_Click" />
                </td>
                <td class="auto-style9">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style25">&nbsp;</td>
                <td class="auto-style38">
                    &nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style43">
                    &nbsp;</td>
                <td class="auto-style9">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style26">
                    <asp:Button ID="quitGame" runat="server" OnClick="quitGame_Click" Text="QUIT GAME" />
                </td>
                <td class="auto-style40">
                    <asp:Button ID="playerOneButtonFive" runat="server" Height="40px" Text="Button" Width="250px" OnClick="playerOneButtonFive_Click" />
                </td>
                <td class="auto-style18">
                    <asp:Button ID="nextCard" runat="server" OnClick="nextCard_Click" Text="NEXT CARD" Height="40px" Width="250px"/>
                    <asp:Button ID="playAgain" runat="server" Height="40px" OnClick="playAgain_Click" Text="PLAY AGAIN" Width="250px" />
                </td>
                <td class="auto-style45">
                    <asp:Button ID="playerTwoButtonFive" runat="server" Height="40px" Text="Button" Width="250px" OnClick="playerTwoButtonFive_Click" />
                </td>
                <td class="auto-style9">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style27">
                    &nbsp;</td>
                <td class="auto-style41">
                    &nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style46">
                    &nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style25">
                    &nbsp;</td>
                <td class="auto-style38">
                    &nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style43">
                    &nbsp;</td>
                <td class="auto-style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style26">
                    </td>
                <td class="auto-style40">
                    </td>
                <td class="auto-style18"></td>
                <td class="auto-style45">
                    </td>
                <td class="auto-style9">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style26">
                    </td>
                <td class="auto-style40">
                    </td>
                <td class="auto-style18">
                    </td>
                <td class="auto-style45"></td>
                <td class="auto-style10">
                    </td>
            </tr>
            <tr>
                <td class="auto-style25">
                    &nbsp;</td>
                <td class="auto-style38">
                    &nbsp;</td>
                <td class="auto-style17">
                    &nbsp;</td>
                <td class="auto-style43">
                    &nbsp;</td>
                <td class="auto-style9">
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Content>
