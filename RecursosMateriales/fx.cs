using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursosMateriales
{
    class fx
    {

        public static int xEjercicio=2015;
        public static int xUsuario = 1;
        public static string xMSGtitulo = "MergeameEsta";

        public static string xserver = @"PILOT\SQLEXPRESS";
        public static string xbd = "BD3SoftBL";
        public static string xpass = "ch3st3r";
        public static String cnnX = @"Data Source =" + xserver + ";Initial Catalog=" + xbd + ";User ID=sa;Password=" + xpass;


        public static bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

    }
}
