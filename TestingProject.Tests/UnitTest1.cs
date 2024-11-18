using FluentAssertions; 

namespace TestingProject.Tests
{
    public class Tests
    {

        [TestCase(TestName = "Testing Rightturn")]
        public void WhenRightTurn_ShouldTurnRight()
        {
            Compass testCompass = new Compass();
            Point directionOne = testCompass.Rotate(Point.North, Direction.Rightturn);
            directionOne.Should().Be(Point.East);

            Point directionTwo = testCompass.Rotate(Point.East, Direction.Rightturn);
            directionTwo.Should().Be(Point.South);

            Point directionThree = testCompass.Rotate(Point.South, Direction.Rightturn);
            directionThree.Should().Be(Point.West);

            Point directionFour = testCompass.Rotate(Point.West, Direction.Rightturn);
            directionFour.Should().Be(Point.North);
        }

        [TestCase(TestName = "Testing Leftturn")]
        public void WhenLeftTurn_ShouldTurnLeft()
        {
            Compass testCompass = new Compass();
            Point directionOne = testCompass.Rotate(Point.North, Direction.Leftturn);
            directionOne.Should().Be(Point.West);

            Point directionTwo = testCompass.Rotate(Point.East, Direction.Leftturn);
            directionTwo.Should().Be(Point.North);

            Point directionThree = testCompass.Rotate(Point.South, Direction.Leftturn);
            directionThree.Should().Be(Point.East);

            Point directionFour = testCompass.Rotate(Point.West, Direction.Leftturn);
            directionFour.Should().Be(Point.South);
        }

        [TestCase(TestName = "String Reversal")]
        public void WhenGivenString_ShouldReverseLetterOrder()
        {
            StringManipulator testManipulator = new StringManipulator(); 
            string inputTest = "ABCDE";
            string reversed = testManipulator.ReverseString(inputTest);
            reversed.Should().Be("EDCBA");
        }

        [TestCase(TestName = "Palindrome")]
        public void WhenGivenString_ShouldCheckIfPalindrome()
        {
            StringManipulator testManipulator = new StringManipulator();
            string inputTest = "hannah";
            bool reversed = testManipulator.IsPalindrome(inputTest);
            reversed.Should().BeTrue();

            string inputTest2 = "hannahno";
            bool reversed2 = testManipulator.IsPalindrome(inputTest2);
            reversed2.Should().BeFalse();
        }

        [TestCase(TestName = "Character frequency: common cases")]
        public void WhenGivenString_ReturnsDictOfCharFrequency()
        {
            WordAnalyser testAnalyser = new WordAnalyser();
            string testString = "Will this detect capital LETTERS?";
            int testForL = testAnalyser.CalculateLetterFrequency(testString)['l'];
            testForL.Should().Be(4);

            int testForW = testAnalyser.CalculateLetterFrequency(testString)['w'];
            testForW.Should().Be(1);

            int testForT = testAnalyser.CalculateLetterFrequency(testString)['t'];
            testForT.Should().Be(6);


        }

        [TestCase(TestName = "Character frequency: punctuation")]
        public void WhenGivenString_ReturnDictDoesNotIncludePunctuation()
        {
            WordAnalyser testAnalyser = new WordAnalyser();
            string testString = "Will this detect punctuation?!";
            bool testForQuestionMark = testAnalyser.CalculateLetterFrequency(testString).ContainsKey('?'); 
            testForQuestionMark.Should().BeFalse();

        }


        [TestCase(TestName = "Largest words: common cases")]
        public void WhenGivenString_ReturnsLargestWords()
        {
            WordAnalyser testAnalyser = new WordAnalyser();
            string testString = "This is a fairly boring sentence.";
            List<string> testList = testAnalyser.FindLongestWords(testString);
            testList.Count.Should().Be(1);
            testList[0].Should().Be("sentence");

            string testStringTwo = "This is a fairly boring thing.";
            List<string> testListTwo = testAnalyser.FindLongestWords(testStringTwo);
            testListTwo.Count.Should().Be(2);
            testListTwo[0].Should().Be("fairly");
            testListTwo[1].Should().Be("boring");

        }

        [TestCase(TestName = "Shopping Cart Add Items: common cases")]
        public void WhenAddItem_ReturnsTrue()
        {
            ShoppingCart myShoppingCart = new ShoppingCart();
            bool IsAdded = myShoppingCart.AddItem("butter", 10); 
            IsAdded.Should().BeTrue();
            bool IsAddedTwice = myShoppingCart.AddItem("butter", 10);
            IsAddedTwice.Should().BeFalse();


        }


        [TestCase(TestName = "Shopping Cart Total Price: common cases")]
        public void WhenTotalPriceCalled_ReturnsTotal()
        {
            ShoppingCart myShoppingCart = new ShoppingCart();

            double TotalPriceZero = myShoppingCart.CalculateTotalPrice();
            TotalPriceZero.Should().Be(0); 

            myShoppingCart.AddItem("butter", 10.50);
            myShoppingCart.AddItem("cereal", 5.0);
            myShoppingCart.AddItem("banana", 2.30);

            double TotalPrice = myShoppingCart.CalculateTotalPrice();
            TotalPrice.Should().Be(17.80);

            myShoppingCart.AddItem("butter", 10.50);
            double TotalPriceNoChange = myShoppingCart.CalculateTotalPrice();
            TotalPriceNoChange.Should().Be(17.80);

        }

        [TestCase(TestName = "Shopping Cart Total Price: discount testing")]
        public void WhenTotalPriceCalled_ReturnsTotalWithDiscount()
        {
            ShoppingCart myShoppingCart = new ShoppingCart();

            myShoppingCart.AddItem("butter", 10.50);
            myShoppingCart.AddItem("cereal", 5.0);
            myShoppingCart.AddItem("banana", 2.30);

            double TotalPrice = myShoppingCart.CalculateTotalPrice();
            TotalPrice.Should().Be(17.80);

            myShoppingCart.ApplyDiscount(0.9);
            double TotalPriceWithDiscount = myShoppingCart.CalculateTotalPrice();
            TotalPriceWithDiscount.Should().Be(1.78);

        }

        [TestCase(TestName = "Shopping Cart Apply Discount")]
        public void WhenApplyDiscount_WithValidInput_DiscountApplied()
        {
            ShoppingCart myShoppingCart = new ShoppingCart();
            double CheckDiscount = myShoppingCart.ApplyDiscount(0.9);
            CheckDiscount.Should().Be(0.9);

        }

        [TestCase(TestName = "Shopping Cart Check Throws")]
        public void WhenApplyDiscount_WithInvalidInput_ExceptionThrown()
        {
            ShoppingCart myShoppingCart = new ShoppingCart();
            Action act = () => myShoppingCart.ApplyDiscount(3); 
            act.Should().Throw<ArgumentException>().WithMessage("Discount out of range");  

        }

    }
}