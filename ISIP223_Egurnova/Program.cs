using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Egurnova
{
    class Program
    {
        static List<string> history = new List<string>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("1. Анализ текста");
                Console.WriteLine("2. История");
                Console.WriteLine("3. Выход");
                Console.Write("Выбор: ");

                string choice = Console.ReadLine();

                if (choice == "1") AnalyzeText();
                else if (choice == "2") ShowHistory();
                else if (choice == "3") break;
            }
        }

        static void AnalyzeText()
        {
            var bufsize = 1000;
            Stream stream = Console.OpenStandardInput(bufsize);
            TextReader inReader = (stream == Stream.Null) ?
            StreamReader.Null :
            TextReader.Synchronized(
            new StreamReader(stream, Console.InputEncoding, false, bufsize, true));
            Console.SetIn(inReader);
            Console.Write("Введите текст (мин 100 символов): ");
            string text = Console.ReadLine();

            if (text.Length < 100)
            {
                Console.WriteLine("Мало символов! Введено: " + text.Length);
                return;
            }

            int words = CountWords(text);
            string shortest = FindShortestWord(text);
            string longest = FindLongestWord(text);
            int sentences = CountSentences(text);
            int vowels = CountVowels(text);
            int consonants = CountConsonants(text);

            string result = $"Слов: {words}, Предложений: {sentences}, Гласных: {vowels}, Согласных: {consonants}";
            history.Add(result);

            Console.WriteLine($"Слов: {words}");
            Console.WriteLine($"Предложений: {sentences}");
            Console.WriteLine($"Короткое слово: {shortest}");
            Console.WriteLine($"Длинное слово: {longest}");
            Console.WriteLine($"Гласных: {vowels}");
            Console.WriteLine($"Согласных: {consonants}");
            ShowLetterStats(text);
        }

        static string[] GetWords(string text)
        {
            string[] words = new string[1000];
            int wordCount = 0;
            string current = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetterOrDigit(text[i]) || (text[i] == '.' && current != ""))
                {
                    current += text[i];
                }
                else if (current != "")
                {
                    words[wordCount] = current;
                    wordCount++;
                    current = "";
                }
            }

            if (current != "")
            {
                words[wordCount] = current;
                wordCount++;
            }

            string[] result = new string[wordCount];
            for (int i = 0; i < wordCount; i++)
            {
                result[i] = words[i];
            }
            return result;
        }
        static int CountWords(string text)
        {
            int count = 0;
            bool inWord = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetterOrDigit(text[i]) || (text[i] == '.' && inWord))
                {
                    if (!inWord)
                    {
                        count++;
                        inWord = true;
                    }
                }
                else
                {
                    inWord = false;
                }
            }
            return count;
        }

        static string FindShortestWord(string text)
        {
            string[] words = GetWords(text);
            if (words.Length == 0) return "нет";

            string shortest = words[0];
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i].Length < shortest.Length)
                    shortest = words[i];
            }
            return shortest;
        }

        static string FindLongestWord(string text)
        {
            string[] words = GetWords(text);
            if (words.Length == 0) return "нет";

            string longest = words[0];
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i].Length > longest.Length)
                    longest = words[i];
            }
            return longest;
        }



        static int CountSentences(string text)
        {
            int count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '.' || text[i] == '!' || text[i] == '?')
                {
                    if (i == text.Length - 1 || char.IsWhiteSpace(text[i + 1]) || text[i + 1] == '"')
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        static int CountVowels(string text)
        {
            int count = 0;
            string vowels = "аеёиоуыэюяaeiou";

            for (int i = 0; i < text.Length; i++)
            {
                char c = char.ToLower(text[i]);
                for (int j = 0; j < vowels.Length; j++)
                {
                    if (c == vowels[j])
                    {
                        count++;
                        break;
                    }
                }
            }
            return count;
        }

        static int CountConsonants(string text)
        {
            int count = 0;
            string consonants = "бвгджзйклмнпрстфхцчшщbcdfghjklmnpqrstvwxyz";

            for (int i = 0; i < text.Length; i++)
            {
                char c = char.ToLower(text[i]);
                for (int j = 0; j < consonants.Length; j++)
                {
                    if (c == consonants[j])
                    {
                        count++;
                        break;
                    }
                }
            }
            return count;
        }

        static void ShowLetterStats(string text)
        {
            int[] letterCounts = new int[59];
            char[] letters = new char[59];

            string russian = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            for (int i = 0; i < 33; i++)
            {
                letters[i] = russian[i];
            }

            string english = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < 26; i++)
            {
                letters[33 + i] = english[i];
            }

            for (int i = 0; i < text.Length; i++)
            {
                char c = char.ToLower(text[i]);
                for (int j = 0; j < letters.Length; j++)
                {
                    if (c == letters[j])
                    {
                        letterCounts[j]++;
                        break;
                    }
                }
            }

            Console.WriteLine("Статистика букв:");
            for (int i = 0; i < letters.Length; i++)
            {
                if (letterCounts[i] > 0)
                {
                    Console.WriteLine($"{letters[i]}: {letterCounts[i]}");
                }
            }
        }

        static void ShowHistory()
        {
            Console.WriteLine("История:");
            for (int i = 0; i < history.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {history[i]}");
            }
        }
    }
}