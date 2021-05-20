using Newtonsoft.Json; // Подключаем библиотеку для работы с JSON
using System;

namespace JSON_BOOK
{   
    // Класс книга 
    class Book
    {   
        public string Name { get; set; }    // Название книги
        public string Author { get; set; }  // Автор книги
        public string Office { get; set; }  // Издательство
        public int countList { get; set; }  // Колличество страниц

        // Запись данных о книге
        public void SetBook()
        {
            Console.WriteLine("Введите название книги");
            Name = Console.ReadLine();
            Console.WriteLine("Введите автора книги");
            Author = Console.ReadLine();
            Console.WriteLine("Введите издательство книги");
            Office = Console.ReadLine();
            Console.WriteLine("Введите колличество страниц книги");

            // Проверка на ввод целочисленного числа
            while (true)
            {
                string countListString = Console.ReadLine();
                bool numeric = int.TryParse(countListString, out int count);
                if (numeric)
                {
                    countList = count;
                    break;
                }
                else
                {
                    Console.WriteLine("Число не распознанно! Повторите ввод числа");
                }
            }
        }

        // вывод информации о книге
        public void GetInfoBook()
        {
            Console.WriteLine($"Вывод информации в консоль\nНазвание книги | {Name}\nАвтор книги    | {Author}\nИздательство   | {Office}\nЧисло страниц  | {countList}");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {   
            // Создаем экземпляр класса 
            Book book = new Book();
            // Запись данных в экземпляр объекта книга
            book.SetBook();
            // Вывод информации о экземплаяре объекта в формате JSON
            JsonWork(book);
            // Вывод информации о экземпляре обекта книга в консольном режиме
            book.GetInfoBook();

            Console.ReadKey();
        }

        // Метод сериализации и десериализации экземпляра объекта
        static public void JsonWork(object book)
        {
            string json = JsonConvert.SerializeObject(book);
            Console.WriteLine("\nСериализация в строку\n" + json);

            object desBook = JsonConvert.DeserializeObject(json);
            Console.WriteLine("\nДесиреализация в новый объект\n" + desBook + "\n");
        }
    }
}

