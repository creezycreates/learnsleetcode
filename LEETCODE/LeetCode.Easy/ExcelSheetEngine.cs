namespace LeetCode.Easy;

public class ExcelSheetEngine
{
    
    public string ConvertToTitle(int columnNumber)
    {
        string title = "";
        int quotient = columnNumber;
        int remainder = -1;

        while (quotient != 0)
        {
            remainder = quotient % 26;
            quotient = quotient / 26;
            if (remainder == 0)
            {
                title = "Z" + title;
                quotient = quotient - 1;
            }
            else
            {
                title = ConvertToLetter(remainder) + title;
            }
        }

        return title;
    }



    private char ConvertToLetter(int columnNumber)
    {
        char letter = '!';

        if (columnNumber >= 1 && columnNumber <= 26)
        {
            int ascIIDelta = 64;
            int ascIILetterValue = ascIIDelta + columnNumber;
            letter = (char)ascIILetterValue;
        }

        return letter;
    }
}