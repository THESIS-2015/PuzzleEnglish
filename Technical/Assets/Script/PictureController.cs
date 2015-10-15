using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PictureController : MonoBehaviour
{
    private Sprite picValueCurrent;
    public Image picImage;

    public void SetSpriteOfPicture(Sprite sprite)
    {
        if (sprite != null)
        {
            this.picValueCurrent = sprite;
            this.picImage.sprite = sprite;
        }
        
    }
}
