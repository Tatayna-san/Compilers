using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ComponentModel;

namespace Lexer
{

    public class LexerException : System.Exception
    {
        public LexerException(string msg)
            : base(msg)
        {
        }
    }

    public class Lexer
    {

        protected int position;
        protected char currentCh; // очередной считанный символ
        protected int currentCharValue; // целое значение очередного считанного символа
        protected System.IO.StringReader inputReader;
        protected string inputString;

        public Lexer(string input)
        {
            inputReader = new System.IO.StringReader(input);
            inputString = input;
        }

        public void Error()
        {
            System.Text.StringBuilder o = new System.Text.StringBuilder();
            o.Append(inputString + '\n');
            o.Append(new System.String(' ', position - 1) + "^\n");
            o.AppendFormat("Error in symbol {0}", currentCh);
            throw new LexerException(o.ToString());
        }

        virtual protected void NextCh()
        {
            this.currentCharValue = this.inputReader.Read();
            this.currentCh = (char) currentCharValue;
            this.position += 1;
        }

        public virtual bool Parse()
        {
            return true;
        }
    }

    public class IntLexer : Lexer
    {

        protected System.Text.StringBuilder intString;
        public int parseResult = 0;

        public IntLexer(string input)
            : base(input)
        {
            intString = new System.Text.StringBuilder();
        }
        protected override void NextCh()
        {
            base.NextCh();
            if (currentCharValue != -1)
            {
                intString.Append(currentCh);
            }
        }

        public override bool Parse()
        {
            NextCh();
            if (currentCh == '+' || currentCh == '-')
            {
                NextCh();
            }
            
            if (char.IsDigit(currentCh))
            {
                NextCh();
            }
            else
            {
                Error();
            }

            while (char.IsDigit(currentCh))
            {
                NextCh();
            }


            if (currentCharValue != -1)
            {
                Error();
            }

            parseResult = int.Parse(intString.ToString());
            return true;

        }
    }
    
    public class IdentLexer : Lexer
    {
        private string parseResult;
        protected StringBuilder builder;
    
        public string ParseResult
        {
            get { return parseResult; }
        }
    
        public IdentLexer(string input) : base(input)
        {
            builder = new StringBuilder();
        }

        public override bool Parse()
        {
            NextCh();
            if (!char.IsLetter(currentCh))
            {
                Error();
            }
            while (char.IsLetterOrDigit(currentCh) || currentCh == '_')
            {
                NextCh();
            }
            if (currentCharValue != -1)
            {
                Error();
            }
            return true;
        }
    }

    public class IntNoZeroLexer : IntLexer
    {
        public IntNoZeroLexer(string input)
            : base(input)
        {
        }

        public override bool Parse()
        {
            NextCh();
            if (currentCh == '+' || currentCh == '-')
            {
                NextCh();
            }

            if (char.IsDigit(currentCh) && currentCh != '0')
            {
                NextCh();
            }
            else
            {
                Error();
            }

            while (char.IsDigit(currentCh))
            {
                NextCh();
            }


            if (currentCharValue != -1)
            {
                Error();
            }

            return true;
        }
    }

    public class LetterDigitLexer : Lexer
    {
        protected StringBuilder builder;
        protected string parseResult;

        public string ParseResult
        {
            get { return parseResult; }
        }

        public LetterDigitLexer(string input)
            : base(input)
        {
            builder = new StringBuilder();
        }

        public override bool Parse()
        {
            while (true) {
                NextCh();
                if (!char.IsLetter(currentCh)) {
                    if (currentCharValue == -1)
                    {
                        break;
                    }
                    Error();
                }
                NextCh();
                if (!char.IsDigit(currentCh))
                {
                    if(currentCharValue == -1)
                    {
                        break;
                    }
                    Error();
                }
            }
            return true;
        }
       
    }

    public class LetterListLexer : Lexer
    {
        protected List<char> parseResult;

        public List<char> ParseResult
        {
            get { return parseResult; }
        }

        public LetterListLexer(string input)
            : base(input)
        {
            parseResult = new List<char>();
        }

        public override bool Parse()
        {
            bool mustBeLetter = false;
            while (true)
            {
                NextCh();
                mustBeLetter = !mustBeLetter;
                if (mustBeLetter)
                {
                    if (char.IsLetter(currentCh))
                    {
                        parseResult.Add(currentCh);
                    }
                    else
                    {
                        Error();
                    }
                }
                if (!mustBeLetter && currentCh != ',' && currentCh != ';')
                {
                    if (currentCharValue == -1)
                    {
                        break;
                    }
                    Error();
                }
            }
            return true;
        }
    }

    public class DigitListLexer : Lexer
    {
        protected List<int> parseResult;

        public List<int> ParseResult
        {
            get { return parseResult; }
        }

        public DigitListLexer(string input)
            : base(input)
        {
            parseResult = new List<int>();
        }

        public override bool Parse()
        {
            NextCh();
            while (true)
            {
                if (!char.IsDigit(currentCh))
                {
                    Error();
                }
                parseResult.Add(int.Parse(currentCh.ToString()));
                NextCh();
                if (currentCharValue == -1)
                {
                    break;
                }
                if (currentCh != ' ')
                {
                    Error();
                }
                while (currentCh == ' ')
                {
                    NextCh();
                }
            }
            return true;
        }
    }

