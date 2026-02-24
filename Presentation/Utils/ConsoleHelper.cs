using Presentation.ConsoleUI;

namespace Presentation.Utils;
public class Helper
{
    public void Color(ConsoleColor backColor, ConsoleColor letterColor)
    {
        Console.BackgroundColor = backColor;
        Console.ForegroundColor = letterColor;
    }
    public string RepeatChar(char letter, int qtd)
    {
        string result = "";
        for (int i = 0; i < qtd; i++)
        {
            result += letter;
        }
        return result;
    }
    public void CursorPosition(int x, int y) => Console.SetCursorPosition(x, y);
    public Dictionary<string, string> EnumCorrected(Type typeEnum)
    {
        var tempList = new List<char>();
        var resultDict = new Dictionary<string,string>();
        int count = 0;
        foreach (string memberEnum in Enum.GetNames(typeEnum))
        {
            foreach (char letter in memberEnum)
            {
                if (char.IsUpper(letter) && count == 0)
                {
                    tempList.Add(letter);
                }
                else if (char.IsUpper(letter))
                {
                    tempList.Add(' ');
                    tempList.Add(char.ToLower(letter));
                }
                else
                {
                    tempList.Add(letter);
                }
                count++;
            }
            resultDict.Add(string.Join("", tempList), memberEnum);
            tempList.Clear();
            count = 0;
        }
        return resultDict;
    }
}