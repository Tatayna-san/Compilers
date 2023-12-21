%using ScannerHelper;
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

// «десь можно делать описани€ типов, переменных и методов - они попадают в класс Scanner
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
  // переход в состо€ние COMMENT
  BEGIN(COMMENT);
}

<COMMENT> "*/" { 
  // переход в состо€ние INITIAL
  BEGIN(INITIAL);
}

<COMMENT>{ID} {
  // обрабатываетс€ ID внутри комментари€
  return (int)Tok.ID_COMMENT;
}


{INT_VAL} { 
	LexValueInt = int.Parse(yytext);
	return (int)Tok.INT_VAL;
}

{FLOAT_VAL} { 
	LexValueDouble = double.Parse(yytext);
	return (int)Tok.FLOAT_VAL;
}

{SYMBOL_VAL} { 
	LexValueSymbol = yytext[1];
	return (int)Tok.SYMBOL_VAL;
}

{TEXT_VAL} { 
	LexValueText = yytext.Substring(1, yytext.Length - 2);
	return (int)Tok.TEXT_VAL;
}

{ID} { 
	return (int)Tok.ID;
}

[^ \r\n\t] {
	LexError();
	return 0; // конец разбора
}

%%

// «десь можно делать описани€ переменных и методов - они тоже попадают в класс Scanner

public void LexError()
{
	Console.WriteLine("({0},{1}): Ќеизвестный символ {2}", yyline, yycol, yytext);
}

public string TokToString(Tok tok)
{
	switch (tok)
	{
		case Tok.ID:
			return tok + " " + yytext;
		case Tok.INT_VAL:
			return tok + " " + LexValueInt;
		case Tok.FLOAT_VAL:
			return tok + " " + LexValueDouble;
		case Tok.SYMBOL_VAL:
			return tok + " " + LexValueSymbol;
		case Tok.TEXT_VAL:
			return tok + " " + LexValueText;
		default:
			return tok + "";
	}
}

