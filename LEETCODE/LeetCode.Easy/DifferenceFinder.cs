namespace LeetCode.Easy;
using System.Collections.Generic;   


public class DifferenceFinder
{
    
    public char FindTheDifference(string s, string t) {
        //char extraChar = FindExtraCharacterSlow(s, t);
        char extraChar = FindExtraCharacterFast(s, t);
        return extraChar;
        
    }



    private char FindExtraCharacterFast(string s, string t)
    {
        char extraChar = ' ';
        Dictionary<char, int> sMap = SetUpCharactersFrequencyMap(s);
        Dictionary<char, int> tMap = SetUpCharactersFrequencyMap(t);

        foreach (char k in tMap.Keys)
        {
            if (sMap.ContainsKey(k))
            {
                if (sMap[k] < tMap[k])
                {
                    extraChar = k;
                    break;   
                }
            }
            else
            {
                extraChar = k;
                break;
            }
        }

     
        return extraChar;   
    }


    private char FindExtraCharacterSlow(string s, string t)
    {
        char extraChar = ' ';

        if (s != null && t != null)
        {
            List<char> sList = new List<char>(s);
            foreach (char c in t)
            {
                if (sList.Contains(c))
                {
                    sList.Remove(c);
                }
                else
                {
                    extraChar = c;
                    break;
                }
            }
        }
        
        return extraChar;
    }

    private Dictionary<char, int> SetUpCharactersFrequencyMap(string s)
    {
        Dictionary<char, int> map = new Dictionary<char, int>();

        if (s != null)
        {
            foreach (char c in s)
            {
                if (map.ContainsKey(c))
                {
                    map[c] = map[c] + 1;
                }
                else 
                {
                    map.Add(c, 1);
                }
            }
        }

        return map;
    }
    
}