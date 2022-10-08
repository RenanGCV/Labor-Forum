using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParedeInvisivel : MonoBehaviour
{
    public Animator anim;
    [SerializeField]
    AudioSource FaseSong;
    [SerializeField]
    AudioSource BossMusic;
    [SerializeField]
    Collider2D col;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("Parede");
            FaseSong.Pause();
            BossMusic.Play();
            col.enabled = false;
        }
    }
}
