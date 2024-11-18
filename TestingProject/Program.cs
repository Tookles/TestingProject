namespace TestingProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WordAnalyser testAnalyser = new WordAnalyser();
            string testString = "This is a fairly boring thing.";
            List<string> testList = testAnalyser.FindLongestWords(testString);
            foreach (String word in testList)
            {
                Console.WriteLine(word);
            }
        }
    }
}
