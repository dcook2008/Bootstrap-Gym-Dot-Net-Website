using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment3
{
 

    public partial class Default : System.Web.UI.Page
    {
        FitnessClassManager.FitnessClassList fitnessClassList = new FitnessClassManager.FitnessClassList();

        /// <summary>
        /// Populates the list box with the another function to show a particular report if available
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {        

            if (!IsPostBack)
            {

                string[] filterChoices = {"Show All", " \xA0 \xA0 -------- by day --------" , "Monday Classes", "Tuesday Classes", "Wednesday Classes", "Thursday Classes", "Friday Classes", "Saturday Classes", "Sunday Classes",
                                          " \xA0 \xA0 -------- by location --------", "City Gym", "Plaza Gym", "Aquatic Gym", "New Gym", "Quadrant Gym"};

                

                foreach(string choice in filterChoices)
                {
                    if (choice == filterChoices[1] || choice == filterChoices[9])
                    {
                        // Should the user select a label rather than an item the code will find the non-applicable value result in no change to the table output
                        filterDropDownList.Items.Add(new ListItem(choice, "N/A"));
                       
                    }
                    else
                    {
                            filterDropDownList.Items.Add(new ListItem(choice, choice));
                    }
                }
             }
               
                
            } 
        

        protected void Load_Click(object sender, EventArgs e)
        {
            Load_Data();
        }

        /// <summary>
        /// A method used to retrieve the data which stores the fitness classes
        /// </summary>
        protected void Load_Data()
        {
            XmlDocument doc = new XmlDocument();

            string[] dets = new string[10];




            doc.Load(Server.MapPath("~/App_Data/report_all.xml"));

            XmlNode root = doc.DocumentElement;
            IEnumerator ienum = root.GetEnumerator();
            XmlNodeList fitnessClass = doc.GetElementsByTagName("class");

            int i = 0;



            foreach (XmlNode node in fitnessClass)
            {
                foreach (XmlNode childNode in node.ChildNodes)
                {

                    dets[i] = childNode.InnerText;
                    i++;

                    if (i == 10)
                    {
                        if (dets[7] == "No" || dets[7] == "no")
                            dets[7] = "false";
                        else
                            dets[7] = "true";

                        FitnessClassManager.FitnessClassOpportunity fcp = new FitnessClassManager.FitnessClassOpportunity(Int32.Parse(dets[0]), dets[1], dets[2], Int32.Parse(dets[3]), dets[4], Convert.ToDateTime(dets[5]),
                                                                            Int32.Parse(dets[6]), Convert.ToBoolean(dets[7]), Convert.ToDateTime(dets[8]), dets[9]);

                        i = 0;

                        fitnessClassList.addFitnessClass(fcp);

                    }
                }
            }


            fitnessClassList.Sort();

            FitnessClassManager.TextReportGenerator trg = new FitnessClassManager.TextReportGenerator(fitnessClassList);
            trg.GenerateAllReport(Server.MapPath("~/App_Data/report_all.xml"));

            if (filterDropDownList.SelectedValue == "Show All")
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/App_Data/report_all.xml"));
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
            }


            trg.GenerateDayReport(Server.MapPath("~/App_Data/report_Monday.xml"), "Monday");
            trg.GenerateDayReport(Server.MapPath("~/App_Data/report_Tuesday.xml"), "Tuesday");
            trg.GenerateDayReport(Server.MapPath("~/App_Data/report_Wednesday.xml"), "Wednesday");
            trg.GenerateDayReport(Server.MapPath("~/App_Data/report_Thursday.xml"), "Thursday");
            trg.GenerateDayReport(Server.MapPath("~/App_Data/report_Friday.xml"), "Friday");
            trg.GenerateDayReport(Server.MapPath("~/App_Data/report_Saturday.xml"), "Saturday");
            trg.GenerateDayReport(Server.MapPath("~/App_Data/report_Sunday.xml"), "Sunday");
            trg.GenerateLocationReport(Server.MapPath("~/App_Data/report_CityGym.xml"), "City Gym");
            trg.GenerateLocationReport(Server.MapPath("~/App_Data/report_PlazaGym.xml"), "Plaza Gym");
            trg.GenerateLocationReport(Server.MapPath("~/App_Data/report_AquaticGym.xml"), "Aquatic Gym");
            trg.GenerateLocationReport(Server.MapPath("~/App_Data/report_NewGym.xml"), "New Gym");
            trg.GenerateLocationReport(Server.MapPath("~/App_Data/report_QuadrantGym.xml"), "Quadrant Gym");
        }

        /// <summary>
        /// When the user selects to change the report list the dropdown list checks the value and retrieves the value then shows the list
        /// if the list is not available a message window is shown informing the user of this
        /// </summary>
        protected void Change_Output(object sender, EventArgs e)
        {
            FitnessClassManager.TextReportGenerator trg = new FitnessClassManager.TextReportGenerator(fitnessClassList);
            DataSet ds = new DataSet();

            if (filterDropDownList.SelectedValue == "Show All")
            {
                try
                {
                    ds.ReadXml(Server.MapPath("~/App_Data/report_all.xml"));
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
                catch
                {
                    string display = "Sorry there are currently no classes.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                }
            }
            else if (filterDropDownList.SelectedValue == "Monday Classes")
            {
                try
                {
                    ds.ReadXml(Server.MapPath("~/App_Data/report_Monday.xml"));
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
                catch
                {
                    string display = "Sorry there are currently no classes held on a Monday currently.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                }
            }
            else if (filterDropDownList.SelectedValue == "Tuesday Classes")
            {
                try
                {
                    ds.ReadXml(Server.MapPath("~/App_Data/report_Tuesday.xml"));
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
                catch
                {
                    string display = "Sorry there are currently no classes held on a Tuesday currently.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                }
            }
            else if (filterDropDownList.SelectedValue == "Wednesday Classes")
            {
                try
                {
                    ds.ReadXml(Server.MapPath("~/App_Data/report_Wednesday.xml"));
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
                catch
                {
                    string display = "Sorry there are currently no classes held on a Wednesday currently.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                }
            }
            else if (filterDropDownList.SelectedValue == "Thursday Classes")
            {
                try
                {
                    ds.ReadXml(Server.MapPath("~/App_Data/report_Thursday.xml"));
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
                catch
                {
                    string display = "Sorry there are currently no classes held on a Thursday currently.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                }
            }
            else if (filterDropDownList.SelectedValue == "Friday Classes")
            {
                try
                {
                    ds.ReadXml(Server.MapPath("~/App_Data/report_Friday.xml"));
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
                catch
                {
                    string display = "Sorry there are currently no classes held on a Friday currently.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                }
            }
            else if (filterDropDownList.SelectedValue == "Saturday Classes")
            {
                try
                {
                    ds.ReadXml(Server.MapPath("~/App_Data/report_Saturday.xml"));
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
                catch
                {
                    string display = "Sorry there are currently no classes held on a Saturday currently.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                }
            }
            else if (filterDropDownList.SelectedValue == "Sunday Classes")
            {
                try
                {
                    ds.ReadXml(Server.MapPath("~/App_Data/report_Sunday.xml"));
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
                catch
                {
                    string display = "Sorry there are currently no classes held on a Sunday currently.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                }
            }
            else if (filterDropDownList.SelectedValue == "City Gym")
            {
                try
                {
                    ds.ReadXml(Server.MapPath("~/App_Data/report_CityGym.xml"));
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
                catch
                {
                    string display = "Sorry there are currently no classes held on at City Gym currently.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                }
            }
            else if (filterDropDownList.SelectedValue == "Plaza Gym")
            {
                try
                {
                    ds.ReadXml(Server.MapPath("~/App_Data/report_PlazaGym.xml"));
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
                catch
                {
                    string display = "Sorry there are currently no classes held on at Plaza Gym currently.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                }
            }
            else if (filterDropDownList.SelectedValue == "New Gym")
            {
                try
                {
                    ds.ReadXml(Server.MapPath("~/App_Data/report_NewGym.xml"));
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
                catch
                {
                    string display = "Sorry there are currently no classes held on at New Gym currently.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                }
            }
            else if (filterDropDownList.SelectedValue == "Quadrant Gym")
            {
                try
                {
                    ds.ReadXml(Server.MapPath("~/App_Data/report_QuadrantGym.xml"));
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
                catch
                {
                    string display = "Sorry there are currently no classes held on at Quadrant Gym currently.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                }
            }
            else if (filterDropDownList.SelectedValue == "Aquatic Gym")
            {
                try
                {
                    ds.ReadXml(Server.MapPath("~/App_Data/report_AquaticGym.xml"));
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
                catch
                {
                    string display = "Sorry there are currently no classes held on at Aquatic Gym currently.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                }
            }

            

        }

    }
}