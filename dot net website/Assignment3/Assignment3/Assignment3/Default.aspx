<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment3.Default" %>
<%@ import Namespace="System.IO" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<style type="text/css">
#filterBlock
{
    float:right;
    margin: -3% 7.5% 0%;
}
</style>

    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css" />
    <title>Fitness Class Manager</title>
</head>
<body>

    <form id="form1" runat="server">

         

        <!-- Fixed navbar -->
    <nav class="navbar navbar-default navbar-fixed-top">
      <div class="container">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="Default.aspx">FMS</a>
        </div>
        <div id="navbar" class="navbar-collapse collapse">
          <ul class="nav navbar-nav">
            <li class="active"><a href="Default.aspx">Home</a></li>
            <li><a href="Add.aspx">Add Fitness Class</a></li>
          </ul>
        </div><!--/.nav-collapse -->
      </div>
    </nav>

            <!-- Main jumbotron for a primary marketing message or call to action -->
    <div class="jumbotron">
      <div class="container">
        <h2>Fitness Management System</h2>
        <p>This is a fitness management system where classes may be added. The classes include a variety of details so the gym member may learn all the details they want to know about a potential class to sign up for.</p>
      </div>
    </div>

    <div class="container">
	<div class="page-header">
        <h1>Fitness Classes</h1>
        <div id="filterBlock">
        <asp:DropDownList ID="filterDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Change_Output" />
        </div>
        <hr />

        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
        <table class="table">
            <thead id="th">   
           <tr>
			  <th>ID</th>
			  <th>Description</th>
			  <th>Location</th>
			  <th>Spaces</th>
			  <th>Day</th>
			  <th>Time</th>
			  <th>Duration</th>
			  <th>Multi-week</th>
			  <th>Start-Date</th>
			  <th>Number of Sessions</th>
			</tr>	  
            </thead>
            </HeaderTemplate>
            <ItemTemplate>
            <tbody>
                <tr>
                    <td style="padding-top: 1.3em"><%# DataBinder.Eval(Container.DataItem, "id") %></td>
                    <td style="padding-top: 1.3em"><%# DataBinder.Eval(Container.DataItem, "description") %></td>
                    <td style="padding-top: 1.3em"><%# DataBinder.Eval(Container.DataItem, "location") %></td>
                    <td style="padding-top: 1.3em"><%# DataBinder.Eval(Container.DataItem, "spaces") %></td>
                    <td style="padding-top: 1.3em"><%# DataBinder.Eval(Container.DataItem, "day") %></td>
                    <td style="padding-top: 1.3em"><%# DataBinder.Eval(Container.DataItem, "time") %></td>
                    <td style="padding-top: 1.3em"><%# DataBinder.Eval(Container.DataItem, "duration") %> Minutes</td>
                    <td style="padding-top: 1.3em"><%# DataBinder.Eval(Container.DataItem, "multiweek") %></td>
                    <td style="padding-top: 1.3em"><%# DataBinder.Eval(Container.DataItem, "startdate") %></td>
                    <td style="padding-top: 1.3em"><%# DataBinder.Eval(Container.DataItem, "nos") %></td>

                </tr>
            
            </tbody>
                </ItemTemplate>
                
            <FooterTemplate>
            </table>
            </FooterTemplate>
            </asp:Repeater>

            
            
      </div>

      <%-- <asp:Button Text="Save" ID="saveButton" runat="server" OnClick="Save_Click" width="120px" class="btn btn-primary btn-lg" /> &nbsp &nbsp --%>
      <asp:Button Text="Load" ID="loadButton" runat="server" OnClick="Load_Click" width="120px" class="btn btn-primary btn-lg" />

      <hr />

      <footer>&copy FMS 2015</footer>

    </div>

        

        
    
    </form>
</body>
</html>
