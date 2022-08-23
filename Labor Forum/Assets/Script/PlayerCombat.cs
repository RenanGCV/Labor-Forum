using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform attakPoint;
    [SerializeField]
    private float attakRange = 0.5f;
    [SerializeField]
    private int attakDamage = 40;
    [SerializeField]
    private float attakRate = 1f;

    public LayerMask enemyLayes;
    float nextAttakTime = 0f;



    void Update()
    {
        if (Time.time >= nextAttakTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                animator.SetTrigger("Attack");
                Attack();
                nextAttakTime = Time.time + 1f / attakRate;
            }
        }
        
    }

    void Attack()
    {
        //ANIMAÇÃO DE ATAQUE
        
        //DETECTAR INIMIGOS NO RANGE DE ATAQUE
       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attakPoint.position, attakRange, enemyLayes);
        //DANO DELE
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnimyController>().TakeDamage(attakDamage);
            
        }


    }

    void OnDrawGizmosSelected()
    {
        if (attakPoint == null)
            return;
        Gizmos.DrawWireSphere(attakPoint.position,attakRange);
    }
}
