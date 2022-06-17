using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splitting
{
	class SplitNumber
	{
		decimal maxvalue;
		int N;// Число для которого будут производиться вычисления 
		SplitCounter sp;//Поле типа SplitCounter для получения таблицы data
		public SplitNumber(int n)// в конструкторе задается число и проводится предвычисление массива data через инициализацию объекта sp класса SplitCounter
		{
			N = n;
			sp = new SplitCounter(n);
			maxvalue = SplitCounterStatic.GetCount(N);// maxvalue инициализирутся количеством разбиений числа N, для проверки аргумента метода getSplitByNum
		}
		public Split getSplitByNum(int Num)//Метод для получения разбиения по номеру Num
		{
			if (Num < 0 || Num > maxvalue)
				return new Split(N); //Если аргумент меньше нуля или больше возможного количества разбиений прекращается работа метода.
			Num--;//декремент Num, так как Now уже будет инициализирован первым разбиением
			Split split = new Split(N); //Инициализируется массив хранящий разбиение, по той же схеме как и в классе Splitting, т.е. нулевой элемент хранит количество задействованных элементов массива, остальное единицы как первое разбиение любого числа
			
			if (Num == 0)//В случае если параметр Num был единицой, то есть требуется получить первое разбиение, сразу после инциализации возвращается массив Now, а метод прекращает выполнение
				return split;
			int i = 1, j, sc = N;//Инициализируются переменные и выполняется вышеописанный алгоритм
			while (sc > 0 || sc < 0)
			{
				j = 1;
				while (Num >= sp.data[sc,j])
				{
					Num -= sp.data[sc, j];
					j++;
				}
				split.Now[i] = j; 
				sc -= j; 
				i++;
			}
			split.Lenght = i - 1;
			return split; //Метод возвращает полученное разбиение
		}
		public int getNumOfSplit(Split split)
		{
			int i, jk = N /*Номер строки в массиве data*/,  p, sc = 1;//Формируем номер разбиения.

			for (i = 1; i <= split.Lenght; i++)//Просматривается разбиение
			{
				for (p = 0; p < split.Now[i]; p++)
				{
					sc += sp.data[jk, p];//Значение числа из разбиения определяет число столбцов в массиве data
				}
				jk -=  split.Now[i];//Изменяется номер строки
			}
			return sc;
		}
	}
}
