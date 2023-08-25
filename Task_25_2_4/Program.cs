namespace Task_25_2_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new AppContext();

            UserRepository userRepository = new UserRepository(db);
            BookRepository bookRepository = new BookRepository(db);

            #region Заполнение таблиц
            //userRepository.AddUser("Вася", "vasya@mail.ru");
            //userRepository.AddUser("Петя", "petya@mail.ru");
            //userRepository.AddUser("Миша", "misha@mail.ru");
            //userRepository.AddUser("Дима", "dima@mail.ru");

            //bookRepository.AddBook("Язык Ада", new DateTime(1987, 1, 1), "Н.Джехани", "Пособие");
            //bookRepository.AddBook("CLR via C#", new DateTime(2020, 1, 1), "Джефри Рихтер", "Пособие");
            //bookRepository.AddBook("Паттерны проектирования", new DateTime(2017, 1, 1), "Эрик Фримен", "Пособие");
            //bookRepository.AddBook("1984", new DateTime(1948, 1, 1), "Джордж Оруэл", "Роман");
            //bookRepository.AddBook("Мы", new DateTime(1920, 1, 1), "Евгений Замятин", "Роман");
            //bookRepository.AddBook("Грокаем алгоритмы", new DateTime(2021, 1, 1), "Адитья Бхаргва", "Пособие");
            //bookRepository.AddBook("Аргессия, или так называемое зло", new DateTime(1983, 1, 1), "Конрад Лоренц", "Антропология");
            //bookRepository.AddBook("Человек находит друга", new DateTime(1983, 1, 1), "Конрад Лоренц", "Документальная литература");
            //bookRepository.AddBook("Язык ассемблера для персонального компьютера Эпл", new DateTime(1984, 1, 1), "У. Морер", "Пособие");

            //userRepository.ReserveBook(user1, book1);
            //userRepository.ReserveBook(user1, book2);
            //userRepository.ReserveBook(user2, book3);
            //userRepository.ReserveBook(user3, book4);
            #endregion

            User user1 = userRepository.GetUser("vasya@mail.ru");
            User user2 = userRepository.GetUser("petya@mail.ru");
            User user3 = userRepository.GetUser("dima@mail.ru");

            Book book1 = bookRepository.GetBook("Язык Ада");
            Book book2 = bookRepository.GetBook("1984");
            Book book3 = bookRepository.GetBook("Мы");
            Book book4 = bookRepository.GetBook("Язык ассемблера для персонального компьютера Эпл");

            Console.WriteLine("Булевый флаг о том, есть ли определенная книга на руках у пользователя");
            Console.WriteLine(userRepository.HasBook(user1, book1));
            Console.WriteLine(userRepository.HasBook(user3, book1));

            Console.WriteLine("Количество книг на руках у пользователя.");
            Console.WriteLine(userRepository.GetBooksCount(user1));
            Console.WriteLine(userRepository.GetBooksCount(user2));

            Console.WriteLine("\nКоличество книг определенного автора в библиотеке");
            Console.WriteLine(bookRepository.GetBooksCountByAuthor("Конрад Лоренц"));

            Console.WriteLine("\nКоличество книг определенного жанра в библиотеке");
            Console.WriteLine(bookRepository.GetBooksCountByGenre("Пособие"));

            Console.WriteLine("\nБулевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке");
            Console.WriteLine(bookRepository.HasBook("Джордж Оруэл", "1984"));

            Console.WriteLine("\nПолучение последней вышедшей книги");
            Console.WriteLine(bookRepository.GetLastReleased().Name);

            Console.WriteLine("\nCписок всех книг, отсортированного в алфавитном порядке по названию.");
            foreach (var b in bookRepository.GetAllByNameOrder())
                Console.WriteLine('\t' + b.Name);

            Console.WriteLine("\nСписок всех книг, отсортированного в порядке убывания года их выхода.");
            foreach (var b in bookRepository.GetAllByReleaseDateOrder())
                Console.WriteLine('\t' + b.Name + " " + b.ReleaseDate);

            Console.WriteLine("Получить список книг определенного жанра и вышедших между определенными годами");
            foreach (var b in bookRepository.GetListByGenreAndPeriod("Пособие", new DateTime(2000, 1, 1), new DateTime(2022, 1, 1)))
                Console.WriteLine('\t' + b.Name + " " + b.ReleaseDate);
        }
    }
}