using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Panel : MonoBehaviour
{
    public Image targetImage;
    public Text targetText;

    public void LoadContent(int idx)
    {
        Texture2D loadedTexture = Resources.Load<Texture2D>("6teamMember" + idx);
        if(loadedTexture != null)
        {
            targetImage.sprite = Sprite.Create(loadedTexture, new Rect(0, 0, loadedTexture.width, loadedTexture.height), Vector2.one * 0.5f);
        }
        TextAsset loadedTextAsset = Resources.Load<TextAsset>("text" + idx);
        if(loadedTextAsset != null)
        {
            targetText.text = loadedTextAsset.text;
        }
    }
}
