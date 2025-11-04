namespace LeetCode.Easy;

public class TreesComparator
{
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        bool areSimilar = false;
        string pString = TraverseTree(p, "");
        string qString = TraverseTree(q, "");
        
        Console.WriteLine(">> PTRAIL = " + pString);
        Console.WriteLine(">> QTRAIL = " + qString);
        
        areSimilar = pString == qString;
        
        return areSimilar;
    }


    private string TraverseTree(TreeNode node, string s)
    {
        if (node != null)
        {
            s = s + node.val + "(";
        }

        if (node != null && node.left != null)
        {
            s = TraverseTree(node.left, s + "L-");
        }

        if (node != null && node.right != null)
        {
            s = TraverseTree(node.right, s + "R-");       
        }

        if (node != null)
        {
            s = s + ")";
        }

        return s;
    }
}