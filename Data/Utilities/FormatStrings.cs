using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utilities
{
    public static class FormatStrings
    {
        public static string FormatingPostalcode(this string Postalcode)
        {
            return Postalcode.Trim().Replace(".", "").Replace("-", "");
        }

        public static string FormatingCellphone(this string Cellphone)
        {
            return Cellphone.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
        }

        public static string FormatingCpf(this string Cpf)
        {
            return Cpf.Trim().Replace(".", "").Replace("-", "");
        }

    }
}
