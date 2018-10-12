using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleApplication1;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
 
namespace GettingStartedCS
{
    class Program
    {
        static void Main(string[] args)
        {
            var code = new StreamReader("..\\..\\Class.cs").ReadToEnd();
            SyntaxTree tree = CSharpSyntaxTree.ParseText(
           code);
 
            var root = (CompilationUnitSyntax)tree.GetRoot();
 
            var collector = new UsingCollector();
            collector.Visit(root);
 
            foreach (var directive in collector.Statements)
            {
                Console.WriteLine(directive.Kind());
            }

            var methods = root
            .DescendantNodes()
            .OfType<MethodDeclarationSyntax>()
            .Where(n => n.ParameterList.Parameters.Any())
            .Where(n=>!n.Modifiers.Any(m=>m.ToString() == "private"))
            .ToList();

            string testFormat = "        [Test]\r\n        public void Test{0} ()\r\n        {{\r\n            var classs = new {1}();\r\n            classs.{2}({3});\r\n        }}";
            int i = 0;
            foreach(var method in methods)
            {
                SyntaxToken className = ((ClassDeclarationSyntax)method.Parent).Identifier;
                Console.Out.WriteLine(className + "::" + method.Modifiers + " " + method.Identifier + method.ParameterList);
                Console.Out.WriteLine(string.Format(testFormat, i, className, method.Identifier, "\"test parametro\""));
                i++;
            }
            Console.Read();
        }
    }
}