using Bogus;
using FakeData.Context;
using FakeData.Entity;

namespace FakeData.Services
{
    public class FakeDataGenerate
    {
        private readonly DataContext _context;

        public FakeDataGenerate(DataContext context)
        {
            _context = context;
        }

        public void GenerateAndSaveData()
        {
            var userFaker = new Faker<User>()
                .RuleFor(u => u.Name, f => f.Name.FullName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.DateOfBirth, f => f.Date.Past(30));

            var users = userFaker.GenerateLazy(1000000); 

            Console.WriteLine("Данные сохраняются в SQL Server...");

            _context.Users.AddRange(users);
            _context.SaveChanges();

            Console.WriteLine("Процесс сохранения данных завершен.");
        }

    }
}
