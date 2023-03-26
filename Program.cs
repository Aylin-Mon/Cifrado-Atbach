#pragma warning disable CS8600

using System;

public static class AtbashCipher
{
    public static string Encrypt(this string plainText)
    {
        string result = "";
        foreach (char c in plainText)
        {
            if (char.IsLetter(c))
            {
                char letter = char.ToLower(c);
                int distance = letter - 'a';
                char encrypted = (char)('z' - distance);
                if (char.IsUpper(c))
                {
                    encrypted = char.ToUpper(encrypted);
                }
                result += encrypted;
            }
            else
            {
                result += c;
            }
        }
        return result;
    }

    public static string Decrypt(this string cipherText)
    {
        return Encrypt(cipherText);
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Ingrese una cadena de texto (o escriba 'salir' para terminar):");
            string input = Console.ReadLine();
            if (input?.ToLower() == "salir")
            {
                exit = true;
            }
            else
            {
                string cipherText = input?.Encrypt();
                Console.WriteLine($"Cadena cifrada: {cipherText}");
                string decryptedText = cipherText?.Decrypt();
                Console.WriteLine($"Cadena descifrada: {decryptedText}");
            }
        }
    }
}

