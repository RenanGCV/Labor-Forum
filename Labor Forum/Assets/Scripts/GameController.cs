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

    [SerializeField]
    int TotalCoins;
    [SerializeField]
    

    void Awake()
    {
        instance = this;   
        
        TotalCoins = PlayerPrefs.GetInt("coins");
        Debug.Log(PlayerPrefs.GetInt("coins"));
        
    }

    private void Start()
    {
        
    }

    void Update()
    {
        pontuacaoTxt.text = TotalCoins.ToString();

    }

    public void AtualizaHud(int value)
    {
        coins += value;
        

        coins++;
        TotalCoins++;

        PlayerPrefs.SetInt("coins", TotalCoins);
        
    }

    public void AtualizaHud2(string value)
    {
        TextTotem = value;
        TotemTextHud.text = TextTotem.ToString();
    }

    public void AtualizaHud3(int value)
    {
        TotalCoins -= TotalCoins;


        

        PlayerPrefs.SetInt("coins", TotalCoins);

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
