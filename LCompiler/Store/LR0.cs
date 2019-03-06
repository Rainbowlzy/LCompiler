using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCompiler.Tools;

namespace LCompiler.Store
{
    public class LR0
    {
        public LR0()
        {
            string derivate = "->";
            string or = "|";
            string statement = @"

S->TK
K->QL
L->P,F|F
P->F

";
            var statements = statement.Split("\n", StringSplitOptions.RemoveEmptyEntries)
                .Where(line => line.Contains(derivate))
                .Select(line => line.Split(derivate, StringSplitOptions.RemoveEmptyEntries))
                .Select(line => new
                {
                    T = line[0],
                    Statements = line[1].Contains(or)
                        ? line[1].Split(or, StringSplitOptions.RemoveEmptyEntries)
                        : new[] {line[1]}
                })
                
                ;


        }

        public List<string> VT { get; set; } = new List<string>("=> , . ".Split(" ", StringSplitOptions.RemoveEmptyEntries));
        public List<string> VN { get; set; } = new List<string>("T K Q L P F".Split(" ", StringSplitOptions.RemoveEmptyEntries));
        public string S { get; set; }
        public string E { get; set; }

        public SafeDictionary<string, SafeDictionary<string, Action>> Table { get; set; } =
            new SafeDictionary<string, SafeDictionary<string, Action>>(
                new Dictionary<string, SafeDictionary<string, Action>>(
                    new Dictionary<string, SafeDictionary<string, Action>>()));
    }
}