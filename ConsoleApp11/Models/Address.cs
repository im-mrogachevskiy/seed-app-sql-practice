using System;
using System.Collections.Generic;
using Bogus;

namespace ConsoleApp11.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        
        public static IEnumerable<Address> Generate(int n)
        {
            var f = new Faker<Address>();

            f.RuleFor(x => x.Street, x => x.Address.StreetName());
            f.RuleFor(x => x.City, x => x.Address.City());
            f.RuleFor(x => x.Country, x => x.Address.Country());
            f.RuleFor(x => x.Id, x => x.Random.Guid());

            return f.Generate(n);
        }
    }
}