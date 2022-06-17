using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splitting
{
	class Split
	{
		public int N { get; private set; }
		public int[] Now { get; set; }
		public int Lenght
		{
			get 
			{
				return Now[0];
			}
			set
			{
				Now[0] = value;
			}
		}
		public Split(int N)
		{
			this.N = N;
			Now = new int[N + 1];
			for (int i = 0; i < Now.Length; i++)
			{
				Now[i] = 1;
			}
			Now[0] = N;
		}
		public override string ToString()//Поскольку в С# все классы неявно являются наследниками базового класса Object, для удобства можно пеопределить метод ToString, теперь метод будет возвращать строку содержащюю текущее разбиение
		{
			string rez = "";
			for (int i = 0; i < Now[0]; i++)// от нуля до now[0], то есть ровно столько раз сколько элементов массива задействованно в текущем разбиении делать:
			{
				rez += $"{Now[i + 1] }";//с помощью конкатенации записываем в строку следующий элемент текущего разбиения 
			}
			return rez;
		}
	}
}
