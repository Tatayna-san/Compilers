%{
// ��� ���������� ����������� � ����� GPPGParser, �������������� ����� ������, ������������ �������� gppg
    public Parser(AbstractScanner<int, LexLocation> scanner) : base(scanner) { }
%}

%output = SimpleYacc.cs

%namespace SimpleParser

%token ID COLON SEMICOLON ASSIGN COMMA RANGE PLUS MINUS MULT DIVISION MOD DIV MULTASSIGN DIVISIONASSIGN PLUSASSIGN MINUSASSIGN DIVASSIGN MODASSIGN AND OR NOT LT GT LEQ GEQ EQ NEQ WHILE FOR IF ELSE BEGIN END FUNCTION LEFT_BRACKET RIGHT_BRACKET LEFT_SQUARE_BRACKET RIGHT_SQUARE_BRACKET INT FLOAT SYMBOL TEXT INT_VAL FLOAT_VAL SYMBOL_VAL TEXT_VAL

%%

progr   : st_f_list
		;

st_f_list	: st_f_list var_decl SEMICOLON
			| st_f_list func_decl
			| var_decl SEMICOLON
			| func_decl
			;

block	: BEGIN st_list END
		| BEGIN END
		;

st_list	: st_list statement
		| statement
		;

statement	: func_call SEMICOLON
			| var_decl SEMICOLON
			| assign_st SEMICOLON
			| if_st
			| while_st
			| for_st
			;

func_decl	: FUNCTION ID LEFT_BRACKET params_list RIGHT_BRACKET ret_params template_params block
			| FUNCTION ID LEFT_BRACKET params_list RIGHT_BRACKET ret_params block
			| FUNCTION ID LEFT_BRACKET params_list RIGHT_BRACKET template_params block
			| FUNCTION ID LEFT_BRACKET params_list RIGHT_BRACKET block
			| FUNCTION ID LEFT_BRACKET RIGHT_BRACKET ret_params template_params block
			| FUNCTION ID LEFT_BRACKET RIGHT_BRACKET ret_params block
			| FUNCTION ID LEFT_BRACKET RIGHT_BRACKET template_params block
			| FUNCTION ID LEFT_BRACKET RIGHT_BRACKET block
			;

ret_params	: LEFT_SQUARE_BRACKET params_list RIGHT_SQUARE_BRACKET
			| LEFT_SQUARE_BRACKET RIGHT_SQUARE_BRACKET
			;

template_params	: LT template_params_list GT
				| LT GT
				;

params_list	: params_list COMMA param
			| param
			;

param	: type ID
		| FUNCTION ID
		;

template_params_list	: template_params_list COMMA template_param
						| template_param
						;

template_param	: type ID ASSIGN comp_term
				| FUNCTION ID ASSIGN ID
				;

func_call	: ID LEFT_BRACKET expr_list RIGHT_BRACKET templ_args
			| ID LEFT_BRACKET expr_list RIGHT_BRACKET
			| ID LEFT_BRACKET RIGHT_BRACKET templ_args
			| ID LEFT_BRACKET RIGHT_BRACKET
			;

templ_args	: LT comp_term_list GT
			| LT GT
			;

comp_term_list	: comp_term_list COMMA comp_term
				| comp_term
				;

var_decl	: type decl_list
			;

type	: INT
		| FLOAT
		| TEXT
		| SYMBOL
		;

decl_list	: decl_list COMMA decl
			| decl
			;

decl	: ID
		| assign_st
		;

expr_list	: expr_list COMMA expr
			| expr
			;

assign_st	: ID ASSIGN expr
			;

expr	: log_op_term log_term
		| log_term
		;

log_op_term	: log_op_term log_term log_op
			| log_term log_op
			;

log_term	: comp_op_term comp_term
			| comp_term
			;

comp_op_term	: comp_op_term comp_term comp_op
				| comp_term comp_op
				;

comp_term	: op_term term
			| term
			;

op_term	: op_term term add_op
		| term add_op
		;

term	: op_factor factor
		| factor
		;

op_factor	: op_factor factor mult_op
			| factor mult_op
			;
	
factor	: ID
		| INT_VAL
		| FLOAT_VAL
		| SYMBOL_VAL
		| TEXT_VAL
		| LEFT_BRACKET expr RIGHT_BRACKET
		| func_call
		| un_op factor
		;

add_op	: PLUS
		| MINUS
		;

mult_op	: MULT
		| DIVISION
        | MOD
        | DIV
		;

comp_op	: LT
        | GT
        | LEQ
        | GEQ
        | EQ
        | NEQ
		;

log_op	: AND
		| OR
		;

un_op	: NOT
		| MINUS
		;

if_st	: IF LEFT_BRACKET expr RIGHT_BRACKET block else_st
		| IF LEFT_BRACKET expr RIGHT_BRACKET block
		;

else_st	: ELSE block
		;

while_st	: WHILE LEFT_BRACKET expr RIGHT_BRACKET block
			;

for_st	: FOR LEFT_BRACKET ID ASSIGN range_st RIGHT_BRACKET block
		;

range_st	: comp_term RANGE comp_term
			;

%%
