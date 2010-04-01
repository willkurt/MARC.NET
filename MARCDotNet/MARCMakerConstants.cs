using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MARCDotNet
{
    /*
     * This class holds the large dictionaries need to convert from
     */ 
    public class MARCMakerConstants
    {
        public static Dictionary<string, char> MnemToHexDictionary
        { get { return MakeMnemToHex(); } }
        public static Dictionary<char, string> HexToMnemDictionary
        {get{return MakeHexToMnem();}}
  

        /*
         * There's a few 32-bit unchecked chars in there that have been commented out
         * how to handle those needs to be figure out.
         */

        private static Dictionary<char, string> MakeHexToMnem()
        {
            Dictionary<char, string> mnemdict = new Dictionary<char, string>(); 
            mnemdict.Add((char)0x1B, "{esc}"); //escape
            //mnemdict.Add((char)0x1B70311B73, "{sup1}"); //
            //mnemdict.Add((char)0x1B70321B73, "{sup2}"); //
            //mnemdict.Add((char)0x1B70331B73, "{sup3}"); //

            mnemdict.Add((char)0x1C, "{1C}"); //hex value 1C
            mnemdict.Add((char)0x1D, "{gs}"); //group separator (end of record)
            mnemdict.Add((char)0x1E, "{rs}"); //record separator (end of field)
            mnemdict.Add((char)0x1F, "{us}"); //unit separator (subfield delimiter)
            mnemdict.Add((char)0x24,"{dollar}");//dollar sign
            mnemdict.Add((char)0x7A68, "{zhcy}"); //cyrillic small letter zhe
            mnemdict.Add((char)0x7B, "{lcub}"); //opening curly brace
            mnemdict.Add((char)0x7C, "{pipe}"); //pipe
            mnemdict.Add((char)0x7D, "{rcub}"); //closing curly brace
           //marcedit doesn't touch this one-- mnemdict.Add((char)0x7E, "{sptilde}"); //spacing tilde
            mnemdict.Add((char)0x7F, "{7F}"); //hex value 7F
            mnemdict.Add((char)0x80, "{80}"); //hex value 80
            mnemdict.Add((char)0x81, "{81}"); //hex value 81
            mnemdict.Add((char)0x82, "{82}"); //hex value 82
            mnemdict.Add((char)0x83, "{83}"); //hex value 83
            mnemdict.Add((char)0x84, "{84}"); //hex value 84
            mnemdict.Add((char)0x85, "{85}"); //hex value 85
            mnemdict.Add((char)0x86, "{86}"); //hex value 86
            mnemdict.Add((char)0x87, "{87}"); //hex value 87
            mnemdict.Add((char)0x88, "{88}"); //hex value 88
            mnemdict.Add((char)0x89, "{89}"); //hex value 89
            mnemdict.Add((char)0x8A, "{8A}"); //hex value 8A
            mnemdict.Add((char)0x8B, "{8B}"); //hex value 8B
            mnemdict.Add((char)0x8C, "{8C}"); //hex value 8C
            mnemdict.Add((char)0x8D, "{joiner}"); //zero width joiner
            mnemdict.Add((char)0x8E, "{nonjoin}"); //zero width non-joiner
            mnemdict.Add((char)0x8F, "{8F}"); //hex value 8F
            mnemdict.Add((char)0x90, "{90}"); //hex value 90
            mnemdict.Add((char)0x91, "{91}"); //hex value 91
            mnemdict.Add((char)0x92, "{92}"); //hex value 92
            mnemdict.Add((char)0x93, "{93}"); //hex value 93
            mnemdict.Add((char)0x94, "{94}"); //hex value 94
            mnemdict.Add((char)0x95, "{95}"); //hex value 95
            mnemdict.Add((char)0x96, "{96}"); //hex value 96
            mnemdict.Add((char)0x97, "{97}"); //hex value 97
            mnemdict.Add((char)0x98, "{98}"); //hex value 98
            mnemdict.Add((char)0x99, "{99}"); //hex value 99
            mnemdict.Add((char)0x9A, "{9A}"); //hex value 9A
            mnemdict.Add((char)0x9B, "{9B}"); //hex value 9B
            mnemdict.Add((char)0x9C, "{9C}"); //hex value 9C
            mnemdict.Add((char)0x9D, "{9D}"); //hex value 9D
            mnemdict.Add((char)0x9E, "{9E}"); //hex value 9E
            mnemdict.Add((char)0x9F, "{9F}"); //hex value 9F
            mnemdict.Add((char)0xA0, "{A0}"); //no-break space
            mnemdict.Add((char)0xA1, "{Lstrok}"); //latin large letter l with stroke
            mnemdict.Add((char)0xA2, "{Ostrok}"); //latin large letter o with stroke
            mnemdict.Add((char)0xA3, "{Dstrok}"); //latin large letter d with stroke
            mnemdict.Add((char)0xA4, "{THORN}"); //latin large letter thorn (icelandic)
            mnemdict.Add((char)0xA5, "{AElig}"); //latin large letter AE
            mnemdict.Add((char)0xA6, "{OElig}"); //latin large letter OE
            mnemdict.Add((char)0xA7, "{softsign}"); //modifier letter soft sign
            mnemdict.Add((char)0xA8, "{middot}"); //middle dot
            mnemdict.Add((char)0xA9, "{flat}"); //musical flat sign
            mnemdict.Add((char)0xAA, "{reg}"); //registered sign
            mnemdict.Add((char)0xAB, "{plusmn}"); //plus-minus sign
            mnemdict.Add((char)0xAC, "{Ohorn}"); //latin large letter o with horn
            mnemdict.Add((char)0xAD, "{Uhorn}"); //latin large letter u with horn
            mnemdict.Add((char)0xAE, "{mlrhring}"); //modifier letter right half ring (alif)
            mnemdict.Add((char)0xAF, "{AF}"); //hex value AF
            mnemdict.Add((char)0xB0, "{mllhring}"); //modifier letter left half ring (ayn)
            mnemdict.Add((char)0xB1, "{lstrok}"); //latin small letter l with stroke
            mnemdict.Add((char)0xB2, "{ostrok}"); //latin small letter o with stroke
            mnemdict.Add((char)0xB3, "{dstrok}"); //latin small letter d with stroke
            mnemdict.Add((char)0xB4, "{thorn}"); //latin small letter thorn (icelandic)
            mnemdict.Add((char)0xB5, "{aelig}"); //latin small letter ae
            mnemdict.Add((char)0xB6, "{oelig}"); //latin small letter oe
            mnemdict.Add((char)0xB7, "{hardsign}"); //modifier letter hard sign
            mnemdict.Add((char)0xB8, "{inodot}"); //latin small letter dotless i
            mnemdict.Add((char)0xB9, "{pound}"); //pound sign
            mnemdict.Add((char)0xBA, "{eth}"); //latin small letter eth
            mnemdict.Add((char)0xBB, "{BB}"); //hex value BB
            mnemdict.Add((char)0xBC, "{ohorn}"); //latin small letter o with horn
            mnemdict.Add((char)0xBD, "{uhorn}"); //latin small letter u with horn
            mnemdict.Add((char)0xBE, "{BE}"); //hex value BE
            mnemdict.Add((char)0xBF, "{BF}"); //hex value BF
            mnemdict.Add((char)0xC0, "{deg}"); //degree sign
            mnemdict.Add((char)0xC1, "{scriptl}"); //latin small letter script l
            mnemdict.Add((char)0xC2, "{phono}"); //sound recording copyright
            mnemdict.Add((char)0xC3, "{copy}"); //copyright sign
            mnemdict.Add((char)0xC4, "{sharp}"); //sharp
            mnemdict.Add((char)0xC5, "{iquest}"); //inverted question mark
            mnemdict.Add((char)0xC6, "{iexcl}"); //inverted exclamation mark
            mnemdict.Add((char)0xC7, "{C7}"); //hex value C7
            mnemdict.Add((char)0xC8, "{C8}"); //hex value C8
            mnemdict.Add((char)0xC9, "{C9}"); //hex value C9
            mnemdict.Add((char)0xCA, "{CA}"); //hex value CA
            mnemdict.Add((char)0xCB, "{CB}"); //hex value CB
            mnemdict.Add((char)0xCC, "{CC}"); //hex value CC
            mnemdict.Add((char)0xCD, "{CD}"); //hex value CD
            mnemdict.Add((char)0xCE, "{CE}"); //hex value CE
            mnemdict.Add((char)0xCF, "{CF}"); //hex value CF
            mnemdict.Add((char)0xD0, "{D0}"); //hex value D0
            mnemdict.Add((char)0xD1, "{D1}"); //hex value D1
            mnemdict.Add((char)0xD2, "{D2}"); //hex value D2
            mnemdict.Add((char)0xD3, "{D3}"); //hex value D3
            mnemdict.Add((char)0xD4, "{D4}"); //hex value D4
            mnemdict.Add((char)0xD5, "{D5}"); //hex value D5
            mnemdict.Add((char)0xD6, "{D6}"); //hex value D6
            mnemdict.Add((char)0xD7, "{D7}"); //hex value D7
            mnemdict.Add((char)0xD8, "{D8}"); //hex value D8
            mnemdict.Add((char)0xD9, "{D9}"); //hex value D9
            mnemdict.Add((char)0xDA, "{DA}"); //hex value DA
            mnemdict.Add((char)0xDB, "{DB}"); //hex value DB
            mnemdict.Add((char)0xDC, "{DC}"); //hex value DC
            mnemdict.Add((char)0xDD, "{DD}"); //hex value DD
            mnemdict.Add((char)0xDE, "{DE}"); //hex value DE
            mnemdict.Add((char)0xDF, "{DF}"); //hex value DF
            mnemdict.Add((char)0xE0, "{hooka}"); //combining hook above
            mnemdict.Add((char)0xE1, "{grave}"); //combining grave
            mnemdict.Add((char)0xE141, "{Agrave}"); //latin large letter a with grave
            mnemdict.Add((char)0xE145, "{Egrave}"); //latin large letter e with grave
            mnemdict.Add((char)0xE149, "{Igrave}"); //latin large letter i with grave
            mnemdict.Add((char)0xE14F, "{Ograve}"); //latin large letter o with grave
            mnemdict.Add((char)0xE155, "{Ugrave}"); //latin large letter u with grave
            mnemdict.Add((char)0xE161, "{agrave}"); //latin small letter a with grave
            mnemdict.Add((char)0xE165, "{egrave}"); //latin small letter e with grave
            mnemdict.Add((char)0xE169, "{igrave}"); //latin small letter i with grave
            mnemdict.Add((char)0xE16F, "{ograve}"); //latin small letter o with grave
            mnemdict.Add((char)0xE175, "{ugrave}"); //latin small letter u with grave
            mnemdict.Add((char)0xE2, "{acute}"); //combining acute
            mnemdict.Add((char)0xE241, "{Aacute}"); //latin large letter a with acute
            mnemdict.Add((char)0xE243, "{Cacute}"); //latin large letter c with acute
            mnemdict.Add((char)0xE245, "{Eacute}"); //latin large letter e with acute
            mnemdict.Add((char)0xE247, "{GJEcy}"); //cyrillic large letter gje
            mnemdict.Add((char)0xE249, "{Iacute}"); //latin large letter i with acute
            mnemdict.Add((char)0xE24B, "{KJEcy}"); //cyrillic large letter kje
            mnemdict.Add((char)0xE24C, "{Lacute}"); //latin large letter l with acute
            mnemdict.Add((char)0xE24E, "{Nacute}"); //latin large letter n with acute
            mnemdict.Add((char)0xE24F, "{Oacute}"); //latin large letter o with acute
            mnemdict.Add((char)0xE252, "{Racute}"); //latin large letter r with acute
            mnemdict.Add((char)0xE253, "{Sacute}"); //latin large letter s with acute
            mnemdict.Add((char)0xE255, "{Uacute}"); //latin large letter u with acute
            mnemdict.Add((char)0xE259, "{Yacute}"); //latin large letter y with acute
            mnemdict.Add((char)0xE25A, "{Zacute}"); //latin large letter z with acute
            mnemdict.Add((char)0xE261, "{aacute}"); //latin small letter a with acute
            mnemdict.Add((char)0xE263, "{cacute}"); //latin small letter c with acute
            mnemdict.Add((char)0xE265, "{eacute}"); //latin small letter e with acute
            mnemdict.Add((char)0xE267, "{gjecy}"); //cyrillic small letter gje
            mnemdict.Add((char)0xE269, "{iacute}"); //latin small letter i with acute
            mnemdict.Add((char)0xE26B, "{kjecy}"); //cyrillic small letter kje
            mnemdict.Add((char)0xE26C, "{lacute}"); //latin small letter l with acute
            mnemdict.Add((char)0xE26E, "{nacute}"); //latin small letter n with acute
            mnemdict.Add((char)0xE26F, "{oacute}"); //latin small letter o with acute
            mnemdict.Add((char)0xE272, "{racute}"); //latin small letter r with acute
            mnemdict.Add((char)0xE273, "{sacute}"); //latin small letter s with acute
            mnemdict.Add((char)0xE275, "{uacute}"); //latin small letter u with acute
            mnemdict.Add((char)0xE279, "{yacute}"); //latin small letter y with acute
            mnemdict.Add((char)0xE27A, "{zacute}"); //latin small letter z with acute
            mnemdict.Add((char)0xE3, "{circ}"); //combining circumflex
            mnemdict.Add((char)0xE341, "{Acirc}"); //latin large letter a with circumflex
            mnemdict.Add((char)0xE345, "{Ecirc}"); //latin large letter e with circumflex
            mnemdict.Add((char)0xE349, "{Icirc}"); //latin large letter i with circumflex
            mnemdict.Add((char)0xE34F, "{Ocirc}"); //latin large letter o with circ
            mnemdict.Add((char)0xE355, "{Ucirc}"); //latin large letter u with circ
            mnemdict.Add((char)0xE361, "{acirc}"); //latin small letter a with circumflex
            mnemdict.Add((char)0xE365, "{ecirc}"); //latin small letter e with circumflex
            mnemdict.Add((char)0xE369, "{icirc}"); //latin small letter i with circumflex
            mnemdict.Add((char)0xE36F, "{ocirc}"); //latin small letter o with circ
            mnemdict.Add((char)0xE375, "{ucirc}"); //latin small letter u with circ
            mnemdict.Add((char)0xE4, "{tilde}"); //combining tilde
            mnemdict.Add((char)0xE441, "{Atilde}"); //latin large letter A with tilde
            mnemdict.Add((char)0xE44E, "{Ntilde}"); //latin large letter n with tilde
            mnemdict.Add((char)0xE44F, "{Otilde}"); //latin large letter o with tilde
            mnemdict.Add((char)0xE461, "{atilde}"); //latin small letter a with tilde
            mnemdict.Add((char)0xE46E, "{ntilde}"); //latin small letter n with tilde
            mnemdict.Add((char)0xE46F, "{otilde}"); //latin small letter o with tilde
            mnemdict.Add((char)0xE5, "{macr}"); //combining macron
            mnemdict.Add((char)0xE6, "{breve}"); //combining breve
            mnemdict.Add((char)0xE641, "{Abreve}"); //latin large letter a with breve
            mnemdict.Add((char)0xE649, "{Jcy}"); //cyrillic large letter short ii
            mnemdict.Add((char)0xE661, "{abreve}"); //latin small letter a with breve
            mnemdict.Add((char)0xE669, "{jcy}"); //cyrillic small letter short ii
            mnemdict.Add((char)0xE7, "{dot}"); //combining dot above
            mnemdict.Add((char)0xE744, "{Ecy}"); //cyrillic large letter reversed e
            mnemdict.Add((char)0xE749, "{Idot}"); //latin large letter i with dot
            mnemdict.Add((char)0xE75A, "{Zdot}"); //latin large letter z with dot above
            mnemdict.Add((char)0xE765, "{ecy}"); //cyrillic small letter reversed e
            mnemdict.Add((char)0xE77A, "{zdot}"); //latin small letter z with dot above
            mnemdict.Add((char)0xE8, "{uml}"); //combining umlaut
            mnemdict.Add((char)0xE841, "{Auml}"); //latin large letter A with umlaut
            mnemdict.Add((char)0xE845, "{Euml}"); //latin large letter e with umlaut
            mnemdict.Add((char)0xE849, "{Iuml}"); //latin large letter i with umlaut
            mnemdict.Add((char)0xE84F, "{Ouml}"); //latin large letter o with uml
            mnemdict.Add((char)0xE855, "{Uuml}"); //latin large letter u with uml
            mnemdict.Add((char)0xE861, "{auml}"); //latin small letter a with umlaut
            mnemdict.Add((char)0xE865, "{euml}"); //latin small letter e with umlaut
            mnemdict.Add((char)0xE869, "{iuml}"); //latin small letter i with umlaut
            mnemdict.Add((char)0xE86F, "{ouml}"); //latin small letter o with uml
            mnemdict.Add((char)0xE875, "{uuml}"); //latin small letter u with uml
            mnemdict.Add((char)0xE9, "{caron}"); //combining hacek
            mnemdict.Add((char)0xE943, "{Ccaron}"); //latin large letter c with caron
            mnemdict.Add((char)0xE944, "{Dcaron}"); //latin large letter d with caron
            mnemdict.Add((char)0xE945, "{Ecaron}"); //latin large letter e with caron
            mnemdict.Add((char)0xE949, "{Icaron}"); //latin large letter i with caron
            mnemdict.Add((char)0xE94E, "{Ncaron}"); //latin large letter n with caron
            mnemdict.Add((char)0xE952, "{Rcaron}"); //latin large letter r with caron
            mnemdict.Add((char)0xE954, "{Tcaron}"); //latin large letter t with caron
            mnemdict.Add((char)0xE963, "{ccaron}"); //latin small letter c with caron
            mnemdict.Add((char)0xE964, "{dcaron}"); //latin small letter d with caron
            mnemdict.Add((char)0xE965, "{ecaron}"); //latin small letter e with caron
            mnemdict.Add((char)0xE969, "{icaron}"); //latin small letter i with caron
            mnemdict.Add((char)0xE96E, "{ncaron}"); //latin small letter n with caron
            mnemdict.Add((char)0xE972, "{rcaron}"); //latin small letter r with caron
            mnemdict.Add((char)0xE974, "{tcaron}"); //latin small letter t with caron
            mnemdict.Add((char)0xEA, "{ring}"); //combining ring above
            mnemdict.Add((char)0xEA41, "{Aring}"); //latin large letter a with ring
            mnemdict.Add((char)0xEA55, "{Uring}"); //latin large letter u with ring
            mnemdict.Add((char)0xEA61, "{aring}"); //latin small letter a with ring
            mnemdict.Add((char)0xEA75, "{uring}"); //latin small letter u with ring
            mnemdict.Add((char)0xEB, "{llig}"); //combining ligature left half
            //mnemdict.Add((char)0xEB49EC41, "{YAcy}"); //cyrillic large letter ia
            //mnemdict.Add((char)0xEB49EC45, "{IEcy}"); //cyrillic large letter ie
            //mnemdict.Add((char)0xEB49EC4F, "{IOcy}"); //cyrillic large letter io
            //mnemdict.Add((char)0xEB49EC55, "{YUcy}"); //cyrillic large letter iu
            //mnemdict.Add((char)0xEB54EC53, "{TScy}"); //cyrillic large letter tse
            //mnemdict.Add((char)0xEB5AEC68, "{ZHcyua}"); //ukrainian large letter zhe
            //mnemdict.Add((char)0xEB69EC61, "{yacy}"); //cyrillic small letter ia
            //mnemdict.Add((char)0xEB69EC65, "{iecy}"); //cyrillic small letter ie
            //mnemdict.Add((char)0xEB69EC6F, "{iocy}"); //cyrillic small letter io
            //mnemdict.Add((char)0xEB69EC75, "{yucy}"); //cyrillic small letter iu
            //mnemdict.Add((char)0xEB74EC73, "{tscy}"); //cyrillic small letter tse
            //mnemdict.Add((char)0xEB7AEC68, "{zhcyua}"); //ukrainian small letter zhe
            mnemdict.Add((char)0xEC, "{rlig}"); //combining ligature right half
            mnemdict.Add((char)0xED, "{rcommaa}"); //combining comma above right
            mnemdict.Add((char)0xEE, "{dblac}"); //combining double acute
            mnemdict.Add((char)0xEE4F, "{Odblac}"); //latin large letter o double acute
            mnemdict.Add((char)0xEE55, "{Udblac}"); //latin large letter u with double acute
            mnemdict.Add((char)0xEE6F, "{odblac}"); //latin small letter o double acute
            mnemdict.Add((char)0xEE75, "{udblac}"); //latin small letter u with double acute
            mnemdict.Add((char)0xEF, "{candra}"); //combining candrabindu
            mnemdict.Add((char)0xF0, "{cedil}"); //combining cedilla
            mnemdict.Add((char)0xF043, "{Ccedil}"); //latin large letter c with cedilla
            mnemdict.Add((char)0xF063, "{ccedil}"); //latin small letter c with cedilla
            mnemdict.Add((char)0xF1, "{ogon}"); //combining right hook
            mnemdict.Add((char)0xF141, "{Aogon}"); //latin large letter a with ogon (hook right)
            mnemdict.Add((char)0xF145, "{Ehookr}"); //latin large letter e with right hook (ogonek)
            mnemdict.Add((char)0xF161, "{aogon}"); //latin small letter a with ogon (hook right)
            mnemdict.Add((char)0xF165, "{ehookr}"); //latin small letter e with right hook (ogonek)
            mnemdict.Add((char)0xF2, "{dotb}"); //combining dot below
            mnemdict.Add((char)0xF3, "{dbldotb}"); //combining double dot below
            mnemdict.Add((char)0xF4, "{ringb}"); //combining circumflex below
            mnemdict.Add((char)0xF5, "{dblunder}"); //combining double underscore
            mnemdict.Add((char)0xF6, "{under}"); //combining underscore
            mnemdict.Add((char)0xF7, "{commab}"); //combining left hook
            mnemdict.Add((char)0xF753, "{Scommab}"); //latin large letter s with comma below
            mnemdict.Add((char)0xF754, "{Tcommab}"); //latin large letter t with comma below
            mnemdict.Add((char)0xF773, "{scommab}"); //latin small letter s with comma below
            mnemdict.Add((char)0xF774, "{tcommab}"); //latin small letter t with comma below
            mnemdict.Add((char)0xF8, "{rcedil}"); //combining right cedilla
            mnemdict.Add((char)0xF9, "{breveb}"); //combining breve below
            mnemdict.Add((char)0xFA, "{ldbltil}"); //combining double tilde left half
            mnemdict.Add((char)0xFB, "{rdbltil}"); //combining double tilde right half
            mnemdict.Add((char)0xFC, "{FC}"); //hex value FC
            mnemdict.Add((char)0xFD, "{FD}"); //hex value FD
            mnemdict.Add((char)0xFE, "{commaa}"); //combining comma above
            mnemdict.Add((char)0xFF, "{FF}"); //hex value FF
            return mnemdict;
        }


        

        private static Dictionary<string, char> MakeMnemToHex()
        {
            Dictionary<string, char> mnemdict = new Dictionary<string, char>();
            mnemdict.Add("{0}", (char)0x30); //zero
            mnemdict.Add("{00}", (char)0x00); //hex value 00
            mnemdict.Add("{01}", (char)0x01); //hex value 01
            mnemdict.Add("{02}", (char)0x02); //hex value 02
            mnemdict.Add("{03}", (char)0x03); //hex value 03
            mnemdict.Add("{04}", (char)0x04); //hex value 04
            mnemdict.Add("{05}", (char)0x05); //hex value 05
            mnemdict.Add("{06}", (char)0x06); //hex value 06
            mnemdict.Add("{07}", (char)0x07); //hex value 07
            mnemdict.Add("{08}", (char)0x08); //hex value 08
            mnemdict.Add("{09}", (char)0x09); //hex value 09
            mnemdict.Add("{0A}", (char)0x0A); //hex value 0A
            mnemdict.Add("{0B}", (char)0x0B); //hex value 0B
            mnemdict.Add("{0C}", (char)0x0C); //hex value 0C
            mnemdict.Add("{0D}", (char)0x0D); //hex value 0D
            mnemdict.Add("{0E}", (char)0x0E); //hex value 0E
            mnemdict.Add("{0F}", (char)0x0F); //hex value 0F
            mnemdict.Add("{1}", (char)0x31); //digit one
            mnemdict.Add("{10}", (char)0x10); //hex value 10
            mnemdict.Add("{11}", (char)0x11); //hex value 11
            mnemdict.Add("{12}", (char)0x12); //hex value 12
            mnemdict.Add("{13}", (char)0x13); //hex value 13
            mnemdict.Add("{14}", (char)0x14); //hex value 14
            mnemdict.Add("{15}", (char)0x15); //hex value 15
            mnemdict.Add("{16}", (char)0x16); //hex value 16
            mnemdict.Add("{17}", (char)0x17); //hex value 17
            mnemdict.Add("{18}", (char)0x18); //hex value 18
            mnemdict.Add("{19}", (char)0x19); //hex value 19
            mnemdict.Add("{1A}", (char)0x1A); //hex value 1A
            mnemdict.Add("{1B}", (char)0x1B); //escape
            mnemdict.Add("{1C}", (char)0x1C); //hex value 1C
            mnemdict.Add("{1D}", (char)0x1D); //end of record
            mnemdict.Add("{1E}", (char)0x1E); //end of field
            mnemdict.Add("{1F}", (char)0x1F); //subfield delimiter
            mnemdict.Add("{2}", (char)0x32); //digit two
            mnemdict.Add("{20}", (char)0x20); //space (blank)
            mnemdict.Add("{21}", (char)0x21); //exclamation point
            mnemdict.Add("{22}", (char)0x22); //quotation mark
            mnemdict.Add("{23}", (char)0x23); //number sign
            mnemdict.Add("{24}", (char)0x24); //dollar sign
            mnemdict.Add("{25}", (char)0x25); //percent sign
            mnemdict.Add("{26}", (char)0x26); //ampersand
            mnemdict.Add("{27}", (char)0x27); //apostrophe
            mnemdict.Add("{28}", (char)0x28); //left parenthesis
            mnemdict.Add("{29}", (char)0x29); //right parenthesis
            mnemdict.Add("{2A}", (char)0x2A); //asterisk
            mnemdict.Add("{2B}", (char)0x2B); //plus
            mnemdict.Add("{2C}", (char)0x2C); //comma
            mnemdict.Add("{2D}", (char)0x2D); //hyphen-minus
            mnemdict.Add("{2E}", (char)0x2E); //period/decimal point
            mnemdict.Add("{2F}", (char)0x2F); //solidus (slash)
            mnemdict.Add("{3}", (char)0x33); //digit three
            mnemdict.Add("{30}", (char)0x30); //digit zero
            mnemdict.Add("{31}", (char)0x31); //digit one
            mnemdict.Add("{32}", (char)0x32); //digit two
            mnemdict.Add("{33}", (char)0x33); //digit three
            mnemdict.Add("{34}", (char)0x34); //digit four
            mnemdict.Add("{35}", (char)0x35); //digit five
            mnemdict.Add("{36}", (char)0x36); //digit six
            mnemdict.Add("{37}", (char)0x37); //digit seven
            mnemdict.Add("{38}", (char)0x38); //digit eight
            mnemdict.Add("{39}", (char)0x39); //digit nine
            mnemdict.Add("{3A}", (char)0x3A); //colon
            mnemdict.Add("{3B}", (char)0x3B); //semicolon
            mnemdict.Add("{3C}", (char)0x3C); //less than
            mnemdict.Add("{3D}", (char)0x3D); //equals sign
            mnemdict.Add("{3E}", (char)0x3E); //greater than
            mnemdict.Add("{3F}", (char)0x3F); //question mark
            mnemdict.Add("{4}", (char)0x34); //digit four
            mnemdict.Add("{40}", (char)0x40); //commercial at sign
            mnemdict.Add("{41}", (char)0x41); //latin large letter a
            mnemdict.Add("{42}", (char)0x42); //latin large letter b
            mnemdict.Add("{43}", (char)0x43); //latin large letter c
            mnemdict.Add("{44}", (char)0x44); //latin large letter d
            mnemdict.Add("{45}", (char)0x45); //latin large letter e
            mnemdict.Add("{46}", (char)0x46); //latin large letter f
            mnemdict.Add("{47}", (char)0x47); //latin large letter g
            mnemdict.Add("{48}", (char)0x48); //latin large letter h
            mnemdict.Add("{49}", (char)0x49); //latin large letter i
            mnemdict.Add("{4A}", (char)0x4A); //latin large letter j
            mnemdict.Add("{4B}", (char)0x4B); //latin large letter k
            mnemdict.Add("{4C}", (char)0x4C); //latin large letter l
            mnemdict.Add("{4D}", (char)0x4D); //latin large letter m
            mnemdict.Add("{4E}", (char)0x4E); //latin large letter n
            mnemdict.Add("{4F}", (char)0x4F); //latin large letter o
            mnemdict.Add("{5}", (char)0x35); //digit five
            mnemdict.Add("{50}", (char)0x50); //latin large letter p
            mnemdict.Add("{51}", (char)0x51); //latin large letter q
            mnemdict.Add("{52}", (char)0x52); //latin large letter r
            mnemdict.Add("{53}", (char)0x53); //latin large letter s
            mnemdict.Add("{54}", (char)0x54); //latin large letter t
            mnemdict.Add("{55}", (char)0x55); //latin large letter u
            mnemdict.Add("{56}", (char)0x56); //latin large letter v
            mnemdict.Add("{57}", (char)0x57); //latin large letter w
            mnemdict.Add("{58}", (char)0x58); //latin large letter x
            mnemdict.Add("{59}", (char)0x59); //latin large letter y
            mnemdict.Add("{5A}", (char)0x5A); //latin large letter z
            mnemdict.Add("{5B}", (char)0x5B); //left bracket
            mnemdict.Add("{5C}", (char)0x5C); //back slash (reverse solidus)
            mnemdict.Add("{5D}", (char)0x5D); //right bracket
            mnemdict.Add("{5E}", (char)0x5E); //spacing circumflex
            mnemdict.Add("{5F}", (char)0x5F); //spacing underscore
            mnemdict.Add("{6}", (char)0x36); //digit six
            mnemdict.Add("{60}", (char)0x60); //spacing grave
            mnemdict.Add("{61}", (char)0x61); //latin small letter a
            mnemdict.Add("{62}", (char)0x62); //latin small letter b
            mnemdict.Add("{63}", (char)0x63); //latin small letter c
            mnemdict.Add("{64}", (char)0x64); //latin small letter d
            mnemdict.Add("{65}", (char)0x65); //latin small letter e
            mnemdict.Add("{66}", (char)0x66); //latin small letter f
            mnemdict.Add("{67}", (char)0x67); //latin small letter g
            mnemdict.Add("{68}", (char)0x68); //latin small letter h
            mnemdict.Add("{69}", (char)0x69); //latin small letter i
            mnemdict.Add("{6A}", (char)0x6A); //latin small letter j
            mnemdict.Add("{6B}", (char)0x6B); //latin small letter k
            mnemdict.Add("{6C}", (char)0x6C); //latin small letter l
            mnemdict.Add("{6D}", (char)0x6D); //latin small letter m
            mnemdict.Add("{6E}", (char)0x6E); //latin small letter n
            mnemdict.Add("{6F}", (char)0x6F); //latin small letter o
            mnemdict.Add("{7}", (char)0x37); //digit seven
            mnemdict.Add("{70}", (char)0x70); //latin small letter p
            mnemdict.Add("{71}", (char)0x71); //latin small letter q
            mnemdict.Add("{72}", (char)0x72); //latin small letter r
            mnemdict.Add("{73}", (char)0x73); //latin small letter s
            mnemdict.Add("{74}", (char)0x74); //latin small letter t
            mnemdict.Add("{75}", (char)0x75); //latin small letter u
            mnemdict.Add("{76}", (char)0x76); //latin small letter v
            mnemdict.Add("{77}", (char)0x77); //latin small letter w
            mnemdict.Add("{78}", (char)0x78); //latin small letter x
            mnemdict.Add("{79}", (char)0x79); //latin small letter y
            mnemdict.Add("{7A}", (char)0x7A); //latin small letter z
            mnemdict.Add("{7B}", (char)0x7B); //opening curly brace
            mnemdict.Add("{7C}", (char)0x7C); //fill/bar over bar/pipe
            mnemdict.Add("{7D}", (char)0x7D); //closing curly brace
            mnemdict.Add("{7E}", (char)0x7E); //spacing tilde
            mnemdict.Add("{7F}", (char)0x7F); //hex value 7F
            mnemdict.Add("{8}", (char)0x38); //digit eight
            mnemdict.Add("{80}", (char)0x80); //hex value 80
            mnemdict.Add("{81}", (char)0x81); //hex value 81
            mnemdict.Add("{82}", (char)0x82); //hex value 82
            mnemdict.Add("{83}", (char)0x83); //hex value 83
            mnemdict.Add("{84}", (char)0x84); //hex value 84
            mnemdict.Add("{85}", (char)0x85); //hex value 85
            mnemdict.Add("{86}", (char)0x86); //hex value 86
            mnemdict.Add("{87}", (char)0x87); //hex value 87
            mnemdict.Add("{88}", (char)0x88); //hex value 88
            mnemdict.Add("{89}", (char)0x89); //hex value 89
            mnemdict.Add("{8A}", (char)0x8A); //hex value 8A
            mnemdict.Add("{8B}", (char)0x8B); //hex value 8B
            mnemdict.Add("{8C}", (char)0x8C); //hex value 8C
            mnemdict.Add("{8D}", (char)0x8D); //zero width joiner
            mnemdict.Add("{8E}", (char)0x8E); //zero width non-joiner
            mnemdict.Add("{8F}", (char)0x8F); //hex value 8F
            mnemdict.Add("{9}", (char)0x39); //digit nine
            mnemdict.Add("{90}", (char)0x90); //hex value 90
            mnemdict.Add("{91}", (char)0x91); //hex value 91
            mnemdict.Add("{92}", (char)0x92); //hex value 92
            mnemdict.Add("{93}", (char)0x93); //hex value 93
            mnemdict.Add("{94}", (char)0x94); //hex value 94
            mnemdict.Add("{95}", (char)0x95); //hex value 95
            mnemdict.Add("{96}", (char)0x96); //hex value 96
            mnemdict.Add("{97}", (char)0x97); //hex value 97
            mnemdict.Add("{98}", (char)0x98); //hex value 98
            mnemdict.Add("{99}", (char)0x99); //hex value 99
            mnemdict.Add("{9A}", (char)0x9A); //hex value 9A
            mnemdict.Add("{9B}", (char)0x9B); //hex value 9B
            mnemdict.Add("{9C}", (char)0x9C); //hex value 9C
            mnemdict.Add("{9D}", (char)0x9D); //hex value 9D
            mnemdict.Add("{9E}", (char)0x9E); //hex value 9E
            mnemdict.Add("{9F}", (char)0x9F); //hex value 9F
            mnemdict.Add("{A}", (char)0x41); //latin large letter a
            mnemdict.Add("{a}", (char)0x61); //latin small letter a
            mnemdict.Add("{A0}", (char)0xA0); //no-break space
            mnemdict.Add("{A1}", (char)0xA1); //latin large letter l with stroke
            mnemdict.Add("{A2}", (char)0xA2); //latin large letter o with stroke
            mnemdict.Add("{A3}", (char)0xA3); //latin large letter d with stroke
            mnemdict.Add("{A4}", (char)0xA4); //latin large letter thorn
            mnemdict.Add("{A5}", (char)0xA5); //latin large letter AE
            mnemdict.Add("{A6}", (char)0xA6); //latin large letter OE
            mnemdict.Add("{A7}", (char)0xA7); //modifier letter prime/soft sign
            mnemdict.Add("{A8}", (char)0xA8); //middle dot
            mnemdict.Add("{A9}", (char)0xA9); //musical flat sign
            mnemdict.Add("{AA}", (char)0xAA); //registered sign
            mnemdict.Add("{Aacute}", (char)0xE241); //latin large letter a with acute
            mnemdict.Add("{aacute}", (char)0xE261); //latin small letter a with acute
            mnemdict.Add("{AB}", (char)0xAB); //plus-minus sign
            mnemdict.Add("{Abreve}", (char)0xE641); //latin large letter a with breve
            mnemdict.Add("{abreve}", (char)0xE661); //latin small letter a with breve
            mnemdict.Add("{AC}", (char)0xAC); //latin large letter o with horn
            mnemdict.Add("{Acirc}", (char)0xE341); //latin large letter a with circumflex
            mnemdict.Add("{acirc}", (char)0xE361); //latin small letter a with circumflex
            mnemdict.Add("{acute}", (char)0xE2); //combining acute
            mnemdict.Add("{AD}", (char)0xAD); //latin large letter u with horn
            mnemdict.Add("{AE}", (char)0xAE); //modifier letter right half ring/alif
            mnemdict.Add("{AElig}", (char)0xA5); //latin large letter AE
            mnemdict.Add("{aelig}", (char)0xB5); //latin small letter ae
            mnemdict.Add("{AF}", (char)0xAF); //hex value AF
            mnemdict.Add("{agr}", (char)0x61); //greek small letter alpha
            mnemdict.Add("{Agrave}", (char)0xE141); //latin large letter a with grave
            mnemdict.Add("{agrave}", (char)0xE161); //latin small letter a with grave
            mnemdict.Add("{alif}", (char)0xAE); //modifier letter right half ring (alif)
            mnemdict.Add("{amp}", (char)0x26); //ampersand
            mnemdict.Add("{Aogon}", (char)0xF141); //latin large letter a with ogon (hook right)
            mnemdict.Add("{aogon}", (char)0xF161); //latin small letter a with ogon (hook right)
            mnemdict.Add("{apos}", (char)0x27); //apostrophe
            mnemdict.Add("{arab}", (char)0x2833); //begin arabic script
            mnemdict.Add("{Aring}", (char)0xEA41); //latin large letter a with ring
            mnemdict.Add("{aring}", (char)0xEA61); //latin small letter a with ring
            mnemdict.Add("{ast}", (char)0x2A); //asterisk
            mnemdict.Add("{asuper}", (char)0x61); //superscript a
            mnemdict.Add("{Atilde}", (char)0xE441); //latin large letter A with tilde
            mnemdict.Add("{atilde}", (char)0xE461); //latin small letter a with tilde
            mnemdict.Add("{Auml}", (char)0xE841); //latin large letter A with umlaut
            mnemdict.Add("{auml}", (char)0xE861); //latin small letter a with umlaut
            mnemdict.Add("{ayn}", (char)0xB0); //modifier letter left half ring (ayn)
            mnemdict.Add("{B}", (char)0x42); //latin large letter b
            mnemdict.Add("{b}", (char)0x62); //latin small letter b
            mnemdict.Add("{B0}", (char)0xB0); //modifier letter left half ring/ayn
            mnemdict.Add("{B1}", (char)0xB1); //latin small letter l with stroke
            mnemdict.Add("{B2}", (char)0xB2); //latin small letter o with stroke
            mnemdict.Add("{B3}", (char)0xB3); //latin small letter d with stroke
            mnemdict.Add("{B4}", (char)0xB4); //latin small letter thorn
            mnemdict.Add("{B5}", (char)0xB5); //latin small letter ae
            mnemdict.Add("{B6}", (char)0xB6); //latin small letter oe
            mnemdict.Add("{B7}", (char)0xB7); //modifier letter double prime/hard sign
            mnemdict.Add("{B8}", (char)0xB8); //latin small letter dotless i
            mnemdict.Add("{B9}", (char)0xB9); //pound sign
            mnemdict.Add("{BA}", (char)0xBA); //latin small letter eth
            mnemdict.Add("{BB}", (char)0xBB); //hex value BB
            mnemdict.Add("{BC}", (char)0xBC); //latin small letter o with horn
            mnemdict.Add("{BD}", (char)0xBD); //latin small letter u with horn
            mnemdict.Add("{BE}", (char)0xBE); //hex value BE
            mnemdict.Add("{BF}", (char)0xBF); //hex value BF
            mnemdict.Add("{bgr}", (char)0x62); //greek small letter beta
            mnemdict.Add("{breve}", (char)0xE6); //combining breve
            mnemdict.Add("{breveb}", (char)0xF9); //combining breve below
            mnemdict.Add("{brvbar}", (char)0x7C); //broken vertical bar
            mnemdict.Add("{bsol}", (char)0x5C); //reverse solidus (back slash)
            mnemdict.Add("{bull}", (char)0x2A); //bullet
            mnemdict.Add("{C}", (char)0x43); //latin large letter c
            mnemdict.Add("{c}", (char)0x63); //latin small letter c
            mnemdict.Add("{C0}", (char)0xC0); //degree sign
            mnemdict.Add("{C1}", (char)0xC1); //latin small letter script l
            mnemdict.Add("{C2}", (char)0xC2); //sound recording copyright
            mnemdict.Add("{C3}", (char)0xC3); //copyright sign
            mnemdict.Add("{C4}", (char)0xC4); //sharp
            mnemdict.Add("{C5}", (char)0xC5); //inverted question mark
            mnemdict.Add("{C6}", (char)0xC6); //inverted exclamation mark
            mnemdict.Add("{C7}", (char)0xC7); //hex value C7
            mnemdict.Add("{C8}", (char)0xC8); //hex value C8
            mnemdict.Add("{C9}", (char)0xC9); //hex value C9
            mnemdict.Add("{CA}", (char)0xCA); //hex value CA
            mnemdict.Add("{Cacute}", (char)0xE243); //latin large letter c with acute
            mnemdict.Add("{cacute}", (char)0xE263); //latin small letter c with acute
            mnemdict.Add("{candra}", (char)0xEF); //combining candrabindu
            mnemdict.Add("{caron}", (char)0xE9); //combining hacek
            mnemdict.Add("{CB}", (char)0xCB); //hex value CB
            mnemdict.Add("{CC}", (char)0xCC); //hex value CC
            mnemdict.Add("{Ccaron}", (char)0xE943); //latin large letter c with caron
            mnemdict.Add("{ccaron}", (char)0xE963); //latin small letter c with caron
            mnemdict.Add("{Ccedil}", (char)0xF043); //latin large letter c with cedilla
            mnemdict.Add("{ccedil}", (char)0xF063); //latin small letter c with cedilla
            mnemdict.Add("{CD}", (char)0xCD); //hex value CD
            mnemdict.Add("{CE}", (char)0xCE); //hex value CE
            mnemdict.Add("{cedil}", (char)0xF0); //combining cedilla
            mnemdict.Add("{cent}", (char)0x63); //cent sign
            mnemdict.Add("{CF}", (char)0xCF); //hex value CF
            mnemdict.Add("{circ}", (char)0xE3); //combining circumflex
            mnemdict.Add("{circb}", (char)0xF4); //combining circumflex below
            mnemdict.Add("{cjk}", (char)0x2431); //begin chinese japanese korean script
            mnemdict.Add("{colon}", (char)0x3A); //colon
            mnemdict.Add("{comma}", (char)0x2C); //comma
            mnemdict.Add("{commaa}", (char)0xFE); //combining comma above
            mnemdict.Add("{commab}", (char)0xF7); //combining comma below
            mnemdict.Add("{commat}", (char)0x40); //commercial at sign
            mnemdict.Add("{copy}", (char)0xC3); //copyright sign
            mnemdict.Add("{curren}", (char)0x2A); //currency sign
            mnemdict.Add("{cyril}", (char)0x284E); //begin cyrillic script
            mnemdict.Add("{D}", (char)0x44); //latin large letter d
            mnemdict.Add("{d}", (char)0x64); //latin small letter d
            mnemdict.Add("{D0}", (char)0xD0); //hex value D0
            mnemdict.Add("{D1}", (char)0xD1); //hex value D1
            mnemdict.Add("{D2}", (char)0xD2); //hex value D2
            mnemdict.Add("{D3}", (char)0xD3); //hex value D3
            mnemdict.Add("{D4}", (char)0xD4); //hex value D4
            mnemdict.Add("{D5}", (char)0xD5); //hex value D5
            mnemdict.Add("{D6}", (char)0xD6); //hex value D6
            mnemdict.Add("{D7}", (char)0xD7); //hex value D7
            mnemdict.Add("{D8}", (char)0xD8); //hex value D8
            mnemdict.Add("{D9}", (char)0xD9); //hex value D9
            mnemdict.Add("{DA}", (char)0xDA); //hex value DA
            mnemdict.Add("{Dagger}", (char)0x7C); //double dagger
            mnemdict.Add("{dagger}", (char)0x7C); //dagger
            mnemdict.Add("{DB}", (char)0xDB); //hex value DB
            mnemdict.Add("{dblac}", (char)0xEE); //combining double acute
            mnemdict.Add("{dbldotb}", (char)0xF3); //combining double dot below
            mnemdict.Add("{dblunder}", (char)0xF5); //combining double underscore
            mnemdict.Add("{DC}", (char)0xDC); //hex value DC
            mnemdict.Add("{Dcaron}", (char)0xE944); //latin large letter d with caron
            mnemdict.Add("{dcaron}", (char)0xE964); //latin small letter d with caron
            mnemdict.Add("{DD}", (char)0xDD); //hex value DD
            mnemdict.Add("{DE}", (char)0xDE); //hex value DE
            mnemdict.Add("{deg}", (char)0xC0); //degree sign
            mnemdict.Add("{DF}", (char)0xDF); //hex value DF
            mnemdict.Add("{diaer}", (char)0xE8); //combining diaeresis
            mnemdict.Add("{divide}", (char)0x2F); //Divide sign (CP850)
            mnemdict.Add("{dollar}", (char)0x24); //dollar sign
            mnemdict.Add("{dot}", (char)0xE7); //combining dot above
            mnemdict.Add("{dotb}", (char)0xF2); //combining dot below
            mnemdict.Add("{Dstrok}", (char)0xA3); //latin large letter d with stroke
            mnemdict.Add("{dstrok}", (char)0xB3); //latin small letter d with stroke
            mnemdict.Add("{E}", (char)0x45); //latin large letter e
            mnemdict.Add("{e}", (char)0x65); //latin small letter e
            mnemdict.Add("{E0}", (char)0xE0); //combining hook above
            mnemdict.Add("{E1}", (char)0xE1); //combining grave
            mnemdict.Add("{E2}", (char)0xE2); //combining acute
            mnemdict.Add("{E3}", (char)0xE3); //combining circumflex
            mnemdict.Add("{E4}", (char)0xE4); //combining tilde
            mnemdict.Add("{E5}", (char)0xE5); //combining macron
            mnemdict.Add("{E6}", (char)0xE6); //combining breve
            mnemdict.Add("{E7}", (char)0xE7); //combining dot above
            mnemdict.Add("{E8}", (char)0xE8); //combining diaeresis
            mnemdict.Add("{E9}", (char)0xE9); //combining hacek
            mnemdict.Add("{EA}", (char)0xEA); //combining ring above
            mnemdict.Add("{ea}", (char)0xea); //combining ring above
            mnemdict.Add("{Eacute}", (char)0xE245); //latin large letter e with acute
            mnemdict.Add("{eacute}", (char)0xE265); //latin small letter e with acute
            mnemdict.Add("{EB}", (char)0xEB); //combining ligature left half
            mnemdict.Add("{EC}", (char)0xEC); //combining ligature right half
            mnemdict.Add("{Ecaron}", (char)0xE945); //latin large letter e with caron
            mnemdict.Add("{ecaron}", (char)0xE965); //latin small letter e with caron
            mnemdict.Add("{Ecirc}", (char)0xE345); //latin large letter e with circumflex
            mnemdict.Add("{ecirc}", (char)0xE365); //latin small letter e with circumflex
            mnemdict.Add("{ED}", (char)0xED); //combining comma above right
            mnemdict.Add("{EE}", (char)0xEE); //combining double acute
            mnemdict.Add("{EF}", (char)0xEF); //combining candrabindu
            mnemdict.Add("{Egrave}", (char)0xE145); //latin large letter e with grave
            mnemdict.Add("{egrave}", (char)0xE165); //latin small letter e with grave
            mnemdict.Add("{Ehookr}", (char)0xF145); //latin large letter e with right hook (ogonek)
            mnemdict.Add("{ehookr}", (char)0xF165); //latin small letter e with right hook (ogonek)
            mnemdict.Add("{Eogon}", (char)0xF145); //latin large letter e with ogonek (right hook)
            mnemdict.Add("{eogon}", (char)0xF165); //latin small letter e with ogonek (right hook)
            mnemdict.Add("{equals}", (char)0x3D); //equals sign
            mnemdict.Add("{esc}", (char)0x1B); //escape
            mnemdict.Add("{Eth}", (char)0xA3); //latin large letter eth
            mnemdict.Add("{eth}", (char)0xBA); //latin small letter eth
            mnemdict.Add("{Euml}", (char)0xE845); //latin large letter e with umlaut
            mnemdict.Add("{euml}", (char)0xE865); //latin small letter e with umlaut
            mnemdict.Add("{excl}", (char)0x21); //exclamation point
            mnemdict.Add("{F}", (char)0x46); //latin large letter f
            mnemdict.Add("{f}", (char)0x66); //latin small letter f
            mnemdict.Add("{F0}", (char)0xF0); //combining cedilla
            mnemdict.Add("{F1}", (char)0xF1); //combining ogonek
            mnemdict.Add("{F2}", (char)0xF2); //combining dot below
            mnemdict.Add("{F3}", (char)0xF3); //combining double dot below
            mnemdict.Add("{F4}", (char)0xF4); //combining ring below
            mnemdict.Add("{F5}", (char)0xF5); //combining double underscore
            mnemdict.Add("{F6}", (char)0xF6); //combining underscore
            mnemdict.Add("{F7}", (char)0xF7); //combining comma below
            mnemdict.Add("{F8}", (char)0xF8); //combining right cedilla
            mnemdict.Add("{F9}", (char)0xF9); //combining breve below
            mnemdict.Add("{FA}", (char)0xFA); //combining double tilde left half
            mnemdict.Add("{FB}", (char)0xFB); //combining double tilde right half
            mnemdict.Add("{FC}", (char)0xFC); //hex value FC
            mnemdict.Add("{FD}", (char)0xFD); //hex value FD
            mnemdict.Add("{FE}", (char)0xFE); //combining comma above
            mnemdict.Add("{FF}", (char)0xFF); //hex value FF
            mnemdict.Add("{flat}", (char)0xA9); //musical flat sign
            mnemdict.Add("{fnof}", (char)0x66); //curvy f (CP850)
            //mnemdict.Add("{frac12}", (char)0x312F32); //fraction 1/2
            //mnemdict.Add("{frac14}", (char)0x312F34); //fraction 1/4
            //mnemdict.Add("{frac34}", (char)0x332F34); //fraction 3/4
            mnemdict.Add("{G}", (char)0x47); //latin large letter g
            mnemdict.Add("{g}", (char)0x67); //latin small letter g
            mnemdict.Add("{ggr}", (char)0x67); //greek small letter gamma
            mnemdict.Add("{grave}", (char)0xE1); //combining grave
            mnemdict.Add("{greek}", (char)0x67); //begin greek script
            mnemdict.Add("{gs}", (char)0x1D); //group separator (end of record)
            mnemdict.Add("{gt}", (char)0x3E); //greater than
            mnemdict.Add("{H}", (char)0x48); //latin large letter h
            mnemdict.Add("{h}", (char)0x68); //latin small letter h
            mnemdict.Add("{hardsign}", (char)0xB7); //modifier letter hard sign
            mnemdict.Add("{hebrew}", (char)0x2832); //begin hebrew script
            //mnemdict.Add("{hellip}", (char)0x2E2E2E); //ellipsis
            mnemdict.Add("{hooka}", (char)0xE0); //combining hook above
            mnemdict.Add("{hookl}", (char)0xF7); //combining left hook
            mnemdict.Add("{hookr}", (char)0xF1); //combining right hook
            mnemdict.Add("{hyphen}", (char)0x2D); //hyphen (minus)
            mnemdict.Add("{I}", (char)0x49); //latin large letter i
            mnemdict.Add("{i}", (char)0x69); //latin small letter i
            mnemdict.Add("{Iacute}", (char)0xE249); //latin large letter i with acute
            mnemdict.Add("{iacute}", (char)0xE269); //latin small letter i with acute
            mnemdict.Add("{Icaron}", (char)0xE949); //latin large letter i with caron
            mnemdict.Add("{icaron}", (char)0xE969); //latin small letter i with caron
            mnemdict.Add("{Icirc}", (char)0xE349); //latin large letter i with circumflex
            mnemdict.Add("{icirc}", (char)0xE369); //latin small letter i with circumflex
            mnemdict.Add("{Idot}", (char)0xE749); //latin large letter i with dot
            mnemdict.Add("{iexcl}", (char)0xC6); //inverted exclamation mark
            mnemdict.Add("{Igrave}", (char)0xE149); //latin large letter i with grave
            mnemdict.Add("{igrave}", (char)0xE169); //latin small letter i with grave
            mnemdict.Add("{IJlig}", (char)0x494A); //latin large letter ij
            mnemdict.Add("{ijlig}", (char)0x696A); //latin small letter ij
            mnemdict.Add("{inodot}", (char)0xB8); //latin small letter dotless i
            mnemdict.Add("{iquest}", (char)0xC5); //inverted question mark
            mnemdict.Add("{Iuml}", (char)0xE849); //latin large letter i with umlaut
            mnemdict.Add("{iuml}", (char)0xE869); //latin small letter i with umlaut
            mnemdict.Add("{J}", (char)0x4A); //latin large letter j
            mnemdict.Add("{j}", (char)0x6A); //latin small letter j
            mnemdict.Add("{joiner}", (char)0x8D); //zero width joiner
            mnemdict.Add("{K}", (char)0x4B); //latin large letter k
            mnemdict.Add("{k}", (char)0x6B); //latin small letter k
            mnemdict.Add("{L}", (char)0x4C); //latin large letter l
            mnemdict.Add("{l}", (char)0x6C); //latin small letter l
            mnemdict.Add("{Lacute}", (char)0xE24C); //latin large letter l with acute
            mnemdict.Add("{lacute}", (char)0xE26C); //latin small letter l with acute
            mnemdict.Add("{laquo}", (char)0x22); //left-pointing double angle quotation mark
            mnemdict.Add("{latin}", (char)0x2842); //begin latin script
            mnemdict.Add("{lcub}", (char)0x7B); //opening curly brace
            mnemdict.Add("{ldbltil}", (char)0xFA); //combining double tilde left half
            mnemdict.Add("{ldquo}", (char)0x22); //left double quotation mark
            mnemdict.Add("{ldquofh}", (char)0x22); //falling double quotation mark left (high)
            mnemdict.Add("{ldquor}", (char)0x22); //rising double quotation mark left (high)
            mnemdict.Add("{llig}", (char)0xEB); //combining ligature left half
            mnemdict.Add("{lpar}", (char)0x28); //left parenthesis
            mnemdict.Add("{lsqb}", (char)0x5B); //left bracket
            mnemdict.Add("{lsquo}", (char)0x27); //left single quotation mark
            mnemdict.Add("{lsquor}", (char)0x27); //rising single quotation left (low)
            mnemdict.Add("{Lstrok}", (char)0xA1); //latin large letter l with stroke
            mnemdict.Add("{lstrok}", (char)0xB1); //latin small letter l with stroke
            mnemdict.Add("{lt}", (char)0x3C); //less than
            mnemdict.Add("{M}", (char)0x4D); //latin large letter m
            mnemdict.Add("{m}", (char)0x6D); //latin small letter m
            mnemdict.Add("{macr}", (char)0xE5); //combining macron
            mnemdict.Add("{mdash}", (char)0x2D2D); //m dash
            mnemdict.Add("{middot}", (char)0xA8); //middle dot
            mnemdict.Add("{mllhring}", (char)0xB0); //modifier letter left half ring (ayn)
            mnemdict.Add("{mlPrime}", (char)0xB7); //modifier letter double prime (hard sign)
            mnemdict.Add("{mlprime}", (char)0xA7); //modifier letter prime (soft sign)
            mnemdict.Add("{mlrhring}", (char)0xAE); //modifier letter right half ring (alif)
            mnemdict.Add("{N}", (char)0x4E); //latin large letter n
            mnemdict.Add("{n}", (char)0x6E); //latin small letter n
            mnemdict.Add("{Nacute}", (char)0xE24E); //latin large letter n with acute
            mnemdict.Add("{nacute}", (char)0xE26E); //latin small letter n with acute
            mnemdict.Add("{Ncaron}", (char)0xE94E); //latin large letter n with caron
            mnemdict.Add("{ncaron}", (char)0xE96E); //latin small letter n with caron
            mnemdict.Add("{ndash}", (char)0x2D2D); //m dash
            mnemdict.Add("{nonjoin}", (char)0x8E); //zero width non-joiner
            mnemdict.Add("{Ntilde}", (char)0xE44E); //latin large letter n with tilde
            mnemdict.Add("{ntilde}", (char)0xE46E); //latin small letter n with tilde
            mnemdict.Add("{num}", (char)0x23); //number sign
            mnemdict.Add("{O}", (char)0x4F); //latin large letter o
            mnemdict.Add("{o}", (char)0x6F); //latin small letter o
            mnemdict.Add("{Oacute}", (char)0xE24F); //latin large letter o with acute
            mnemdict.Add("{oacute}", (char)0xE26F); //latin small letter o with acute
            mnemdict.Add("{Ocirc}", (char)0xE34F); //latin large letter o with circ
            mnemdict.Add("{ocirc}", (char)0xE36F); //latin small letter o with circ
            mnemdict.Add("{Odblac}", (char)0xEE4F); //latin large letter o double acute
            mnemdict.Add("{odblac}", (char)0xEE6F); //latin small letter o double acute
            mnemdict.Add("{OElig}", (char)0xA6); //latin large letter OE
            mnemdict.Add("{oelig}", (char)0xB6); //latin small letter oe
            mnemdict.Add("{ogon}", (char)0xF1); //combining ogonek (hook right)
            mnemdict.Add("{Ograve}", (char)0xE14F); //latin large letter o with grave
            mnemdict.Add("{ograve}", (char)0xE16F); //latin small letter o with grave
            mnemdict.Add("{Ohorn}", (char)0xAC); //latin large letter o with horn
            mnemdict.Add("{ohorn}", (char)0xBC); //latin small letter o with horn
            mnemdict.Add("{ordf}", (char)0x61); //feminine ordinal indicator
            mnemdict.Add("{ordm}", (char)0x6F); //masculine ordinal indicator
            mnemdict.Add("{Ostrok}", (char)0xA2); //latin large letter o with stroke
            mnemdict.Add("{ostrok}", (char)0xB2); //latin small letter o with stroke
            mnemdict.Add("{osuper}", (char)0x6F); //latin small letter superscript o
            mnemdict.Add("{Otilde}", (char)0xE44F); //latin large letter o with tilde
            mnemdict.Add("{otilde}", (char)0xE46F); //latin small letter o with tilde
            mnemdict.Add("{Ouml}", (char)0xE84F); //latin large letter o with uml
            mnemdict.Add("{ouml}", (char)0xE86F); //latin small letter o with uml
            mnemdict.Add("{P}", (char)0x50); //latin large letter p
            mnemdict.Add("{p}", (char)0x70); //latin small letter p
            mnemdict.Add("{para}", (char)0x7C); //pilcrow (paragraph)
            mnemdict.Add("{percnt}", (char)0x25); //percent sign
            mnemdict.Add("{period}", (char)0x2E); //period (decimal point)
            mnemdict.Add("{phono}", (char)0xC2); //sound recording copyright
            mnemdict.Add("{pipe}", (char)0x7C); //pipe
            mnemdict.Add("{plus}", (char)0x2B); //plus
            mnemdict.Add("{plusmn}", (char)0xAB); //plus-minus sign
            mnemdict.Add("{pound}", (char)0xB9); //pound sign
            mnemdict.Add("{Q}", (char)0x51); //latin large letter q
            mnemdict.Add("{q}", (char)0x71); //latin small letter q
            mnemdict.Add("{quest}", (char)0x3F); //question mark
            mnemdict.Add("{quot}", (char)0x22); //quotation mark
            mnemdict.Add("{R}", (char)0x52); //latin large letter r
            mnemdict.Add("{r}", (char)0x72); //latin small letter r
            mnemdict.Add("{Racute}", (char)0xE252); //latin large letter r with acute
            mnemdict.Add("{racute}", (char)0xE272); //latin small letter r with acute
            mnemdict.Add("{raquo}", (char)0x22); //right-pointing double angle quotation mark
            mnemdict.Add("{Rcaron}", (char)0xE952); //latin large letter r with caron
            mnemdict.Add("{rcaron}", (char)0xE972); //latin small letter r with caron
            mnemdict.Add("{rcedil}", (char)0xF8); //combining right cedilla
            mnemdict.Add("{rcommaa}", (char)0xED); //combining comma above right
            mnemdict.Add("{rcub}", (char)0x7D); //closing curly brace
            mnemdict.Add("{rdbltil}", (char)0xFB); //combining double tilde right half
            mnemdict.Add("{rdquo}", (char)0x22); //right double quotation mark
            mnemdict.Add("{rdquofh}", (char)0x22); //falling double quotation right (high)
            mnemdict.Add("{rdquor}", (char)0x22); //rising double quotation right (high)
            mnemdict.Add("{reg}", (char)0xAA); //registered sign
            mnemdict.Add("{ring}", (char)0xEA); //combining ring above
            mnemdict.Add("{ringb}", (char)0xF4); //combining ring below
            mnemdict.Add("{rlig}", (char)0xEC); //combining ligature right half
            mnemdict.Add("{rpar}", (char)0x29); //right parenthesis
            mnemdict.Add("{rs}", (char)0x1E); //record separator (end of field)
            mnemdict.Add("{rsqb}", (char)0x5D); //right bracket
            mnemdict.Add("{rsquo}", (char)0x27); //right single quotation mark
            mnemdict.Add("{rsquor}", (char)0x27); //rising single quotation right (high)
            mnemdict.Add("{S}", (char)0x53); //latin large letter s
            mnemdict.Add("{s}", (char)0x73); //latin small letter s
            mnemdict.Add("{Sacute}", (char)0xE253); //latin large letter s with acute
            mnemdict.Add("{sacute}", (char)0xE273); //latin small letter s with acute
            mnemdict.Add("{Scommab}", (char)0xF753); //latin large letter s with comma below
            mnemdict.Add("{scommab}", (char)0xF773); //latin small letter s with comma below
            mnemdict.Add("{scriptl}", (char)0xC1); //latin small letter script l
            mnemdict.Add("{sect}", (char)0x7C); //section sign
            mnemdict.Add("{semi}", (char)0x3B); //semicolon
            mnemdict.Add("{sharp}", (char)0xC4); //sharp
            mnemdict.Add("{shy}", (char)0x2D); //soft hyphen (CP850)
            mnemdict.Add("{softsign}", (char)0xA7); //modifier letter soft sign
            mnemdict.Add("{sol}", (char)0x2F); //slash (solidus)
            mnemdict.Add("{space}", (char)0x20); //space (blank)
            mnemdict.Add("{spcirc}", (char)0x5E); //spacing circumflex
            mnemdict.Add("{spgrave}", (char)0x60); //spacing grave
            mnemdict.Add("{sptilde}", (char)0x7E); //spacing tilde
            mnemdict.Add("{spundscr}", (char)0x5F); //spacing underscore
            mnemdict.Add("{squf}", (char)0x7C); //fill character
            mnemdict.Add("{sub}", (char)0x62); //begin subscript
            //mnemdict.Add("{sup1}", (char)0x1B70311B73); //
            //mnemdict.Add("{sup2}", (char)0x1B70321B73); //
            //mnemdict.Add("{sup3}", (char)0x1B70331B73); //
            mnemdict.Add("{super}", (char)0x70); //begin superscript
            mnemdict.Add("{szlig}", (char)0x7373); //latin small letter sharp s (german)
            mnemdict.Add("{T}", (char)0x54); //latin large letter t
            mnemdict.Add("{t}", (char)0x74); //latin small letter t
            mnemdict.Add("{Tcaron}", (char)0xE954); //latin large letter t with caron
            mnemdict.Add("{tcaron}", (char)0xE974); //latin small letter t with caron
            mnemdict.Add("{Tcommab}", (char)0xF754); //latin large letter t with comma below
            mnemdict.Add("{tcommab}", (char)0xF774); //latin small letter t with comma below
            mnemdict.Add("{THORN}", (char)0xA4); //latin large letter thorn (icelandic)
            mnemdict.Add("{thorn}", (char)0xB4); //latin small letter thorn (icelandic)
            mnemdict.Add("{tilde}", (char)0xE4); //combining tilde
            mnemdict.Add("{times}", (char)0x78); //times sign
            //mnemdict.Add("{trade}", (char)0x28546D29); //trade mark sign
            mnemdict.Add("{U}", (char)0x55); //latin large letter u
            mnemdict.Add("{u}", (char)0x75); //latin small letter u
            mnemdict.Add("{Uacute}", (char)0xE255); //latin large letter u with acute
            mnemdict.Add("{uacute}", (char)0xE275); //latin small letter u with acute
            mnemdict.Add("{Ucirc}", (char)0xE355); //latin large letter u with circ
            mnemdict.Add("{ucirc}", (char)0xE375); //latin small letter u with circ
            mnemdict.Add("{Udblac}", (char)0xEE55); //latin large letter u with double acute
            mnemdict.Add("{udblac}", (char)0xEE75); //latin small letter u with double acute
            mnemdict.Add("{Ugrave}", (char)0xE155); //latin large letter u with grave
            mnemdict.Add("{ugrave}", (char)0xE175); //latin small letter u with grave
            mnemdict.Add("{Uhorn}", (char)0xAD); //latin large letter u with horn
            mnemdict.Add("{uhorn}", (char)0xBD); //latin small letter u with horn
            mnemdict.Add("{uml}", (char)0xE8); //combining umlaut
            mnemdict.Add("{under}", (char)0xF6); //combining underscore
            mnemdict.Add("{Uring}", (char)0xEA55); //latin large letter u with ring
            mnemdict.Add("{uring}", (char)0xEA75); //latin small letter u with ring
            mnemdict.Add("{us}", (char)0x1F); //unit separator (subfield delimiter)
            mnemdict.Add("{Uuml}", (char)0xE855); //latin large letter u with uml
            mnemdict.Add("{uuml}", (char)0xE875); //latin small letter u with uml
            mnemdict.Add("{V}", (char)0x56); //latin large letter v
            mnemdict.Add("{v}", (char)0x76); //latin small letter v
            mnemdict.Add("{verbar}", (char)0x7C); //vertical bar (fill character)
            mnemdict.Add("{vlineb}", (char)0xF2); //combining vertical line below
            mnemdict.Add("{W}", (char)0x57); //latin large letter w
            mnemdict.Add("{w}", (char)0x77); //latin small letter w
            mnemdict.Add("{X}", (char)0x58); //latin large letter x
            mnemdict.Add("{x}", (char)0x78); //latin small letter x
            mnemdict.Add("{Y}", (char)0x59); //latin large letter y
            mnemdict.Add("{y}", (char)0x79); //latin small letter y
            mnemdict.Add("{Yacute}", (char)0xE259); //latin large letter y with acute
            mnemdict.Add("{yacute}", (char)0xE279); //latin small letter y with acute
            mnemdict.Add("{yen}", (char)0x59); //yen (CP850)
            mnemdict.Add("{Z}", (char)0x5A); //latin large letter z
            mnemdict.Add("{z}", (char)0x7A); //latin small letter z
            mnemdict.Add("{Zacute}", (char)0xE25A); //latin large letter z with acute
            mnemdict.Add("{zacute}", (char)0xE27A); //latin small letter z with acute
            mnemdict.Add("{Zdot}", (char)0xE75A); //latin large letter z with dot above
            mnemdict.Add("{zdot}", (char)0xE77A); //latin small letter z with dot above
            mnemdict.Add("{Acy}", (char)0x41); //cyrillic large letter a
            mnemdict.Add("{acy}", (char)0x61); //cyrillic small letter a
            mnemdict.Add("{Bcy}", (char)0x42); //cyrillic large letter be
            mnemdict.Add("{bcy}", (char)0x62); //cyrillic small letter be
            mnemdict.Add("{CHcy}", (char)0x4368); //cyrillic large letter cha
            mnemdict.Add("{chcy}", (char)0x6368); //cyrillic small letter cha
            mnemdict.Add("{Dcy}", (char)0x44); //cyrillic large letter de
            mnemdict.Add("{dcy}", (char)0x64); //cyrillic small letter de
            mnemdict.Add("{DJEcy}", (char)0xA3); //cyrillic large letter dje
            mnemdict.Add("{djecy}", (char)0xB3); //cyrillic small letter dje
            mnemdict.Add("{DZEcy}", (char)0x447A); //cyrillic large letter dze
            mnemdict.Add("{dzecy}", (char)0x647A); //cyrillic small letter dze
            //mnemdict.Add("{DZHEcy}", (char)0x44E97A); //cyrillic large letter dzhe
            //mnemdict.Add("{dzhecy}", (char)0x64E97A); //cyrillic small letter dzhe
            mnemdict.Add("{Ecy}", (char)0xE744); //cyrillic large letter reversed e
            mnemdict.Add("{ecy}", (char)0xE765); //cyrillic small letter reversed e
            mnemdict.Add("{Fcy}", (char)0x46); //cyrillic large letter ef
            mnemdict.Add("{fcy}", (char)0x66); //cyrillic small letter ef
            mnemdict.Add("{Gcy}", (char)0x47); //cyrillic large letter ge
            mnemdict.Add("{gcy}", (char)0x67); //cyrillic small letter ge
            mnemdict.Add("{GEcy}", (char)0x47); //cyrillic large letter ge
            mnemdict.Add("{gecy}", (char)0x67); //cyrillic small letter ge
            mnemdict.Add("{GHcy}", (char)0x47); //ukrainian large letter ghe
            mnemdict.Add("{ghcy}", (char)0x67); //ukrainian small letter ghe
            mnemdict.Add("{GJEcy}", (char)0xE247); //cyrillic large letter gje
            mnemdict.Add("{gjecy}", (char)0xE267); //cyrillic small letter gje
            mnemdict.Add("{HARDcy}", (char)0xB7); //cyrillic large letter hardsign
            mnemdict.Add("{hardcy}", (char)0xB7); //cyrillic small letter hardsign
            mnemdict.Add("{Hcy}", (char)0x48); //cyrillic large letter he
            mnemdict.Add("{hcy}", (char)0x68); //cyrillic small letter he
            mnemdict.Add("{Icy}", (char)0x49); //cyrillic large letter ii
            mnemdict.Add("{icy}", (char)0x69); //cyrillic small letter ii
            //mnemdict.Add("{IEcy}", (char)0xEB49EC45); //cyrillic large letter ie
            //mnemdict.Add("{iecy}", (char)0xEB69EC65); //cyrillic small letter ie
            //mnemdict.Add("{IOcy}", (char)0xEB49EC4F); //cyrillic large letter io
            //mnemdict.Add("{iocy}", (char)0xEB69EC6F); //cyrillic small letter io
            mnemdict.Add("{Iumlcy}", (char)0xE849); //cyrillic large letter i with umlaut
            mnemdict.Add("{iumlcy}", (char)0xE869); //cyrillic small letter i with umlaut
            mnemdict.Add("{IYcy}", (char)0x59); //cyrillic large letter ukranian y
            mnemdict.Add("{iycy}", (char)0x79); //cyrillic small letter ukranian y
            mnemdict.Add("{Jcy}", (char)0xE649); //cyrillic large letter short ii
            mnemdict.Add("{jcy}", (char)0xE669); //cyrillic small letter short ii
            mnemdict.Add("{JEcy}", (char)0x4A); //cyrillic large letter je
            mnemdict.Add("{jecy}", (char)0x6A); //cyrillic small letter je
            mnemdict.Add("{JIcy}", (char)0xE849); //cyrillic large letter ji
            mnemdict.Add("{jicy}", (char)0xE869); //cyrillic small letter ji
            mnemdict.Add("{Kcy}", (char)0x4B); //cyrillic large letter ka
            mnemdict.Add("{kcy}", (char)0x6B); //cyrillic small letter ka
            mnemdict.Add("{KHcy}", (char)0x4B68); //cyrillic large letter kha
            mnemdict.Add("{khcy}", (char)0x6B68); //cyrillic small letter kha
            mnemdict.Add("{KJEcy}", (char)0xE24B); //cyrillic large letter kje
            mnemdict.Add("{kjecy}", (char)0xE26B); //cyrillic small letter kje
            mnemdict.Add("{Lcy}", (char)0x4C); //cyrillic large letter el
            mnemdict.Add("{lcy}", (char)0x6C); //cyrillic small letter el
            mnemdict.Add("{LJEcy}", (char)0x4C6A); //cyrillic large letter lje
            mnemdict.Add("{ljecy}", (char)0x6C6A); //cyrillic small letter lje
            mnemdict.Add("{Mcy}", (char)0x4D); //cyrillic large letter em
            mnemdict.Add("{mcy}", (char)0x6D); //cyrillic small letter em
            mnemdict.Add("{Ncy}", (char)0x4E); //cyrillic large letter en
            mnemdict.Add("{ncy}", (char)0x6E); //cyrillic small letter en
            mnemdict.Add("{NJEcy}", (char)0x4E6A); //cyrillic large letter nj
            mnemdict.Add("{njecy}", (char)0x6E6A); //cyrillic small letter nj
            //mnemdict.Add("{No}", (char)0x4E6F2E); //cyrillic abbr. for �nomer�
            mnemdict.Add("{Ocy}", (char)0x4F); //cyrillic large letter o
            mnemdict.Add("{ocy}", (char)0x6F); //cyrillic small letter o
            mnemdict.Add("{Pcy}", (char)0x50); //cyrillic large letter pe
            mnemdict.Add("{pcy}", (char)0x70); //cyrillic small letter pe
            mnemdict.Add("{Rcy}", (char)0x52); //cyrillic large letter er
            mnemdict.Add("{rcy}", (char)0x72); //cyrillic small letter er
            mnemdict.Add("{Scy}", (char)0x53); //cyrillic large letter es
            mnemdict.Add("{scy}", (char)0x73); //cyrillic small letter es
            //mnemdict.Add("{SHCHcy}", (char)0x53686368); //cyrillic large letter shcha
            //mnemdict.Add("{shchcy}", (char)0x73686368); //cyrillic small letter shcha
            mnemdict.Add("{SHcy}", (char)0x5368); //cyrillic large letter sha
            mnemdict.Add("{shcy}", (char)0x7368); //cyrillic small letter sha
            mnemdict.Add("{SOFTcy}", (char)0xA7); //cyrillic large letter softsign
            mnemdict.Add("{softcy}", (char)0xA7); //cyrillic smalll letter softsign
            mnemdict.Add("{Tcy}", (char)0x54); //cyrillic large letter te
            mnemdict.Add("{tcy}", (char)0x74); //cyrillic small letter te
            mnemdict.Add("{TSHEcy}", (char)0xE243); //cyrillic large letter tshe
            mnemdict.Add("{tshecy}", (char)0xE263); //cyrillic small letter tshe
            //mnemdict.Add("{TScy}", (char)0xEB54EC53); //cyrillic large letter tse
            //mnemdict.Add("{tscy}", (char)0xEB74EC73); //cyrillic small letter tse
            mnemdict.Add("{Ucy}", (char)0x55); //cyrillic large letter u
            mnemdict.Add("{ucy}", (char)0x75); //cyrillic small letter u
            mnemdict.Add("{Vcy}", (char)0x56); //cyrillic large letter ve
            mnemdict.Add("{vcy}", (char)0x76); //cyrillic small letter ve
            //mnemdict.Add("{YAcy}", (char)0xEB49EC41); //cyrillic large letter ia
            //mnemdict.Add("{yacy}", (char)0xEB69EC61); //cyrillic small letter ia
            mnemdict.Add("{Ycy}", (char)0x59); //cyrillic large letter yeri
            mnemdict.Add("{ycy}", (char)0x79); //cyrillic small letter yeri
            mnemdict.Add("{YEcy}", (char)0x45); //cyrillic large letter ye
            mnemdict.Add("{yecy}", (char)0x65); //cyrillic small letter ye
            mnemdict.Add("{YIcy}", (char)0x49); //cyrillic large letter yi
            mnemdict.Add("{yicy}", (char)0x69); //cyrillic small letter yi
            mnemdict.Add("{YIumlcy}", (char)0xE849); //cyrillic large letter yi with umlaut
            mnemdict.Add("{yiumlcy}", (char)0xE869); //cyrillic small letter yi
            //mnemdict.Add("{YUcy}", (char)0xEB49EC55); //cyrillic large letter iu
            //mnemdict.Add("{yucy}", (char)0xEB69EC75); //cyrillic small letter iu
            mnemdict.Add("{Zcy}", (char)0x5A); //cyrillic large letter ze
            mnemdict.Add("{zcy}", (char)0x7A); //cyrillic small letter ze
            mnemdict.Add("{ZHcy}", (char)0x5A68); //cyrillic large letter zhe
            mnemdict.Add("{zhcy}", (char)0x7A68); //cyrillic small letter zhe
            //mnemdict.Add("{ZHcyua}", (char)0xEB5AEC68); //ukrainian large letter zhe
            //mnemdict.Add("{zhcyua}", (char)0xEB7AEC68); //ukrainian small letter zhe
            return mnemdict;
        
        }
        
    }
}
