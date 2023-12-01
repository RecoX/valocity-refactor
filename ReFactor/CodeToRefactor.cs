using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingAssessment.Refactor
{
    public class Person
    {
        private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);
        public string Name { get; private set; }
        public DateTimeOffset DOB { get; private set; }

        public Person(string name) : this(name, Under16.Date)
        {
        }

        public Person(string name, DateTime dob)
        {
            Name = name;
            DOB = dob;
        }
    }

    public class BirthingUnit
    {
        /// <summary>
        /// MaxItemsToRetrieve
        /// </summary>
        private List<Person> _people;

        public BirthingUnit()
        {
            _people = new List<Person>();
        }

        /// <summary>
        /// Adds a person in the internal _people property
        /// </summary>
        /// <param name="person"></param>
        public void AddPerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person), "Person cannot be null.");
            }

            _people.Add(person);
        }


        /// <summary>
        /// Generates a list of people with random names and birthdates.
        /// </summary>
        /// <param name="quantity">The number of people to be generated.</param>
        /// <returns>A list of generated people.</returns>
        public List<Person> GetPeople (int quantity)
        {
            for (int personIndex = 0; personIndex < quantity; personIndex++)
            {
                try
                {
                    string name = GenerateRandomName();
                    DateTime randomBirthDate = GenerateRandomBirthDate();

                    // Add a new person to the list
                    _people.Add(new Person(name, randomBirthDate));
                }
                catch (Exception e)
                {
                    throw new Exception("GeneratePeopleList error: ", e);
                }
            }
            return _people;
        }

        /// <summary>
        /// Retrieves a filtered list of people named Bob deppending on criteria.
        /// </summary>
        /// <param name="olderThan30">A boolean value indicating whether to filter by age (older than 30 years).</param>
        /// <returns>An IEnumerable of People objects representing persons named Bob.</returns>
        public IEnumerable<Person> GetBobs(bool olderThan30)
        {
            var result = _people.Where(person => person.Name == "Bob");

            if (olderThan30)
            {
                var currentDateTime = DateTime.Now;
                var thirtyYearsAgo = currentDateTime.AddYears(-30);

                result = result.Where(bob => bob.DOB <= thirtyYearsAgo);
            }

            return result;
        }

        public string GetMarried(Person person, string lastName)
        {
            if (lastName.Contains("test"))
            {
                return person.Name;
            }

            string fullName = $"{person.Name} {lastName}";

            if (fullName.Length > 255)
            {
                fullName = fullName.Substring(0, 255);
            }

            return fullName;
        }

        private string GenerateRandomName()
        {
            var random = new Random();
            int randomNumber = random.Next(0, 2);
            return randomNumber == 0 ? "Bob" : "Betty";
        }

        private DateTime GenerateRandomBirthDate()
        {
            var random = new Random();
            const int minAge = 18;
            const int maxAge = 85;

            int randomAge = random.Next(minAge, maxAge);
            DateTime birthDate = DateTime.UtcNow.Subtract(TimeSpan.FromDays(randomAge * 365));
            return birthDate;
        }

    }
}