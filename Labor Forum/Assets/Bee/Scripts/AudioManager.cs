using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static bool audioOn = true;
    private static Image img;
    public Sprite spriteon;
    public Sprite spriteoff;

    void Start ()
     {
        img = GameObject.Find("Btn_Vol").GetComponent<Image>();
     }
    
    void Awake()
    {
        img = GameObject.Find("Btn_Vol").GetComponent<Image>();

        if(audioOn == true)
        {
           AudioListener.volume = 1;
           img.sprite = spriteon;

        }
        else if(audioOn == false)
        {
            AudioListener.volume = 0;
            img.sprite = spriteoff;
        }

    }

    public void VolumeGame()
    {
        audioOn = !audioOn;

        if(audioOn == true)
        {
           AudioListener.volume = 1;
           img.sprite = spriteon;

        }
        else if(audioOn == false)
        {
            AudioListener.volume = 0;
            img.sprite = spriteoff;
        }

    }
}
