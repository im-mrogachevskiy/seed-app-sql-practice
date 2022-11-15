using System;
using System.Collections.Generic;
using Bogus;

namespace ConsoleApp11.Models
{
    public class StudySubject
    {
        public static string[] Names =
        {
            "Nineteenth-Century European Realism", "Literary Criticism", "World Literature",
            "American Literature", "European Classic Literature", "Postcolonial Literature",
            "Literature and Cinema", "Indian Classic Literature", "Modern European Drama",
            "British Literature", "Post World War II", "British Romantic Literature",
            "English Poetry: The Pre- Romantic to the Victorian", "Women?s Writing Literary Theory",
            "English Drama: Elizabethan to Victorian", "BA Economics Subjects",
            "Introductory Microeconomics", "Introductory Macroeconomics", "Introductory Econometrics",
            "Mathematical Methods for Economics", "Development Economics", "BA Psychology Subjects",
            "Development Psychology", "Educational Psychology", "Social Psychology",
            "Industrial Psychology", "Psychopathology", "Guidance and Counselling", "Project work",
            "Field Work", "Forensic Psychology", "Environmental Psychology", "Sports Psychology",
            "BA Geography", "Analytical Physical Geography", "Cartographic Techniques", "Oceanography",
            "Environmental Geography", "Spatial Dimensions of Development",
            "Evolution of Geographical Thought", "Social Geography", "Disaster Management",
            "Regional Planning: Case Studies", "Geographical Information System", "Rural Development",
            "BA Sociology Subjects", "Introduction to Sociology", "Economy and Society",
            "Gender Sensitisation", "Methods of Sociological Enquiry", "Religion and Society",
            "Sociological Theories", "Gender and Sexuality", "Techniques of Social Research",
            "BA Anthropology Subjects", "Human Genetics", "Introduction to Social Anthropology",
            "Introduction to Biological Anthropology", "Primate Biology / Cell Biology",
            "Anthropology of religion, politics & economy", "Biostatistics and Data Analysis",
            "Biological Diversity in Human Populations", "Human Ecology: Social and Cultural Dimensions",
            "Genetics & Genomics", "BA Kannada Subjects", "History of Kannada Literature",
            "Old and Medieval Kannada Literature", "Cultural History of Kannada", "Kannada Folk Literature",
            "Traditional Kannada Grammar", "Linguistics", "Modern Kannada Literature"
        };
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UniversityId { get; set; }
        public Guid ProfessorId { get; set; }

        public static IEnumerable<StudySubject> Generate(int n, Guid[] univetsIds, Guid[] personIds)
        {
            var f = new Faker<StudySubject>();

            f.RuleFor(x => x.Name, x => x.PickRandom(Names));
            f.RuleFor(x => x.Id, x => x.Random.Guid());
            f.RuleFor(x => x.UniversityId, x => univetsIds[x.Random.Int(0, univetsIds.Length - 1)]);
            f.RuleFor(x => x.ProfessorId, x => personIds[x.Random.Int(0, personIds.Length - 1)]);

            return f.Generate(n);
        }
        
        

    }
}