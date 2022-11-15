using System;
using System.Collections.Generic;
using Bogus;

namespace ConsoleApp11.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Guid? AddressId { get; set; }

        public static IEnumerable<Person> Generate(int n, Guid[] addressIds)
        {
            var f = new Faker<Person>();

            f.RuleFor(x => x.Name, x => x.Person.FullName);
            f.RuleFor(x => x.Age, (x => (new DateTime(1, 1, 1) + (DateTime.Now - x.Person.DateOfBirth)).Year - 1));
            f.RuleFor(x => x.Id, x => x.Random.Guid());
            f.RuleFor(x => x.AddressId, x => addressIds[x.Random.Int(0, addressIds.Length - 1)]);

            return f.Generate(n);
        }
    }
}