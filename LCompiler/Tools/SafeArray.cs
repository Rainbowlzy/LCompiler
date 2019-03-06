namespace LCompiler.Tools
{
    public class SafeArray<T>
    {
        private readonly T[] _arr;

        public SafeArray(T[] arr)
        {
            _arr = arr;
        }

        public T this[int i] => _arr != null && i < _arr.Length && i >= 0 ? _arr[i] : default(T);
    }
}