
using System;
using Word_Eklenti.Summarizer;

namespace TextAnalysis.Tests.Summarizer
{
	public class SimpleSummarizerTest
	{
		SimpleSummarizer summarizer = null;

		public void Setup()
		{
			summarizer = new SimpleSummarizer();
		}

		public void TearDown()
		{
			summarizer = null;
		}


		public string TestSummarize(string input, int line)
		{
			Setup();
			//string input = "Metin Analizi, metinle çalışmak için bir dotnet derlemesidir. Metin Analizi bir özetleyici içerir.";
			//string expected
			//Result = "TextAnalysis, metinle çalışmak için bir dotnet derlemesidir.";
			string result = summarizer.Summarize(input, line);
			//Assert.AreEqual(expectedResult, result);

			//input = "TextAnalysis, metinle çalışmak için bir dotnet derlemesidir. TextAnalysis bir özetleyici içerir. Özetleyici, metnin özetine izin verir. Bir Özetleyici gerçekten harika. Başka dotnet özetleyici olduğunu sanmıyorum.";
			//expectedResult = "TextAnalysis is a dotnet assembly for working with text. TextAnalysis includes a summarizer.";
			//result = summarizer.Summarize(input, 2);
			//Assert.AreEqual(expectedResult, result);
			TearDown();

			return result;
		}
	}
}