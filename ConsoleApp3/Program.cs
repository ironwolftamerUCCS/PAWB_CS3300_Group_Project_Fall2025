using PAWB.Domain.Model;
using PAWB.Domain.Services;
using PAWB.EntityFramework;
using PAWB.EntityFramework.Services;
using System;


namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDataService<User> userService = new GenericDataService<User>(new PAWBDbContextFactory());
            userService.Create(new User { Username = "test" }).Wait();
        }
    }
}
