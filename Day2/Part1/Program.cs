// multiple strings of X amount of numbers. Determine how many are safe.
// A string is safe if all numbers are increasing or decreasing AND if 
// none of the difference in adjacent numbers is outside the range of 1-3

// I wanted to try to think of a more elegant solution for checking ascending and descending order simultaneously instead
// of looping over the sequences multiple times but couldn't think of anything off the top of my head


// Declare necessary variables and data structures
string input;
string[] splitInputs;
List<int> numSequence = new List<int>();
bool isSafe = true;
int totalSafeSequences = 0;

// Receive input from file
StreamReader reader = new StreamReader("C:\\values.txt");
input = reader.ReadLine();

// Loop through each line and determine if it is valid
while (input != null)
{
    isSafe = true;
    numSequence.Clear();

    // Convert input to number list FIX THIS NOW
    splitInputs = input.Split(' ');
    foreach (string num in splitInputs)
    {
        numSequence.Add(int.Parse(num));
    }

    // Check Ascending
    if (numSequence[0] - numSequence[1] < 0)
    {
        for (int j = 1; j < numSequence.Count - 1; j++)
        {
            if (!(numSequence[j] - numSequence[j + 1] < 0))
            {
                isSafe = false;
                break;
            }
        } 
    }
    // Check Descending
    else if (numSequence[0] - numSequence[1] > 0)
    {
        for (int j = 1; j < numSequence.Count - 1; j++)
        {
            if (!(numSequence[j] - numSequence[j + 1] > 0))
            {
                isSafe = false;
                break;
            }
        } 
    }
    else
    {
        isSafe = false;    
    }

    // Check for range 1-3
    for (int i = 0; i < numSequence.Count - 1; i++)
    {
        if (Math.Abs(numSequence[i] - numSequence[i + 1]) < 1 || Math.Abs(numSequence[i] - numSequence[i + 1]) > 3)
        {
            isSafe = false;
            break;
        }
    }

    if (isSafe == true)
    {
        totalSafeSequences++;
    }

    // Read next line
    input = reader.ReadLine();
}

Console.WriteLine(totalSafeSequences);