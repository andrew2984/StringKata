using StringCalculatorApp;
namespace StringCalculatorTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenNothing_AddReturns_Zero()
        {
            Assert.That(Program.Add(""),Is.EqualTo(0));
        }

        [Test]
        public void GivenOne_AddReturns_One()
        {
            Assert.That(Program.Add("1"), Is.EqualTo(1));
        }

        [Test]
        public void GivenOneCommaTwo_AddReturns_Three()
        {
            Assert.That(Program.Add("1,2"), Is.EqualTo(3));
        }

        [TestCase("1,2,3,4,5",15)]
        public void GivenStringFromOneToFive_AddReturns_Fifteen(string input,int expectedResult)
        {
            Assert.That(Program.Add(input), Is.EqualTo(15));
        }

        [TestCase("1\n2,3", 6)]
        public void GivenAlternateFormatStringOneToThree_AddReturns_Six(string input, int expectedResult)
        {
            Assert.That(Program.Add(input), Is.EqualTo(6));
        }

        [TestCase("//;\n1;2", 3)]
        public void GivenAlternateDelimiterOnStringOneAndTwo_AddReturns_Three(string input, int expectedResult)
        {
            Assert.That(Program.Add(input), Is.EqualTo(3));
        }

        [TestCase("//;\n1;-2")]
        public void GivenNegativeValueInInput_AddReturns_ArgumentOutOfRangeException(string input)
        {
            Assert.That(() => Program.Add(input), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase("//;\n1;-2")]
        public void GivenNegativeValueInInput_AddReturns_ArgumentOutOfRangeExceptionMessageIncludingValue(string input)
        {
            Assert.That(() => Program.Add(input), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contain("negatives not allowed -2"));
        }

        [TestCase("//;\n1;-2;-2;-3")]
        public void GivenNegativeValueInInput_AddReturns_ArgumentOutOfRangeExceptionMessageIncludingAllValues(string input)
        {
            Assert.That(() => Program.Add(input), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contain("negatives not allowed -2 -2 -3"));
        }
        s
        [TestCase("1,2,1001", 3)]
        public void GivenLargerThanAThousandInInput_AddIgnores_Returns3(string input, int expectedResult)
        {
            Assert.That(Program.Add(input), Is.EqualTo(3));
        }

    }
}