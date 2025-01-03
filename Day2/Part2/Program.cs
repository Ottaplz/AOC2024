// Same as part 1 but each sequence is allowed to have one point of error to be considered safe and the unsafe item

// I wanted to try to think of a more elegant solution for checking ascending and descending order simultaneously instead
// of looping over the sequences multiple times but couldn't think of anything off the top of my head


// Need to fix edge case of the starting pair being ascending or descending with the rest of the input being the opposite if a number is removed
// Due to this need to create a more scalable and adaptive process instead of the current spaghetti (example edge case 9 8 11 12 15 17 19)

// Declare necessary variables and data structures
string input;
string[] splitInputs;
List<int> numSequence = new List<int>();
bool isSafe = true;
bool problemDampened = false;
int totalSafeSequences = 0;
int Z = 0;

// Receive input from file
StreamReader reader = new StreamReader("C:\\Users\\DCMur\\OneDrive\\Coding Projects\\C#\\AOC2024\\Day2\\values.txt");
input = reader.ReadLine();

// Loop through each line and determine if it is valid
while (input != null)
{
    Z++;
    // Reset variables
    problemDampened = false;
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
        for (int j = 0; j < numSequence.Count - 1; j++)
        {
            if (!(numSequence[j] - numSequence[j + 1] < 0))
            {
                if (problemDampened)
                {
                    isSafe = false;
                    break;
                }
                else
                {
                    numSequence.RemoveAt(j + 1);
                    j = -1;
                    problemDampened = true;
                }
            }
        } 
    }
    // Check Descending
    else if (numSequence[0] - numSequence[1] > 0)
    {
        for (int j = 0; j < numSequence.Count - 1; j++)
        {
            if (!(numSequence[j] - numSequence[j + 1] > 0))
            {
                if (problemDampened)
                {
                    isSafe = false;
                    break;
                }
                else
                {
                    numSequence.RemoveAt(j + 1);
                    j = -1;
                    problemDampened = true;
                }
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
            if (problemDampened)
            {
                isSafe = false;
                break;
            }
            else
            {
                numSequence.RemoveAt(i + 1);
                i = -1;
                problemDampened = true;
            }
        }
    }

    if (isSafe == true)
    {
        totalSafeSequences++;
    }

    Console.WriteLine($"{Z} {isSafe}");
    // Read next line
    input = reader.ReadLine();
}

Console.WriteLine(totalSafeSequences);