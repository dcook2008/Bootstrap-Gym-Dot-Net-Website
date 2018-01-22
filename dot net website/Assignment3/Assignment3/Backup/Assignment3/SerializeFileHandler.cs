using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace FitnessClassManager
{
    class SerializeFileHandler : IFileHandler
    {
        public void WriteFitnessClassListToFile(FitnessClassList fitnessClassList, String filePath)
        {
            FileStream outFile;
            BinaryFormatter bFormatter = new BinaryFormatter();

            // open file for output
            outFile = new FileStream(filePath, FileMode.Create, FileAccess.Write);

            // output object to file via serialization
            bFormatter.Serialize(outFile, fitnessClassList);

            // close file
            outFile.Close();
        }

        public FitnessClassList ReadFitnessClassListFromFile(String filePath)
        {
            FileStream inFile;
        	FitnessClassList fitnessClassList = null;
            BinaryFormatter bFormatter = new BinaryFormatter();

            // open file for input
            inFile = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            // keep going while there are still records to read
            while (inFile.Position < inFile.Length)
            {
                // obtain object from file via serialization
                fitnessClassList = (FitnessClassList)bFormatter.Deserialize(inFile);
            }

            // close file
            inFile.Close();

        	return fitnessClassList;
        }
    }
}
