// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, QUT 2005-2010
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.3.6
// Machine:  DESKTOP-TPAIPAV
// DateTime: 13.12.2023 16:07:12
// UserName: ymayma
// Input file <SimpleYacc.y>

// options: no-lines gplex

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using QUT.Gppg;
using ProgramTree;

namespace SimpleParser
{
public enum Tokens {
    error=1,EOF=2,ID=3,COLON=4,SEMICOLON=5,ASSIGN=6,
    COMMA=7,RANGE=8,PLUS=9,MINUS=10,MULT=11,DIVISION=12,
    MOD=13,DIV=14,MULTASSIGN=15,DIVISIONASSIGN=16,PLUSASSIGN=17,MINUSASSIGN=18,
    DIVASSIGN=19,MODASSIGN=20,AND=21,OR=22,NOT=23,LT=24,
    GT=25,LEQ=26,GEQ=27,EQ=28,NEQ=29,WHILE=30,
    FOR=31,IF=32,ELSE=33,BEGIN=34,END=35,FUNCTION=36,
    LEFT_BRACKET=37,RIGHT_BRACKET=38,LEFT_SQUARE_BRACKET=39,RIGHT_SQUARE_BRACKET=40,INT=41,FLOAT=42,
    SYMBOL=43,TEXT=44,INT_VAL=45,FLOAT_VAL=46,SYMBOL_VAL=47,TEXT_VAL=48};

public struct ValueType
{ 
	public float fVal; 
	public int iVal; 
	public char sVal;
	public string tVal;
	public string idVal;
	public Node nVal;
	public TypeNode typeVal;
	public ExprNode eVal;
	public StatementNode stVal;
	public BlockNode blVal;
	public ExprListNode elVal;
}
// Abstract base class for GPLEX scanners
public abstract class ScanBase : AbstractScanner<ValueType,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

public class Parser: ShiftReduceParser<ValueType, LexLocation>
{
  // Verbatim content from SimpleYacc.y
	public StatementNode root;
    public Parser(AbstractScanner<ValueType, LexLocation> scanner) : base(scanner) { }
  // End verbatim content from SimpleYacc.y

#pragma warning disable 649
  private static Dictionary<int, string> aliasses;
#pragma warning restore 649
  private static Rule[] rules = new Rule[87];
  private static State[] states = new State[161];
  private static string[] nonTerms = new string[] {
      "type", "ident", "ret_params", "template_params", "params", "param", "template_param", 
      "func_call", "templ_args", "decl", "expr", "comp_term", "term", "factor", 
      "value", "range_st", "func_decl", "assign_st", "if_st", "while_st", "for_st", 
      "var_decl", "statement", "st_f_list", "block", "st_list", "params_list", 
      "template_params_list", "term_list", "decl_list", "expr_list", "progr", 
      "$accept", };

