using System.Globalization;

namespace MasterSkills.BlazorSpa.Common.Features
{
    public static class DateTimeConverter
    {
        public static string ConvertDateToPolish(DateTime date)
        {
            string format = "d MMMM yyyy 'r.'";
            CultureInfo polishCulture = new CultureInfo("pl-PL");
            string formattedDate = date.ToString(format, polishCulture);
            return formattedDate;

        }
    }
}
