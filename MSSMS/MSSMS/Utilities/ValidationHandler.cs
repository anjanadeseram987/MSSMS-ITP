using MSSMS.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSMS.Utilities
{
    public class ValidationHandler
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool isValidLocalContactNumber (string contact_number)
        {
            try
            {
                return Regex.IsMatch(contact_number, @"^([0]\d{9})*([+][9][4]\d{9})*$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool IsValidInternationalContactNumber(String number)
        {

            try
            {
                return Regex.IsMatch(number, @"^([0-9])*([+][0-9]*)*$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool IsValidPassword (string password, string confirmationPassword)
        {
            if (password == confirmationPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidResetToken(string token, string dbToken)
        {
            if (token == dbToken)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsTokenExpired(ResetToken resetToken)
        {
            if (DateTime.Compare(resetToken.tokenExpiration, DateTime.Now) < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidNumber(String number)
        {

            try
            {
                return Regex.IsMatch(number, @"^[0-9]*$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool IsValidDecimal(String number)
        {
            
            try
            {
                return Regex.IsMatch(number, @"^([0-9]){1,18}([.]{0,1}([0-9]){0,2}){1}$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool IsValidBirthday(DateTime birthday)
        {
            if (DateTime.Compare(birthday, DateTime.Now) > 0 || DateTime.Now.Subtract(birthday).TotalDays < 365* Properties.Settings.Default.EmpMINAge)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsBeforeDate(DateTime date)
        {
            if (DateTime.Compare(date, DateTime.Now) < 0)
            { 
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsAftereDate(DateTime date)
        {
            if (DateTime.Compare(date, DateTime.Now) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
