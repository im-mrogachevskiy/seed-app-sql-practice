using System.Linq;
using ConsoleApp11.Models;

namespace ConsoleApp11
{
    class Program
    {
        private static Address[] _addresses;
        private static Person[] _persons;
        private static University[] _universities;
        private static StudySubject[] _studySubjects;
        private static PersonStudySubject[] _personStudySubjects;

        static Program()
        {
            SeedData();
        }

        static void Main(string[] args)
        {
            // your code 
        }

        static void SeedData()
        {
            _addresses = Address.Generate(100).ToArray();

            _persons = Person.Generate(350, _addresses.Select(x => x.Id).ToArray()).ToArray();
            _universities = University.Generate(5, _addresses.Select(x => x.Id).ToArray()).ToArray();

            _studySubjects = StudySubject.Generate(25, _universities.Select(x => x.Id).ToArray(),
                _persons.Select(x => x.Id).ToArray()).ToArray();

            _personStudySubjects = PersonStudySubject.Generate(200, _studySubjects.Select(x => x.Id).ToArray(),
                    _persons.Select(x => x.Id).ToArray()).Select(x => (x.StudentId, x.SubjectId)).ToHashSet()
                .Select(x => new PersonStudySubject() { StudentId = x.StudentId, SubjectId = x.SubjectId }).ToArray();
        }
    }
}