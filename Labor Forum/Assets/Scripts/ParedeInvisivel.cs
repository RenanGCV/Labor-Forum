using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedeInvisivel : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("Parede");
        }
    }
}
