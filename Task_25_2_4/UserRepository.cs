using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_25_2_4
{
    internal class UserRepository
    {
        AppContext db;
        public UserRepository(AppContext appContext)
        {
            db = appContext;
        }

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll() => db.Users.ToList();

        /// <summary>
        /// Получение пользователя
        /// </summary>
        /// <param name="id"> Ид пользователя</param>
        /// <returns>Пользовтаель</returns>
        public User GetUser(int id) => db.Users.Where(u => u.Id == id).FirstOrDefault();

        /// <summary>
        /// Получение пользователя по Email
        /// </summary>
        /// <param name="email">Email пользователя</param>
        /// <returns>Пользовтаель</returns>
        public User GetUser(string email) => db.Users.Where(u => u.Email == email).FirstOrDefault();

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="email">Email пользователя</param>
        /// <exception cref="Exception"></exception>
        public void DeleteUser(int id)
        {
            var userToDelete = db.Users.Where(u => u.Id == id).FirstOrDefault();
            if (userToDelete != null)
            {
                db.Users.Remove(userToDelete);
                db.SaveChanges();
            }
            else
                throw new Exception("Не найден ИД пользователя" + id + " Информация не удалена.");

        }

        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <param name="email">Email пользователя</param>
        /// <param name="newName">Новое имя</param>
        /// <param name="newEmail">Новый Email</param>
        /// <exception cref="Exception"></exception>
        public void UpdateUser(string email, string newName, string newEmail)
        {
            User user = db.Users.Where(u => u.Email == email).FirstOrDefault();

            if (user != null)
            {
                user.Name = newName;
                user.Email = newEmail;
                db.SaveChanges();
            }
            else
                throw new Exception("Не найдена пользователь " + email + " Информация не обновлена.");

        }

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="email">Email</param>
        public void AddUser(string name, string email)
        {
            User user = new User()
            {
                Email = email,
                Name = name
            };

            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}
