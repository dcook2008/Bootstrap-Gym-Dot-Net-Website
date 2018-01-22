using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessClassManager
{
    class FitnessClassListSorterFilterer
    {
        /// <summary>
        /// Creates a list new list derived from the orginal fitness class list then the sort method is called to created the same list but sorted numrically by ID
        /// </summary>
        /// <param name="fitnessClassList"> A list of fitness classes to be sorted </param>
        /// <returns> A Fitness Class sorted numerically by ID </returns>
        public static FitnessClassList SortById(FitnessClassList fitnessClassList)
        {
            FitnessClassList sortedFitnessClassList = new FitnessClassList();

            for (int i = 0; i < fitnessClassList.Count(); i++)
            {
                sortedFitnessClassList.addFitnessClass(fitnessClassList.getFitnessClass(i));
            }

            sortedFitnessClassList.Sort();

            return sortedFitnessClassList;
        }


        /// <summary>
        /// Filter through the fitness class list selecting classes where the second parameter is equal to a particular day of the week then 
        /// creates a list of classes that occur on that day
        /// </summary>
        /// <param name="fitnessClassList"> A list of all fitness classes </param>
        /// <param name="selectedDay"> A day of the week </param>
        /// <returns> A list of classes that occur on a specified day </returns>
        public static FitnessClassList FilterDay(FitnessClassList fitnessClassList, String selectedDay)
        {
            FitnessClassList filteredFitnessClassList = new FitnessClassList();

            for (int i = 0; i < fitnessClassList.Count(); i++)
            {
                if (fitnessClassList.getFitnessClass(i).Day == selectedDay)
                {
                    filteredFitnessClassList.addFitnessClass(fitnessClassList.getFitnessClass(i));
                }
            }

            return filteredFitnessClassList;
        }

        /// <summary>
        /// Filter through the class list selecting the classes that match the location specified then create list with classes at that location
        /// </summary>
        /// <param name="fitnessClassList"> A list of all fitness classes</param>
        /// <param name="selectedLocation"> A location where fitness classes occur </param>
        /// <returns> A list of fitness classes at a specified location </returns>
        public static FitnessClassList FilterLocation(FitnessClassList fitnessClassList, String selectedLocation)
        {
            FitnessClassList filteredFitnessClassList = new FitnessClassList();

            for (int i = 0; i < fitnessClassList.Count(); i++)
            {
                if (fitnessClassList.getFitnessClass(i).Location == selectedLocation)
                {
                    filteredFitnessClassList.addFitnessClass(fitnessClassList.getFitnessClass(i));
                }
            }

            return filteredFitnessClassList;
        }
    }
}
