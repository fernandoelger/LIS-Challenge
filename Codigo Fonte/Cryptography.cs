using System;
using System.IO;
using System.Linq;

public class Cryptography
{
    private EncryptionValues EncryptionValues;
    private EnglishLetterFrequency LetterFrequency;
    private Char mostOccurrenceChar;
    private string Ciphertext;

    public Cryptography()
    {
        EncryptionValues = new EncryptionValues();

        LetterFrequency = new EnglishLetterFrequency();
    }


    public void BreakEncryption(string filePath)
    {
        // Used to separate the lines of the ciphertext by
        // adding a blank space between them.
        string[] fileContent = File.ReadAllLines(filePath);
        Ciphertext = String.Join(" ", fileContent);

        // Removes all incidences of "#" to find the most
        // occurrence letter in ciphertext.
        string words = Ciphertext.Replace("#", "");
        MostOccurrenceChar(words);

        Boolean hasDecode = false;
        // In case of the encryption is not decrypted, a new attempt is made
        // to discover the key with the next most frequent English letter.
        while (!hasDecode)
        {
            Char mostFrequency = LetterFrequency.RemoveFirst();

            int key = DiscoverKey(mostFrequency);
            Decode(key);

            Console.WriteLine("\nIs the message decoded?\n");
            Console.WriteLine("1- Yes, I can read the message!");
            Console.WriteLine("2- No, try again with another english letter frequency.");
            int input = Convert.ToInt32(Console.ReadLine());
            if (input == 1)
            {
                hasDecode = true;
            }
        }
    }

    // Finds the most occurrence letter in ciphertext.
    // Time complexity of this method is O(n).
    private void MostOccurrenceChar(string words)
    {
        // Initialized with size 120 because it's the number of elements that the ASCII table has.
        int[] OccurrenceCount = new int[120];
        int max = 0;

        // Iterates the ciphertext to discover the letter that has the higher occurrence count.
        foreach (Char c in words)
        {
            if (++OccurrenceCount[c] > max)
            {
                max = OccurrenceCount[c];
                mostOccurrenceChar = c;
            }
        }
    }

    // Discovers the key by associating the most occurrence letter
    // in ciphertext with the highest frequencie of English letters.
    private int DiscoverKey(Char mostFrequencyChar)
    {
        // Get character values
        int mostFrequencyValue = EncryptionValues.Alphabet[mostFrequencyChar];
        int mostOccurrenceValue = EncryptionValues.Alphabet[mostOccurrenceChar];

        // Decreases the value of the alphabet size to be able
        // to define the key, which is the distance between the characters.
        mostOccurrenceValue = EncryptionValues.Alphabet.Count - mostOccurrenceValue;
        int key = mostFrequencyValue + mostOccurrenceValue;

        return key;
    }

    // Concatenates characteres in the plaintext according to the key.
    // Time complexity of this method is (O(n) * key number).
    private void Decode(int key)
    {
        string plaintext = "\n";

        for (int i = 0; i < Ciphertext.Length; i++)
        {
            int cipher = 0;
            Char c = Ciphertext[i];

            // Adds a black space in the plaintext.
            if (c == '#')
            {
                plaintext += " ";
            }
            // Breaks the line in the same position as the ciphertext.
            else if (c == ' ')
            {
                plaintext += "\n";
            }
            else
            {
                // Get character value and increment the number of times of the key value.
                cipher = EncryptionValues.Alphabet[c];

                for (int j = key; j > 0; j--)
                {
                    cipher++;

                    // If it's the last position of the alphabet, jump to the beginning.
                    if (cipher == 31)
                    {
                        cipher = 0;
                    }
                }
                // Concatenates the letter or symbol associated to the real value.
                plaintext += EncryptionValues.Alphabet.FirstOrDefault(x => x.Value == cipher).Key;
            }
        }

        Console.WriteLine($"{plaintext}");
    }
}