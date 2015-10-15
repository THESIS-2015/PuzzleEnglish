using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Word{

    public string wordValue;
    public string wordMedia;

    public Word(string value, string media)
    {
        wordValue = value;
        wordMedia = media;
    }

    public Word()
    {

    }
}


public class WordData{

    public static List<Word> wordDataList = new List<Word>();

    public static void InitData()
    {
        wordDataList.Add(new Word("anemone", "anemone"));
        wordDataList.Add(new Word("crocus", "crocus"));
        wordDataList.Add(new Word("daffodil", "daffodil"));
        wordDataList.Add(new Word("daisy", "daisy"));
        wordDataList.Add(new Word("freesia", "freesia"));
        wordDataList.Add(new Word("iris", "iris"));
        wordDataList.Add(new Word("lilac", "lilac"));
        wordDataList.Add(new Word("snowdrops", "snowdrops"));
        wordDataList.Add(new Word("tulip", "tulip"));
        wordDataList.Add(new Word("violet", "violet"));
    }
}