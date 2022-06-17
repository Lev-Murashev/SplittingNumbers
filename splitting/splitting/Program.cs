using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace splitting
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Введите число");
			int a = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Выберите действие для целого числа: ");
			Console.WriteLine("1. Посчитать количество разбиений");
			Console.WriteLine("2. Сгенерировать все разбиения");
			Console.WriteLine("3. Получить разбиение по номеру");
			Console.WriteLine("4. Получить номер разбиения");
			Console.WriteLine("0. Выход");
			int b = Convert.ToInt32(Console.ReadLine());
			switch (b)
			{
				case 1:
					Console.WriteLine($"Количество разбиений для числа {a} = {SplitCounterStatic.GetCount(a)}");
					break;
				case 2:
					{
						Splitting sp = new Splitting(a);
						for (int i = 0; i < SplitCounterStatic.GetCount(a); i++)
						{
							Console.WriteLine(sp.split.ToString());
							sp.GetNext();
						}

						break;
					}
				case 3:
					{
						Console.WriteLine($"Введите номер разбиения до {SplitCounterStatic.GetCount(a)}");
						int c = Convert.ToInt32(Console.ReadLine());
						var sn = new SplitNumber(a);
						Console.WriteLine((sn.getSplitByNum(c)).ToString());


						break;
					}
				case 4:
					{
						Console.WriteLine($"Введите разбиение числа {a}");
						var c = Console.ReadLine();
						Split split = new Split(a);
						
						for (int i = 1; i <= c.Length; i++)
						{
							split.Now[i] = c[i-1] - 48;
						}
						split.Lenght = c.Length;
						
						var sn = new SplitNumber(a);
						Console.WriteLine(sn.getNumOfSplit(split));

						break;
					}
				case 0:
					return;
					break;
				default:
					break;
			}
		}
	}
}
