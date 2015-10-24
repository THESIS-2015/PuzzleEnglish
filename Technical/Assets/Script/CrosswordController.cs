using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrosswordController : MonoBehaviour {

	// Use this for initialization
    private const int CROSSWORD_COUNT_MAX = 11;
    public GameObject[] crosswordList;
    public Transform repawnPosition;
    public GameObject characterPrefab;
    public List<int> characterKey;
    private int crosswordObjectCount;
    private int crosswordCountCurrent;
    

    public void Awake()
    {
        if (crosswordList != null)
        {
            crosswordObjectCount = crosswordList.Length;
        }
        characterKey = new List<int>();
    }

    public void InitCrosswordGUI(int crosswordCount){
        if (crosswordCount > CROSSWORD_COUNT_MAX)
        {
            Debug.LogError("Khong the khoi tao");
            return;
        }
        if (crosswordObjectCount <= 0)
        {
            Debug.LogError("List rong");
            return;
        }
        this.crosswordCountCurrent = crosswordCount;
        for (int i = 0; i < crosswordObjectCount; i++)
        {
            if (i < crosswordCount)
            {
                crosswordList[i].SetActive(true);
            }
        }
    }


    public void ResetCrosswordGUI()
    {
        if (crosswordCountCurrent > CROSSWORD_COUNT_MAX)
        {
            Debug.LogError("Khong the khoi tao");
            return;
        }
        if (crosswordObjectCount <= 0)
        {
            Debug.LogError("List rong");
            return;
        }
        Crossword crossWord;
        for (int i = 0; i < crosswordCountCurrent; i++)
        {
            if (i < crosswordCountCurrent)
            {
                crosswordList[i].SetActive(false);
                crossWord = crosswordList[i].GetComponent<Crossword>();
                crossWord.crosswordSprite = ResourcesController.GetCharacterSprite("Basic");
                crossWord.crosswordcharacter = "";
            }
        }
    }

    public int GetCrosswordIndex(char character, string word)
    {
        if(!string.IsNullOrEmpty(word.Trim())){
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i].Equals(character) && !characterKey.Contains(i))
                {
                    return i;
                }
            }
        }
        return -1;
    }

    [ContextMenu("Repawn Character")]
    public void RepawnCharacter(string word)
    {
        Crossword crossWord;
        Sprite sprite;
        for (int i = 0; i < word.Length; i++)
        {
            //
            GameObject newCharacter = GameObject.Instantiate(characterPrefab);
            newCharacter.transform.SetParent(repawnPosition.parent);
            newCharacter.transform.position = repawnPosition.position;
            //
            crossWord = newCharacter.GetComponent<Crossword>();
            sprite = ResourcesController.GetCharacterSprite(char.ToUpper(word[i]).ToString());
            crossWord.SetSprite(sprite);
            crossWord.SetCharacter(word[i].ToString());
            crossWord.Move(crosswordList[i].transform.localPosition);
            crossWord.ZoomIn();
        }
        //iTween.MoveTo(newCharacter, iTween.Hash("islocal", true, "y", repawnPosition.position.y + 100, "time", 3.0f, "easeType", iTween.EaseType.easeInOutExpo, "onComplete"));
        //iTween.ScaleTo(newCharacter, iTween.Hash("islocal", true, "scale", new Vector3(2.5f, 2.5f, 2.5f), "time", 3.0f, "easeType", iTween.EaseType.easeInOutBack));
    }

    public bool CreateCharacter(char character, string word)
    {
        Crossword crossWord;
        Sprite sprite;
        int index = this.GetCrosswordIndex(character, word);
        if (index != -1 && !characterKey.Contains(index))
        {
            characterKey.Add(index);
            //
            GameObject newCharacter = GameObject.Instantiate(characterPrefab);
            newCharacter.transform.SetParent(repawnPosition.parent);
            newCharacter.transform.position = repawnPosition.position;
            newCharacter.GetComponent<RectTransform>().sizeDelta = crosswordList[index].GetComponent<RectTransform>().sizeDelta;
            //
            crossWord = newCharacter.GetComponent<Crossword>();
            sprite = ResourcesController.GetCharacterSprite(char.ToUpper(character).ToString());
            crossWord.SetSprite(sprite);
            crossWord.SetCharacter(character.ToString());
            crossWord.Move(crosswordList[index].transform.localPosition);
            crossWord.ZoomIn();
            //r
            Debug.Log("A: " + characterKey.Count);
            Debug.Log("B: " + word.Length);
            return true;
        }
        return false;
    }

    //Test
    public void Test(string word)
    {
        Crossword crossWord;
        Sprite sprite;
        for (int i = 0; i < word.Length; i++)
        {
            Debug.Log(char.ToUpper(word[i]));
            crossWord = crosswordList[i].GetComponent<Crossword>();
            sprite = ResourcesController.GetCharacterSprite(char.ToUpper(word[i]).ToString());
            crossWord.SetSprite(sprite);
            crossWord.SetCharacter(word[i].ToString());
        }
    }
}
