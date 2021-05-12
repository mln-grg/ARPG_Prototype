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
        health -= damage;
        animator.CrossFade("GetHit", 0f);

    }
}
