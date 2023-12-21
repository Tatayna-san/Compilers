namespace ScannerHelper
{
    public enum Tok
    {
        EOF = 0,
        ID,
        COLON,
        SEMICOLON,
        ASSIGN,
        COMMA,
        RANGE,

        PLUS,
        MINUS,
        MULT,
        DIVISION,
        MOD,
        DIV,

        MULTASSIGN,
        DIVISIONASSIGN,
        PLUSASSIGN,
        MINUSASSIGN,
        DIVASSIGN,
        MODASSIGN,

        AND,
        OR,
        NOT,

        LT,  //lesser
        GT,  //greater
        LEQ, //less or equal
        GEQ, //greater or equal
        EQ,  //equal
        NEQ, //not equal

        WHILE,
        FOR,
        IF,
        ELSE,
        BEGIN,
        END,
        FUNCTION,

        LEFT_BRACKET,
        RIGHT_BRACKET,
        LEFT_SQUARE_BRACKET,
        RIGHT_SQUARE_BRACKET,

        INT,
        FLOAT,
        SYMBOL,
        TEXT,

        INT_VAL,
        FLOAT_VAL,
        SYMBOL_VAL,
        TEXT_VAL,

        ID_COMMENT
    };
}