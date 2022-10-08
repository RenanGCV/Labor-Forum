using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class final : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    private void Start()
    {
        Esperar();
    }
    void Esperar()
    {
        Invoke("Esperar2", 5f);
    }

    void Esperar2()
    {
        anim.SetTrigger("FadeOut");
        Invoke("Esperar3", 1f);
    }

    void Esperar3()
    {
        SceneManager.LoadScene("MENU");
    }
}
