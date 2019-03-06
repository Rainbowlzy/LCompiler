using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCompiler.Tools;
using Newtonsoft.Json;

namespace LCompiler.Store
{
    public class LR0
    {
        public LR0()
        {
            string derivate = "->";
            string or = "|";
            string statement = @"
S->tK.
K->=>L
L->P,f|L
P->f
";

            /*
L0:
    S'->S
    S->·tK.
    S->t·K.

L1:
    K->·=>L
    K->=>·L

L2:
    L->·P,L
    L->·f

L3:
    P->·f
             */


            var statements = statement.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Where(line => line.Contains(derivate))
                .Select(line => line.Split(derivate, StringSplitOptions.RemoveEmptyEntries))
                .Select(line => new
                {
                    T = line[0],
                    S = line[1]
//                        .Contains(or)
//                        ? line[1].Split(or, StringSplitOptions.RemoveEmptyEntries)
//                        : new[] {line[1]}
                })
                
                ;

            Console.WriteLine(JsonConvert.SerializeObject(statements));

        }

        public bool IsUpper(string s) => !s.Any(c => c < 'A' && c > 'Z');
        public bool IsLower(string s) => !s.Any(c => c < 'a' && c > 'z');

        public List<string> VT { get; set; } = new List<string>("=> , . ".Split(" ", StringSplitOptions.RemoveEmptyEntries));
        public List<string> VN { get; set; } = new List<string>("K Q L P".Split(" ", StringSplitOptions.RemoveEmptyEntries));
        public string S { get; set; } = "S";
        public string E { get; set; } = ".";

        public List<string> Symbols { get; set; }

        public SafeDictionary<string, SafeDictionary<string, Action>> Table { get; set; } =
            new SafeDictionary<string, SafeDictionary<string, Action>>(
                new Dictionary<string, SafeDictionary<string, Action>>(
                    new Dictionary<string, SafeDictionary<string, Action>>()));
    }
}