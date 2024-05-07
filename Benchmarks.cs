using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;

namespace LoopLists
{
    [MemoryDiagnoser]
    public class Benchmarks
    {
        private readonly List<string> _list = [];
        private readonly int _size = 1_000_000;

        [GlobalSetup]
        public void Setup()
        {
            //Seed the random to have the same values for all benchmarks
            var random = new Random(420);
            for (var i = 0; i < _size; i++)
            {
                _list.Add(random.Next().ToString());
            }
        }

        [Benchmark]
        public string For()
        {
            var result = string.Empty;
            var size = _list.Count;
            for (var i = 0; i < size; i++)
            {
                result = _list[i];
            }
            return result;
        }

        [Benchmark]
        public string ForEach()
        {
            var result = string.Empty;
            foreach (var item in _list)
            {
                result = item;
            }
            return result;
        }

        [Benchmark]
        public string ForEachBis()
        {
            var result = string.Empty;
            _list.ForEach(i => result = i);
            return result;
        }

        [Benchmark]
        public string While()
        {
            var i = 0;
            var result = string.Empty;
            var size = _list.Count;
            while (i < size)
            {
                result = _list[i];
                i++;
            }
            return result;
        }

        [Benchmark]
        public string DoWhile()
        {
            var i = 0;
            var result = string.Empty;
            var size = _list.Count;
            do
            {
                result = _list[i];
                i++;
            } while (i < size);
            return result;
        }

        //Don't use this one on a code i can read in my life
        [Benchmark]
        public string GoTo()
        {
            var i = 0;
            var result = string.Empty;
            var size = _list.Count;
            Start:
            if (i < size)
            {
                result = _list[i];
                i++;
                goto Start;
            }
            return result;
        }

        [Benchmark]
        public string Span()
        {
            var result = string.Empty;
            var size = _list.Count;
            Span<string> span = CollectionsMarshal.AsSpan(_list);
            for (var i = 0; i < size; i++)
            {
                result = span[i];
            }
            return result;
        }
    }
}
