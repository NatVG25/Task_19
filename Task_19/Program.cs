using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_19
{
   
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listComputer = new List<Computer>() //список, параметризированный типом компьютер, в нем 7 записей с различными характеристиками компьютеров
            {
                new Computer() { Id = "0000-AS01", Name = "Asus", Processor = "Intel Core i5", Frequency = 3, Memory = 256, HardDisk = 1000, CardMemory = 512, Cost = 60, Sum=2 },
                new Computer() { Id = "0000-AC05", Name = "Acer", Processor = "Intel Core i7", Frequency = 6, Memory = 512, HardDisk = 1500, CardMemory = 1000, Cost = 110, Sum=4 },
                new Computer() { Id = "0000-T004", Name = "Toshiba", Processor ="AMD Ryzen", Frequency = 2, Memory = 256, HardDisk = 512, CardMemory = 512, Cost = 80, Sum=12 },
                new Computer() { Id = "0000-S010", Name = "Sony", Processor = "Intel Core i9", Frequency = 4, Memory = 1000, HardDisk = 2000, CardMemory = 2000, Cost = 140, Sum=5 },
                new Computer() { Id = "0000-AS05", Name = "Asus", Processor = "Intel Core i5", Frequency = 5, Memory = 512, HardDisk =512, CardMemory = 1500, Cost = 70, Sum=32 },
                new Computer() { Id = "0000-AC03", Name = "Acer", Processor = "AMD Ryzen", Frequency = 3, Memory = 120, HardDisk = 256, CardMemory = 512, Cost = 50, Sum=14 },
                new Computer() { Id = "0000-S002", Name = "Sony", Processor = "Intel Core i7", Frequency = 2, Memory = 1000, HardDisk = 1000, CardMemory = 1000, Cost = 96, Sum=23 },

            };
            //определим все компьютеры с указанным процессором

            Console.WriteLine("Введите название процессора:");
            string name = Console.ReadLine();
            List<Computer> computers1 = listComputer //Переменная "c" принимает по очереди все значения из списка
                                               .Where(c => c.Processor == name) //если условие выполняется, то значение c возвращается
                                               .ToList(); //И добавляется в список
            Print(computers1);

            //определим все компьютеры с указанным объемом оперативной памяти
            Console.WriteLine("Введите объем оперативной памяти:");
            int frequency = Convert.ToInt32(Console.ReadLine());

            List<Computer> computers2 = (from c in listComputer  //ищем компьютер с объемом озу не меньше frequency
                                         where c.Frequency >= frequency
                                         select c).ToList();
            Print(computers2);

            //сортируем по цене
            Console.WriteLine("Сортировка по цене:");

            List<Computer> computers3 = (from c in listComputer
                                         orderby c.Cost ascending
                                         select c).ToList();

            Print(computers3);

            // группирование списка по названию процессора
            Console.WriteLine("Группировка по процессору:");
            IEnumerable<IGrouping<string, Computer>> computers4 = listComputer  //создаем коллекцию computers4 с группированием
                                         .GroupBy(c => c.Processor);
            foreach (IGrouping<string, Computer> gr in computers4) //перебираем коллекцию computers4 
            {
                Console.WriteLine(gr.Key); //выводим общий ключ (название процессора)
                foreach (Computer c in gr) //перебираем элементы внутри группы для вывода
                {
                    Console.WriteLine($"{c.Id}, {c.Name}, {c.Processor}, {c.Frequency}, {c.Memory}, {c.HardDisk}, {c.CardMemory}, {c.Cost}, {c.Sum}");
                }
            }
            Console.WriteLine();

            //находим самый дорогой компьютер в списке
            Console.WriteLine("Самый дорогой компьютер:");
            Computer computer5 = listComputer
                                .OrderByDescending(c => c.Cost)
                                .FirstOrDefault();
           
            Console.WriteLine($"{computer5.Id}, {computer5.Name}, {computer5.Processor}, {computer5.Frequency}, {computer5.Memory}, {computer5.HardDisk}, {computer5.CardMemory}, {computer5.Cost}, {computer5.Sum}");


            //находим самый дешевый компьютер в списке
            Console.WriteLine("Самый бюджетный компьютер:");
            Computer computer6 = listComputer
                               .OrderByDescending(c => c.Cost)
                               .LastOrDefault();
            
            Console.WriteLine($"{computer6.Id}, {computer6.Name}, {computer6.Processor}, {computer6.Frequency}, {computer6.Memory}, {computer6.HardDisk}, {computer6.CardMemory}, {computer6.Cost}, {computer6.Sum}");
            Console.WriteLine();

            //определяем есть ли хотя бы один компьютер в количестве 30шт
            Console.WriteLine("Есть ли любая модель в наличии не менее 30шт:");
            Console.WriteLine(listComputer.Any(c => c.Sum > 30));  //с помощью функции Any определяем есть ли элемент отвечающий заданным условиям и выводим булевое значение

            Console.ReadKey();


        }
        static void Print(List<Computer> computers) //метод выводящий нужный список на консоль
        {
            foreach (Computer c in computers)
            {
                Console.WriteLine($"{c.Id}, {c.Name}, {c.Processor}, {c.Frequency}, {c.Memory}, {c.HardDisk}, {c.CardMemory}, {c.Cost}, {c.Sum}");
            }
            Console.WriteLine();
        }
    }
}
