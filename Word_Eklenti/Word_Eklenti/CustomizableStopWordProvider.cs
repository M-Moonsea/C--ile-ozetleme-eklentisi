
using System;
using System.Collections;
using System.IO;

namespace Word_Eklenti
{
	public class CustomizableStopWordProvider : IStopWordProvider
	{
		string _path;
		string[] _words;

		public static string DEFAULT_STOPWORD_PROVIDER_FILENAME = "DefaultStopWords.txt";

		/// <param name="filename">
		///Uygulamanın kökündeki, her satırda bir tane olmak üzere, durma sözcüklerinin bir listesini içeren metin dosyasının adı
		/// </param>
		public CustomizableStopWordProvider(string filename)
		{
			_path = Directory.GetCurrentDirectory() + "\\" + filename;
			Init();
		}

		public CustomizableStopWordProvider() : this(DEFAULT_STOPWORD_PROVIDER_FILENAME) { }

		protected void Init()
		{
			ArrayList wordsList = new ArrayList();
			TextReader reader = File.OpenText(_path);

			string word;
			while ((word = reader.ReadLine()) != null)
				wordsList.Add(word.Trim());

			reader.Close();

			_words = (string[])wordsList.ToArray(typeof(string));

			Array.Sort(_words);
		}

		public bool IsStopWord(string word)
		{
			return (Array.BinarySearch(_words, word) >= 0);
		}
	}
}