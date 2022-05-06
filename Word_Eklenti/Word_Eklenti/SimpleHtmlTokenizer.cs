
using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace Word_Eklenti
{
	/// <summary>
	/// Basit HTML belirteci. Amacı, normal bir web tarayıcısında görüntülenecek sözcükleri belirtmektir.
	/// </summary>
	/// <remarks>
	/// Meta etiketleri, alt veya metin niteliklerini işlemez, ancak CSS stil tanımlarını ve javascript kodunu kaldırır.
	/// 
	/// Varlık referansını bir boşlukla değiştirerek işler. Bu geçersiz kılınabilir.
	/// </remarks>
	public class SimpleHtmlTokenizer : DefaultTokenizer
	{
		/// <summary>
		/// Yapıcı, varsayılan olarak BREAK_ON_WORD_BREAKS belirteç yapılandırmasını kullanır.
		/// </summary>
		public SimpleHtmlTokenizer() : base() { }

		public SimpleHtmlTokenizer(int tokenizerConfig) : base(tokenizerConfig) { }

		public SimpleHtmlTokenizer(string regularExpression) : base(regularExpression) { }

		/// <summary>
		/// Varlık referanslarını boşluklarla değiştirir.
		/// </summary>
		/// <param name="contentsWithUnresolvedEntityReferences">Varlık referanslarına sahip içerikler..</param>
		/// <returns>Varlıkları olan içerikler boşluklarla değiştirildi..</returns>
		public string ResolveEntities(string contentsWithUnresolvedEntityReferences)
		{
			if (contentsWithUnresolvedEntityReferences == null)
				throw new ArgumentException("Cannot pass null.", "contentsWithUnresolvedEntityReferences");
			return Regex.Replace(contentsWithUnresolvedEntityReferences, "&.{2,8};", " ");
		}

		public override string[] Tokenize(string input)
		{
			Stack stack = new Stack();
			Stack tagStack = new Stack();

			// giriş dizesini yineleyin ve görüntülenecek metin bulma metnini ayrıştırın.
			char[] chars = input.ToCharArray();

			StringBuilder result = new StringBuilder();
			StringBuilder currentTagName = new StringBuilder();
			for (int i = 0; i < chars.Length; i++)
			{
				switch (chars[i])
				{
					case '<':
						stack.Push(true);
						currentTagName = new StringBuilder();
						break;
					case '>':
						stack.Pop();
						if (currentTagName != null)
						{
							string currentTag = currentTagName.ToString();
							if (currentTag.StartsWith("/"))
								tagStack.Pop();
							else
								tagStack.Push(currentTag.ToLower());
						}
						break;
					default:
						if (stack.Count == 0)
						{
							string currentTag = (string)tagStack.Peek();
							// ignore everything inside <script></script> or <style></style>
							if (currentTag != null)
							{
								if (!(currentTag.StartsWith("script") || currentTag.StartsWith("style")))
									result.Append(chars[i]);
							}
							else
								result.Append(chars[i]);
						}
						else
							currentTagName.Append(chars[i]);
						break;
				}
			}
			return base.Tokenize(ResolveEntities(result.ToString()).Trim());
		}
	}
}