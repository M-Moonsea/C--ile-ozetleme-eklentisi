using System;
namespace Word_Eklenti.Summarizer
{
    public interface ISummarizer
    {
        string Summarize(string input, int numberOfSentences);
    }
}