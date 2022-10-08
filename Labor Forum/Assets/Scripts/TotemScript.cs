using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotemScript : MonoBehaviour
{
    public Animator anim;
    public int scoreValue;
    public string fraseToten;
    public EdgeCollider2D col;
    public Image caixa;
    public AudioSource som;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            caixa.gameObject.SetActive(true);
            anim.SetTrigger("Pego");
            som.Play();
            GameController.instance.AtualizaHud(scoreValue);
            col.enabled = false;
            GameController.instance.AtualizaHud2(fraseToten);
            Invoke("LimpaText", 5f);
        }
        
    }

    void LimpaText()
    {
        fraseToten = "";
        GameController.instance.AtualizaHud2(fraseToten);
        caixa.gameObject.SetActive(false);
    }
}
