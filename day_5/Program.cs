// using MyUtils;

// Read in the input
using System.Data;

List<int> nums = File.ReadAllLines("input/input.txt").Select(int.Parse).ToList();


// Use a counter to keep track of the number of steps taken
int jumpCounter = 0;

// track the index we're at
int currentIndex = 0;

// Use a while loop to keep track of whether we're inside the valid bounds

// Part 1

// while (currentIndex >= 0 && currentIndex < nums.Count)
// {
//     // update local val
//     nums[currentIndex] += 1;

//     // jump
//     currentIndex += nums[currentIndex] - 1;

//     // increment jump counter
//     jumpCounter += 1;
// }

// Part 2

while (currentIndex >= 0 && currentIndex < nums.Count)
{
    int previousIndex = currentIndex;

    // jump
    currentIndex += nums[currentIndex];

    if (nums[previousIndex] > 2) 
    {
        nums[previousIndex] -= 1;
    }
    else
    {
        nums[previousIndex] += 1;
    }
    // increment jump counter
    jumpCounter += 1;
}


Console.WriteLine(jumpCounter);