// Parse a string and find all valid instances of the funcion mul(num1, num2) that multiplies two numbers together
// Print final value which is the sum of all valid functions

// Decided to break the identification of certain elements when parsing the string to identify a valid function call

// Declare necessary variables and data structures 
string input;
long total = 0;
int MAXINTLENGTH = 3;

// Receive input from file
StreamReader reader = new StreamReader("C:\\values.txt");
input = reader.ReadLine();

// Parse the line until reaching the point where "mul(" exists 
while (input != null)
{
    for (int i = 0; i < input.Length; i++)
    {
        int intLength = 0;
        bool isValid = true;
        string temp = "";
        int num1 = 0;
        int num2 = 0;

        // Check Substring mul( in overall string
        if (input[i] == 'm' && input[i + 1] == 'u' && input[i + 2] == 'l' && input[i + 3] == '(')
        {
            i += 4;
        }
        else 
        {
            isValid = false;
        }

        // Check for a valid number between 1-3 digits then for a *
        if (isValid)
        {
            for (int k = 0; k < MAXINTLENGTH; k++) 
            {
                if (Char.IsDigit(input[i]))
                {
                    intLength++;
                    temp += input[i];
                    i++;
                }
                else
                {
                    isValid = false;
                    i++;
                    break;
                }

                if (input[i] == ',' && intLength > 0)
                {
                    intLength = 0;
                    num1 = int.Parse(temp);
                    temp = "";
                    i++;
                    break;
                }
            }
        }
        
        // Check for a valid number between 1-3 digits then for a closing parentheses
        if (isValid)
        {
            for (int z = 0; z < MAXINTLENGTH; z++)
            {
                if (Char.IsDigit(input[i]))
                {
                    intLength++;
                    temp += input[i];
                    i++;
                }
                else
                {
                    break;
                }

                if (input[i] == ')' && intLength > 0)
                {
                    num2 = int.Parse(temp);
                    total += mul(num1, num2);
                    break;
                }
            }
        }
    }

    input = reader.ReadLine();
}

Console.WriteLine(total);

    
int mul(int a, int b)
{
    return a * b;
}

