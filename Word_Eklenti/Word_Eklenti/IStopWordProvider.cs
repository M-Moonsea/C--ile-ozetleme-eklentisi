
using System;

namespace Word_Eklenti
{
    /// <summary>
    /// Durdurma kelimesinin belirlenmesi için bir arayüz tanımlar.
    /// </summary>
    public interface IStopWordProvider
    {
        /// <summary>
        /// Belirtilen sözcüğün bir durdurma sözcüğü olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="word">Kontrol edilecek kelime.</param>
        bool IsStopWord(string word);
    }
}
