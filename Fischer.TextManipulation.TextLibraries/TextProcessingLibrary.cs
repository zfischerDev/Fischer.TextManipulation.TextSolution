using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.IO.Compression;

namespace Fischer.TextManipulation.TextLibraries
{
    public class TextProcessingLibrary
    {
        #region Searching

        public List<string> GetAllSearchMatches(string filePath, string searchText)
        {
            List<string> resultsList = new List<string>();
            string fileText = File.ReadAllText(filePath);
            string textToSearchFor = searchText;
            MatchCollection matchCollection = Regex.Matches(fileText, textToSearchFor);

            foreach (Match match in matchCollection)
            {
                int startIndex = match.Index;
                StringBuilder stringBuilder = new StringBuilder();

                //Get the position in the text file
                stringBuilder.Append(string.Format($"{startIndex} : "));

                //Iterate through the characters until you get to a period
                for (int i = startIndex; i < fileText.Length; i++)
                {
                    if (fileText[i] == '.')
                    {
                        break;
                    }

                    stringBuilder.Append(fileText[i]);
                }

                resultsList.Add(stringBuilder.ToString());


            }
            //return the results
            return resultsList;

        }

        #endregion

        #region String Manipulation
        public string ReverseText(string textToReverse)
        {
            StringBuilder stringResult = new StringBuilder();

            //convert the string to a char array
            var charArray = textToReverse.ToCharArray();

            for (int i = charArray.Length - 1; i >= 0; i--)
            {
                stringResult.Append(charArray[i]);
            }

            return stringResult.ToString();
        }

        public string GetCharCount(string textToCount)
        {
            StringBuilder countResult = new StringBuilder();
            foreach (DictionaryEntry charCounts in GetCharCountHashTable(textToCount))
            {
                countResult.Append(string.Format($"'{charCounts.Key}' = {charCounts.Value} |"));
            }
            return countResult.ToString();
        }

        #endregion

        #region Private Methods 
        public Hashtable GetCharCountHashTable(string textToCount)
        {
            //convert to uppercase so all letters are counted as one case
            textToCount = textToCount.ToUpper();

            Hashtable hashtable = new Hashtable();
            for (int i = 0; i <= textToCount.Length - 1; i++)
            {
                //Do not take punctuation or whitespace
                if (!char.IsPunctuation(textToCount[i]) || 
                    char.IsWhiteSpace(textToCount[i]))
                {
                    //If hashtable has key, the letter is already counted
                    if (hashtable.ContainsKey(textToCount[i]))
                    {
                        int hashTableValue = (int)hashtable[textToCount[i]];
                        hashtable[textToCount[i]] = hashTableValue + 1;
                    }
                    else
                    {
                        //Add the letter to the hashtable
                        hashtable.Add(textToCount[i], 1);
                    }
                }
            }
            
            return hashtable;
        }

        #endregion
    }
}

