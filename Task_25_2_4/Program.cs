namespace Task_25_2_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                var user1 = new User { Name = "Arthur",  Email = "1@mail.ru" };
                var user2 = new User { Name = "Klim", Email = "2@mail.ru" };

                var book = new Book { Name = "Язык Ада", ReleaseDate = "1983" };

                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
            }
        }
    }
}