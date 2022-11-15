using System;
using System.Collections.Generic;
using Bogus;

namespace ConsoleApp11.Models
{
    public class PersonStudySubject
    {
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }

        public static IEnumerable<PersonStudySubject> Generate(int n, Guid[] subjIds, Guid[] personIds)
        {
            var f = new Faker<PersonStudySubject>();

            f.RuleFor(x => x.StudentId, x => personIds[x.Random.Int(0, personIds.Length - 1)]);
            f.RuleFor(x => x.SubjectId, x => subjIds[x.Random.Int(0, subjIds.Length - 1)]);

            return f.Generate(n);
        }
    }
}