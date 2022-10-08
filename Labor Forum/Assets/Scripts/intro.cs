using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    private void Start()
    {
        Carrega();
    }
    void Carrega()
    {
        Invoke("Load", 3.5f);
    }
   void Load()
    {
        anim.SetTrigger("FadeOut");
        Invoke("Load2", 1f);
    }

    void Load2()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