    public class LetterDigitGroupLexer : Lexer
    {
        protected StringBuilder builder;
        protected string parseResult;
        static int maxGroupSize = 2;

        public string ParseResult
        {
            get { return parseResult; }
        }
        
        public LetterDigitGroupLexer(string input)
            : base(input)
        {
            builder = new StringBuilder();
        }

        public override bool Parse()
        {
            int letterStreak = 0, digitStreak = 0;
            bool mustBeLetter = false, mustBeDigit = false;
            NextCh();
            if (!char.IsLetter(currentCh))
            {
                Error();
            }
            while (currentCharValue != -1)
            {
                builder.Append(currentCh.ToString());
                if (!char.IsLetter(currentCh) && !char.IsDigit(currentCh) ||
                    mustBeDigit && !char.IsDigit(currentCh) ||
                    mustBeLetter && !char.IsLetter(currentCh))
                {
                    Error();
                }
                mustBeLetter = false;
                mustBeDigit = false;
                if (char.IsLetter(currentCh))
                {
                    digitStreak = 0;
                    letterStreak++;
                    if (letterStreak == maxGroupSize)
                    {
                        mustBeDigit = true;
                    }
                }
                if (char.IsDigit(currentCh))
                {
                    letterStreak = 0;
                    digitStreak++;
                    if(digitStreak == maxGroupSize)
                    {
                        mustBeLetter = true;
                    }
                }
                NextCh();
            }
            parseResult = builder.ToString();
            return true;
        }
       
    }

    public class DoubleLexer : Lexer
    {
        private StringBuilder builder;
        private double parseResult;

        public double ParseResult
        {
            get { return parseResult; }

        }

        public DoubleLexer(string input)
            : base(input)
        {
            builder = new StringBuilder();
        }

        public override bool Parse()
        {
            NextCh();
            if (!char.IsDigit(currentCh))
            {
                Error();
            }
            while (char.IsDigit(currentCh))
            {
                builder.Append(currentCh);
                NextCh();
            }
            if (currentCharValue != -1)
            {
                if (currentCh != '.')
                {
                    Error();
                }
                builder.Append(currentCh);
                NextCh();
                if (!char.IsDigit(currentCh))
                {
                    Error();
                }
                while (char.IsDigit(currentCh))
                {
                    builder.Append(currentCh);
                    NextCh();
                }
                if (currentCharValue != -1)
                {
                    Error();
                }
            }
            parseResult = double.Parse(builder.ToString());
            return true;
        }
       
    }

    public class StringLexer : Lexer
    {
        private StringBuilder builder;
        private string parseResult;

        public string ParseResult
        {
            get { return parseResult; }

        }

        public StringLexer(string input)
            : base(input)
        {
            builder = new StringBuilder();
        }

        public override bool Parse()
        {
            NextCh();
            if (currentCh != '\'') { 
                Error();
            }
            NextCh();
            while(currentCh != '\'' && currentCharValue != -1)
            {
                builder.Append(currentCh);
                NextCh();
            }
            if (currentCh != '\'')
            {
                Error();
            }
            NextCh();
            if (currentCharValue != -1)
            {
                Error();
            }
            return true;
        }
    }

    public class CommentLexer : Lexer
    {
        private StringBuilder builder;
        private string parseResult;

        public string ParseResult
        {
            get { return parseResult; }

        }

        public CommentLexer(string input)
            : base(input)
        {
            builder = new StringBuilder();
        }

        public override bool Parse()
        {
            NextCh();
            if (currentCh != '/')
            {
                Error();
            }
            builder.Append(currentCh);
            NextCh();
            if (currentCh != '*')
            {
                Error();
            }
            builder.Append(currentCh);
            while (true)
            {
                NextCh();
                builder.Append(currentCh);
                if (currentCharValue == -1)
                {
                    Error();
                }
                if (currentCh == '*')
                {
                    NextCh();
                    builder.Append(currentCh);
                    if (currentCh == '/')
                    {
                        break;
                    }
                }
            }
            NextCh();
            if (currentCharValue != -1)
            {
                Error();
            }
            return true;
        }
    }

    public class IdentChainLexer : Lexer
    {
        private StringBuilder builder;
        private List<string> parseResult;

        public List<string> ParseResult
        {
            get { return parseResult; }

        }

        public IdentChainLexer(string input)
            : base(input)
        {
            builder = new StringBuilder();
            parseResult = new List<string>();
        }

        public override bool Parse()
        {
            while (true)
            {
                NextCh();
                if (!char.IsLetter(currentCh))
                {
                    Error();
                }
                while (char.IsLetterOrDigit(currentCh) || currentCh == '_')
                {
                    builder.Append(currentCh);
                    NextCh();
                }
                if (currentCh == '.')
                {
                    builder.Append(currentCh);
                    continue;
                }
                if (currentCharValue == -1)
                {
                    break;
                } else
                {
                    Error();
                }
            }
            return true;
        }
    }

    public class Program
    {
        public static void Main()
        {
            string input = "154216";
            Lexer L = new IntLexer(input);
            try
            {
                L.Parse();
            }
            catch (LexerException e)
            {
                System.Console.WriteLine(e.Message);
            }

        }
    }
}