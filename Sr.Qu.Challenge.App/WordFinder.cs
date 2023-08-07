using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sr.Qu.Challenge.App
{
    public class WordFinder
    {
        private const int maxColumns = 64;
        private const int maxRows = 64;
        private IEnumerable<string> _rows;
        private IEnumerable<string> _columns;

        public WordFinder(IEnumerable<string> matrix)
        {
            ValidateMatrix(matrix);
            _rows = matrix;
            _columns = GetColumns(matrix);
        }

        /// <summary>
        /// Return the top 10 most repeated words from the word stream found in the matrix.
        /// </summary>
        /// <param name="wordstream"></param>
        /// <returns>Return the top 10 most repeated words from the word stream found in the matrix.</returns>
        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (var word in wordstream.Distinct())
            {
                int count = 0;
                foreach (var row in _rows)
                {
                    count += CountOccurrences(row, word);
                }
                foreach (var column in _columns)
                {
                    count += CountOccurrences(column, word);
                }

                if (count != 0)
                {
                    wordCount.Add(word, count);
                }
            }

            return wordCount.OrderByDescending(x => x.Value).Select(s => s.Key).Take(10);
        }

        /// <summary>
        /// Get the times of occurrences of a word on a string.
        /// </summary>
        /// <param name="mainString"></param>
        /// <param name="word"></param>
        /// <returns>Count of ocurrences of a word on a string.</returns>
        private int CountOccurrences(string mainString, string word)
        {
            int count = 0;
            int index = mainString.IndexOf(word);

            while (index != -1)
            {
                count++;
                index = mainString.IndexOf(word, index + word.Length);
            }

            return count;
        }

        /// <summary>
        /// Get the list of columns from the Matrix.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns>List of columns.</returns>
        private IEnumerable<string> GetColumns(IEnumerable<string> matrix)
        {
            List<string> columns = new List<string>();

            int lenght = matrix.FirstOrDefault().Length;

            for (int i = 0; i < lenght; i++)
            {
                string newColumn = "";
                foreach (string row in matrix)
                {
                    newColumn += row[i];
                }
                columns.Add(newColumn);
            }

            return columns;
        }


        /// <summary>
        /// Validates the matrix input.
        /// </summary>
        /// <param name="matrix"></param>
        private bool ValidateMatrix(IEnumerable<string> matrix)
        {
            if (matrix == null || !matrix.Any())
            {
                throw new ArgumentNullException("The matrix is empty.");
            }

            int lenght = matrix.FirstOrDefault().Length;

            if (matrix.Count() > maxRows || matrix.First().Length > maxColumns)
            {
                throw new ArgumentException($"The matrix is larger than {maxRows}.");
            }

            if (matrix.Any(s => s.Length != lenght))
            {
                throw new ArgumentException($"The matrix rows must have the same lenght.");
            }

            return true;
        }
    }
}
