using CodingAssessment.Refactor;
using Xunit;

namespace Tests
{
    public class BirthingUnitTests
    {
        [Fact]
        public void GeneratePeopleList_ReturnsEmptyList_WhenRequestedZeroPeople()
        {
            var birthingUnit = new BirthingUnit();

            var people = birthingUnit.GeneratePeopleList(0);

            Assert.Empty(people);
        }

        [Fact]
        public void GeneratePeopleList_ReturnsPeopleList_WhenRequestedOneOrMore()
        {
            var birthingUnit = new BirthingUnit();

            int requestedCount = 5;
            var people = birthingUnit.GeneratePeopleList(requestedCount);

            Assert.NotNull(people);
            Assert.Equal(requestedCount, people.Count);
        }

        [Theory]
        [InlineData("John", "Doe", "John Doe")]
        [InlineData("Alice", "Smith", "Alice Smith")]
        [InlineData("Bob", "test", "Bob")]
        public void GetMarriedName_ReturnsFullName(string firstName, string lastName, string expectedFullName)
        {
            var person = new Person(firstName);
            var birthingUnit = new BirthingUnit();

            string marriedName = birthingUnit.GetMarriedName(person, lastName);

            Assert.Equal(expectedFullName, marriedName);
        }

        [Fact]
        public void GetMarriedName_TruncatesFullNameIfTooLong()
        {
            var person = new Person("Michael");
            var birthingUnit = new BirthingUnit();
            string longLastName = new string('X', 300);

            string marriedName = birthingUnit.GetMarriedName(person, longLastName);

            Assert.Equal(255, marriedName.Length);
        }

        [Fact]
        public void GetBobs_ReturnsBobs_WhenOlderThan30()
        {
            var birthingUnit = new BirthingUnit();
            var olderThan30Bob = new Person("Bob", DateTime.UtcNow.Subtract(new TimeSpan(35 * 356, 0, 0, 0)));
            var youngerThan30Bob = new Person("Bob", DateTime.UtcNow.Subtract(new TimeSpan(25 * 356, 0, 0, 0)));

            birthingUnit.AddPerson(olderThan30Bob);
            birthingUnit.AddPerson(youngerThan30Bob);

            IEnumerable<Person> result = birthingUnit.GetBobs(true);

            Assert.Contains(olderThan30Bob, result);
            Assert.DoesNotContain(youngerThan30Bob, result);
        }

        [Fact]
        public void GetBobs_ReturnsAllBobs_WhenNotOlderThan30()
        {
            var birthingUnit = new BirthingUnit();
            var olderThan30Bob = new Person("Bob", DateTime.UtcNow.Subtract(new TimeSpan(35 * 356, 0, 0, 0)));
            var youngerThan30Bob = new Person("Bob", DateTime.UtcNow.Subtract(new TimeSpan(25 * 356, 0, 0, 0)));

            birthingUnit.AddPerson(olderThan30Bob);
            birthingUnit.AddPerson(youngerThan30Bob);

            IEnumerable<Person> result = birthingUnit.GetBobs(false);

            Assert.Contains(olderThan30Bob, result);
            Assert.Contains(youngerThan30Bob, result);
        }

        [Fact]
        public void AddPerson_ShouldAddPersonToList()
        {
            var birthingUnit = new BirthingUnit();
            var person = new Person("Alice", DateTime.UtcNow);

            birthingUnit.AddPerson(person);

            Assert.Contains(person, birthingUnit.GeneratePeopleList(1));
        }
    }
}
