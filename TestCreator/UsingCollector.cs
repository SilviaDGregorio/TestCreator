using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ConsoleApplication1
{
    class UsingCollector:CSharpSyntaxWalker
    {
        public readonly List<SyntaxNode> Statements = new List<SyntaxNode>();
        public  List<SyntaxKind> find = new List<SyntaxKind>() {SyntaxKind.IfStatement,SyntaxKind.ElseClause,SyntaxKind.ForEachStatement,SyntaxKind.WhileStatement,SyntaxKind.ForStatement,SyntaxKind.DoStatement,SyntaxKind.SwitchStatement,SyntaxKind.TryStatement}; 
        public override void VisitIfStatement(IfStatementSyntax node)
        {
            this.Statements.Add(node);
        }
        public override void VisitSwitchStatement(SwitchStatementSyntax node)
        {
            this.Statements.Add(node);
        }
         public override void VisitElseClause(ElseClauseSyntax node)
        {
            this.Statements.Add(node);
        }
        public override void VisitWhileStatement(WhileStatementSyntax node)
        {
            this.Statements.Add(node);
        }
        public override void VisitForEachStatement(ForEachStatementSyntax node)
        {
            this.Statements.Add(node);
        }
        public override void VisitForStatement(ForStatementSyntax node)
        {
            this.Statements.Add(node);
        }

        public override void VisitDoStatement(DoStatementSyntax node)
        {
            this.Statements.Add(node);
        }
        public override void VisitTryStatement(TryStatementSyntax node)
        {
            this.Statements.Add(node);
        }
    }
}
