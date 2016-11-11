using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace problem018
{
	class Program
	{
		private static readonly List<List<int>> nss = new List<List<int>>
		{
			new List<int> { 75 },
			new List<int> { 95, 64 },
			new List<int> { 17, 47, 82 },
			new List<int> { 18, 35, 87, 10 },
			new List<int> { 20, 04, 82, 47, 65 },
			new List<int> { 19, 01, 23, 75, 03, 34 },
			new List<int> { 88, 02, 77, 73, 07, 63, 67 },
			new List<int> { 99, 65, 04, 28, 06, 16, 70, 92 },
			new List<int> { 41, 41, 26, 56, 83, 40, 80, 70, 33 },
			new List<int> { 41, 48, 72, 33, 47, 32, 37, 16, 94, 29 },
			new List<int> { 53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14 },
			new List<int> { 70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57 },
			new List<int> { 91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48 },
			new List<int> { 63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31 },
			new List<int> { 04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23 }
		};

		static void Print<T>(List<T> xs)
		{
			for (var i = 0; i < xs.Count(); ++i)
			{
				Console.Write("{0}", xs[i]);
				if (i < xs.Count() - 1)
					Console.Write(", ");
			}
			Console.WriteLine("");
		}

		/// <summary>
		/// リストの先頭を返す(Haskell標準)
		/// </summary>
		static T Head<T>(IEnumerable<T> xs)
		{
			return xs.FirstOrDefault();
		}

		/// <summary>
		/// リストの先頭以外を返す(Haskell標準)
		/// </summary>
		static IEnumerable<T> Tail<T>(IEnumerable<T> xs)
		{
			return xs.Skip(1);
		}

		/// <summary>
		/// 指定された関数で二つのリストを合成する(Haskell標準)
		/// </summary>
		static List<U> ZipWith<T, U>(Func<T, T, U> f, List<T> xs, List<T> ys)
		{
			var rs = new List<U>();
			int count = Math.Min(xs.Count, ys.Count);
			for (var i = 0; i < count; ++i)
				rs.Add(f(xs[i], ys[i]));
			Console.Write("ZipWith xs = ");
			Print(xs);
			Console.Write("ZipWith ys = ");
			Print(ys);
			Console.Write("ZipWith rs = ");
			Print(rs);
			return rs;
		}

		/// <summary>
		/// 指定された関数でリストを右側から畳み込む(Haskell標準)
		/// </summary>
		static T Foldr1<T>(Func<T, T, T> f, List<T> xs)
		{
			Print(xs);
			if (xs.Count <= 0)
				return default(T);
			T r = xs[xs.Count - 1];
			for (var i = xs.Count - 2; i >= 0; --i)
				r = f(r, xs[i]);
			return r;
		}

		static List<int> SelectMax(List<int> ns)
		{
			Console.WriteLine("SelectMax");
			return ZipWith(Math.Max, ns, Tail(ns).ToList());
		}

		static List<int> PlusMax(List<int> ns1, List<int> ns2)
		{
			Console.WriteLine("PlusMax");
			return ZipWith((x, y) => x + y, ns1, SelectMax(ns2));
		}

		static int Problem018()
		{
			return	Head(Foldr1(PlusMax, nss));
		}

		static void Main(string[] args)
		{
			Print(ZipWith(Math.Max, new List<int> {1, 2, 3}, new List<int>{2, 3, 4}));
			Print(ZipWith(Math.Max, new List<int> { 1, 2, 3 }, new List<int> { 2, 3 }));
			Print(ZipWith(Math.Max, new List<int> { 1, 2 }, new List<int> { 2, 3, 4 }));
			Print(ZipWith(Math.Max, new List<int> {  }, new List<int> { 2, 3, 4 }));
			Print(ZipWith(Math.Max, new List<int> { 1, 2, 3 }, new List<int> {  }));
			Print(ZipWith((x, y) => x + y, new List<int> { 1, 2, 3 }, SelectMax(new List<int> { 2, 3, 4 })));
			Console.WriteLine("answer = {0}", Problem018());
			Console.ReadKey();
		}
	}
}
