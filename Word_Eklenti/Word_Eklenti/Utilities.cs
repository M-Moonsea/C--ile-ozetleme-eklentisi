
using System;
using System.Collections;
using System.Text.RegularExpressions;


namespace Word_Eklenti
{
	public class Utilities
	{
		public static Hashtable GetWordFrequency(string input) 
		{
			return GetWordFrequency(input, false);
		}

		public static Hashtable GetWordFrequency(string input, bool caseSensitive)  //kelime sıklığını alır.
		{
			DefaultStopWordProvider data = new DefaultStopWordProvider();
			data.readFile();
			return GetWordFrequency(input, caseSensitive, new DefaultTokenizer(), data);
		}


		// Her kelimenin sayısını temsil eden bir kelime ve tamsayı Hashtable'ı alır.
		/// <param name="input">Kelime frekansını alacak dize.</param>
		/// <param name="caseSensitive">Farklı büyük/küçük harfe sahip olmaları durumunda sözcüklerin ayrı olarak ele alınması gerekiyorsa doğrudur.</param>
		/// <param name="tokenizer">Bir ITokenizer örneği.</param>
		/// <param name="stopWordProvider">IStopWordProvider örneği.</param>
		/// <returns></returns>
		public static Hashtable GetWordFrequency(string input, bool caseSensitive, ITokenizer tokenizer, IStopWordProvider stopWordProvider)
		{
			string convertedInput = input;
			if (!caseSensitive)
				convertedInput = input.ToLower();

			string[] words = tokenizer.Tokenize(convertedInput);
			Array.Sort(words);

			string[] uniqueWords = GetUniqueWords(words);

			Hashtable result = new Hashtable();
			for (int i = 0; i < uniqueWords.Length; i++)
			{
				if (stopWordProvider == null || (IsWord(uniqueWords[i]) && !stopWordProvider.IsStopWord(uniqueWords[i])))
				{
					if (result.ContainsKey(uniqueWords[i]))
						result[uniqueWords[i]] = (int)result[uniqueWords[i]] + CountWords(uniqueWords[i], words);
					else
						result.Add(uniqueWords[i], CountWords(uniqueWords[i], words));
				}
			}

			return result;
		}

		public static bool IsWord(string word)
		{
			if (word != null && word.Trim() != string.Empty)
				return true;
			else
				return false;
		}

		/// <summary>
		/// Bir dizi sözcükteki tüm benzersiz sözcükleri bulun.
		/// </summary>
		/// <param name="input">An array of strings.</param>
		/// <returns>Tüm benzersiz dizelerden oluşan bir dizi. Sipariş garanti edilmez.</returns>
		public static string[] GetUniqueWords(string[] input)
		{
			if (input == null)
				return new string[0];
			else
			{
				ArrayList result = new ArrayList();
				for (int i = 0; i < input.Length; i++)
					if (!result.Contains(input[i]))
						result.Add(input[i]);
				return (string[])result.ToArray("".GetType());
			}
		}

		/// <summary>
		/// Bir kelime dizisinde bir kelimenin kaç kez göründüğünü sayın.
		/// </summary>
		/// <param name="word">sayılacak kelime.</param>
		/// <param name="words">Boş olmayan bir kelime dizisi.</param>
		public static int CountWords(string word, string[] words)
		{

			// dizideki öğelerden birinin dizinini bulma
			int itemIndex = Array.BinarySearch(words, word);

			// ilk eşleşmeyi bulana kadar geriye doğru yineleyin

			// now itemIndex is kelimelerin başlangıcından önce bir öğe
			int count = 0;
			itemIndex = 0;
            while (itemIndex < words.Length && itemIndex >= 0)
            {
                EnglishStemmer.EnglishWord s = new EnglishStemmer.EnglishWord(words[itemIndex].ToString());
                String output1 = s.Stem.ToLower();

                EnglishStemmer.EnglishWord s1 = new EnglishStemmer.EnglishWord(word);
                String output2 = s1.Stem.ToLower();

                if (words[itemIndex] == word)
                    count++;
                else if (output1 == output2)
                    count++;


                itemIndex++;

                
            }

            return count;
		}

		/// <summary>
		/// Bir dizi cümle alır.
		/// </summary>
		/// <param name="input">Cümleler içeren bir dize.</param>
		/// <returns>her eleman bir cümle içeren bir dizi .</returns>
		public static string[] GetSentences(string input)
		{
			if (input == null)
				return new string[0];
			else
			{
				// split on a ".", a "!", a "?" followed by a space or EOL
				// the original Java regex was (\.|!|\?)+(\s|\z)
				string[] result = Regex.Split(input, @"(?:\.|!|\?)+(?:\s+|\z)");

				// hacky... doing this to pass the unit tests
				ArrayList list = new ArrayList();
				foreach (string s in result)
					if (s.Length > 0)
						list.Add(s);
				return (string[])list.ToArray(typeof(string));
			}
		}
	}
}
