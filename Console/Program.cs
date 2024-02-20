using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        string str = "В C# вы можете использовать следующий код для вывода ключей и значений словаря";
        Dictionary<char, int> keyValuePairs = new Dictionary<char, int>(); // заполнение словоря буквами из которых состоят входные данные и высчитываем частоту их появления
        for (int i = 0; i < str.Length; i++)
        {
            if (keyValuePairs.ContainsKey(str[i]))
            {
                keyValuePairs[str[i]]++;
            }
            else
            {
                keyValuePairs.Add(str[i], 1);
            }
        }

        keyValuePairs = new Dictionary<char, int>(keyValuePairs.OrderByDescending(i => i.Value)); 

        foreach (KeyValuePair<char, int> item in keyValuePairs)
        {
            System.Console.WriteLine("Ключ: {0}, Значение: {1}", item.Key, item.Value);
        }

        int leftSum = 0;
        int rightSum = 0;
        int raznica = int.MaxValue;
        int imin = 0;

        for (int i = 0; i < keyValuePairs.Count - 1; i++) 
        {
            for (int j = 0; j <= i; j++)
            {
                leftSum += keyValuePairs.ElementAt(j).Value;
            }
            for (int j = i + 1; j < keyValuePairs.Count; j++)
            {
                rightSum += keyValuePairs.ElementAt(j).Value;
            }
            if (Math.Abs(leftSum - rightSum) <= raznica)
            {
                raznica = Math.Abs(leftSum - rightSum);
                imin = i;
            }
        }
    }
}