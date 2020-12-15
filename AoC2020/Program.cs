using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

int[] input1_1_1 = { 1721, 979, 366, 299, 675, 1456 };
Console.WriteLine(Day1_1(input1_1_1));
List<int> input1_1_2 = ReadInput("Day1_1.txt");
Console.WriteLine(Day1_1(input1_1_2));

int Day1_1(IList<int> input)
{
    // Brute force approach:
    //int numComparisons = 0;
    //for (int i = 0; i < input.Count - 1; i++)
    //{
    //    for (int j = i + 1; j < input.Count; j++)
    //    {
    //        numComparisons++;
    //        if (input[i] + input[j] == 2020)
    //        {
    //            Console.WriteLine($"Day1_1() brute force comparisons: {numComparisons}.");
    //            return input[i] * input[j];
    //        }
    //    }
    //}

    // And a lovely single-pass solution thanks to https://github.com/89netraM/Advent-of-Code/blob/master/2020/1/1.csx:
    int numComparisons = 0;
    BitArray numberInList = new BitArray(2020);
    for (int i = 0; i < input.Count; i++)
    {
        numComparisons++;
        int number = input[i];
        if (number < 2020)
        {
            numberInList[number] = true;
            if (numberInList[2020 - number])
            {
                Console.WriteLine($"Day1_1() single-pass comparisons: {numComparisons}.");
                return number * (2020 - number);
            }
        }
    }

    return 0;
}

List<int> ReadInput(string filename)
{
    List<int> input = new List<int>();
    using StreamReader sr = new StreamReader(filename);
    string? line;
    while ((line = sr.ReadLine()) != null)
    {
        input.Add(int.Parse(line));
    }

    return input;
}
