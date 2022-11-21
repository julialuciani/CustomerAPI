namespace Data.Utilities
{
    public static class FormatStrings
    {
        public static string FormatingPostalcode(this string Postalcode)
        {
            return Postalcode.Trim().Replace(".", "").Replace("-", "").Replace(",", "")
                .Replace(" ","");
        }
        public static string FormatingCellphone(this string Cellphone)
        {
            return Cellphone.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Replace(".","")
                .Replace(",","");
        }
        public static string FormatingCpf(this string Cpf)
        {
            return Cpf.Trim().Replace(".", "").Replace("-", "").Replace(",", "").Replace(" ","");
        }
    }
}