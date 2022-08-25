using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;


    public int coins;
    public Text pontuacaoTxt;
    public Text TotemTextHud;
    public string TextTotem;

    void Awake()
    {
        instance = this;   
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        
    }

    public void AtualizaHud(int value)
    {
        coins += value;
        pontuacaoTxt.text = coins.ToString();
        
    }

    public void AtualizaHud2(string value)
    {
        TextTotem = value;
        TotemTextHud.text = TextTotem.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            coins++;
            Destroy(collision.gameObject);
        }

    }

    

}
