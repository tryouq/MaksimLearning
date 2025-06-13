using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace CodeWars
{
    class Program
    {
        public class User
        {
            public User(Guid id, string name, decimal salery, List<Project> projects)
            {
                Id = id;
                Name = name;
                Salery = salery;
                Projects = projects;
            }

            public Guid Id { get; set; }
            public string Name { get; set; }
            public decimal Salery { get; set; }
            public List<Project> Projects { get; set; }
        }
        public class Project
        {
            public Project(Guid id, string name, decimal price)
            {
                Id = id;
                Name = name;
                Price = price;
            }

            public Guid Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
        static void Main(string[] args)
        {
            List<User> users = [];
            var zalupa = new Project(Guid.NewGuid(), "Zalupa.com", 2_000_000m);
            var korFentaneel = new Project(Guid.NewGuid(), "KorFentaneel.ru", 4_000_000m);
            var zavod = new Project(Guid.NewGuid(), "Zavod.ru", 10_000_000m);
            users.Add(new User(Guid.NewGuid(), "Maxim", 200_000m,
                [
                    zalupa
                ]));
            users.Add(new User(Guid.NewGuid(), "Gleb", 200_000m,
                [
                    zalupa,
                    korFentaneel
                ]));
            users.Add(new User(Guid.NewGuid(), "Sanya", 40_000m,
                [
                    zavod
                ]));
            var options1 = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            Console.WriteLine(JsonSerializer.Serialize(Task1(users), options1));
            Console.WriteLine(JsonSerializer.Serialize(Task2(users), options1));
            Console.WriteLine(JsonSerializer.Serialize(Task3(users), options1));
            Console.WriteLine(JsonSerializer.Serialize(Task4(users), options1));
        }
        /// <summary>
        ///  Вывести всех пользователей с проектами >= 2
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public static List<string> Task1(List<User> users) 
        {
            return users.Where(user => user.Projects.Count() >= 2).Select(user => user.Name).ToList();
        }
        /// <summary>
        /// Кол-во месяцов оплыта пользователя
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public static List<string> Task2(List<User> users) 
        {
            return users.Select(user => $"Пользователь {user.Name} может работать {user.Projects.Select(project => project.Price).Sum() / user.Salery}").ToList();
        }
        /// <summary>
        /// Вывести все уникальные проекты
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public static List<string> Task3(List<User> users) 
        {
            return users.SelectMany(user => user.Projects).DistinctBy(project => project.Id).Select(project => project.Name).ToList();
        }
        /// <summary>
        /// Кол-во месяцев оплаты пользователей в зависимости от кол-ва проектов
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public static List<string> Task4(List<User> users)
        {
            return users
                .Select(user => $"Пользователь {user.Name} может работать " +
                    $"{user.Projects.Select(project => 
                        project.Price 
                        / 
                        users.Where(item => item.Projects.Any(x => x.Id == project.Id)).Sum(x => x.Salery))
                            .Sum()}"
                    )
                .ToList();
        }
    }
}
