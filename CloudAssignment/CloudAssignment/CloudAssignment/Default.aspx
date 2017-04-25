<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CloudAssignment.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class ="jumbotron">
    <h1>TOP TRUMPS</h1>
    <p class="lead">Lorem ipsum dolor sit amet, pri nemore audire elaboraret ex, cum brute aliquip instructior ex, urbanitas omittantur ex cum</p>
        <p><a href="/LoginBasic.aspx" class="btn btn-primary btn-lg">Sign In »</a></p>


</div>

        <div class="row">
        <div class="col-md-4">
            <h2>Play Game</h2>
            <p>
Mei blandit adversarium contentiones ei. Accumsan dignissim ei vim. At vix movet contentiones, sea et tempor phaedrum maiestatis. Quis velit graeco duo cu. Ex tamquam democritum percipitur est, eum wisi nihil cetero eu. .           
            </p>
            <p>
                <a class="btn btn-default" href="GamePage0.aspx">Play Game &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>High Score Table</h2>
            <p>
Pro an invenire definiebas, brute posidonium vituperatoribus quo eu, ut ius vivendo dissentias. Novum aliquid invenire eum in. Nec soleat graeci delenit te. Nisl mentitum incorrupte in nam. Usu et convenire evertitur.            </p>
            <p>
                <a class="btn btn-default" href="HighScores">High Scores &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Add Players</h2>
            <p>
Dico zril quaestio sit ea, graecis apeirian ad sit. At quo nihil oporteat mandamus, at vix debet facilisi argumentum. Vis et altera atomorum. Mei ex veniam consul alienum, eum sint integre aliquid te, malis consectetuer ex est. Veniam vidisse te sit, sea ornatus consulatu ne.            </p>
            <p>
                <a class="btn btn-default" href="Players1.aspx">Add Players »</a>
            </p>
        </div>
    </div>
    <p style="font-size: large">Some of our recent categories<asp:ObjectDataSource ID="categoryImages" runat="server" SelectMethod="GetCategories" TypeName="CloudAssignment.DeveloperPage"></asp:ObjectDataSource>
                  
    </p>
       <br />                
                        
                        <asp:DataList ID="DataList1" runat="server" DataSourceID="categoryImages" RepeatDirection="Horizontal" RepeatColumns="4"  >
                            <ItemTemplate>
                                <asp:Image ID="Image2" runat="server" Height="300px" ImageUrl='<%# Eval("ImageURI") %>' Width="300px" />
                                &nbsp;<br />
                                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                                <br />
<br />
                            </ItemTemplate>
                        </asp:DataList>
                  
    </asp:Content>
