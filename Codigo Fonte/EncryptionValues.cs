using System.Collections.Generic;

// This class has a dictionary that associates each letter and symbol
// to it's numeric value to encrypt.

class EncryptionValues
{
    public Dictionary<char, int> Alphabet { get; set; }

    public EncryptionValues()
    {
        Alphabet = new Dictionary<char, int>();

        // Used primarily to add to the dictionary all the letters of the
        // alphabet with their numerical value.
        char letter = 'A';
        for (int i = 0; i < 26; i++)
        {
            Alphabet.Add(letter, i);
            letter++;
        }

        // Then the symbols are manually inserted.
        Alphabet.Add('.', 26);
        Alphabet.Add(',', 27);
        Alphabet.Add(';', 28);
        Alphabet.Add('!', 29);
        Alphabet.Add('?', 30);
    }
}