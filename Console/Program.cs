﻿using Console;
using System;
using System.Collections.Generic;

namespace System;
internal class Program
{
    private static void Main(string[] args)
    {
        string str = "АБРАКАДАБРА"; //"В C# вы можете использовать следующий код для вывода ключей и значений словаря";
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


        Node tree = new Node();

        CreateTree(keyValuePairs, tree);

        Dictionary<char, string> keyCodes = new Dictionary<char, string>();

        CreateKeyCodes(tree, keyCodes);

        for (int i = 0; i < keyCodes.Count; i++)
        {
            Console.WriteLine($"{keyCodes.ElementAt(i).Key} {keyCodes.ElementAt(i).Value}");
        }
    }

    private static Node CreateTree(Dictionary<char, int> keyValuePairs, Node parent)
    {
        Node node = null;

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
                Console.WriteLine($"{leftSum} {rightSum} {leftSum - rightSum} {i}");
                raznica = Math.Abs(leftSum - rightSum);
                imin = i;
            }
            leftSum = 0;
            rightSum = 0;
        }

        Dictionary<char, int> leftKeyValuePairs = new Dictionary<char, int>();
        for (int i = 0; i <= imin; i++)
        {
            leftKeyValuePairs.Add(keyValuePairs.ElementAt(i).Key, keyValuePairs.ElementAt(i).Value);
        }

        Dictionary<char, int> rightKeyValuePairs = new Dictionary<char, int>();
        for (int i = imin + 1; i < keyValuePairs.Count; i++)
        {
            rightKeyValuePairs.Add(keyValuePairs.ElementAt(i).Key, keyValuePairs.ElementAt(i).Value);
        }

        if (leftKeyValuePairs.Count > 1)
        {
            parent.LeftNode = new Node() { ParentNode = parent };
            CreateTree(leftKeyValuePairs, parent.LeftNode);
        }
        else
        {
            parent.LeftNode = new Node() { ParentNode = parent, Item = leftKeyValuePairs.ElementAt(0).Key };
        }
        if (rightKeyValuePairs.Count > 1)
        {
            parent.RightNode = new Node() { ParentNode = parent };
            CreateTree(rightKeyValuePairs, parent.RightNode);
        }
        else
        {
            parent.RightNode = new Node() { ParentNode = parent, Item = rightKeyValuePairs.ElementAt(0).Key };
        }

        return node;
    }

    private static void CreateKeyCodes(Node node, Dictionary<char, string> keyCodes, string code = "")
    {
        if (node.Item == null)
        {
            if (node.LeftNode != null)
            {
                CreateKeyCodes(node.LeftNode, keyCodes, code + "0");
            }
            if (node.RightNode != null)
            {
                CreateKeyCodes(node.RightNode, keyCodes, code + "1");
            }
        }
        else
        {
            keyCodes.Add((char)node.Item, code);
        }
    }
}