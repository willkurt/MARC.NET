using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MARCDotNet
{
    
    public class MARCField
        //Refactor notes
        //1. Check if StringBuilder may be more appropriate in some cases
        //2. Check for cases with 'char' makes more sense than 'string'
    {
        public string tag;
        private string[] indicators = new string[2]{" ", " "};
        //maybe make this private?
        private List<string> subfields;//NB I think this is actually a ht of some sort? nope see pymarc example
        public string data;
        
        //this constructor is the most like the original pymarc constructur
        //refactored to make it more C#-esque
        public MARCField(int tag, string[] indicators, List<string> subfields, string data)
        {
            this.tag = tag.ToString("000");
            if (tag < 010)
            {
                this.data = data;
            }
            else
            {
                for (int i = 0; i < indicators.Length; i++)
                {
                    this.indicators[i] = indicators[i];
                }
            }

            this.subfields = subfields;

        }

        //constructor assumes tag is >= 010
        public MARCField(int tag, string[] indicators, List<string> subfields)
        {
            this.tag = tag.ToString("000");
            for (int i = 0; i < indicators.Length; i++)
            {
                this.indicators[i] = indicators[i];
            }
            this.subfields = subfields;
        }

        
        //asumes field is less then "010" 
        public MARCField(int tag, string data)
        {
            this.tag = tag.ToString("000");
            this.data = data;
            this.subfields = new List<string> { };
            
        }


        public string Indicator1
        {
            get{ return indicators[0];}
            set{ indicators[0] = value; }
        }

        public string Indicator2
        {
            get { return indicators[1]; }
            set { indicators[1] = value; }
        }


        public override string ToString()
            //look into StringBuilder when refactors
            /* 
             * From the original Pymarc notes:
             *A Field object in a string context will return the tag, indicators
              and subfield as a string. This follows MARCMaker format; see [1]
              and [2] for further reference. Special character mnemonic strings
              have yet to be implemented (see [3]), so be forewarned. Note also
              for complete MARCMaker compatibility, you will need to change your
              newlines to DOS format ('\r\n').
        
            [1] http://www.loc.gov/marc/makrbrkr.html#mechanics
            [2] http://search.cpan.org/~eijabb/MARC-File-MARCMaker/
            [3] http://www.loc.gov/marc/mnemonics.html
             * 
             */
        {
            string returnText;
            List<string> spaceOrSlashIndicators = new List<string> { " ", "\\","" };
            if (this.IsControlField())
            {
                returnText = "=" + this.tag + "  " + this.data.Replace(" ", "\\");
            }
            else
            {
                returnText = "=" + this.tag + "  ";
                foreach(string indicator in this.indicators)
                {
                    if (spaceOrSlashIndicators.Contains(indicator))
                    {
                        returnText += "\\";
                    }
                    else
                    {
                        returnText += indicator;
                    }
                }
                for (int i = 0; i < this.subfields.ToArray().Length; i = i+2 )
                {
                    returnText += "$" + this.subfields[i] + this.subfields[i + 1];
                }
            }
            return returnText;
        }

        /*
         * Identical to ToString(), accept it uses the Mnemonics per MARCMaker/Breaker (also MARCedit)
         * see: http://www.loc.gov/marc/makrbrkr.html#mnemonics
         */
        public string MARCMakerFormat()
        {
            StringBuilder returnText = new StringBuilder();
            List<string> spaceOrSlashIndicators = new List<string> { " ", "\\", "" };
            if (this.IsControlField())
            {
                returnText.Append(
                    MARCMakerMnemonics.ReplaceCharsWithMnemonics(
                        "=" + this.tag + "  " + this.data.Replace(" ", "\\")));
            }
            else
            {
                returnText.Append("=" + this.tag + "  ");
                foreach (string indicator in this.indicators)
                {
                    if (spaceOrSlashIndicators.Contains(indicator))
                    {
                        returnText.Append("\\");
                    }
                    else
                    {
                        returnText.Append(indicator);
                    }
                }
                for (int i = 0; i < this.subfields.ToArray().Length; i = i + 2)
                {
                    returnText.Append(
                        "$" + //don't want to accidently replace this "$" with "{dollar}"
                        MARCMakerMnemonics.ReplaceCharsWithMnemonics(
                        this.subfields[i] + this.subfields[i + 1]));
                }
            }
            return returnText.ToString();
        }


        public bool IsControlField()
        {
            if (Int32.Parse(this.tag) < 10)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool IsSubjectField()
        {
            if (this.tag[0] == '6')
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //sets a subfield to a new value, returns true if this happend
        //false if the subfield does not exist
        public bool SetSubfield(string subfieldLetter, string newValue)
        {
            for (int i = 0; i < this.subfields.ToArray().Length; i = i + 2)
            {
                if (this.subfields[i] == subfieldLetter)
                {
                    this.subfields[i + 1] = newValue;
                    return true;
                }
            }
            return false;

        }

        public string GetSubfield(string subfieldLetter)
        {
            for (int i = 0; i < this.subfields.ToArray().Length; i = i + 2)
            {
                if (this.subfields[i] == subfieldLetter)
                {

                    return this.subfields[i + 1];
                }
            }
            return null;

        }


        public string[] GetSubfields(string[] subfieldLetters)
        {
            List<string> returnList = new List<string>{};
            for(int i = 0; i < this.subfields.ToArray().Length; i = i+2)
            {
                if (subfieldLetters.Contains(this.subfields[i]))
                {
                    returnList.Add(this.subfields[i+1]);
                }
            }
            return returnList.ToArray();
        }

        public string[] Subfields
        {
            get { return this.subfields.ToArray(); }
        }




        public string Value()
            //Returns the field as a string without tag, indicators, and subfield indicators.
        {
            if (this.IsControlField())
            {
                return this.data;
            }
            string returnString = "";
            for (int i = 0; i < this.subfields.ToArray().Length; i = i + 2)
            {
                returnString += this.subfields[i + 1];
            }
            return returnString;
        }

        public void AddSubfield(string subfieldLetter, string subfieldData)
            //this is exactly as the pymarc vesion, but I'm not sure whether or not
            //it is okay to potentially have subfields displayed NOT in alphabetical order.
        {
            this.subfields.Add(subfieldLetter);
            this.subfields.Add(subfieldData);
        }

        public string AsMARC21()
        {
            if (this.IsControlField())
            {
                return this.data + MARCConstants.END_OF_FIELD;
            }
            string marc = this.Indicator1 + this.Indicator2;
            for (int i = 0; i < this.subfields.ToArray().Length; i = i + 2)
            {
                marc += MARCConstants.SUBFIELD_INDICATOR+this.subfields[i] + this.subfields[i + 1];
            }
            return marc + MARCConstants.END_OF_FIELD;
        }

        public string FormatField()
        //from Pymarc comments:
        //"""
        //Returns the field as a string without tag, indicators, and
        //subfield indicators. Like pymarc.Field.value(), but prettier
        //(adds spaces, formats subject headings).
        //"""
        {
            if (this.IsControlField())
            {
                return this.data;
            }
            List<string> onlyOneSubfield = new List<string>{"v","x","y","z"};
            string fieldData = "";
            for (int i = 0; i < this.subfields.ToArray().Length; i = i + 2)
            {
                if (!this.IsSubjectField())
                {
                    fieldData += " " + this.subfields[i + 1];
                }
                else
                {
                    //just copying pymarc here.. but seems like an OR could do this
                    if (!onlyOneSubfield.Contains(this.subfields[i]))
                    {
                        fieldData += " " + this.subfields[i + 1];
                    }
                    else
                    {
                        fieldData += " -- " + subfields[i + 1];
                    }
                }
              
            }
            return fieldData.Substring(1);
        }

    }
}
