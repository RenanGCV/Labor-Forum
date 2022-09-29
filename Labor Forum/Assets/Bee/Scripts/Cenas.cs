using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cenas : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    string cena;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Passar2()
    {
        anim.SetTrigger("FadeOut");
        Invoke("Passar", 1f);
    }
    public void Passar()// Botões menu
    {
        SceneManager.LoadScene(cena);
        Time.timeScale = 1;
    }

    /*public void MenuPause2()
    {
        anim.SetTrigger("FadeOut");
        Time.timeScale = 1;
        Invoke("MenuPause", 1f);
    }*/
    public void MenuPause() // Home Pause Menu
    {
        
        SceneManager.LoadScene(cena);
        Time.timeScale = 1;
    }

    public void pause()
    {
        Time.timeScale = 0;
    }
    
    public void despause()
    {
        Time.timeScale = 1;
    }

    public void Sair1()
    {
        anim.SetTrigger("FadeOut");
        Invoke("Sair", 1f);
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void TelaCheia()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void ModoJanela()
    {
        Screen.SetResolution(1280, 720, false);
    }
}