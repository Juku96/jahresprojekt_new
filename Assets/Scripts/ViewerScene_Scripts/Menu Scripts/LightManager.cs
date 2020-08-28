using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightManager : MonoBehaviour
{
    public Color[] colorOne = new Color[2];
    public Color[] colorTwo = new Color[2];
    public Color[] colorThree = new Color[2];
    public string[] text = new string[2];
    public Sprite[] sprite = new Sprite[2];
    public Light myLightOne;
    public Light myLightTwo;
    public Light myLightThree;
    public Text myText;
    public Image myImage;
    private int lightIndex = 0;
    private int textIndex = 0;
    private int spriteIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        lightIndex = PlayerPrefs.GetInt("LastLightUsed", lightIndex);
        textIndex = PlayerPrefs.GetInt("LastTextUsed", textIndex);
        spriteIndex = PlayerPrefs.GetInt("LastSpriteUsed", spriteIndex);
        Change();
    }

    public void Change()
    {
        if(lightIndex >= colorOne.Length)
        {
            lightIndex = 0;
            textIndex = 0;
            spriteIndex = 0;
        }
        myLightOne.color = colorOne[lightIndex];
        myLightTwo.color = colorTwo[lightIndex];
        myLightThree.color = colorThree[lightIndex];
        myText.text = text[textIndex];
        myImage.sprite = sprite[spriteIndex];
        PlayerPrefs.SetInt("LastLightUsed", lightIndex);
        PlayerPrefs.SetInt("LastTextUsed", textIndex);
        PlayerPrefs.SetInt("LastSpriteUsed", spriteIndex);
        lightIndex = lightIndex + 1;
        textIndex = textIndex + 1;
        spriteIndex = spriteIndex + 1;
    }
}
