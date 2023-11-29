using System;
using System.Collegctions.Generic; //LUCAS: Typo error "System.Collections.Generic"
using System.Linq;

namespace Utility.Valocity.ProfileHelper
{
    public class People
    {
     private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);
     public string Name { get; private set; }
     public DateTimeOffset DOB { get; private set; }
     public People(string name) : this(name, Under16.Date) { } // LUCAS: Add recommended XML tags for C#
     public People(string name, DateTime dob) { // LUCAS: Add recommended XML tags for C#
         Name = name;
         DOB = dob;
     }}

    public class BirthingUnit
    {
        /// <summary>
        /// MaxItemsToRetrieve // LUCAS: the summary should be more descriptive.
        /// </summary>
        private List<People> _people;

        public BirthingUnit()
        {
            _people = new List<People>();
        }

        /// <summary>
        /// GetPeoples // LUCAS: There is a typo error in "GetPeople" also the summary should be more descriptive like "Creates a list of people"
        /// </summary>
        /// <param name="j"></param> // LUCAS: The parameter j should have more meaningful name like "quantity" and a description is needed like "The number of people to be created"
        /// <returns>List<object></returns>
        public List<People> GetPeople(int i) // LUCAS: Parameter name discrepancy (i should be j)
        {
            for (int j = 0; j < i; j++)
            {
                try
                {
                    // Creates a dandon Name // LUCAS: Typo in comment
                    string name = string.Empty;
                    var random = new Random();
                    if (random.Next(0, 1) == 0) { // LUCAS: Always return 0 because Random.Next(min, max) generates a number in the range, so it should be "random.Next(0, 2)"
                        name = "Bob";
                    }
                    else {
                        name = "Betty";
                    }
                    // Adds new people to the list
					// LUCAS: Break down this line into multiple lines and separate the logic into clear steps and replace magic numbers with named constants to improve code readability and maintainability
                    _people.Add(new People(name, DateTime.UtcNow.Subtract(new TimeSpan(random.Next(18, 85) * 356, 0, 0, 0))));
                }
                catch (Exception e)
                {
                    // Dont think this should ever happen
                    throw new Exception("Something failed in user creation"); // LUCAS: The message should provide meaningful information, like use throw to obtain the full stack trace of the exception.
                }
            }
            return _people;
        }

        private IEnumerable<People> GetBobs(bool olderThan30)
        {
			// LUCAS: Break down this line into multiple lines and separate the logic into clear steps and use named re-use constants for the age range
            return olderThan30 ? _people.Where(x => x.Name == "Bob" && x.DOB >= DateTime.Now.Subtract(new TimeSpan(30 * 356, 0, 0, 0))) : _people.Where(x => x.Name == "Bob");
        }

		// LUCAS: Add recommended XML tags for C#
		// LUCAS: The logic in the function seems to be checking rules about the full name of the person, probably the name of the function is incorrect or the implementation is incorrect.
        public string GetMarried(People p, string lastName)
        {
            if (lastName.Contains("test"))
                return p.Name;
            if ((p.Name.Length + lastName).Length > 255)
            {
                (p.Name + " " + lastName).Substring(0, 255); // LUCAS: This line doesn't do anything because the result is not returned.
            }

            return p.Name + " " + lastName;
        }
    }
}