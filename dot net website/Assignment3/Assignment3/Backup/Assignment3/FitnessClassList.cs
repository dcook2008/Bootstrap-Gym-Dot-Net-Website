using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessClassManager
{
    [Serializable]
    class FitnessClassList
    {
        /// <summary>
        /// Declare then then initiate a list of classes
        /// </summary>
        private List<FitnessClassOpportunity> fitnessClassList;

        public FitnessClassList()
        {
            fitnessClassList = new List<FitnessClassOpportunity>();
        }

        public void addFitnessClass(FitnessClassOpportunity fitnessClassOpportunity)
        {
            
            // Make sure a class with this ID does not already exist
            foreach (FitnessClassOpportunity f in fitnessClassList)
            {
                if (f.Id == fitnessClassOpportunity.Id)
                {
                    throw new DuplicateIdException();
                }
            }

            fitnessClassList.Add(fitnessClassOpportunity);
        }

        // Removes a fitness class at a specified index in the list
        public void removeFitnessClass(int index)
        {
            fitnessClassList.RemoveAt(index);
        }

        public void removefitnessClass(FitnessClassOpportunity fitnessClassOpportunity)
        {
            fitnessClassList.Remove(fitnessClassOpportunity);
        }

        public FitnessClassOpportunity getFitnessClass(int index)
        {
            return fitnessClassList[index];
        }

        // Counts the amount of fitness classes opportunity then return that number
        public int Count()
        {
            return fitnessClassList.Count;
        }

        // Calls a sort method - detailed in the fitness class opportunity class - which sorts the class numerically by ID
        public void Sort()
        {
            fitnessClassList.Sort();
        }
    }
}
