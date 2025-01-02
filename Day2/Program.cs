// multiple strings of X amount of numbers. Determine how many are safe.
// A string is safe if all numbers are increasing or decreasing AND if 
// none of the difference in adjacent numbers is outside the range of 1-3

// Declare necessary variables and data structures
string input;
List<int> numSequence = new List<int>();
bool isSafe = true;
int totalSafeSequences = 0;

// Receive input from file
StreamReader reader = new StreamReader("C:\\Users\\DCMur\\OneDrive\\Coding Projects\\C#\\AOC2024\\Day2\\values.txt");
input = reader.ReadLine();

// Loop through each line and determine if it is valid
while (input != null)
{
    isSafe = true;
    numSequence.Clear();

    // Convert input to number list FIX THIS NOW
    for (int i = 0; i < input.Length; i++)
    {
        if (Char.IsDigit(input[i]))
        {
             numSequence.Add(input[i]);
        } 
    }

    for (int i = 0; i < numSequence.Count - 1; i++)
    {
        // Check Ascending
        if (numSequence[i] - numSequence[i + 1] < 0)
        {
            for (int j = i; j < numSequence.Count - 1; j++)
            {
                if (!(numSequence[j] - numSequence[j + 1] < 0))
                {
                    isSafe = false;
                    break;
                }
            } 
        }

        // Check Descending
        else if (numSequence[i] - numSequence[i + 1] > 0)
        {
            for (int j = i; j < numSequence.Count - 1; j++)
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
        if (Math.Abs(numSequence[i] - numSequence[i + 1]) < 1 || Math.Abs(numSequence[i] - numSequence[i + 1]) < 3)
        {
            isSafe = false;
            break;
        }
    }

    if (isSafe == true)
    {
        totalSafeSequences++;
    }

    input = reader.ReadLine();
}

Console.WriteLine(totalSafeSequences);