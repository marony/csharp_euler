using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuleLib
{
	class PrimeNumber
	{
		//private static ArrayList memoPrime = new ArrayList(2);
		//// 数値が素数かどうかを返す(メモ化対応)
		//public static bool IsPrime(int n)
		//{
		//	// 2未満に素数は存在しない
		//	if (n < 2)
		//		return false;
		//	if (n == 2)
		//		return true;
		//	// メモ化されていればそれを返す
		//	if (n < memoPrime.Count && memoPrime[n] != null)
		//		return (bool)memoPrime[n];
		//// 自分のルート以下で割れる数値がなければ素数
		//// 自分のルートより大きい数値は割れるわけない
		//var r = (int)Math.Sqrt((double) n);
		//for (int i = 3; i <= r; i += 2)
		//	{
		//		if ((n % i) == 0)
		//		{
		//			// 割り切れたので素数ではない
		//			// メモ化処理
		//			if (n >= memoPrime.Count)
		//			{
		//				int count = memoPrime.Count;
		//				for (int j = 0; j <= n - count + 1; ++j)
		//					memoPrime.Add(null);
		//			}
		//			memoPrime[n] = false;
		//			return false;
		//		}
		//	}
		//	// 割り切れなかったので素数
		//	// メモ化処理
		//	if (n >= memoPrime.Count)
		//	{
		//		int count = memoPrime.Count;
		//		for (int j = 0; j <= n - count + 1; ++j)
		//			memoPrime.Add(null);
		//	}
		//	memoPrime[n] = true;
		//	return true;
		//}
		//private static ArrayList memoNthPrime = new ArrayList(2);
		//// i番目の素数を返す(メモ化対応)
		//public static int NthPrime(int i)
		//{
		//	// メモ化されていればそれを返す
		//	if (i < memoNthPrime.Count && memoNthPrime[i] != null)
		//		return (int)memoNthPrime[i];
		//	int c = 0;
		//	int n = 2;
		//	if (memoNthPrime.Count > 0 && memoNthPrime[memoNthPrime.Count - 1] != null)
		//	{
		//		c = memoNthPrime.Count - 1;
		//		n = (int)memoNthPrime[memoNthPrime.Count - 1];
		//	}
		//	while (c <= i)
		//	{
		//		if (IsPrime(n))
		//			++c;
		//		++n;
		//	}
		//	--n;
		//	// メモ化処理
		//	if (i >= memoNthPrime.Count)
		//	{
		//		int count = memoNthPrime.Count;
		//		for (int j = 0; j <= i - count + 1; ++j)
		//			memoNthPrime.Add(null);
		//	}
		//	memoNthPrime[i] = n;
		//	return n;
		//}
	}
}
