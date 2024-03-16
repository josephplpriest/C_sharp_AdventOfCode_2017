namespace MyUtils;
using System.Linq;

class AnagramChecker
{
    public static bool IsAnagram(string strA, string strB)
    {

        var dict1 = GetCharCounts(strA);
        var dict2 = GetCharCounts(strB);
        return dict1.OrderBy(kvp => kvp.Key)
                            .SequenceEqual(dict2.OrderBy(kvp => kvp.Key));
    }

    private static Dictionary<char, int> GetCharCounts(string str) {
        Dictionary<char, int> dict = [];
        foreach (char letter in str) {
            if (dict.ContainsKey(letter)) {
                dict[letter] += 1;
            }
            else {
                dict[letter] = 1;
            }
        }
        return dict;
    }
}