
using System;
using System.Collections;
using System.IO;


namespace Word_Eklenti
{
	public class DefaultStopWordProvider : IStopWordProvider
	{
		#region Fields
		string[] _stopWords =
		{
			"a", "and", "the", "me", "i", "of", "if", "it",
			"is", "they", "there", "but", "or", "to", "this", "you",
			"in", "your", "on", "for", "as", "are", "that", "with",
			"have", "be", "at", "or", "was", "so", "out", "not", "an",
			"ve","veya","kadar","ama","bu","ben","için","eğer","o","onlar","burası","yada","sen",
			"içinde","senin","onun","ile","bunun","benim","senin","fakat","lakin","dolayısıyla","bu yüzden"
		};

        public void readFile()
        {
            ArrayList al = new ArrayList();
            StreamReader st = new StreamReader("DefaultStopWords.txt");
            while (!st.EndOfStream)
            {
                al.Add(st.ReadLine());
            }

            _stopWords = new string[al.Count];
            for (int i = 0; i < al.Count; i++)
            {
                _stopWords[i] = al[i].ToString();
            }

            _sortedStopWords = _stopWords;
            Array.Sort(_sortedStopWords);
        }

        string[] _sortedStopWords = null;
		#endregion

		public string[] StopWords { get { return _stopWords; } }

		public DefaultStopWordProvider()
		{
			_sortedStopWords = _stopWords;
			Array.Sort(_sortedStopWords);
		}

		public bool IsStopWord(string word)
		{
			if (word == null || word == string.Empty)
				return false;
			else
				return Array.BinarySearch(_sortedStopWords, word.ToLower()) >= 0;
		}
	}
}