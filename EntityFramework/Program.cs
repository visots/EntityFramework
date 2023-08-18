namespace EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                var user1 = new User { Name = "Arthur", Role = "Admin" , Email = "1@mail.ru" };
                var user2 = new User { Name = "Klim", Role = "User" , Email = "2@mail.ru" };
            
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
            }
        }
    }
}