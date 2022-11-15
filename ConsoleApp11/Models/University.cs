using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;

namespace ConsoleApp11.Models
{
    public class University
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public Guid? AddressId { get; set; }

        public static IEnumerable<University> Generate(int n, Guid[] addressIds)
        {
            var f = new Faker<University>();

            f.RuleFor(x => x.Name, x => x.Company.CompanyName());
            f.RuleFor(x => x.EstablishmentDate, x => x.Date.Past());
            f.RuleFor(x => x.Id, x => x.Random.Guid());
            f.RuleFor(x => x.AddressId, x => addressIds[x.Random.Int(0, addressIds.Length - 1)]);

            return f.Generate(n);
        }
    }
}