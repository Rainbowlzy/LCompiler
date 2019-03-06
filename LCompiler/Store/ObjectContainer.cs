using System;
using System.Collections.Generic;
using System.Text;
using LCompiler.Tools;

namespace LCompiler.Store
{
    public class ObjectContainer
    {
        public SafeDictionary<string, Entity> Entities { get; set; } =
            new SafeDictionary<string, Entity>(new Dictionary<string, Entity>());

        public SafeDictionary<string, Property> Properties { get; set; } =
            new SafeDictionary<string, Property>(new Dictionary<string, Property>());
    }

}