  static Parser() {
    states[0] = new State(new int[]{41,78,42,79,44,80,43,81,36,82},new int[]{-32,1,-24,3,-22,158,-1,7,-17,160});
    states[1] = new State(new int[]{2,2});
    states[2] = new State(-1);
    states[3] = new State(new int[]{41,78,42,79,44,80,43,81,36,82,2,-2},new int[]{-22,4,-17,6,-1,7});
    states[4] = new State(new int[]{5,5});
    states[5] = new State(-3);
    states[6] = new State(-4);
    states[7] = new State(new int[]{3,36},new int[]{-30,8,-10,77,-2,11,-18,76});
    states[8] = new State(new int[]{7,9,5,-43});
    states[9] = new State(new int[]{3,36},new int[]{-10,10,-2,11,-18,76});
    states[10] = new State(-48);
    states[11] = new State(new int[]{6,12,7,-50,5,-50});
    states[12] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-11,13,-12,68,-13,67,-14,48,-15,58,-2,22,-8,51});
    states[13] = new State(new int[]{21,14,22,44,7,-54,5,-54});
    states[14] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-12,15,-13,67,-14,48,-15,58,-2,22,-8,51});
    states[15] = new State(new int[]{24,16,25,46,26,59,27,61,28,63,29,65,21,-55,22,-55,7,-55,5,-55,38,-55});
    states[16] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-13,17,-14,48,-15,58,-2,22,-8,51});
    states[17] = new State(new int[]{9,18,10,32,24,-58,25,-58,26,-58,27,-58,28,-58,29,-58,21,-58,22,-58,7,-58,5,-58,38,-58});
    states[18] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-14,19,-15,58,-2,22,-8,51});
    states[19] = new State(new int[]{11,20,12,34,13,49,14,54,9,-65,10,-65,24,-65,25,-65,26,-65,27,-65,28,-65,29,-65,21,-65,22,-65,7,-65,5,-65,38,-65,8,-65});
    states[20] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-15,21,-2,22,-8,51});
    states[21] = new State(-68);
    states[22] = new State(new int[]{37,23,11,-73,12,-73,13,-73,14,-73,9,-73,10,-73,24,-73,25,-73,26,-73,27,-73,28,-73,29,-73,21,-73,22,-73,7,-73,5,-73,38,-73,8,-73});
    states[23] = new State(new int[]{38,73,3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-31,24,-11,75,-12,68,-13,67,-14,48,-15,58,-2,22,-8,51});
    states[24] = new State(new int[]{38,25,7,71});
    states[25] = new State(new int[]{24,27,11,-36,12,-36,13,-36,14,-36,9,-36,10,-36,25,-36,26,-36,27,-36,28,-36,29,-36,21,-36,22,-36,7,-36,5,-36,38,-36,8,-36},new int[]{-9,26});
    states[26] = new State(-35);
    states[27] = new State(new int[]{25,69,3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-29,28,-13,70,-14,48,-15,58,-2,22,-8,51});
    states[28] = new State(new int[]{25,29,7,30});
    states[29] = new State(-39);
    states[30] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-13,31,-14,48,-15,58,-2,22,-8,51});
    states[31] = new State(new int[]{9,18,10,32,25,-41,7,-41});
    states[32] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-14,33,-15,58,-2,22,-8,51});
    states[33] = new State(new int[]{11,20,12,34,13,49,14,54,9,-66,10,-66,24,-66,25,-66,26,-66,27,-66,28,-66,29,-66,21,-66,22,-66,7,-66,5,-66,38,-66,8,-66});
    states[34] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-15,35,-2,22,-8,51});
    states[35] = new State(-69);
    states[36] = new State(-17);
    states[37] = new State(-74);
    states[38] = new State(-75);
    states[39] = new State(-76);
    states[40] = new State(-77);
    states[41] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-11,42,-12,68,-13,67,-14,48,-15,58,-2,22,-8,51});
    states[42] = new State(new int[]{38,43,21,14,22,44});
    states[43] = new State(-78);
    states[44] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-12,45,-13,67,-14,48,-15,58,-2,22,-8,51});
    states[45] = new State(new int[]{24,16,25,46,26,59,27,61,28,63,29,65,21,-56,22,-56,7,-56,5,-56,38,-56});
    states[46] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-13,47,-14,48,-15,58,-2,22,-8,51});
    states[47] = new State(new int[]{9,18,10,32,24,-59,25,-59,26,-59,27,-59,28,-59,29,-59,21,-59,22,-59,7,-59,5,-59,38,-59});
    states[48] = new State(new int[]{11,20,12,34,13,49,14,54,9,-67,10,-67,24,-67,25,-67,26,-67,27,-67,28,-67,29,-67,21,-67,22,-67,7,-67,5,-67,38,-67,8,-67});
    states[49] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-15,50,-2,22,-8,51});
    states[50] = new State(-70);
    states[51] = new State(-79);
    states[52] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-14,53,-15,58,-2,22,-8,51});
    states[53] = new State(new int[]{11,20,12,34,13,49,14,54,9,-80,10,-80,24,-80,25,-80,26,-80,27,-80,28,-80,29,-80,21,-80,22,-80,7,-80,5,-80,38,-80,8,-80});
    states[54] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-15,55,-2,22,-8,51});
    states[55] = new State(-71);
    states[56] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-14,57,-15,58,-2,22,-8,51});
    states[57] = new State(new int[]{11,20,12,34,13,49,14,54,9,-81,10,-81,24,-81,25,-81,26,-81,27,-81,28,-81,29,-81,21,-81,22,-81,7,-81,5,-81,38,-81,8,-81});
    states[58] = new State(-72);
    states[59] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-13,60,-14,48,-15,58,-2,22,-8,51});
    states[60] = new State(new int[]{9,18,10,32,24,-60,25,-60,26,-60,27,-60,28,-60,29,-60,21,-60,22,-60,7,-60,5,-60,38,-60});
    states[61] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-13,62,-14,48,-15,58,-2,22,-8,51});
    states[62] = new State(new int[]{9,18,10,32,24,-61,25,-61,26,-61,27,-61,28,-61,29,-61,21,-61,22,-61,7,-61,5,-61,38,-61});
    states[63] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-13,64,-14,48,-15,58,-2,22,-8,51});
    states[64] = new State(new int[]{9,18,10,32,24,-62,25,-62,26,-62,27,-62,28,-62,29,-62,21,-62,22,-62,7,-62,5,-62,38,-62});
    states[65] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-13,66,-14,48,-15,58,-2,22,-8,51});
    states[66] = new State(new int[]{9,18,10,32,24,-63,25,-63,26,-63,27,-63,28,-63,29,-63,21,-63,22,-63,7,-63,5,-63,38,-63});
    states[67] = new State(new int[]{9,18,10,32,24,-64,25,-64,26,-64,27,-64,28,-64,29,-64,21,-64,22,-64,7,-64,5,-64,38,-64});
    states[68] = new State(new int[]{24,16,25,46,26,59,27,61,28,63,29,65,21,-57,22,-57,7,-57,5,-57,38,-57});
    states[69] = new State(-40);
    states[70] = new State(new int[]{9,18,10,32,25,-42,7,-42});
    states[71] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-11,72,-12,68,-13,67,-14,48,-15,58,-2,22,-8,51});
    states[72] = new State(new int[]{21,14,22,44,38,-52,7,-52});
    states[73] = new State(new int[]{24,27,11,-38,12,-38,13,-38,14,-38,9,-38,10,-38,25,-38,26,-38,27,-38,28,-38,29,-38,21,-38,22,-38,7,-38,5,-38,38,-38,8,-38},new int[]{-9,74});
    states[74] = new State(-37);
    states[75] = new State(new int[]{21,14,22,44,38,-53,7,-53});
    states[76] = new State(-51);
    states[77] = new State(-49);
    states[78] = new State(-44);
    states[79] = new State(-45);
    states[80] = new State(-46);
    states[81] = new State(-47);
    states[82] = new State(new int[]{3,36},new int[]{-2,83});
    states[83] = new State(new int[]{37,154},new int[]{-5,84});
    states[84] = new State(new int[]{39,145,24,127,34,88},new int[]{-3,85,-4,142,-25,144});
    states[85] = new State(new int[]{24,127,34,88},new int[]{-4,86,-25,126});
    states[86] = new State(new int[]{34,88},new int[]{-25,87});
    states[87] = new State(-18);
    states[88] = new State(new int[]{35,124,3,36,41,78,42,79,44,80,43,81,32,100,30,108,31,114},new int[]{-26,89,-23,125,-8,92,-2,94,-22,95,-1,7,-18,97,-19,99,-20,107,-21,113});
    states[89] = new State(new int[]{35,90,3,36,41,78,42,79,44,80,43,81,32,100,30,108,31,114},new int[]{-23,91,-8,92,-2,94,-22,95,-1,7,-18,97,-19,99,-20,107,-21,113});
    states[90] = new State(-7);
    states[91] = new State(-9);
    states[92] = new State(new int[]{5,93});
    states[93] = new State(-11);
    states[94] = new State(new int[]{37,23,6,12});
    states[95] = new State(new int[]{5,96});
    states[96] = new State(-12);
    states[97] = new State(new int[]{5,98});
    states[98] = new State(-13);
    states[99] = new State(-14);
    states[100] = new State(new int[]{37,101});
    states[101] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-11,102,-12,68,-13,67,-14,48,-15,58,-2,22,-8,51});
    states[102] = new State(new int[]{38,103,21,14,22,44});
    states[103] = new State(new int[]{34,88},new int[]{-25,104});
    states[104] = new State(new int[]{33,105,35,-83,3,-83,41,-83,42,-83,44,-83,43,-83,32,-83,30,-83,31,-83});
    states[105] = new State(new int[]{34,88},new int[]{-25,106});
    states[106] = new State(-82);
    states[107] = new State(-15);
    states[108] = new State(new int[]{37,109});
    states[109] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-11,110,-12,68,-13,67,-14,48,-15,58,-2,22,-8,51});
    states[110] = new State(new int[]{38,111,21,14,22,44});
    states[111] = new State(new int[]{34,88},new int[]{-25,112});
    states[112] = new State(-84);
    states[113] = new State(-16);
    states[114] = new State(new int[]{37,115});
    states[115] = new State(new int[]{3,36},new int[]{-2,116});
    states[116] = new State(new int[]{6,117});
    states[117] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-16,118,-13,121,-14,48,-15,58,-2,22,-8,51});
    states[118] = new State(new int[]{38,119});
    states[119] = new State(new int[]{34,88},new int[]{-25,120});
    states[120] = new State(-85);
    states[121] = new State(new int[]{8,122,9,18,10,32});
    states[122] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-13,123,-14,48,-15,58,-2,22,-8,51});
    states[123] = new State(new int[]{9,18,10,32,38,-86});
    states[124] = new State(-8);
    states[125] = new State(-10);
    states[126] = new State(-19);
    states[127] = new State(new int[]{25,140,41,78,42,79,44,80,43,81,36,136},new int[]{-28,128,-7,141,-1,132});
    states[128] = new State(new int[]{25,129,7,130});
    states[129] = new State(-26);
    states[130] = new State(new int[]{41,78,42,79,44,80,43,81,36,136},new int[]{-7,131,-1,132});
    states[131] = new State(-31);
    states[132] = new State(new int[]{3,36},new int[]{-2,133});
    states[133] = new State(new int[]{6,134});
    states[134] = new State(new int[]{3,36,45,37,46,38,47,39,48,40,37,41,23,52,10,56},new int[]{-13,135,-14,48,-15,58,-2,22,-8,51});
    states[135] = new State(new int[]{9,18,10,32,25,-33,7,-33});
    states[136] = new State(new int[]{3,36},new int[]{-2,137});
    states[137] = new State(new int[]{6,138});
    states[138] = new State(new int[]{3,36},new int[]{-2,139});
    states[139] = new State(-34);
    states[140] = new State(-27);
    states[141] = new State(-32);
    states[142] = new State(new int[]{34,88},new int[]{-25,143});
    states[143] = new State(-20);
    states[144] = new State(-21);
    states[145] = new State(new int[]{40,152,41,78,42,79,44,80,43,81},new int[]{-27,146,-6,153,-1,150});
    states[146] = new State(new int[]{40,147,7,148});
    states[147] = new State(-24);
    states[148] = new State(new int[]{41,78,42,79,44,80,43,81},new int[]{-6,149,-1,150});
    states[149] = new State(-28);
    states[150] = new State(new int[]{3,36},new int[]{-2,151});
    states[151] = new State(-30);
    states[152] = new State(-25);
    states[153] = new State(-29);
    states[154] = new State(new int[]{38,157,41,78,42,79,44,80,43,81},new int[]{-27,155,-6,153,-1,150});
    states[155] = new State(new int[]{38,156,7,148});
    states[156] = new State(-22);
    states[157] = new State(-23);
    states[158] = new State(new int[]{5,159});
    states[159] = new State(-5);
    states[160] = new State(-6);

    rules[1] = new Rule(-33, new int[]{-32,2});
    rules[2] = new Rule(-32, new int[]{-24});
    rules[3] = new Rule(-24, new int[]{-24,-22,5});
    rules[4] = new Rule(-24, new int[]{-24,-17});
    rules[5] = new Rule(-24, new int[]{-22,5});
    rules[6] = new Rule(-24, new int[]{-17});
    rules[7] = new Rule(-25, new int[]{34,-26,35});
    rules[8] = new Rule(-25, new int[]{34,35});
    rules[9] = new Rule(-26, new int[]{-26,-23});
    rules[10] = new Rule(-26, new int[]{-23});
    rules[11] = new Rule(-23, new int[]{-8,5});
    rules[12] = new Rule(-23, new int[]{-22,5});
    rules[13] = new Rule(-23, new int[]{-18,5});
    rules[14] = new Rule(-23, new int[]{-19});
    rules[15] = new Rule(-23, new int[]{-20});
    rules[16] = new Rule(-23, new int[]{-21});
    rules[17] = new Rule(-2, new int[]{3});
    rules[18] = new Rule(-17, new int[]{36,-2,-5,-3,-4,-25});
    rules[19] = new Rule(-17, new int[]{36,-2,-5,-3,-25});
    rules[20] = new Rule(-17, new int[]{36,-2,-5,-4,-25});
    rules[21] = new Rule(-17, new int[]{36,-2,-5,-25});
    rules[22] = new Rule(-5, new int[]{37,-27,38});
    rules[23] = new Rule(-5, new int[]{37,38});
    rules[24] = new Rule(-3, new int[]{39,-27,40});
    rules[25] = new Rule(-3, new int[]{39,40});
    rules[26] = new Rule(-4, new int[]{24,-28,25});
    rules[27] = new Rule(-4, new int[]{24,25});
    rules[28] = new Rule(-27, new int[]{-27,7,-6});
    rules[29] = new Rule(-27, new int[]{-6});
    rules[30] = new Rule(-6, new int[]{-1,-2});
    rules[31] = new Rule(-28, new int[]{-28,7,-7});
    rules[32] = new Rule(-28, new int[]{-7});
    rules[33] = new Rule(-7, new int[]{-1,-2,6,-13});
    rules[34] = new Rule(-7, new int[]{36,-2,6,-2});
    rules[35] = new Rule(-8, new int[]{-2,37,-31,38,-9});
    rules[36] = new Rule(-8, new int[]{-2,37,-31,38});
    rules[37] = new Rule(-8, new int[]{-2,37,38,-9});
    rules[38] = new Rule(-8, new int[]{-2,37,38});
    rules[39] = new Rule(-9, new int[]{24,-29,25});
    rules[40] = new Rule(-9, new int[]{24,25});
    rules[41] = new Rule(-29, new int[]{-29,7,-13});
    rules[42] = new Rule(-29, new int[]{-13});
    rules[43] = new Rule(-22, new int[]{-1,-30});
    rules[44] = new Rule(-1, new int[]{41});
    rules[45] = new Rule(-1, new int[]{42});
    rules[46] = new Rule(-1, new int[]{44});
    rules[47] = new Rule(-1, new int[]{43});
    rules[48] = new Rule(-30, new int[]{-30,7,-10});
    rules[49] = new Rule(-30, new int[]{-10});
    rules[50] = new Rule(-10, new int[]{-2});
    rules[51] = new Rule(-10, new int[]{-18});
    rules[52] = new Rule(-31, new int[]{-31,7,-11});
    rules[53] = new Rule(-31, new int[]{-11});
    rules[54] = new Rule(-18, new int[]{-2,6,-11});
    rules[55] = new Rule(-11, new int[]{-11,21,-12});
    rules[56] = new Rule(-11, new int[]{-11,22,-12});
    rules[57] = new Rule(-11, new int[]{-12});
    rules[58] = new Rule(-12, new int[]{-12,24,-13});
    rules[59] = new Rule(-12, new int[]{-12,25,-13});
    rules[60] = new Rule(-12, new int[]{-12,26,-13});
    rules[61] = new Rule(-12, new int[]{-12,27,-13});
    rules[62] = new Rule(-12, new int[]{-12,28,-13});
    rules[63] = new Rule(-12, new int[]{-12,29,-13});
    rules[64] = new Rule(-12, new int[]{-13});
    rules[65] = new Rule(-13, new int[]{-13,9,-14});
    rules[66] = new Rule(-13, new int[]{-13,10,-14});
    rules[67] = new Rule(-13, new int[]{-14});
    rules[68] = new Rule(-14, new int[]{-14,11,-15});
    rules[69] = new Rule(-14, new int[]{-14,12,-15});
    rules[70] = new Rule(-14, new int[]{-14,13,-15});
    rules[71] = new Rule(-14, new int[]{-14,14,-15});
    rules[72] = new Rule(-14, new int[]{-15});
    rules[73] = new Rule(-15, new int[]{-2});
    rules[74] = new Rule(-15, new int[]{45});
    rules[75] = new Rule(-15, new int[]{46});
    rules[76] = new Rule(-15, new int[]{47});
    rules[77] = new Rule(-15, new int[]{48});
    rules[78] = new Rule(-15, new int[]{37,-11,38});
    rules[79] = new Rule(-15, new int[]{-8});
    rules[80] = new Rule(-15, new int[]{23,-14});
    rules[81] = new Rule(-15, new int[]{10,-14});
    rules[82] = new Rule(-19, new int[]{32,37,-11,38,-25,33,-25});
    rules[83] = new Rule(-19, new int[]{32,37,-11,38,-25});
    rules[84] = new Rule(-20, new int[]{30,37,-11,38,-25});
    rules[85] = new Rule(-21, new int[]{31,37,-2,6,-16,38,-25});
    rules[86] = new Rule(-16, new int[]{-13,8,-13});
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Tokens.error, (int)Tokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
    switch (action)
    {
      case 2: // progr -> st_f_list
{ root = ValueStack[ValueStack.Depth-1].blVal; }
        break;
      case 3: // st_f_list -> st_f_list, var_decl, SEMICOLON
{ 
				ValueStack[ValueStack.Depth-3].blVal.Add(ValueStack[ValueStack.Depth-2].stVal); 
				CurrentSemanticValue.blVal = ValueStack[ValueStack.Depth-3].blVal; 
			}
        break;
      case 4: // st_f_list -> st_f_list, func_decl
{ 
				ValueStack[ValueStack.Depth-2].blVal.Add(ValueStack[ValueStack.Depth-1].stVal); 
				CurrentSemanticValue.blVal = ValueStack[ValueStack.Depth-2].blVal; 
			}
        break;
      case 5: // st_f_list -> var_decl, SEMICOLON
{	
				CurrentSemanticValue.blVal = new BlockNode(ValueStack[ValueStack.Depth-2].stVal); 
			}
        break;
      case 6: // st_f_list -> func_decl
{	
				CurrentSemanticValue.blVal = new BlockNode(ValueStack[ValueStack.Depth-1].stVal); 
			}
        break;
      case 7: // block -> BEGIN, st_list, END
{ CurrentSemanticValue.blVal = ValueStack[ValueStack.Depth-2].blVal; }
        break;
      case 9: // st_list -> st_list, statement
{ 
			ValueStack[ValueStack.Depth-2].blVal.Add(ValueStack[ValueStack.Depth-1].stVal); 
			CurrentSemanticValue.blVal = ValueStack[ValueStack.Depth-2].blVal; 
		}
        break;
      case 10: // st_list -> statement
{	
			CurrentSemanticValue.blVal = new BlockNode(ValueStack[ValueStack.Depth-1].stVal); 
		}
        break;
      case 11: // statement -> func_call, SEMICOLON
{ CurrentSemanticValue.stVal = new FucnCallStatementNode(ValueStack[ValueStack.Depth-2].eVal as FuncCallNode); }
        break;
      case 12: // statement -> var_decl, SEMICOLON
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-2].stVal; }
        break;
      case 13: // statement -> assign_st, SEMICOLON
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-2].stVal; }
        break;
      case 14: // statement -> if_st
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].stVal; }
        break;
      case 15: // statement -> while_st
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].stVal; }
        break;
      case 16: // statement -> for_st
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].stVal; }
        break;
      case 17: // ident -> ID
{ CurrentSemanticValue.eVal = new IdNode(ValueStack[ValueStack.Depth-1].idVal); }
        break;
      case 18: // func_decl -> FUNCTION, ident, params, ret_params, template_params, block
{
				CurrentSemanticValue.stVal = new FuncDeclNode(ValueStack[ValueStack.Depth-5].eVal  as IdNode, ValueStack[ValueStack.Depth-1].blVal, ValueStack[ValueStack.Depth-4].eVal, ValueStack[ValueStack.Depth-3].eVal, ValueStack[ValueStack.Depth-2].eVal);
			}
        break;
      case 19: // func_decl -> FUNCTION, ident, params, ret_params, block
{
				CurrentSemanticValue.stVal = new FuncDeclNode(ValueStack[ValueStack.Depth-4].eVal as IdNode, ValueStack[ValueStack.Depth-1].blVal, ValueStack[ValueStack.Depth-3].eVal, ValueStack[ValueStack.Depth-2].eVal, null);
			}
        break;
      case 20: // func_decl -> FUNCTION, ident, params, template_params, block
{
				CurrentSemanticValue.stVal = new FuncDeclNode(ValueStack[ValueStack.Depth-4].eVal as IdNode, ValueStack[ValueStack.Depth-1].blVal, ValueStack[ValueStack.Depth-3].eVal, null, ValueStack[ValueStack.Depth-2].eVal);
			}
        break;
      case 21: // func_decl -> FUNCTION, ident, params, block
{
				CurrentSemanticValue.stVal = new FuncDeclNode(ValueStack[ValueStack.Depth-3].eVal as IdNode, ValueStack[ValueStack.Depth-1].blVal, ValueStack[ValueStack.Depth-2].eVal, null, null);
			}
        break;
      case 22: // params -> LEFT_BRACKET, params_list, RIGHT_BRACKET
{
			CurrentSemanticValue.eVal = new ParamsNode(ValueStack[ValueStack.Depth-2].elVal);
		}
        break;
      case 23: // params -> LEFT_BRACKET, RIGHT_BRACKET
{
			CurrentSemanticValue.eVal = new ParamsNode(null);
		}
        break;
      case 24: // ret_params -> LEFT_SQUARE_BRACKET, params_list, RIGHT_SQUARE_BRACKET
{
				CurrentSemanticValue.eVal = new RetParamsNode(ValueStack[ValueStack.Depth-2].elVal);
			}
        break;
      case 25: // ret_params -> LEFT_SQUARE_BRACKET, RIGHT_SQUARE_BRACKET
{
				CurrentSemanticValue.eVal = new RetParamsNode(null);
			}
        break;
      case 26: // template_params -> LT, template_params_list, GT
{
					CurrentSemanticValue.eVal = new TemplateParamsNode(ValueStack[ValueStack.Depth-2].elVal);
				}
        break;
      case 27: // template_params -> LT, GT
{
					CurrentSemanticValue.eVal = new TemplateParamsNode(null);
				}
        break;
      case 28: // params_list -> params_list, COMMA, param
{ 
				ValueStack[ValueStack.Depth-3].elVal.Add(ValueStack[ValueStack.Depth-1].eVal); 
				CurrentSemanticValue.elVal = ValueStack[ValueStack.Depth-3].elVal; 
			}
        break;
      case 29: // params_list -> param
{ 
				CurrentSemanticValue.elVal = new ExprListNode(ValueStack[ValueStack.Depth-1].eVal); 
			}
        break;
      case 30: // param -> type, ident
{
			CurrentSemanticValue.eVal = new ParamNode(ValueStack[ValueStack.Depth-2].typeVal, ValueStack[ValueStack.Depth-1].eVal as IdNode);
		}
        break;
      case 31: // template_params_list -> template_params_list, COMMA, template_param
{ 
							ValueStack[ValueStack.Depth-3].elVal.Add(ValueStack[ValueStack.Depth-1].eVal); 
							CurrentSemanticValue.elVal = ValueStack[ValueStack.Depth-3].elVal; 
						}
        break;
      case 32: // template_params_list -> template_param
{ 
							CurrentSemanticValue.elVal = new ExprListNode(ValueStack[ValueStack.Depth-1].eVal); 
						}
        break;
      case 33: // template_param -> type, ident, ASSIGN, term
{
					CurrentSemanticValue.eVal = new TemplateParamVarNode(ValueStack[ValueStack.Depth-4].typeVal, ValueStack[ValueStack.Depth-3].eVal as IdNode, ValueStack[ValueStack.Depth-1].eVal);
				}
        break;
      case 34: // template_param -> FUNCTION, ident, ASSIGN, ident
{
					CurrentSemanticValue.eVal = new TemplateParamFunctionVarNode(ValueStack[ValueStack.Depth-3].eVal as IdNode, ValueStack[ValueStack.Depth-1].eVal as IdNode);
				}
        break;
      case 35: // func_call -> ident, LEFT_BRACKET, expr_list, RIGHT_BRACKET, templ_args
{
				CurrentSemanticValue.eVal = new FuncCallNode(ValueStack[ValueStack.Depth-5].eVal as IdNode, ValueStack[ValueStack.Depth-3].elVal as ExprListNode, ValueStack[ValueStack.Depth-1].eVal as TemplArgsNode);
			}
        break;
      case 36: // func_call -> ident, LEFT_BRACKET, expr_list, RIGHT_BRACKET
{
				CurrentSemanticValue.eVal = new FuncCallNode(ValueStack[ValueStack.Depth-4].eVal as IdNode, ValueStack[ValueStack.Depth-2].elVal as ExprListNode, null);
			}
        break;
      case 37: // func_call -> ident, LEFT_BRACKET, RIGHT_BRACKET, templ_args
{
				CurrentSemanticValue.eVal = new FuncCallNode(ValueStack[ValueStack.Depth-4].eVal as IdNode, null, ValueStack[ValueStack.Depth-1].eVal as TemplArgsNode);
			}
        break;
      case 38: // func_call -> ident, LEFT_BRACKET, RIGHT_BRACKET
{
				CurrentSemanticValue.eVal = new FuncCallNode(ValueStack[ValueStack.Depth-3].eVal as IdNode, null, null);
			}
        break;
      case 39: // templ_args -> LT, term_list, GT
{
				CurrentSemanticValue.eVal = new TemplArgsNode(ValueStack[ValueStack.Depth-2].elVal);
			}
        break;
      case 40: // templ_args -> LT, GT
{
				CurrentSemanticValue.eVal = new TemplArgsNode(null);
			}
        break;
      case 41: // term_list -> term_list, COMMA, term
{ 
				ValueStack[ValueStack.Depth-3].elVal.Add(ValueStack[ValueStack.Depth-1].eVal); 
				CurrentSemanticValue.elVal = ValueStack[ValueStack.Depth-3].elVal; 
			}
        break;
      case 42: // term_list -> term
{ 
				CurrentSemanticValue.elVal = new ExprListNode(ValueStack[ValueStack.Depth-1].eVal); 
			}
        break;
      case 43: // var_decl -> type, decl_list
{
				CurrentSemanticValue.stVal = new VariablesDeclNode(ValueStack[ValueStack.Depth-2].typeVal, ValueStack[ValueStack.Depth-1].elVal);
			}
        break;
      case 44: // type -> INT
{ CurrentSemanticValue.typeVal = new IntTypeNode(); }
        break;
      case 45: // type -> FLOAT
{ CurrentSemanticValue.typeVal = new FloatTypeNode(); }
        break;
      case 46: // type -> TEXT
{ CurrentSemanticValue.typeVal = new TextTypeNode(); }
        break;
      case 47: // type -> SYMBOL
{ CurrentSemanticValue.typeVal = new SymbolTypeNode(); }
        break;
      case 48: // decl_list -> decl_list, COMMA, decl
{ 
				ValueStack[ValueStack.Depth-3].elVal.Add(ValueStack[ValueStack.Depth-1].eVal); 
				CurrentSemanticValue.elVal = ValueStack[ValueStack.Depth-3].elVal; 
			}
        break;
      case 49: // decl_list -> decl
{ 
				CurrentSemanticValue.elVal = new ExprListNode(ValueStack[ValueStack.Depth-1].eVal); 
			}
        break;
      case 50: // decl -> ident
{
			CurrentSemanticValue.eVal = new DeclNode(ValueStack[ValueStack.Depth-1].eVal as IdNode, null);
		}
        break;
      case 51: // decl -> assign_st
{
			CurrentSemanticValue.eVal = new DeclNode(null, ValueStack[ValueStack.Depth-1].stVal as AssignNode);
		}
        break;
      case 52: // expr_list -> expr_list, COMMA, expr
{ 
				ValueStack[ValueStack.Depth-3].elVal.Add(ValueStack[ValueStack.Depth-1].eVal); 
				CurrentSemanticValue.elVal = ValueStack[ValueStack.Depth-3].elVal; 
			}
        break;
      case 53: // expr_list -> expr
{ 
				CurrentSemanticValue.elVal = new ExprListNode(ValueStack[ValueStack.Depth-1].eVal); 
			}
        break;
      case 54: // assign_st -> ident, ASSIGN, expr
{
				CurrentSemanticValue.stVal = new AssignNode(ValueStack[ValueStack.Depth-3].eVal as IdNode, ValueStack[ValueStack.Depth-1].eVal);
			}
        break;
      case 55: // expr -> expr, AND, comp_term
{
			CurrentSemanticValue.eVal = new BinaryNode(ValueStack[ValueStack.Depth-3].eVal, BinaryOperation.AND, ValueStack[ValueStack.Depth-1].eVal);
		}
        break;
      case 56: // expr -> expr, OR, comp_term
{
			CurrentSemanticValue.eVal = new BinaryNode(ValueStack[ValueStack.Depth-3].eVal, BinaryOperation.OR, ValueStack[ValueStack.Depth-1].eVal);
		}
        break;
      case 57: // expr -> comp_term
{
			CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-1].eVal;
		}
        break;
      case 58: // comp_term -> comp_term, LT, term
{
				CurrentSemanticValue.eVal = new BinaryNode(ValueStack[ValueStack.Depth-3].eVal, BinaryOperation.LT, ValueStack[ValueStack.Depth-1].eVal);
			}
        break;
      case 59: // comp_term -> comp_term, GT, term
{
				CurrentSemanticValue.eVal = new BinaryNode(ValueStack[ValueStack.Depth-3].eVal, BinaryOperation.GT, ValueStack[ValueStack.Depth-1].eVal);
			}
        break;
      case 60: // comp_term -> comp_term, LEQ, term
{
				CurrentSemanticValue.eVal = new BinaryNode(ValueStack[ValueStack.Depth-3].eVal, BinaryOperation.LEQ, ValueStack[ValueStack.Depth-1].eVal);
			}
        break;
      case 61: // comp_term -> comp_term, GEQ, term
{
				CurrentSemanticValue.eVal = new BinaryNode(ValueStack[ValueStack.Depth-3].eVal, BinaryOperation.GEQ, ValueStack[ValueStack.Depth-1].eVal);
			}
        break;
      case 62: // comp_term -> comp_term, EQ, term
{
				CurrentSemanticValue.eVal = new BinaryNode(ValueStack[ValueStack.Depth-3].eVal, BinaryOperation.EQ, ValueStack[ValueStack.Depth-1].eVal);
			}
        break;
      case 63: // comp_term -> comp_term, NEQ, term
{
				CurrentSemanticValue.eVal = new BinaryNode(ValueStack[ValueStack.Depth-3].eVal, BinaryOperation.NEQ, ValueStack[ValueStack.Depth-1].eVal);
			}
        break;
      case 64: // comp_term -> term
{
				CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-1].eVal;
			}
        break;
      case 65: // term -> term, PLUS, factor
{
			CurrentSemanticValue.eVal = new BinaryNode(ValueStack[ValueStack.Depth-3].eVal, BinaryOperation.PLUS, ValueStack[ValueStack.Depth-1].eVal);
		}
        break;
      case 66: // term -> term, MINUS, factor
{
			CurrentSemanticValue.eVal = new BinaryNode(ValueStack[ValueStack.Depth-3].eVal, BinaryOperation.MINUS, ValueStack[ValueStack.Depth-1].eVal);
		}
        break;
      case 67: // term -> factor
{
			CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-1].eVal;
		}
        break;
      case 68: // factor -> factor, MULT, value
{
			CurrentSemanticValue.eVal = new BinaryNode(ValueStack[ValueStack.Depth-3].eVal, BinaryOperation.MULT, ValueStack[ValueStack.Depth-1].eVal);
		}
        break;
      case 69: // factor -> factor, DIVISION, value
{
			CurrentSemanticValue.eVal = new BinaryNode(ValueStack[ValueStack.Depth-3].eVal, BinaryOperation.DIVISION, ValueStack[ValueStack.Depth-1].eVal);
		}
        break;
      case 70: // factor -> factor, MOD, value
{
			CurrentSemanticValue.eVal = new BinaryNode(ValueStack[ValueStack.Depth-3].eVal, BinaryOperation.MOD, ValueStack[ValueStack.Depth-1].eVal);
		}
        break;
      case 71: // factor -> factor, DIV, value
{
			CurrentSemanticValue.eVal = new BinaryNode(ValueStack[ValueStack.Depth-3].eVal, BinaryOperation.DIV, ValueStack[ValueStack.Depth-1].eVal);
		}
        break;
      case 72: // factor -> value
{
			CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-1].eVal;
		}
        break;
      case 73: // value -> ident
{
			CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-1].eVal;
		}
        break;
      case 74: // value -> INT_VAL
{
			CurrentSemanticValue.eVal = new IntValueNode(ValueStack[ValueStack.Depth-1].iVal);
		}
        break;
      case 75: // value -> FLOAT_VAL
{
			CurrentSemanticValue.eVal = new FloatValueNode(ValueStack[ValueStack.Depth-1].fVal); 
		}
        break;
      case 76: // value -> SYMBOL_VAL
{
			CurrentSemanticValue.eVal = new SymbolValueNode(ValueStack[ValueStack.Depth-1].sVal); 
		}
        break;
      case 77: // value -> TEXT_VAL
{
			CurrentSemanticValue.eVal = new TextValueNode(ValueStack[ValueStack.Depth-1].tVal); 
		}
        break;
      case 78: // value -> LEFT_BRACKET, expr, RIGHT_BRACKET
{
			CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-2].eVal;
		}
        break;
      case 79: // value -> func_call
{
			CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-1].eVal;
		}
        break;
      case 80: // value -> NOT, factor
{
			CurrentSemanticValue.eVal = new UnaryNode(UnaryOperation.NOT, ValueStack[ValueStack.Depth-1].eVal);
		}
        break;
      case 81: // value -> MINUS, factor
{
			CurrentSemanticValue.eVal = new UnaryNode(UnaryOperation.MINUS, ValueStack[ValueStack.Depth-1].eVal);
		}
        break;
      case 82: // if_st -> IF, LEFT_BRACKET, expr, RIGHT_BRACKET, block, ELSE, block
{
			CurrentSemanticValue.stVal = new IfNode(ValueStack[ValueStack.Depth-5].eVal, ValueStack[ValueStack.Depth-3].blVal, ValueStack[ValueStack.Depth-1].blVal);
		}
        break;
      case 83: // if_st -> IF, LEFT_BRACKET, expr, RIGHT_BRACKET, block
{
			CurrentSemanticValue.stVal = new IfNode(ValueStack[ValueStack.Depth-3].eVal, ValueStack[ValueStack.Depth-1].blVal, null);
		}
        break;
      case 84: // while_st -> WHILE, LEFT_BRACKET, expr, RIGHT_BRACKET, block
{
				CurrentSemanticValue.stVal = new WhileNode(ValueStack[ValueStack.Depth-3].eVal, ValueStack[ValueStack.Depth-1].blVal);
			}
        break;
      case 85: // for_st -> FOR, LEFT_BRACKET, ident, ASSIGN, range_st, RIGHT_BRACKET, block
{
			CurrentSemanticValue.stVal = new ForNode(ValueStack[ValueStack.Depth-5].eVal as IdNode, ValueStack[ValueStack.Depth-3].eVal as RangeNode, ValueStack[ValueStack.Depth-1].blVal);
		}
        break;
      case 86: // range_st -> term, RANGE, term
{
				CurrentSemanticValue.eVal = new RangeNode(ValueStack[ValueStack.Depth-3].eVal, ValueStack[ValueStack.Depth-1].eVal);
			}
        break;
    }
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliasses != null && aliasses.ContainsKey(terminal))
        return aliasses[terminal];
    else if (((Tokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Tokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }

}
}
