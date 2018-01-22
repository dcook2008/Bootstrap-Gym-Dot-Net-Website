using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessClassManager
{
    [Serializable]
    public class FitnessClassOpportunity : IComparable<FitnessClassOpportunity>
    {
        private int id;

        public int Id
        {
          get { return id; }
          set { id = value; }
        }

        private String description;
        private String location;

        public String Location
        {
            get { return location; }
            set { location = value; }
        }

        private int spaces;
        private String day;

        public String Day
        {
            get { return day; }
            set { day = value; }
        }

        private DateTime time;
        private int duration;
        private bool multiWeek;

        public bool MultiWeek
        {
            get { return multiWeek; }
            set { multiWeek = value; }
        }

        private DateTime startDate;
        private String numSessions;

        public FitnessClassOpportunity(int id,
                                    String description,
                                    String location,
                                    int spaces,
                                    String day,
                                    DateTime time,
                                    int duration,
                                    bool multiWeek,
                                    DateTime startDate,
                                    String numSessions)
        {
            this.id = id;
            this.description = description;
            this.location = location;
            this.spaces = spaces;
            this.day = day;
            this.time = time;
            this.duration = duration;
            this.multiWeek = multiWeek;
            this.startDate = startDate;
            this.numSessions = numSessions;
        }


        /// <summary>
        /// Creates a string in XML form to be used with a repeater in the application. The time format is 24 hour so I have included a not very elegant way of ensuring the times sit between
        /// 06:00 and 20:00 meaning classes can't start before 6am or after 8pm to make the system more realistic
        /// </summary>
        /// <returns> A string with XML syntax to later be written to an XML file </returns>
        public override string ToString()
        {
            String str;
            String strTime;




            strTime = String.Format("{0:HH:mm}", time);

            string strTimeCheck = strTime[0].ToString() + strTime[1].ToString();

            if (strTimeCheck == "00")
            {
                strTime = "12" + strTime.Remove(0, 2);
            }
            else if (strTimeCheck == "01")
            {
                strTime = "13" + strTime.Remove(0, 2);
            }
            else if (strTimeCheck == "02")
            {
                strTime = "14" + strTime.Remove(0, 2);
            }
            else if (strTimeCheck == "03")
            {
                strTime = "15" + strTime.Remove(0, 2);
            }
            else if (strTimeCheck == "04")
            {
                strTime = "16" + strTime.Remove(0, 2);
            }
            else if (strTimeCheck == "05")
            {
                strTime = "17" + strTime.Remove(0, 2);
            }
            else if (strTimeCheck == "21")
            {
                strTime = "09" + strTime.Remove(0, 2);
            }
            else if (strTimeCheck == "22")
            {
                strTime = "10" + strTime.Remove(0, 2);
            }
            else if (strTimeCheck == "23")
            {
                strTime = "11" + strTime.Remove(0, 2);
            }

            String multiWeekString;

            if (multiWeek)
            {
                multiWeekString = "Yes";
            }
            else
            {
                multiWeekString = "No";
            }

            str = String.Format("<class> <id>{0}</id> <description>{1}</description> <location>{2}</location> <spaces>{3}</spaces> <day>{4}</day> <time>{5}</time> <duration>{6}</duration> <multiweek>{7}</multiweek> <startdate>{8}</startdate> <nos>{9}</nos> </class>",
                                    id,
                                    description,
                                    location,
                                    spaces,
                                    day,
                                    strTime,
                                    duration,
                                    multiWeekString,
                                    startDate.Date.ToShortDateString(),
                                    numSessions);
            return str;
        }

        /// <summary>
        /// Compares fitness classes by ID sorting them numrically and returning each one to eventually create a list sorted in numrical order when
        /// this method is called from the FitnessClassList class
        /// </summary>
        public int CompareTo(FitnessClassOpportunity fitnessClass)
        {
            if (this.id > fitnessClass.id)
            {
                return 1;
            }
            else if (this.id < fitnessClass.id)
            {
                return -1;
            }
            else
            {
                return 0;
            }

            
        }

      
    }
}
