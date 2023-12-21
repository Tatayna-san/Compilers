using System.Collections.Generic;

namespace ProgramTree
{
    public enum BinaryOperation { PLUS, MINUS, MULT, DIVISION, MOD, DIV, LT, GT, LEQ, GEQ, EQ, NEQ, AND, OR };
    public enum UnaryOperation { NOT, MINUS };
    public class Node // базовый класс для всех узлов    
    {
    }

    public class ExprNode : Node // базовый класс для всех выражений
    {
    }

    public class IdNode : ExprNode
    {
        public string Name { get; set; }
        public IdNode(string name) { Name = name; }
    }

    public class IntValueNode : ExprNode
    {
        public int Value { get; set; }
        public IntValueNode(int value) 
        { 
            Value = value; 
        }
    }
    public class FloatValueNode : ExprNode
    {
        public float Value { get; set; }
        public FloatValueNode(float value)
        {
            Value = value;
        }
    }
    public class SymbolValueNode : ExprNode
    {
        public char Value { get; set; }
        public SymbolValueNode(char value)
        {
            Value = value;
        }
    }
    public class TextValueNode : ExprNode
    {
        public string Value { get; set; }
        public TextValueNode(string value)
        {
            Value = value;
        }
    }
    public class BinaryNode : ExprNode { 
        public ExprNode Left { get; set; }
        public BinaryOperation Op {  get; set; }
        public ExprNode Right {  get; set; }
        public BinaryNode(ExprNode left, BinaryOperation op, ExprNode right)
        {
            Left = left;
            Right = right;
            Op = op;
        }
    }
    class UnaryNode : ExprNode
    {
        public UnaryOperation Op { get; set; }
        public ExprNode Value { get; set; }
        public UnaryNode(UnaryOperation op, ExprNode value)
        {
            Op = op;
            Value = value;
        }
    }
    public class StatementNode : Node // базовый класс для всех операторов
    {
    }

    public class AssignNode : StatementNode
    {
        public IdNode Id { get; set; }
        public ExprNode Expr { get; set; }
        public AssignNode(IdNode id, ExprNode expr)
        {
            Id = id;
            Expr = expr;
        }
    }

    public class CycleNode : StatementNode
    {
        public ExprNode Expr { get; set; }
        public StatementNode Stat { get; set; }
        public CycleNode(ExprNode expr, StatementNode stat)
        {
            Expr = expr;
            Stat = stat;
        }
    }

    public class BlockNode : StatementNode
    {
        public List<StatementNode> StList = new List<StatementNode>();
        public BlockNode(StatementNode stat)
        {
            Add(stat);
        }
        public void Add(StatementNode stat)
        {
            StList.Add(stat);
        }
    }

    public class ExprListNode : ExprNode
    {
        public List<ExprNode> ExprList = new List<ExprNode>();
        public ExprListNode(ExprNode expr)
        {
            Add(expr);
        }
        public void Add(ExprNode expr)
        {
            ExprList.Add(expr);
        }
    }

    public class FuncDeclNode : StatementNode
    {
        public IdNode Id { get; set; }
        public ExprNode Params { get; set; }
        public ExprNode RetParams { get; set; }
        public ExprNode TemplateParams { get; set; }
        public BlockNode Body { get; set; }

        public FuncDeclNode(IdNode id, BlockNode body, ExprNode @params = null, ExprNode retParams = null, ExprNode templateParams = null)
        {
            Id = id;
            Params = @params;
            RetParams = retParams;
            TemplateParams = templateParams;
            Body = body;
        }
    }
    public class ParamsNode : ExprNode
    {
        public ExprListNode Params { get; set; }
        public ParamsNode(ExprListNode @params)
        {
            Params = @params;
        }
    }
    public class RetParamsNode : ExprNode {
        public ExprListNode Params { get; set; }
        public RetParamsNode(ExprListNode @params)
        {
            Params = @params;
        }
    }
    public class TemplateParamsNode : ExprNode
    {
        public ExprListNode Params { get; set; }
        public TemplateParamsNode(ExprListNode @params)
        {
            Params = @params;
        }
    }
    public class TypeNode : Node{ }
    public class IntTypeNode : TypeNode { }
    public class FloatTypeNode : TypeNode { }
    public class SymbolTypeNode : TypeNode { }
    public class TextTypeNode : TypeNode { }

