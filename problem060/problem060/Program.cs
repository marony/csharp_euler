using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using EuleLib;

/*

Problem 60

The primes 3, 7, 109, and 673, are quite remarkable. By taking any two primes and concatenating
them in any order the result will always be prime. For example, taking 7 and 109, both 7109 and 1097
are prime. The sum of these four primes, 792, represents the lowest sum for a set of four primes with this property.
Find the lowest sum for a set of five primes for which any two primes concatenate to produce another prime.

*/

/*

4つの場合は3, 7, 109, 673

・2と5はあり得ない
・素数を小さな順で回して、2つで成り立つ、3つで成り立つ…で、5つの素数で成り立つのが結局最小の答え

13, 5197, 5701, 6733, 8389,  = 26033
00:01:24.0889915
7, 1237, 2341, 12409, 18433,  = 34427
00:26:11.9605312
467, 941, 2099, 19793, 25253,  = 48553
01:08:16.8459710
lastPrime = 26029, minTotal = 26033
01:15:19.9647138
[END]
*/


namespace problem060
{
	class Program
	{
		// 求める素数の数
		const int numberOfPrime = 5;

		// 2つの素数をくっつけても素数か返す
		static bool CheckPrime(long x, long y)
		{
			var xs = x.ToString();
			var ys = y.ToString();
			return (IsPrime(long.Parse(xs + ys)) &&
					IsPrime(long.Parse(ys + xs)));
		}

		// 数値が素数かどうかを返す
		public static bool IsPrime(long n)
		{
			// 2未満に素数は存在しない
			if (n < 2)
				return false;
			// 2は素数
			if (n == 2)
				return true;
			if ((n % 2) == 0)
				return false;
			// 自分のルート以下で割れる数値がなければ素数
			// 自分のルートより大きい数値は割れるわけない
			for (int i = 3; i <= n / i; i += 2)
			{
				if ((n % i) == 0)
				{
					// 割り切れたので素数ではない
					return false;
				}
			}
			// 割り切れなかったので素数
			return true;
		}

		static void Main(string[] args)
		{
			Stopwatch	sw = new Stopwatch();
			sw.Start();

			var minTotal = long.MaxValue;
			var lastPrime = 0L;
			var primeList = new List<List<long>>();
			// 素数を最初から探す
			for (long n = 3; n < minTotal; n += 2)
			{
				// 素数判定
				if (n == 2 || n == 5 || !IsPrime(n))
					continue;
				//Console.WriteLine("n = {0}", n);
				var savePrimeList = new List<List<long>>();
				foreach (var list in primeList)
				{
					if (list.Count >= numberOfPrime)
						continue;
					//Console.WriteLine("count = {0}", list.Count);
					// くっつけても素数か
					if (list.All(x => CheckPrime(x, n)))
					{
						savePrimeList.Add(new List<long>(list));
						list.Add(n);
						if (list.Count >= numberOfPrime)
						{
							// 答えが出た
							var total = list.Sum();
							if (minTotal > total)
								minTotal = total;
							foreach (var x in list)
								Console.Write("{0}, ", x);
							Console.WriteLine(" = {0}", total);
							Console.WriteLine(sw.Elapsed.ToString());
						}
					}
				}
				// 素数リストに追加する
				primeList.Add(new List<long>() { n });
				primeList.AddRange(savePrimeList);
				lastPrime = n;
			}
			Console.WriteLine("lastPrime = {0}, minTotal = {1}", lastPrime, minTotal);
			Console.WriteLine(sw.Elapsed.ToString());
			Console.WriteLine("[END]");
			Console.ReadLine();
			return;
		}
	}
}
