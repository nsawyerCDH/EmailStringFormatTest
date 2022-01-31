using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailStringFormatTest
{
    class Program
    {

        #region Test Project code

        static void Main(string[] args)
        {
            string Email1 = "nSaWyEr@cDhTs.CoM";
            string Email2 = "aorihara@cdhts.com;,,nsawyer@cdhTS.com,pdellaRocca@cdhts.com;sfisher@cdhts.com";
            string Email3 = ">>nSAWYER@cdhts.com; pdellarocca@CDHTS.com,;SFisher@cdhts.COM<<,another_email@gmail.com/";

            string FormattedEmail1 = CleanEmail(Email1);
            string FormattedEmail2 = CleanEmail(Email2);
            string FormattedEmail3 = CleanEmail(Email3);
            string FormattedEmail3WithSeperator = CleanEmail(Email3, ";");

            Console.WriteLine($"Email1 Raw: {Email1}");
            Console.WriteLine($"Email1 Clean: {FormattedEmail1}");
            Console.WriteLine();
            Console.WriteLine($"Email2 Raw: {Email2}");
            Console.WriteLine($"Email2 Clean: {FormattedEmail2}");
            Console.WriteLine();
            Console.WriteLine($"Email3 Raw: {Email3}");
            Console.WriteLine($"Email3 Clean: {FormattedEmail3}");
            Console.WriteLine();

            Console.WriteLine($"Email3 Raw: {Email3}");
            Console.WriteLine($"Email3 Clean (w/ Seperator): {FormattedEmail3WithSeperator}");
            Console.WriteLine();

            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
        #endregion





        #region Code from Customer Project

        private const string PermitChars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ@.;, ";
        /// <summary>
        /// Clean a string of emails - remove unwanted chars and format into comma-seperated list of string.
        /// </summary>
        /// <param name="emailIn">The raw string given</param>
        /// <param name="seperator">Optional.  The seperator for the formatted list of string</param>
        /// <returns>List of string, seperated by seperator param.</returns>
        public static string CleanEmail(string emailIn, string seperator = ",")
        {
            string emailOut = emailIn.ToLower();

            //Remove all chars not permitted in email string
            foreach (char c in emailIn)
                if (PermitChars.IndexOf(c) == -1)
                    emailOut = emailOut.Replace(c.ToString(), "");

            //Perform additional formatting
            emailOut = emailOut.Replace(";", seperator);
            emailOut = emailOut.Replace(",", seperator);
            emailOut = emailOut.Replace(" ", seperator);

            while (emailOut.IndexOf(seperator + seperator) > 0)
                emailOut = emailOut.Replace(seperator + seperator, seperator);

            emailOut = emailOut.Trim(seperator[0]);
            emailOut = string.Join(seperator + " ", emailOut.Split(seperator[0]).ToList().Distinct());

            return emailOut;
        }
        #endregion
    }
}
