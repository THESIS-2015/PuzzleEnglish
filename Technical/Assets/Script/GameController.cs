using UnityEngine;
using System.Collections;

public class GameController : MonoSingleton<GameController> {

	// Use this for initialization
    public PictureController picController;
    public CrosswordController crosswordController;
    private bool isWin;
    private bool isLose;
    private Word currentWord;
    private int currentWordIndex;
    private int maxWordIndex;

	void Start () {
        WordData.InitData();
        GameInit();
	}

    void GameInit()
    {
        maxWordIndex = WordData.wordDataList.Count;
        if (maxWordIndex > 0)
        {
            currentWordIndex = 0;
            currentWord = WordData.wordDataList[currentWordIndex++];
        }
        else
        {
            Debug.LogError("Da xay ra loi load data");
        }
        ChangeWord(currentWord);
    }

    void GameLose()
    {

    }

    void GameWin()
    {

    }

    void ChangeWord(Word word)
    {
        if (word != null)
        {
            Sprite sprite = ResourcesController.GetPictureSprite(word.wordMedia);
            picController.SetSpriteOfPicture(sprite);
            crosswordController.ResetCrosswordGUI();
            crosswordController.InitCrosswordGUI(word.wordValue.Length);
            //crosswordController.RepawnCharacter(word.wordValue);
            //crosswordController.Test(word.wordValue);
        }
    }

    [ContextMenu("Respawn character")]
    public void Respawn(char let)
    {
        //crosswordController.RepawnCharacter(currentWord.wordValue);
        //char letter = GetLetter();
        //crosswordController.CreateCharacter(letter, currentWord.wordValue);
        crosswordController.CreateCharacter(let, currentWord.wordValue);
        //crosswordController.CreateCharacter('n', currentWord.wordValue);
    }

    //Random character
    public char GetLetter()
    {
        // This method returns a random lowercase letter.
        // ... Between 'a' and 'z' inclusize.
        int num = Random.Range(0, 26); // Zero to 25
        char let = (char)('a' + num);
        return let;
    }

	// Update is called once per frame
	void Update () {
        if (crosswordController.characterKey.Count == currentWord.wordValue.Length)
        {
            crosswordController.characterKey.Clear();
            Invoke("ChangeData", 0.5f);
        }
	}

    public void ChangeData()
    {
        if (currentWordIndex < maxWordIndex)
        {
            currentWord = WordData.wordDataList[currentWordIndex++];
            ChangeWord(currentWord);
        }
    }
}
