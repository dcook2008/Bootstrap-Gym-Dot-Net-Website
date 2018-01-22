<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="Assignment3.Success" %>
<%@ import Namespace="System.IO" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            <li><a href="Default.aspx">Home</a></li>
            <li class="active"><a href="Add.aspx">Add Fitness Class</a></li>
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
        <h1>Fitness Class Added</h1>
        

            
            
      </div>

    </div>
    
    </form>
</body>
</html>
