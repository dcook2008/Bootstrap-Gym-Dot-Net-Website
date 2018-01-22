



<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Assignment3.Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css" />
    <title></title>
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
    <%-- Summarise any error messages as a consequence of the validation process --%>
	<asp:ValidationSummary ID="validationSummary" ShowMessageBox="true" HeaderText="Add Fitness Class" runat="Server" />
    <asp:Panel ID="spacerPanel11" runat="server" Height="30px" Width="50px" />
    <h3>Add Fitness Class</h3>
    <hr />
    
    <asp:Label ID="idLabel" runat="server" Text="ID:" ToolTip="Must be numeric and unique" /> 
    <asp:TextBox ID="idTextBox" runat="server" ToolTip="Must be numeric and unique" />
    <asp:Panel ID="spacerPanel1" runat="server" Height="20px" Width="50px" />

    <asp:Label ID="descriptionLabel" runat="server" Text="Description:" /> 
    <asp:TextBox ID="descriptionTextBox" runat="server" />
    <asp:Panel ID="spacerPanel2" runat="server" Height="20px" Width="50px" />

    <asp:Label ID="locationLabel" runat="server" Text="Location:" /> 
    <asp:DropDownList ID="locationDropDownList" runat="server" />
    <asp:Panel ID="spacerPanel3" runat="server" Height="20px" Width="50px" />

    <asp:Label ID="spacesLabel" runat="server" Text="Spaces:" /> 
    <asp:TextBox ID="spacesTextBox" runat="server"/>
    <asp:Panel ID="spacerPanel4" runat="server" Height="20px" Width="50px" />

    <asp:Label ID="dowLabel" runat="server" Text="Day of Week:" /> 
    <asp:DropDownList ID="dowDropDownList" runat="server" />
    <asp:Panel ID="spacerPanel5" runat="server" Height="20px" Width="50px" />

    <asp:Label ID="timeLabel" runat="server" Text="Time:" /> 
    <asp:TextBox ID="timeTextBox" runat="server" />
    <asp:Panel ID="spacerPanel6" runat="server" Height="20px" Width="50px" />

    <asp:Label ID="durationLabel" runat="server" Text="Duration:" /> 
    <asp:TextBox ID="durationTextBox" runat="server" />
    <asp:Panel ID="spacerPanel7" runat="server" Height="20px" Width="50px" />

    <asp:Label ID="multiweekLabel" runat="server" Text="Multi-week:" /> 
    <asp:CheckBox ID="multiweekCheckBox" runat="server" AutoPostBack="true" OnCheckedChanged="Check_CheckedChanged" ToolTip="Does the class take place over multiple weeks" />
    <asp:Panel ID="spacerPanel8" runat="server" Height="20px" Width="50px" />

    <asp:Label ID="currentdateLabel" runat="server" Text="Current Date:" /><asp:TextBox ID="currentdateTextBox" runat="server" ReadOnly="true" />
    <asp:Panel ID="Panel1" runat="server" Height="20px" Width="50px" />

    <asp:Label ID="startdateLabel" runat="server" Text="Start Date:" /> 
    <asp:TextBox ID="startdateTextBox" runat="server" />
    <asp:Panel ID="spacerPanel9" runat="server" Height="20px" Width="50px" />

    <asp:Label ID="nosLabel" runat="server" Text="Number of Sessions:" /> 
    <asp:TextBox ID="nosTextBox" runat="server" />
    <asp:Panel ID="spacerPanel10" runat="server" Height="30px" Width="50px" />

    <asp:Button Text="Submit" ID="submitButton" runat="server" OnClick="submitButton_Click"  />
    <asp:Panel ID="Panel2" runat="server" Height="5px" Width="50px" />
    <p>*Please Note: Gym classes start between 06:00 and 20:00 if a valid time format is entered outside of these times it will be automatically converted e.g. 05:00 would be converted to 17:00</p>
    

    

    <%-- Validate that the ID field is not empty --%>
   	<asp:RequiredFieldValidator ID="idRequiredFieldValidator" runat="server"
   		ControlToValidate="idTextBox" ErrorMessage="ID cannot be empty!"
   		Display="None" SetFocusOnError="True" >
   	</asp:RequiredFieldValidator>

    <%-- Validate that the Description field is not empty --%>
   	<asp:RequiredFieldValidator ID="descriptionRequiredFieldValidator" runat="server"
   		ControlToValidate="descriptionTextBox" ErrorMessage="Description cannot be empty!"
   		Display="None" SetFocusOnError="True" >
   	</asp:RequiredFieldValidator>

    <%-- Validate that the Spaces field is not empty --%>
   	<asp:RequiredFieldValidator ID="spacesRequiredFieldValidator" runat="server"
   		ControlToValidate="spacesTextBox" ErrorMessage="Spaces cannot be empty!"
   		Display="None" SetFocusOnError="True" >
   	</asp:RequiredFieldValidator>

    <%-- Validate that the Time field is not empty --%>
   	<asp:RequiredFieldValidator ID="timeRequiredFieldValidator" runat="server"
   		ControlToValidate="timeTextBox" ErrorMessage="Time cannot be empty!"
   		Display="None" SetFocusOnError="True" >
   	</asp:RequiredFieldValidator>

    <%-- Validate that the Duration field is not empty --%>
   	<asp:RequiredFieldValidator ID="durationRequiredFieldValidator" runat="server"
   		ControlToValidate="durationTextBox" ErrorMessage="Duration cannot be empty!"
   		Display="None" SetFocusOnError="True" >
   	</asp:RequiredFieldValidator>

    <%-- Validate that the Duration field is not empty --%>
   	<asp:RequiredFieldValidator ID="startdateRequiredFieldValidator" runat="server"
   		ControlToValidate="startdateTextBox" ErrorMessage="Start Date cannot be empty!"
   		Display="None" SetFocusOnError="True" >
   	</asp:RequiredFieldValidator>

    <%-- Check if the nos field is enable then validate that the nos field is not empty and the input is an integer between 1 and 20 --%>
    <asp:CustomValidator id="nosCustomValidator" runat="server" 
        OnServerValidate="nosValidate" ValidateEmptyText="true"
        ControlToValidate="nosTextBox" Display="None" 
        >
    </asp:CustomValidator>

    <%-- Checks if the value enter is an integer between 3 and 100 --%>
    <asp:RangeValidator ID="spacesRangeValidator" runat="server" 
        ControlToValidate="spacesTextBox" ErrorMessage="Spaces must be a number between 3 and 100"
        Display="None" SetFocusOnError="true" MinimumValue="3" MaximumValue="100" Type="Integer">
    </asp:RangeValidator>

    <%-- Checks if the value is an integer between 15 and 180 --%>
    <asp:RangeValidator ID="durationRangeValidator" runat="server" 
        ControlToValidate="durationTextBox" ErrorMessage="The duration of the class must be between 15 and 180"
        Display="None" SetFocusOnError="true" MinimumValue="15" MaximumValue="180" Type="Integer">
    </asp:RangeValidator>

    <%-- Checks if the value is an enter is above 0 --%>
    <asp:RangeValidator ID="idRangeValidator" runat="server" 
        ControlToValidate="idTextBox" ErrorMessage="ID must be one or above and be a unique number."
        Display="None" SetFocusOnError="true" MinimumValue="1" MaximumValue="1000000" Type="Integer">
    </asp:RangeValidator>

    <%-- Checks if the date entered is in the correct format --%>
    <asp:CompareValidator ID="startdateCompareValidator" runat="server"
        ControlToValidate="startdateTextBox" ErrorMessage="Start date is not in the correct format!"
        Operator="DataTypeCheck"  Type="Date" Display="None" SetFocusOnError="true"></asp:CompareValidator>

        <%-- Checks the date of the class is not starting at a date that has already passed at the point it is added to the system --%>
    <asp:CompareValidator ID="startdateCompareValidator2" runat="server"
        ControlToValidate="startdateTextBox" 
        ErrorMessage="Start date must be more than or equal to the current date!"
        Operator="GreaterThanEqual" ControlToCompare="currentdateTextBox" 
        Type="Date" Display="None" SetFocusOnError="true">
        </asp:CompareValidator>

    <%-- Check the time field is entered in the expected form --%>
    <asp:RegularExpressionValidator ID="timeRegularExpressionValidator" runat="server"
        ControlToValidate="timeTextBox" ErrorMessage="Invalid time entered" 
        ValidationExpression="^^([0-1]?[0-9]|2[0-4]):([0-5][0-9])(:[0-5][0-9])?$"
        Display="None" SetFocusOnError="true">
    </asp:RegularExpressionValidator>
    

    </form>

    <hr />
    
    <footer>&copy FMS 2015</footer>
    </div>
</body>
</html>
