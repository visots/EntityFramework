namespace Task_25_2_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new AppContext();

            UserRepository userRepository = new UserRepository(db);
            BookRepository bookRepository = new BookRepository(db);

            //userRepository.AddUser("Вася", "vasya@mail.ru");
            //userRepository.AddUser("Петя", "petya@mail.ru");
            //userRepository.AddUser("Миша", "misha@mail.ru");
            //userRepository.AddUser("Дима", "dima@mail.ru");

            //bookRepository.AddBook("Язык Ада", "1987", "Н.Джехани", "Пособие");
            //bookRepository.AddBook("CLR via C#", "2020", "Джефри Рихтер", "Пособие");
            //bookRepository.AddBook("Паттерны проектирования", "2017", "Эрик Фримен", "Пособие");
            //bookRepository.AddBook("Язык Ада", "1987", "Н.Джехани", "Пособие");
            //bookRepository.AddBook("1984", "1948", "Джордж Оруэл", "Роман");
            //bookRepository.AddBook("Мы", "1920", "Евгений Замятин", "Роман");
            //bookRepository.AddBook("Грокаем лгоритмы", "2021", "Адитья Бхаргва", "Пособие");
            //bookRepository.AddBook("Аргессия, или так называемое зло", "1983", "Конрад Лоренц", "Антропология");
            //bookRepository.AddBook("Человек находит друга", "1983", "Конрад Лоренц", "Документальная литература");

            Console.WriteLine("\nКоличество книг определенного автора в библиотеке");
            Console.WriteLine( bookRepository.GetBooksCountByAuthor("Конрад Лоренц"));

            Console.WriteLine("\nКоличество книг определенного жанра в библиотеке");
            Console.WriteLine(bookRepository.GetBooksCountByGenre("Пособие"));

            Console.WriteLine("\nБулевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке");
            Console.WriteLine(bookRepository.HasBook("Джордж Оруэл","1984"));

            Console.WriteLine("\nCписок всех книг, отсортированного в алфавитном порядке по названию.");
            foreach (var b in bookRepository.GetAllByNameOrder())
                Console.WriteLine(b.Name);

            Console.WriteLine("\nСписок всех книг, отсортированного в порядке убывания года их выхода.");
            foreach (var b in bookRepository.GetAllByReleaseDateOrder())
                Console.WriteLine(b.Name+ " "+ b.ReleaseDate);
        }
    }
}