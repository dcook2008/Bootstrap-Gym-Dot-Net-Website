using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment3
{


    public partial class Add : System.Web.UI.Page
    {
        bool mw;

        /// <summary>
        /// Sets up the controls to be shown on the page and any other details such as placeholder text to aid the user in completing the form
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {

            
            DateTime currentDate = new DateTime();

            currentDate = DateTime.Today;

            

            int i = 0;
            nosTextBox.Enabled = false;

            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            string[] locations = { "City Gym", "Plaza Gym", "Aquatic Gym", "New Gym", "Quadrant Gym" };

            foreach (string day in daysOfWeek)
            {
                dowDropDownList.Items.Add(new ListItem(daysOfWeek[i], daysOfWeek[i]));
                i++;
            }

            i = 0;

            foreach (string loc in locations)
            {
                locationDropDownList.Items.Add(new ListItem(locations[i], locations[i]));
                i++;
            }

           
            durationTextBox.Attributes["placeholder"] = "Minutes of class";
            timeTextBox.Attributes["placeholder"] = "e.g. 09:30";
            descriptionTextBox.Attributes["placeholder"] = "e.g. Spinning";
            startdateTextBox.Attributes["placeholder"] = "e.g. 09/07/2015";

            currentdateTextBox.Text = currentDate.ToString("dd/MM/yyyy");

        }

        /// <summary>
        /// Enables and disables a text box dependent on the check state of a check box
        /// </summary>
        protected void Check_CheckedChanged(object sender, EventArgs e)
        {
            if (multiweekCheckBox.Checked)
            {
                nosTextBox.Enabled = true;
            }
            else if (!multiweekCheckBox.Checked)
            {
                nosTextBox.Enabled = false;
            }
        }

        /// <summary>
        /// A custom validater used to check a particular field that is a string when the text field is disabled and an integer if not
        /// </summary>
        protected void nosValidate(object source, ServerValidateEventArgs args)
        {
            if (nosTextBox.Text == null || nosTextBox.Text == "")
            {
                nosTextBox.Text = "N/A";
                args.IsValid = true;
                mw = false;
            }
            else
            {
                try
                {
                    int number = Convert.ToInt32(nosTextBox.Text);

                    if (number < 51 && number > 1)
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                        nosTextBox.Text = "";
                    }

                    nosCustomValidator.ErrorMessage = "Number of sessions must be between 2 and 50";
                    mw = true;
                    multiweekCheckBox.Checked = false;
                    


                }
                catch
                {
                    nosCustomValidator.ErrorMessage = "Incorrect characters entered. You must enter a number for the number of sessions.";
                    nosTextBox.Text = "";
                    args.IsValid = false;
                    multiweekCheckBox.Checked = false;
                }
                
            }

           
            
        }

        /// <summary>
        /// If the form details have been filled in correctly then a new class is added to the fitness class list. In the case the user has enter a duplicate ID a
        /// exception is thrown with the message shown in a message window
        /// </summary>
        protected void submitButton_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                try
                {
                    

                    FitnessClassManager.FitnessClassOpportunity fco = new FitnessClassManager.FitnessClassOpportunity(Int32.Parse(idTextBox.Text), descriptionTextBox.Text, locationDropDownList.SelectedValue,
                                                                           Int32.Parse(spacesTextBox.Text), dowDropDownList.SelectedValue, Convert.ToDateTime(timeTextBox.Text),
                                                                           Int32.Parse(durationTextBox.Text), mw, Convert.ToDateTime(startdateTextBox.Text), nosTextBox.Text);

                    XmlDocument doc = new XmlDocument();

                    string[] dets = new string[10];


                    FitnessClassManager.FitnessClassList fitnessClassList = new FitnessClassManager.FitnessClassList();

                    fitnessClassList.addFitnessClass(fco);

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

                    FitnessClassManager.TextReportGenerator trg = new FitnessClassManager.TextReportGenerator(fitnessClassList);
                    trg.GenerateAllReport(Server.MapPath("~/App_Data/report_all.xml"));

                    Response.Redirect("Success.aspx");
                }
                catch(FitnessClassManager.DuplicateIdException dIP)
                {
                    string display = dIP.Message;
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                }
               
            }
            else
            {
                validationSummary.ShowSummary = true;
            }

            }

        }
    }
