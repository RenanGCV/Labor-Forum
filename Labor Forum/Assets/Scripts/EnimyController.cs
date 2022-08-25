using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnimyController : MonoBehaviour
{
    public float PatrolSpeed;//Velocidade do inimigo em patrulha
    public float ChaseSpeed;//Velocidade do Inimigo
    public float StoppingDistance;//Distancia para ele parar quando chegar proximo do player
    public float VisionRange;//Campo de visao para entrar em chase
    public int scoreValue;

    private Rigidbody2D rb;
    private int andandoDireita = 1;
    private bool isRight = true;
    private Animator anim;


    [SerializeField]
    int currentHealth;
    [SerializeField]
    public bool playerDetected = false;
    [SerializeField]
    private LayerMask layersPermitidas;
    [SerializeField]
    private Vector2 raycastOffset;
    [SerializeField]
    private float rangeDetect;
    [SerializeField]
    public bool modoChase = true;
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    int maxHealth = 100;
    
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        
        
    }

    void Update()
    {

        Patrol();
        Chase();
        AddCoin();





    }

    void FixedUpdate()
    {
        MovimentEnemy();
        FlipRequirement();

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Dano");

        //Animacao de dano

        if (currentHealth <= 0)
        {
            
            anim.SetTrigger("Death");
            
            Die();
        }
    }

    public void AddCoin()
    {
        if(currentHealth <= 0)
        {
            
            rb.isKinematic = false;
        }
        
    }

    void Die()
    {
        ChaseSpeed = 0f;
        GameController.instance.AtualizaHud(scoreValue);
        Invoke("Destruir", 1.5f);
    }

    void Destruir()
    {
        Destroy(gameObject);
    }


    void Chase() //Void que executa o codigo de Chase
    {
        var diferencaPlayer = player.gameObject.transform.position.x - transform.position.x;
        var seguindoPlayer = Mathf.Abs(diferencaPlayer) < rangeDetect;
        if (modoChase && seguindoPlayer)
        {
            anim.SetBool("Chasing", true);
            anim.SetBool("Patroling", false);
            if (diferencaPlayer < 1.7)
            {
                PatrolSpeed = (-1 * 3);
            }
            else if (diferencaPlayer > -1.7)
            {
                PatrolSpeed = (1 * 3);
            }
        }

       
        
    }

    void MovimentEnemy()
    {
        transform.Translate(Vector2.right * PatrolSpeed * Time.deltaTime * andandoDireita);
    }

    void Patrol()
    {
        anim.SetBool("Patroling", true);
        anim.SetBool("Chasing", false);
        var origemX = transform.position.x + raycastOffset.x;
        var origemY = transform.position.y + raycastOffset.y;
        var raycastParedeDireita = Physics2D.Raycast(new Vector2(origemX, origemY), Vector2.right, 0.5f, layersPermitidas);
        Debug.DrawRay(new Vector2(transform.position.x, origemY), Vector2.right, Color.cyan);
        if (raycastParedeDireita.collider != null)
        {
            PatrolSpeed = (-1 * PatrolSpeed);
        }

        var raycastParedeEsquerda = Physics2D.Raycast(new Vector2(transform.position.x - raycastOffset.x, origemY), Vector2.left, 0.4f, layersPermitidas);
        Debug.DrawRay(new Vector2(transform.position.x, origemY), Vector2.left, Color.cyan);
        if (raycastParedeEsquerda.collider != null)
        {
            PatrolSpeed = (-1 * PatrolSpeed);
        }
        var raycastChaoDireita = Physics2D.Raycast(new Vector2(transform.position.x + raycastOffset.x, transform.position.y), Vector2.down, 1f, layersPermitidas);
        Debug.DrawRay(new Vector2(transform.position.x + raycastOffset.x, transform.position.y), Vector2.down, Color.red);
        if (raycastChaoDireita.collider == null)
        {
            PatrolSpeed = (-1 * PatrolSpeed);
        }
        var raycastChaoEsquerda = Physics2D.Raycast(new Vector2(transform.position.x - raycastOffset.x, transform.position.y), Vector2.down, 1f, layersPermitidas);
        Debug.DrawRay(new Vector2(transform.position.x - raycastOffset.x, transform.position.y), Vector2.down, Color.red);
        if (raycastChaoEsquerda.collider == null)
        {
            PatrolSpeed = (-1 * PatrolSpeed);
        }
    }

    void FlipRequirement()
    {
        if (PatrolSpeed > 0 && !isRight)
        {
            Flip();
        }

        else if (PatrolSpeed < 0 && isRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        isRight = !isRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, rangeDetect);
    }
}