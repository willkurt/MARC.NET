using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MARCDotNet
{
    public class MARCMakerMnemonics
    {
        public static string ReplaceCharsWithMnemonics(string aString)
        {
           
            StringBuilder cleanString = new StringBuilder();
            int[] charsToChangeBelow7F = new int[8] { 0x1B,0x1C,0x1D,0x1E,0x24,0x7B,0x7C,0x7D};

            for(int i = 0;i < aString.Length;i++)
            {
                int charValue = Convert.ToInt32(aString[i]);
                if (charValue >= 0x7F || charsToChangeBelow7F.Contains(charValue))
                {
                    //this try catch block exists solely to for the cashes where a 
                    //char is about 0x7F but not in the lookup-table.
                    try
                    {
                        cleanString.Append(MARCMakerConstants.HexToMnemDictionary[aString[i]]);
                    }
                    catch
                    { 
                        cleanString.Append(aString[i]); 
                    }
                }
                else
                {
                    cleanString.Append(aString[i]);
                }
                 
            }
            return cleanString.ToString();

           
        }

        public static string ReplaceMnemonicsWithChars(string aString)
        {
            
            string cleanString = aString;
            MatchCollection matches = Regex.Matches(cleanString, @"{[^{]*}");
            foreach (Match match in matches)
            {
                System.Console.WriteLine(match.ToString());
                if(MARCMakerConstants.MnemToHexDictionary.Keys.Contains(match.ToString()))
                {
                    cleanString = cleanString.Replace(match.ToString(), MARCMakerConstants.MnemToHexDictionary[match.ToString()].ToString());
                }
            }
            return cleanString;

        }
    }
}
