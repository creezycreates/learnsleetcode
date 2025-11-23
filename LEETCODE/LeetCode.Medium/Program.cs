
using LeetCode.Medium;

string s = "applepenapple";
string[] wordDict = {"apple","pen"};
WordSegmenter segmenter = new WordSegmenter();
Console.WriteLine(">> " + segmenter.WordBreak(s, wordDict));