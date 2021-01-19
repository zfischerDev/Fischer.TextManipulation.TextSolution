using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
namespace Fischer.TextManipulation.TextLibraries
{
    public class TextProcessingLibrary
    {
        public List<string> GetAllSearchMatches(string filePath, string searchText)
        {
            List<string> resultsList = new List<string>();
            string fileText = File.ReadAllText(filePath);
            string textToSearchFor = searchText;
            MatchCollection matchCollection = Regex.Matches(fileText, textToSearchFor);

            foreach (Match match in matchCollection)
            {
                try
                {
                    int startIndex = match.Index;
                    int endIndex = startIndex + fileText.IndexOf('.');
                    int endOfText = endIndex >= fileText.Length ? fileText.Length : endIndex;
                    int textLength = fileText.Length;
                    int theLength = (endOfText - startIndex);
                    string theSubstringText = fileText.Substring(startIndex, theLength);
                    string theResult = string.Format($"{startIndex} ~ {endOfText}: {theSubstringText}");
                    resultsList.Add(theResult);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
            //return the results
            return resultsList;
        }
    }
}
