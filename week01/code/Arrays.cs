public static class Arrays
{

    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number'
    /// followed by multiples of 'number'.
    /// Example: MultiplesOf(7, 5) → {7, 14, 21, 28, 35}
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create a new array of doubles with the given length
        double[] result = new double[length];

        // Step 2: Loop from 0 to length - 1
        for (int i = 0; i < length; i++)
        {
            // Step 3: Each element is number multiplied by (i + 1)
            result[i] = number * (i + 1);
        }

        // Step 4: Return the filled array
        return result;
    }

    /// <summary>
    /// Rotate the 'data' list to the right by the given 'amount'.
    /// Example:
    /// {1,2,3,4,5,6,7,8,9}, amount = 3
    /// Result → {7,8,9,1,2,3,4,5,6}
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Determine how many elements will move from the end to the front
        int count = data.Count;
        int splitIndex = count - amount;

        // Step 2: Copy the last 'amount' elements into a temporary list
        List<int> rightPart = data.GetRange(splitIndex, amount);

        // Step 3: Copy the remaining elements at the front
        List<int> leftPart = data.GetRange(0, splitIndex);

        // Step 4: Clear the original list
        data.Clear();

        // Step 5: Add the rotated elements back in correct order
        data.AddRange(rightPart);
        data.AddRange(leftPart);
    }
}
