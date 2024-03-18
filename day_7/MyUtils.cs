namespace MyUtils;
using System.Linq;

public class TreeNode
{
    public string NodeName { get; set; }
    public bool HasChildren { get; set; }
    public List<TreeNode> Children { get; set; }
    public int Weight { get; set; }

    public TreeNode(string nodeName, bool hasChildren, List<TreeNode> children, int weight)
    {
        NodeName = nodeName;
        HasChildren = hasChildren;
        Children = children;
        Weight = weight;
    }

    public void AddChild(TreeNode child)
    {
        Children.Add(child);
        HasChildren = true;
    }

    public int GetWeight()
    {
        if (!HasChildren)
        {
            return Weight;
        }
        else
        {
            // calculate child weights, check for equality
            List<int> childWeights = Children.Select(child => child.GetWeight()).ToList();
            if (!childWeights.All(x => x == childWeights[0]))
            {
                foreach (TreeNode child in Children)
                {
                    Console.WriteLine($"name: {child.NodeName}\nindividual weight: {child.Weight}, total weight: {child.GetWeight()}");
                }
            }
            return Weight + childWeights.Sum();
        }
    }
}