// The program must take two separate lists of values and compare the differences between the sorted lists
// e.g. the difference between the smallest number of each list, second smallest number of each list etc..
// The program must then print the total sum of differences to answer the challenge.

// My thought process completing this challenge was to create two lists for the left and right columns and then sort them
// Once sorted finding the difference between paired values is easy to sum

// Declare both lists
List<int> listL = new List<int>();
List<int> listR = new List<int>();
int totalDiff = 0;
string[] inputs;
string input;

// Receieve input from file containing challenge values
StreamReader reader = new StreamReader("C:\\values.txt");
input = reader.ReadLine();

// Separate each readline into two different int values
while (input != null) 
{
    inputs = input.Split("   ");
    listL.Add(int.Parse(inputs[0]));
    listR.Add(int.Parse(inputs[1]));
    input = reader.ReadLine();
}

reader.Close();

// Sort lists
listL.Sort();
listR.Sort();

// Compare each ordered pair for diference in value and tally total difference amongst all pairs
for (int i = 0; i < listL.Count; i++)
{
    totalDiff += Math.Abs(listL[i] - listR[i]);
}

// Print Total
Console.WriteLine(totalDiff);