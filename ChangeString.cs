using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegetes
{
    class StringOperations
    {
        

        static public List<string> getMaxBrackets(string[] lines, ref string str )
        {
            int maxBracket = 0,tempMax;
            int indexBracket;//index of first endbracket;
            int indexLineStartSentences=0,indexStartSentences=0,indexEndSent;
            ;string tempStr;
            List<string> sentences = new List<string>();
            StringBuilder curSentences = new StringBuilder();
            string curLine ;
            
            for(int i = 0; i < lines.Length; ++i)
            {
                curLine = lines[i];
                while ((indexEndSent = curLine.IndexOf('.')) >= 0)
                {
                    curSentences.Clear();
                    if (indexLineStartSentences == i){
                        curSentences.Insert(0,lines[i].ToCharArray(), indexStartSentences,indexEndSent- indexStartSentences);
                    }else{
                        curSentences.Insert(0, lines[indexLineStartSentences].ToCharArray(), indexStartSentences,
                            lines[indexLineStartSentences].Length - indexStartSentences-1);

                        for (int j = indexLineStartSentences + 1; j < i; j++)
                        {
                            curSentences.Clear();
                            curSentences.Append(lines[j]);
                        }
                        curSentences.Append(lines[i].ToCharArray(), 0,indexEndSent);
                    }
                    if (indexEndSent == lines[i].Length - 1)
                    {
                        indexLineStartSentences = i + 1;
                        indexStartSentences = 0;
                    }
                    else
                    {
                        indexLineStartSentences = i;
                        indexStartSentences = indexEndSent + 1;
                    }
                    tempStr = curSentences.ToString();
                    sentences.Add(tempStr);
                    if ((indexBracket= tempStr.IndexOf(')')) >= 0){
                        if (maxBracket < (tempMax= tempStr.Count(ch=> ch == '(')))
                        {
                            maxBracket = tempMax;
                            str = tempStr;
                        }
                    }                    
                    curSentences.Clear();
                    curSentences.Append(curLine.ToCharArray(),0, indexEndSent);
                    curSentences.Append(' ');
                    if (indexEndSent < curLine.Length-1)
                    {
                        curSentences.Append(curLine.ToCharArray(),indexEndSent + 1, curLine.Length - 1- indexEndSent);
                    }
                    curLine = curSentences.ToString();
                }
                
            }

            return sentences;
        }
       
    }
}
