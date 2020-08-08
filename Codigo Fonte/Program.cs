// AUTOR: FERNANDO ELGER

// This program is the implementation of the challenge
// of the selection process of the Laboratório de Inovação em Software (LIS)

using System;

class Program
{
    public static void Main(string[] args)
    {
        Cryptography cryptography = new Cryptography();

        string filePath = Environment.CurrentDirectory;

        filePath += @"\input\SecretMessage.txt";

        try
        {
            cryptography.BreakEncryption(filePath);
        }
        catch(Exception ex)
        {
            throw new Exception($"The program cannot find the text file path: [{ex.Message}]");
        }
    }
}