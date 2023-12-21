%using SimpleParser;
%using QUT.Gppg;
%using System.Linq;

%namespace SimpleScanner

Alpha 	[a-zA-Z_]
Digit   [0-9]
AlphaDigit {Alpha}|{Digit}
INT_VAL  {Digit}+
FLOAT_VAL {INT_VAL}\.{INT_VAL}
SYMBOL_VAL \'.\'
TEXT_VAL \".*\"
NOT_ENDL [^\r\n]
ONELINE_COMMENT \/\/{NOT_ENDL}*
MULTILINE_COMMENT \/\*[^]*\*\/
ID {Alpha}{AlphaDigit}*

// ����� ����� ������ �������� �����, ���������� � ������� - ��� �������� � ����� Scanner
%{
  public int LexValueInt;
  public double LexValueDouble;
  public char LexValueSymbol;
  public string LexValueText;
%}

%x COMMENT

%%

":" { return (int)Tokens.COLON; }
";" { return (int)Tokens.SEMICOLON; }
"=" { return (int)Tokens.ASSIGN; }
"," { return (int)Tokens.COMMA; }
".." { return (int)Tokens.RANGE; }
"+" { return (int)Tokens.PLUS; }
"-" { return (int)Tokens.MINUS; }
"*" { return (int)Tokens.MULT; }
"/" { return (int)Tokens.DIVISION; }
"%" { return (int)Tokens.MOD; }
"/~" { return (int)Tokens.DIV; }
"+=" { return (int)Tokens.PLUSASSIGN; }
"-=" { return (int)Tokens.MINUSASSIGN; }
"*=" { return (int)Tokens.MULTASSIGN; }
"/=" { return (int)Tokens.DIVISIONASSIGN; }
"%=" { return (int)Tokens.MODASSIGN; }
"/~=" { return (int)Tokens.DIVASSIGN; }
"and" { return (int)Tokens.AND; }
"or" { return (int)Tokens.OR; }
"not" { return (int)Tokens.NOT; }
"<" { return (int)Tokens.LT; }
">" { return (int)Tokens.GT; }
"<=" { return (int)Tokens.LEQ; }
">=" { return (int)Tokens.GEQ; }
"==" { return (int)Tokens.EQ; }
"!=" { return (int)Tokens.NEQ; }
"while" { return (int)Tokens.WHILE; }
"for" { return (int)Tokens.FOR; }
"if" { return (int)Tokens.IF; }
"else" { return (int)Tokens.ELSE; }
"{" { return (int)Tokens.BEGIN; }
"}" { return (int)Tokens.END; }
"function" { return (int)Tokens.FUNCTION; }
"(" { return (int)Tokens.LEFT_BRACKET; }
")" { return (int)Tokens.RIGHT_BRACKET; }
"[" { return (int)Tokens.LEFT_SQUARE_BRACKET; }
"]" { return (int)Tokens.RIGHT_SQUARE_BRACKET; }
"int" { return (int)Tokens.INT; }
"float" { return (int)Tokens.FLOAT; }
"symbol" { return (int)Tokens.SYMBOL; }
"text" { return (int)Tokens.TEXT; }

{ONELINE_COMMENT} {
}

"/*" { 
  // ������� � ��������� COMMENT
  BEGIN(COMMENT);
}

<COMMENT> "*/" { 
  // ������� � ��������� INITIAL
  BEGIN(INITIAL);
}


{INT_VAL} { 
	yylval.iVal = int.Parse(yytext);
	return (int)Tokens.INT_VAL;
}

{FLOAT_VAL} { 
	yylval.fVal = float.Parse(yytext, CultureInfo.InvariantCulture);
	return (int)Tokens.FLOAT_VAL;
}

{SYMBOL_VAL} { 
	yylval.sVal = yytext[1];
	return (int)Tokens.SYMBOL_VAL;
}

{TEXT_VAL} { 
	yylval.tVal = yytext.Substring(1, yytext.Length - 2);
	return (int)Tokens.TEXT_VAL;
}

{ID} { 
	int res = ScannerHelper.GetIDToken(yytext);
	if (res == (int)Tokens.ID)
		yylval.idVal = yytext;
	return res;
}

[^ \r\n\t] {
	LexError();
	return 0; // ����� �������
}

%{
  yylloc = new LexLocation(tokLin, tokCol, tokELin, tokECol); // ������� ������� (������������� ��� ���������������), ������������ @1 @2 � �.�.
%}

%%

public override void yyerror(string format, params object[] args) // ��������� �������������� ������
{
  var ww = args.Skip(1).Cast<string>().ToArray();
  string errorMsg = string.Format("({0},{1}): ��������� {2}, � ��������� {3}", yyline, yycol, args[0], string.Join(" ��� ", ww));
  throw new SyntaxException(errorMsg);
}

public void LexError()
{
	string errorMsg = string.Format("({0},{1}): ����������� ������ {2}", yyline, yycol, yytext);
    throw new LexException(errorMsg);
}

class ScannerHelper 
{
  private static Dictionary<string,int> keywords;

  static ScannerHelper() 
  {
    keywords = new Dictionary<string,int>();

    keywords.Add("function",(int)Tokens.FUNCTION);

    keywords.Add("int",(int)Tokens.INT);
	keywords.Add("float",(int)Tokens.FLOAT);
	keywords.Add("symbol",(int)Tokens.SYMBOL);
	keywords.Add("text",(int)Tokens.TEXT);

    keywords.Add("and",(int)Tokens.AND);
	keywords.Add("or",(int)Tokens.OR);
	keywords.Add("not",(int)Tokens.NOT);

	keywords.Add("if",(int)Tokens.IF);
	keywords.Add("else",(int)Tokens.ELSE);
	keywords.Add("while",(int)Tokens.WHILE);
	keywords.Add("for",(int)Tokens.FOR);
  }
  public static int GetIDToken(string s)
  {
    if (keywords.ContainsKey(s)) // ���� �������������� � ��������
      return keywords[s];
    else
      return (int)Tokens.ID;
  }
}
