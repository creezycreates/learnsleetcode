namespace LeetCode.Medium;

public class WordSegmenter
{
    Dictionary<string, bool> cache = new Dictionary<string, bool>();
    
    public bool WordBreak(string s, IList<string> wordDict)
    {
        bool canBeSegmented = false;
        string word = "";

        if (s.Length == 0)
        {
            return true;
        }

        if (cache.ContainsKey(s))
        {
            return cache[s];
        }

        foreach (char c in s)
        {
            word += c;
            if (WordExists(word, wordDict))
            {
                
                canBeSegmented = WordBreak(s.Substring(word.Length), 
                    wordDict);
                
                if (canBeSegmented)
                {
                    cache.TryAdd(word, true);
                    return true;
                }
            }
            
        }
        
        cache.TryAdd(s, false);
        
        return canBeSegmented;
    }

    private bool WordExists(string wordToFind, IList<string> words)
    {
        bool exists = false;

        foreach (string word in words)
        {
            if (word == wordToFind)
            {
                exists = true;
                break;
            }
        }

        return exists;
    }
}