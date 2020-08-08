using System;
using System.Collections.Generic;

// This class has a list of the top 10 highest frequencies of English letters,
// based on a sample of 40,000 words.
// Reference: http://pi.math.cornell.edu/~mec/2003-2004/cryptography/subs/frequencies.html

public class EnglishLetterFrequency
{
    public List<Char> OrderedLetters { get; set; }

    public EnglishLetterFrequency()
    {
        OrderedLetters = new List<Char> {'E', 'T', 'A', 'O', 'I', 'N', 'S', 'R', 'H', 'D'};
    }


    // Removes and returns the first element in the list.
    public Char RemoveFirst()
    {
        try
        {
            Char c = OrderedLetters[0];
            OrderedLetters.RemoveAt(0);
            return c;
        }
        catch (ArgumentNullException ex)
        {
            throw new Exception($"The english letter frequency list is empty: [{ex.Message}]");
        }
    }
}