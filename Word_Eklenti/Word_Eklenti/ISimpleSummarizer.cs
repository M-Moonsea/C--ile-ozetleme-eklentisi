using System;


namespace Word_Eklenti.Summarizer
{
    interface ISimpleSummarizer
    {
        string Summarize(string input, int numberOfSentences);
    }
}
