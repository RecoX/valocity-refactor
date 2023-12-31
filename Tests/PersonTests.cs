using CodingAssessment.Refactor;
using Xunit;

namespace Tests
{
    public class PersonTests
    {
        [Fact]
        public void Constructor_WithDefaultDateOfBirth_SetsDateOfBirthToUnder16YearsAgo()
        {
            DateTimeOffset expectedDateOfBirth = DateTimeOffset.UtcNow.AddYears(-15).Date;
            string expectedName = "Alice";

            var person = new Person(expectedName);

            Assert.Equal(expectedDateOfBirth, person.DateOfBirth);
            Assert.Equal(expectedName, person.Name);
        }

        [Fact]
        public void Constructor_WithCustomDateOfBirth_SetsDateOfBirthProperty()
        {
            DateTime customDateOfBirth = new DateTime(1990, 1, 1);
            DateTimeOffset expectedDateOfBirth = customDateOfBirth;
            string expectedName = "Bob";

            var person = new Person(expectedName, customDateOfBirth);

            Assert.Equal(expectedDateOfBirth, person.DateOfBirth);
            Assert.Equal(expectedName, person.Name);
        }
    }
}
