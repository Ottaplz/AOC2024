// The program must take values from two lists and then determine their "similarity score"
// The similarity score is determined by identifying if a value in the left list of values 
// exists in the right list of values.
// If the value exists in the right list of values then the 

// My approach for this problem was to create a hash table of the right list of values with a key value pair of value and frequency
// After creating the hash table the left list can then be compared and added to the similarity score for key * value


// Declare necessary variables and data structures
List<int> listL = new List<int>();
Dictionary<int, int> DictR = new Dictionary<int, int>();
int totalSimilarity = 0;
string[] inputs;
string input;

StreamReader reader = new StreamReader("C:\\values.txt");
input = reader.ReadLine();

// Receive input from file and split the values
while (input != null) 
{
    inputs = input.Split("   ");
    int rightVal = int.Parse(inputs[1]);

    // Turn the left input into a list
    listL.Add(int.Parse(inputs[0]));

    // Turn the right input into a dictionary<int, int> with the first value being the number input and the second value being number of times it occurs
    if (DictR.ContainsKey(rightVal))
    {
        DictR[rightVal]++;
    }
    else
    {
        DictR.Add(rightVal, 1);
    }

    input = reader.ReadLine();
}

reader.Close();

// Parse the left list and check the values against the Dictionary keys, if exists multiply by number of occurences and add to total
foreach (int num in listL)
{
    if (DictR.TryGetValue(num, out int value))
    {
        totalSimilarity += num * value;
    }
}

// Print the total tallies value
Console.WriteLine(totalSimilarity);
