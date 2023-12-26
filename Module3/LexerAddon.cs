using System;
using System.IO;
using SimpleScanner;
using ScannerHelper;
using System.Collections.Generic;

namespace  GeneratedLexer
{ 
    public class LexerAddon
    {
        public Scanner myScanner;
        private byte[] inputText = new byte[255];

        public int idCount = 0;
        public int minIdLength = Int32.MaxValue;
        public double avgIdLength = 0;
        public int maxIdLength = 0;
        public int sumInt = 0;
        public double sumDouble = 0.0;
        public List<string> idsInComment = new List<string>();

        public LexerAddon(string programText)
        {
            
            using (StreamWriter writer = new StreamWriter(new MemoryStream(inputText)))
            {
                writer.Write(programText);
                writer.Flush();
            }
            
            MemoryStream inputStream = new MemoryStream(inputText);
            
            myScanner = new Scanner(inputStream);
        }

        public void Lex()
        {
            // Чтобы вещественные числа распознавались и отображались в формате 3.14 (а не 3,14 как в русской Culture)
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            int tok = 0;
            do {
                tok = myScanner.yylex();
                switch (tok)
                {
                    case (int)Tok.ID:
                        if (myScanner.yytext.Length < minIdLength)
                        {
                            minIdLength = myScanner.yytext.Length;
                        }
                        if (myScanner.yytext.Length > maxIdLength)
                        {
                            maxIdLength = myScanner.yytext.Length;
                        }
                        avgIdLength += myScanner.yytext.Length;
                        idCount++;
                        break;
                    case (int)Tok.INT_VAL:
                        sumInt += myScanner.LexValueInt;
                        break;
                    case (int)Tok.FLOAT_VAL:
                        sumDouble += myScanner.LexValueDouble;
                        break;
                    case (int)Tok.ID_COMMENT:
                        idsInComment.Add(myScanner.yytext);
                        break;
                    default:
                        break;
                }
                if (tok == (int)Tok.EOF)
                {
                    avgIdLength /= idCount;
                    break;
                }
            } while (true);
        }
    }
}

