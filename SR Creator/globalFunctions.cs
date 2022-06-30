using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            [Required(AllowEmptyStrings =false)]
            [Range(.0001,5.00)]

            public static string partNumber { get; set; }
            [Required]
            public static string revisionNumber;
            public static Decimal insideDiameter;
            public static Decimal crossSection;
            public static Decimal thickness;
            public static Decimal slitThickness;
            public static string slitAngle;
            public static string filepath;
            public static string comments = "Comments";

            public static string fileDirectory, swPackAndGoDirectory;
            public static string staticFileDirectory = @"\\PAI5\Everyone\MMP\PROJECTS\AUTOMATED SLIT RING";
        }



        #endregion Classes

        #region Methods


        #endregion Methods
    }
}
