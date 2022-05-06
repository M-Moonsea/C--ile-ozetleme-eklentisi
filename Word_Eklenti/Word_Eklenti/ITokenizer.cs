
using System;

namespace Word_Eklenti
{
    /// <summary>
    /// Dizelerin belirteçlere bölünmesi için bir arabirim tanımlar.
    /// </summary>
    public interface ITokenizer
    {
        /// <summary>
        /// Girdi dizesini, her birinin ayrı olasılıkları olan belirteçlere böler.
        /// </summary>
        /// <param name="input">Belirtilecek dize.</param>
        string[] Tokenize(string input);
    }
}
