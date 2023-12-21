using System;
using NUnit.Framework;
using SimpleScanner;
using SimpleParser;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestASTParser
{
    public class ASTParserTests
    {
        public static JObject Parse(string text)
        {
            Scanner scanner = new Scanner();
            scanner.SetSource(text, 0);

            Parser parser = new Parser(scanner);

            var b = parser.Parse();
            if (!b)
                Assert.Fail("программа не распознана");
            else
            {
                JsonSerializerSettings jsonSettings = new JsonSerializerSettings();
                jsonSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                jsonSettings.TypeNameHandling = TypeNameHandling.All;
                string output = JsonConvert.SerializeObject(parser.root, jsonSettings);
                return JObject.Parse(output);
            }

            return null;

        }
    }
    
    [TestFixture]
    public class WhileTests
    {
        
        [Test]
        public void TestWhile()
        {
            var tree = ASTParserTests.Parse("function main() { while (2) { a=2; } }");
            Assert.AreEqual("ProgramTree.WhileNode, SimpleLang", (string)tree["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["$type"]);   
            Assert.AreEqual("ProgramTree.IntValueNode, SimpleLang", (string)tree["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["Condition"]["$type"]);
            Assert.AreEqual("2", ((string)tree["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["Condition"]["Value"]).Trim());
            Assert.AreEqual("ProgramTree.AssignNode, SimpleLang", (string)tree["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["$type"]);
        }
    }
    
    [TestFixture]
    public class IfTests
    {
        
        [Test]
        public void TestIf()
        {
            var tree = ASTParserTests.Parse("function main() { if (2 > 1) { a=2; } }");
            Assert.AreEqual("ProgramTree.IfNode, SimpleLang", (string)tree["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["$type"]);
            Assert.AreEqual("ProgramTree.BinaryNode, SimpleLang", (string)tree["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["Condition"]["$type"]);
            Assert.AreEqual("2", ((string)tree["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["Condition"]["Left"]["Value"]).Trim());
            Assert.AreEqual("1", ((string)tree["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["Condition"]["Right"]["Value"]).Trim());
            Assert.AreEqual("ProgramTree.AssignNode, SimpleLang", (string)tree["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["Then"]["StList"]["$values"][0]["$type"]);
        }
    }
    
    [TestFixture]
    public class ForTests
    {
        
        [Test]
        public void TestFor()
        {
            var tree = ASTParserTests.Parse("function main() { for (a = 1..5) { b=1; } }");
            Assert.AreEqual("ProgramTree.ForNode, SimpleLang", (string)tree["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["$type"]);
            Assert.AreEqual("ProgramTree.RangeNode, SimpleLang", (string)tree["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["Range"]["$type"]);
            Assert.AreEqual("1", ((string)tree["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["Range"]["Min"]["Value"]).Trim());
            Assert.AreEqual("5", ((string)tree["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["Range"]["Max"]["Value"]).Trim());
            Assert.AreEqual("ProgramTree.AssignNode, SimpleLang", (string)tree["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["$type"]);
        }
    }
    
    [TestFixture]
    ////[Ignore("This test is disabled")]
    public class WriteTests
    {
        
        [Test]
        public void TestWrite()
        {
            var tree = ASTParserTests.Parse("function main() { print(\"Hello World\"); }");
            Assert.AreEqual("ProgramTree.FucnCallStatementNode, SimpleLang", (string)tree["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["$type"]);
            Assert.AreEqual("ProgramTree.FuncCallNode, SimpleLang", (string)tree["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["FuncCall"]["$type"]);
            Assert.AreEqual("print", (string)tree["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["FuncCall"]["Id"]["Name"]);
            Assert.AreEqual("ProgramTree.TextValueNode, SimpleLang", (string)tree["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["FuncCall"]["Args"]["ExprList"]["$values"][0]["$type"]);
            Assert.AreEqual("Hello World", (string)tree["StList"]["$values"][0]["Body"]["StList"]["$values"][0]["FuncCall"]["Args"]["ExprList"]["$values"][0]["Value"]);
        }
    }
    
    [TestFixture]
    public class ExtraTests
    {
        
        [Test]
        //[Ignore("This test is disabled")]
        public void TestIf()
        {
            Assert.Throws<SimpleParser.SyntaxException>(() => ASTParserTests.Parse("function main() { if (2 >> 1) { a=2; } }"));
        }
        
        [Test]
        //[Ignore("This test is disabled")]
        public void TestVarDef()
        {
            Assert.Throws<SimpleParser.SyntaxException>(() => ASTParserTests.Parse("function main() { float a = 3..5; }"));
            Assert.DoesNotThrow(() => ASTParserTests.Parse("function main() { float a = 3.5; }"));
        }
        
        [Test]
        public void TestBinary()
        {
            Assert.Throws<SimpleParser.SyntaxException>(() => ASTParserTests.Parse("function main() { float a = 23 + + 11; }"));
            Assert.DoesNotThrow(() => ASTParserTests.Parse("function main() { float a = 3.5 + 14 * 25 - 4; }"));
        }
    }
}