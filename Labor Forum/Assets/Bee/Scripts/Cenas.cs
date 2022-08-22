using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cenas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Passar(string cena)
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