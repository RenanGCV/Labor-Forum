using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Porteiro : MonoBehaviour
{
    [SerializeField]
    string TextPorteiro;
    [SerializeField]
    GameObject porteiro;
    [SerializeField]
    int scoreValue = 0;

    public Behaviour PlayerScript;

    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            porteiro.SetActive(true);
            GameController.instance.AtualizaHud3(scoreValue);
            PlayerScript.enabled = false;

        }

        

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            porteiro.SetActive(false);
            Destroy(gameObject);
            PlayerScript.enabled = true;

        }
    }

}
