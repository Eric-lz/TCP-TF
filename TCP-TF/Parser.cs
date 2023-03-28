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
    public static char[] Parse(string text)
    {
      text += '\0';  // adiciona null terminator ao fim do texto (sinal de parada)  
      return text.ToCharArray();
    }
  }
}