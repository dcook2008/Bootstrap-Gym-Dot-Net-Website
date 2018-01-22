using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace FitnessClassManager
{
    class TextReportGenerator : IReportGenerator
    {
        public readonly FitnessClassList fitnessClassList;

        public TextReportGenerator(FitnessClassList fitnessClassList)
        {
            this.fitnessClassList = fitnessClassList;
        }

        public void GenerateAllReport(String filePath)
        {
            CreateReport(filePath, FitnessClassListSorterFilterer.SortById(fitnessClassList));
        }

        public void GenerateDayReport(String filePath, String selectedDay)
        {
            CreateReport(filePath, FitnessClassListSorterFilterer.FilterDay(fitnessClassList, selectedDay));
        }

        public void GenerateLocationReport(String filePath, String selectedLocation)
        {
            CreateReport(filePath, FitnessClassListSorterFilterer.FilterLocation(fitnessClassList, selectedLocation));
        }

        private void CreateReport(String filePath, FitnessClassList fitnessClassList)
        {
            FileStream outFile;
            StreamWriter writer;

            outFile = new FileStream(filePath, FileMode.Create,
                                     FileAccess.Write);
            writer = new StreamWriter(outFile);

            for (int i=0; i < fitnessClassList.Count(); i++)
            {
                FitnessClassOpportunity f = fitnessClassList.getFitnessClass(i);

                // output fitness class opportunity details and enclose these details with the xml root tags

                if (i == 0)
                    writer.WriteLine("<fitnessclasses>");
             
                writer.WriteLine(f.ToString());

                if (i == fitnessClassList.Count() - 1)
                    writer.WriteLine("</fitnessclasses>");
            }

            // close writer
            writer.Close();

            // close file
            outFile.Close();
        }
    }
}
