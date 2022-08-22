using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public int coins;
    public int vida = 5;
    public Text pontuacaoTxt;

    private Rigidbody2D rb;
    private Animator anim;
    private Transform GroundCheck;
    public Animator hudAnim;

    private bool noChao = false;
    private bool jump = false;
    private bool facingRight = true;

    [SerializeField]
    private bool isDead = false;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        GroundCheck = gameObject.transform.Find("GroundCheck");
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        NoChao();
        Jump();
        Death();
        AtualizaHud();
        coins = GetComponent<EnimyController>().coin;

    }

    void NoChao()
    {
        noChao = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Piso"));
        if (noChao)
        {
            anim.SetTrigger("Chao");
        }
    }

    void FixedUpdate()
    {
        MovimentPlayer();
        Vida();
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Death()
    {
        if (isDead)
        {
            anim.SetBool("Death", true);
        }
    }

    

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && noChao)
        {
            jump = true;
            anim.SetTrigger("Jump");
        }

        if (jump)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }
    }

    void MovimentPlayer()
    {
        float h = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Velocidade", Mathf.Abs(h));

        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            coins++;
            Destroy(collision.gameObject);
        }

        

        if (collision.gameObject.tag == "Life")
        {
            vida++;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            vida--;
        }
    }

    void AtualizaHud()
    {
        pontuacaoTxt.text = coins.ToString();
    }

    void Vida()
    {
        if (vida > 5)
        {
            vida = vida - 1;
        }
        if (vida < 0)
        {
            vida = vida + 1;
        }
        if (vida == 0)
        {
            isDead = true;
            speed = 0;
            jumpForce = 0;
        }
        var vidaValor = vida;
        hudAnim.SetInteger("Vida", vidaValor);
    }
}
