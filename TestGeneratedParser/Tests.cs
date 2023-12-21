using System;
using System.IO;
using NUnit.Framework;
using SimpleScanner;
using SimpleParser;

namespace TestGeneratedParser
{
    [TestFixture]
    public class GeneratedParserTests
    {
        private bool Parse(string text)
        {
            Scanner scanner = new Scanner();
            scanner.SetSource(text, 0);
            
            Parser parser = new Parser(scanner);
                      
            return parser.Parse();
        }
        
        [Test]
        public void TestWhile()
        {
            Assert.True(Parse(@"function main() { while (2) { a=2; } }"));
        }
        
        [Test]
        public void TestRepeat()
        {
            Assert.True(Parse(@"function main() { 
                                     while (5)
                                     { 
                                       while (6)
                                       {
                                         a=2; 
                                       }
                                       while (7)
                                       {
                                         a=3;
                                         c=4;
                                       }
                                     }
                                  }"));
        }
        
        [Test]
        public void TestFor()
        {
            Assert.True(Parse(@"function main() {  
                                     for (a = 1..5)
                                     {
                                       b=1;
                                     }
                                  }"));
            
            Assert.True(Parse(@"function main() { 
                                     for (a = 1..5)
                                     { 
                                       for (i = 1..6)
                                       {
                                          c=1;
                                       }
                                       b=1;
                                     }
                                  }"));
        }
        
        [Test]
        public void TestWrite()
        {
            Assert.True(Parse(@"function main() { 
                                     for (a = 1..5)
                                     { 
                                       for (i = 1..6)
                                       {
                                          print(""asdasd"");
                                       }
                                       print(14);
                                     }
                                  }"));


            Assert.True(Parse(@"function main() {
                                if (4)
                                {
                                    if (4)
                                    {
                                        if (6)
                                        {
                                            print('a');
                                        }
                                    }
                                }
                    }"));
            
            Assert.True(Parse(@"function main() { 
                                     while(c > b) 
                                     { 
                                        a = 2;
                                        print(-3 * c + 12);
                                     }
                                  }"));
        }
        
        [Test]
        public void TestIf()
        {
            Assert.True(Parse(@"function main() {  
                                     if (2) {  
                                        a=2;
                                     } else {
                                        b=2;
                                     }
                                     if (3) {  
                                        if (c) {  
                                            c=4;
                                        } else {
                                            m=1;
                                        }
                                     } else {
                                        v=8;   
                                     }
                                     if (4) { 
                                       if (4) { 
                                         if (6) { 
                                            m=0;
                                         }
                                       }
                                     }
                                  }"));
            
            Assert.True(Parse(@"function main() {  while (1) { if (2) { a=1; } else { b = 2; }  } }"));
        }
        
        [Test]
        public void TestVar()
        {
            Assert.True(Parse(@"function main() { int a, b, c = 3, d = 6; float x = 1.2; text abc = ""abc"", str; symbol chr = '$', sym; }"));
        }
        
        [Test]
        public void TestExr()
        {
            Assert.True(Parse(@"function main() {  a =x-z*3/(c+3-(ddz)+2); }"));

            Assert.True(Parse(@"function main() { 
                                     if (2+2*(c-d/3)) {
                                        a=2;
                                        while (2-3+f) { c=c*2; }
                                     }
                                     else {
                                        b=2-3*(c-d/f*3);
                                     }
                                     for (i = 2-3*(s-d)..(c-3)) {
                                         a=(a-(3-3));
                                     }
                                     if (3) {
                                        if (c-3) {
                                            c=4+2;
                                        } else {
                                            m=1;
                                        }
                                     } else {
                                        v=(8+2);
                                     }
                                  }"));
        }
    }
}