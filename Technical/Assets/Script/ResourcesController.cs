using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourcesController : MonoBehaviour {

	// Use this for initialization
    public static Dictionary<string, Sprite> pictureLibrary;
    public static Dictionary<string, Sprite> characterLibrary;

	void Start () {
        pictureLibrary = new Dictionary<string, Sprite>();
        characterLibrary = new Dictionary<string, Sprite>();
        LoadSpriteFromFile("Image/Picture",ref pictureLibrary);
        LoadSpriteFromFile("Image/Alphabet", ref characterLibrary);
	}

    public static void LoadSpriteFromFile(string filePath, ref Dictionary<string, Sprite> source)
    {
        if (!string.IsNullOrEmpty(filePath))
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>(filePath);
            foreach (var item in sprites)
            {
                source.Add(item.name, item);
            }
        }
    }

    public static Sprite GetCharacterSprite(string spriteName)
    {
        if (characterLibrary != null)
        {
            if (characterLibrary.ContainsKey(spriteName))
            {
                return characterLibrary[spriteName];
            }
        }
        return null;
    }

    public static Sprite GetPictureSprite(string spriteName)
    {
        if (pictureLibrary != null)
        {
            if (pictureLibrary.ContainsKey(spriteName))
            {
                return pictureLibrary[spriteName];
            }
        }
        return null;
    }
}
