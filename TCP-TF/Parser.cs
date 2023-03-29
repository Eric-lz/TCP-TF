namespace TCP_TF
{
  public class Parser
  {
    /// <summary>
    /// Construtor do Parser.
    /// </summary>
    public Parser() { }

    /// <summary>
    /// Recebe uma string, adiciona null terminator '\0' e converte para array de char
    /// </summary>
    /// <param name="text">String de entrada (texto livre)</param>
    /// <returns>Null terminated char array</returns>
    public static char[] Parse(string text)
    {
      text += '\0';  // adiciona null terminator ao fim do texto (sinal de parada)  
      return text.ToCharArray();
    }
  }
}