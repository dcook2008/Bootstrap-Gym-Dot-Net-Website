using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessClassManager
{
    interface IFileHandler
    {
        void WriteFitnessClassListToFile(FitnessClassList fitnessClassList, String filePath);
        FitnessClassList ReadFitnessClassListFromFile(String filePath);
    }
}
