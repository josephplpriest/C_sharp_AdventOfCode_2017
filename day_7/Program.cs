using System.Globalization;
using MyUtils;


string filePath = "input/input.txt";

var data = File.ReadAllLines(filePath);

// Part 1

// Dictionary<string, int> wordCounter = new Dictionary<string, int>{};

// foreach(string line in data)
// {
//     var words = line.Split();
//     foreach (string word in words)
//     {
//         string strippedWord = word.Replace(",", "");
//         if (!strippedWord.Contains("-") && !strippedWord.Contains("("))
//         {
//             if (wordCounter.ContainsKey(strippedWord))
//             {
//                 wordCounter[strippedWord] += 1;
//             }
//             else
//             {
//                 wordCounter[strippedWord] = 1;
//             }
//         }
//     }
// }

// foreach (KeyValuePair<string, int> entry in wordCounter)
// {
//     if (entry.Value == 1)
//     {
//         Console.WriteLine(entry.Key);
//     } 
// }
Dictionary<string, TreeNode> nodeDict = [];

foreach (string line in data)
{
    var nodeData = line.Split(" ");

    string nodeName = nodeData[0];
    int nodeWeight = int.Parse(nodeData[1][1..^1]);

    TreeNode treenode = new TreeNode(nodeName, false, [], nodeWeight);

    nodeDict[nodeName] = treenode;
}

foreach (string line in data)
{
    var nodeData = line.Split(" -> ");
    var nodeName = nodeData[0].Split(" ")[0];
    if (nodeData.Length > 1)
    {
        foreach (string child in nodeData[1].Split(", "))
        {
            var childNode = nodeDict[child];
            nodeDict[nodeName].AddChild(childNode);
        }
    }
}

foreach (TreeNode treeNode in nodeDict.Values)
{
    treeNode.GetWeight();
}
