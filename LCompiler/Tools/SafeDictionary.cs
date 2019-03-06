using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCompiler.Tools
{
    public class SafeDictionary<T, V>
    {
        private readonly Dictionary<T, V> _dic;

        public SafeDictionary(Dictionary<T, V> dic)
        {
            _dic = dic;
        }

        public V this[T key] => _dic != null && _dic.ContainsKey(key) ? _dic[key] : default(V);
        public IEnumerable<V> this[IEnumerable<T> key] => key.Select(k => this[(T)k]);

        public override string ToString()
        {
            return string.Join("\n", _dic?.Select(t => string.Join(":", t.Key, t.Value)));
        }
    }
}
