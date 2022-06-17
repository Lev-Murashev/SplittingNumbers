using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splitting
{
	class Splitting
	{
		public Split split { get; private set; }//Оба поля имеют публичные геттеры, и закрытые сеттеры так как взаимодействия со стороны могут легко нарушить работу класса 

		public Splitting(int n)// Конструктор класса принимает аргументом параметр n - число, для которого будут генерироваться разбиения
		{
			split = new Split(n);//Инициализируется объект split
		}
		public void GetNext()
		{
			int i, j, sc;

			i = split.Lenght-1;//Предпоследний элемент разбиения.
			sc = split.Now[i + 1] - 1;
			split.Now[i + 1] = 0; //*В sc накапливаем сумму, это число представляется затем минимально возможными элементами.


			while(i > 1 && split.Now[i] == split.Now[i - 1])//Поиск скачка
			{
				sc += split.Now[i];
				split.Now[i] = 0;
				i--;
			}
			
			split.Now[i]++;//Увеличиваем найденный элемент на единицу
			split.Lenght = i + sc;
			for (j = 1; j <= sc; j++)//Изменяем длину разбиения.
			{
				split.Now[j + i] = 1;//Записываем минимально возможные элементы, т.е.единицы.
			}
		}

	}
}
