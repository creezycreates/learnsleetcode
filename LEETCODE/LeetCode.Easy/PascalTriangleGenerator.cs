namespace LeetCode.Easy;

public static class PascalTriangleGenerator
{
    public static IList<IList<int>> Generate(int numRows)
    {
        IList<IList<int>> rows = new List<IList<int>>();

        if (numRows is >= 1 and <= 30)
        {
            // we set up the rows
            for (int i = 1; i <= numRows; i++)
            {
                rows.Add(new List<int>());
            }

            int elementsCount = 0;
            IList<int> currentRow = new List<int>();
            IList<int> previousRow = new List<int>();
            
            
            //now we fill the rows
            for (int i = 0; i < numRows; i++)
            {
                if (i == 0)
                {
                    rows[i].Add(1);
                }
                else if (i == 1)
                {
                    rows[i].Add(1);
                    rows[i].Add(1);
                }
                else
                { 
                    previousRow = rows[i - 1];
                    currentRow = rows[i];
                    elementsCount = i + 1;
                    
                    for(int j=0; j<previousRow.Count; j++)
                    {
                        if (j == 0 || j == previousRow.Count - 1)
                        {
                            currentRow.Add(previousRow[j]);
                        }
                        
                        if (((j + 1) < previousRow.Count) && 
                            (previousRow.Count + 1 <= elementsCount))
                        {
                            currentRow.Add(previousRow[j] + previousRow[j + 1]);
                        }
                    }
                }
            }
        }

        return rows;
    }
}