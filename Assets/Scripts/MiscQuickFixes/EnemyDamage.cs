using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    float health = 100f;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("ouch");
        if(health -damage == 0)
        {
            Die();
            return;
        }
        health -= damage;
        animator.CrossFade("GetHit", 0.2f);
    }

    private void Die()
    {
        Debug.Log("ded");
    }
}
