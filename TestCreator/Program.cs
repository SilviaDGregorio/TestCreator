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



           /* IEnumerable<SyntaxNode> methods = root
            .DescendantNodes()
            .OfType<SyntaxNode>().ToList();
            foreach(var method in methods)
            {
               Console.Out.WriteLine(method.Kind());
            }*/
        }
    }
}