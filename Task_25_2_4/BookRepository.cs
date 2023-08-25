using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_25_2_4
{
    internal class BookRepository
    {
        AppContext db;

        public BookRepository(AppContext appContext)
        {
            db = appContext;
        }

        /// <summary>
        /// Получение всех книг
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAll() => db.Books.ToList();

        /// <summary>
        /// Получение книги
        /// </summary>
        /// <param name="id">ИД книги</param>
        /// <returns>Объект книги</returns>
        public Book GetBook(int id) => db.Books.Where(book => book.Id == id).FirstOrDefault();

        public Book GetBook(string name) => db.Books.Where(book => book.Name == name).FirstOrDefault();

        /// <summary>
        /// Удаление книги
        /// </summary>
        /// <param name="id">Имя книги</param>
        /// <exception cref="Exception"></exception>
        public void DeleteBook(int id)
        {
            var bookToDelete = db.Books.Where(b => b.Id == id).FirstOrDefault();
            if (bookToDelete != null)
            {
                db.Books.Remove(bookToDelete);
                db.SaveChanges();
            }
            else
                throw new Exception("Не найден ИД книги" + id + " Информация не удалена.");
        }

        /// <summary>
        /// Обновление книги
        /// </summary>
        /// <param name="Id">Ид книги</param>
        /// <param name="newName">Новое имя</param>
        /// <param name="newReleaseDate">Новая дата выпуска</param>
        /// <param name="newAuthor">Новый автор</param>
        /// <param name="newGenre">Новый жанр</param>
        /// <exception cref="Exception"></exception>
        public void UpdateBook(int id, string newName, DateTime newReleaseDate, string newAuthor, string newGenre)
        {
            Book book = db.Books.Where(b => b.Id == id).FirstOrDefault();

            if (book != null)
            {
                book.Name = newName;
                book.ReleaseDate = newReleaseDate;
                db.SaveChanges();
            }
            else
                throw new Exception("Не найден ИД книги" + id + " Информация не обновлена.");
        }

        /// <summary>
        /// Создание книги
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="releaseDate">Дата выпуска</param>
        /// <param name="author">Автор</param>
        /// <param name="genre">Жанр</param>
        public void AddBook(string name, DateTime releaseDate, string author, string genre)
        {
            Book book = new Book()
            {
                Name = name,
                ReleaseDate = releaseDate,
                Author = author,
                Genre = genre
            };

            if (!db.Books.Contains(book))
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
            else
                throw new Exception("Такая книга уже есть");
               
        }

        /// <summary>
        /// Обновление даты выпука книги
        /// </summary>
        /// <param name="id">Ид книги</param>
        /// <param name="newReleaseDate">Новая дата выпуска</param>
        public void UpdateReleaseDate(int id, DateTime newReleaseDate)
        {
            Book book = db.Books.Where(b => b.Id == id).FirstOrDefault();

            if (book != null)
                book.ReleaseDate = newReleaseDate;

            db.SaveChanges();
        }

        /// <summary>
        /// Получать список книг определенного жанра и вышедших между определенными годами
        /// </summary>
        /// <param name="genre">Жанр</param>
        /// <param name="period"></param>
        /// <returns>Список книг</returns>
        public List<Book> GetListByGenreAndPeriod(string genre, DateTime dateFrom, DateTime dateTo)
        {
            return db.Books.Where(b => b.Genre == genre && (b.ReleaseDate >=dateFrom && b.ReleaseDate<=dateTo)).AsNoTracking().ToList();
        }

        /// <summary>
        /// Получать количество книг определенного автора в библиотеке.
        /// </summary>
        /// <param name="author">Автор</param>
        /// <returns></returns>
        public int GetBooksCountByAuthor(string author) => db.Books.Where(b=>b.Author == author).Count();

        /// <summary>
        /// Получать количество книг определенного жанра в библиотеке.
        /// </summary>
        /// <param name="genre">Жанр</param>
        /// <returns></returns>
        public int GetBooksCountByGenre(string genre) => db.Books.Where(b=>b.Genre == genre).Count();

        /// <summary>
        /// Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке
        /// </summary>
        /// <param name="author">Автор</param>
        /// <param name="name">Название</param>
        /// <returns></returns>
        public bool HasBook(string author, string name) => db.Books.Where(b=>b.Author ==author && b.Name ==name).AsNoTracking().Any();


        /// <summary>
        /// Получение последней вышедшей книги
        /// </summary>
        /// <returns></returns>
        public Book GetLastReleased() => db.Books.OrderByDescending(b => b.ReleaseDate).FirstOrDefault();

        /// <summary>
        /// Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        /// </summary>
        /// <returns>Cписок всех книг, отсортированный в алфавитном порядке по названию</returns>
        public List<Book> GetAllByNameOrder() => db.Books.OrderBy(b => b.Name).AsNoTracking().ToList();

        /// <summary>
        /// Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        /// </summary>
        /// <returns>Cписок всех книг, отсортированный в порядке убывания года их выхода.</returns>
        public List<Book> GetAllByReleaseDateOrder() => db.Books.OrderByDescending(b => b.ReleaseDate).AsNoTracking().ToList();

    }
}
