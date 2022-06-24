using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SR_Creator
{
    public class globalFunctions
    {
        #region Classes


        public static class globalVariablesStatic
        {
            public static string partNumber;
            public static string revisionNumber;
            public static Decimal insideDiameter;
            public static Decimal crossSection;
            public static Decimal thickness;
            public static Decimal slitThickness;
            public static string slitAngle;
            public static string filepath;
            public static string comments = "Comments";

            public static string fileDirectory, swPackAndGoDirectory;
            public static string staticFileDirectory = @"\\PAI5\SMMC Customers\PAI\Mold Standard Drawings\CNC Slitting Fixtures";
        }



        #endregion Classes

        #region Methods


        #endregion Methods
    }
}
