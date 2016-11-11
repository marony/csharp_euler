using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem001
{
	class Program
	{
		static void Main(string[] args)
		{
			// 普通にループを回した場合
			var total1 = 0;
			for (var i = 1; i < 1000; ++i)
			{
				if ((i % 3) == 0 || (i % 5) == 0)
					total1 += i;
			}
			Console.WriteLine(total1);
			// LINQを使用した場合
			var total2 = (from n in Enumerable.Range(1, 999)
						 where (n % 3) == 0 || (n % 5) == 0
				select n).Sum();
			Console.WriteLine(total2);
			Console.WriteLine("[ENTER]");
			Console.ReadLine();
		}
	}
}
