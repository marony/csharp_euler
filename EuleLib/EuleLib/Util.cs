using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuleLib
{
	class Util
	{
		/// <summary>
		/// 最大公約数を求める
		/// </summary>
		/// <typeparam name="T">型</typeparam>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>最大公約数</returns>
		//public T gcd<T>(T a, T b) where T : System.Number
		public static int gcd(int a, int b)
		{
			if (b == 0)
				return a;
			return gcd(b, a % b);
		}

		/// <summary>
		/// 最小公倍数を求める
		/// </summary>
		/// <typeparam name="T">型</typeparam>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns>最小公倍数</returns>
		//public T lcm<T>(T a, T b)
		public static int lcm(int a, int b)
		{
			return a * b / gcd(a, b);
		}

		/// <summary>
		/// 順列(nPr)を全通り書き出す
		/// </summary>
		/// <typeparam name="T">リストの型</typeparam>
		/// <param name="list">リスト</param>
		/// <param name="r">いくつ取り出すか</param>
		/// <returns>リストからr個取り出した全通りのリスト</returns>
		public static List<List<T>> Permutation<T>(List<T> list, int r)
		{
			// 内部関数
			Action<List<T>, List<T>, List<List<T>>, int> f = null;
			f = (_list, _remain, _result, _r) =>
			{
				if (_r <= 0)
				{
					_result.Add(_list);
					return;
				}
				foreach (var _n in _remain)
				{
					var _list2 = new List<T>(_list);
					_list2.Add(_n);
					var _list3 = new List<T>(_remain);
					_list3.Remove(_n);
					f(_list2, _list3, _result, _r - 1);
				}
			};
			// ロジック始まり
			var result = new List<List<T>>();
			foreach (var n in list)
			{
				var list2 = new List<T>();
				list2.Add(n);
				var list3 = new List<T>(list);
				list3.Remove(n);
				f(list2, list3, result, r - 1);
			}
			return result;
		}

		/// <summary>
		/// 組み合わせ(nCr)を全通り書き出す
		/// </summary>
		/// <typeparam name="T">リストの型</typeparam>
		/// <param name="list">リスト</param>
		/// <param name="r">いくつ取り出すか</param>
		/// <returns>リストからr個取り出した全通りのリスト</returns>
		public static List<List<T>> Combination<T>(List<T> list, int r) where T : IComparable
		{
			Action<List<T>, List<T>, HashSet<List<T>>, int> f = null;
			f = (_list, _remain, _result, _r) =>
			{
				if (_r <= 0)
				{
					var contains = false;
					foreach (var _list2 in _result)
					{
						if (_list.Except(_list2).Count() == 0 &&
							_list2.Except(_list).Count() == 0)
						{
							contains = true;
							break;
						}
					}
					if (!contains)
						_result.Add(_list);
					return;
				}
				foreach (var _n in _remain)
				{
					var _list2 = new List<T>(_list);
					_list2.Add(_n);
					var _list3 = new List<T>(_remain);
					_list3.Remove(_n);
					f(_list2, _list3, _result, _r - 1);
				}
			};
			var result = new HashSet<List<T>>();
			foreach (var n in list)
			{
				var list2 = new List<T>();
				list2.Add(n);
				var list3 = new List<T>(list);
				list3.Remove(n);
				f(list2, list3, result, r - 1);
			}
			return result.ToList();
		}
	}
}
