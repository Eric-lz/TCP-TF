namespace TCP_TF
{
    public class Parser
    {
        /// <summary>
        /// Construtor do Parser.
        /// </summary>
        public Parser() { }

        /// <summary>
        /// Transforma uma string em uma cadeia de caracteres.
        /// </summary>
        public char[] Parse(string text)
        {
            return text.ToCharArray();
        }
    }
}