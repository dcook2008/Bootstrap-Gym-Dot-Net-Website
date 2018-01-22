using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessClassManager
{
    class DuplicateIdException : Exception
    {
        /// <summary>
        /// An exception in the case a user attempts to add a class with a duplicate ID
        /// </summary>

        private static String msg = "Duplicate ID numbers not allowed";

        public DuplicateIdException()
            : base(msg)
        {
        }
    }
}
