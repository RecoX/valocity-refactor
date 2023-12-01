using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingAssessment.Refactor
{
    public class People
    {
        private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);
        public string Name { get; private set; }
        public DateTimeOffset DOB { get; private set; }

        public People(string name) : this(name, Under16.Date)
        {
        }

        public People(string name, DateTime dob)
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
        private List<People> _people;

        public BirthingUnit()
        {
            _people = new List<People>();
        }

        /// <summary>
        /// Adds a person in the internal _people property
        /// </summary>
        /// <param name="person"></param>
        public void AddPerson(People person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person), "Person cannot be null.");
            }

            _people.Add(person);
        }


        /// <summary>
        /// GetPeoples
        /// </summary>
        /// <param name="j"></param>
        /// <returns>List<object></returns>
        public List<People> GetPeople(int i)
        {
            for (int j = 0; j < i; j++)
            {
                try
                {
                    // Creates a dandon Name
                    string name = string.Empty;
                    var random = new Random();
                    if (random.Next(0, 1) == 0) {
                        name = "Bob";
                    }
                    else {
                        name = "Betty";
                    }
                    // Adds new people to the list
                    _people.Add(new People(name, DateTime.UtcNow.Subtract(new TimeSpan(random.Next(18, 85) * 356, 0, 0, 0))));
                }
                catch (Exception e)
                {
                    // Dont think this should ever happen
                    throw new Exception("Something failed in user creation");
                }
            }
            return _people;
        }

        /// <summary>
        /// Retrieves a filtered list of people named Bob deppending on criteria.
        /// </summary>
        /// <param name="olderThan30">A boolean value indicating whether to filter by age (older than 30 years).</param>
        /// <returns>An IEnumerable of People objects representing persons named Bob.</returns>
        public IEnumerable<People> GetBobs(bool olderThan30)
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

        public string GetMarried(People person, string lastName)
        {
            string fullName = $"{person.Name} {lastName}";

            if (fullName.Length > 255)
            {
                fullName = fullName.Substring(0, 255);
            }

            return fullName;
        }

    }
}