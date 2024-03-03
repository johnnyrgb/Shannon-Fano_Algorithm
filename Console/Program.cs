using Console;
using System;
using System.Collections.Generic;

namespace System;
internal class Program
{
    private static void Main(string[] args)
    {
        string codeString = "ЕВГЕНИЙ РАФАИЛОВИЧ ПАТИЛЕЕВ"; //"В C# вы можете использовать следующий код для вывода ключей и значений словаря";
        
        Coder coder = new Coder();
        string returnString = coder.Coding(codeString);

        Console.WriteLine(returnString);

        Decoder decoder = new Decoder();
        codeString = decoder.Decoding(returnString);

        Console.WriteLine(codeString);
    }
}