    public class ParamNode : ExprNode
    {
        public TypeNode Type { get; set; }
        public IdNode Id { get; set; }
        public ParamNode(TypeNode type, IdNode id)
        {
            Type = type;
            Id = id;
        }
    }
    public class TemplateParamNode : ExprNode { }
    public class TemplateParamVarNode : TemplateParamNode
    {
        public TypeNode Type { get; set; }
        public IdNode Id { get; set; }
        public ExprNode Term { get; set; }
        public TemplateParamVarNode(TypeNode type, IdNode id, ExprNode term)
        {
            Type = type;
            Id = id;
            Term = term;
        }
    }
    public class TemplateParamFunctionVarNode : TemplateParamNode 
    { 
        public IdNode InnerId { get; set; }
        public IdNode OuterId { get; set; }
        public TemplateParamFunctionVarNode(IdNode innerId, IdNode outerId)
        {
            InnerId = innerId;
            OuterId = outerId;
        }
    }
    public class FuncCallNode : ExprNode
    {
        public IdNode Id { get; set; }
        public ExprListNode Args { get; set; }
        public TemplArgsNode TemplateArgs { get; set; }
        public FuncCallNode(IdNode id, ExprListNode args, TemplArgsNode templateArgs)
        {
            Id = id;
            Args = args;
            TemplateArgs = templateArgs;
        }
    }
    public class FucnCallStatementNode : StatementNode
    {
        public FuncCallNode FuncCall { get; set; }
        public FucnCallStatementNode(FuncCallNode funcCall)
        {
            FuncCall = funcCall;
        }
    }
    public class TemplArgsNode : ExprNode {
        public ExprListNode Args { get; set; }
        public TemplArgsNode(ExprListNode args)
        {
            Args = args;
        }
    }
    public class VariablesDeclNode : StatementNode
    {
        public TypeNode Type { get; set; }
        public ExprListNode DeclList { get; set; }
        public VariablesDeclNode(TypeNode type, ExprListNode declList)
        {
            Type = type;
            DeclList = declList;
        }
    }
    class DeclNode : ExprNode
    {
        public IdNode Id { get; set; }
        public AssignNode Assign { get; set; }
        public DeclNode(IdNode id, AssignNode assign)
        {
            if (id == null)
            {
                Id = assign.Id;
            } else
            {
                Id = id;
            }
            Assign = assign;
        }
    }
    class IfNode : StatementNode
    {
        public ExprNode Condition { get; set; }
        public BlockNode Then {  get; set; }
        public BlockNode Else { get; set; }
        public IfNode(ExprNode condition, BlockNode then, BlockNode @else)
        {
            Condition = condition;
            Then = then;
            Else = @else;
        }
    }
    class WhileNode : StatementNode
    {
        public ExprNode Condition { get; set; }
        public BlockNode Body { get; set; }
        public WhileNode(ExprNode cond, BlockNode body)
        {
            Condition = cond;
            Body = body;
        }
    }
    class ForNode : StatementNode
    {
        public IdNode Id { get; set; }
        public RangeNode Range { get; set; }
        public BlockNode Body { get; set; }
        public ForNode(IdNode id, RangeNode range, BlockNode body)
        {
            Id = id;
            Range = range;
            Body = body;
        }
    }
    class RangeNode : ExprNode
    {
        public ExprNode Min { get; set; }
        public ExprNode Max { get; set; }
        public RangeNode(ExprNode min, ExprNode max)
        {
            Min = min;
            Max = max;
        }
    }
}