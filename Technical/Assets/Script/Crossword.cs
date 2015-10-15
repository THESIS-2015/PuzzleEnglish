using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Crossword : MonoBehaviour {

	//Thong tin doi tuong
    public Image crosswordImage;
    public Sprite crosswordSprite;
    public string crosswordcharacter;

	void Start () {
       
	
	}

    public void SetCharacter(string character)
    {
        this.crosswordcharacter = character;
    }

    public void SetSprite(Sprite sprite)
    {
        if (sprite != null)
        {
            this.crosswordSprite = sprite;
            crosswordImage.sprite = this.crosswordSprite;
        }
        else
        {
            crosswordImage.sprite = ResourcesController.GetCharacterSprite("Basic");
        }
    }

    private Vector3 startScale;
    private Vector3 startPosition;
    private Vector3 endPosition;
    public void Move(Vector3 endPosition)
    {
        this.startPosition = transform.localPosition;
        this.endPosition = endPosition;
        iTween.MoveTo(gameObject, iTween.Hash("islocal", true, "y", startPosition.y + 200, "time", 2.0f, "easeType", iTween.EaseType.easeInOutExpo, "onComplete", "Back"));
    }

    public void Back()
    {
        iTween.MoveTo(gameObject, iTween.Hash("islocal", true, "position", endPosition, "time", 2.0f, "easeType", iTween.EaseType.easeInOutExpo));
    }

    public void ZoomIn()
    {
        startScale = transform.localScale;
        iTween.ScaleTo(gameObject, iTween.Hash("islocal", true, "scale", new Vector3(3.5f, 3.5f, 3.5f), "time", 2.0f, "easeType", iTween.EaseType.easeInOutBack, "onComplete", "ZoomOut"));
    }

    public void ZoomOut()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("islocal", true, "scale", startScale, "time", 1.5f, "easeType", iTween.EaseType.easeInOutBack));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
