using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessClassManager
{
    interface IFitnessClassManagerUI
    {
        void RunReportAll();
        void RunReportDay();
        void RunReportLocation();
        void SaveData();
        void LoadData();
        void AddFitnessClass();
        void RemoveFitnessClass();
    }
}
