using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    float health = 100f;
    Animator animator;
    public Transform[] bloodPoints;
    public GameObject[] blood;
    private void Awake()
    {
        animator = GetComponent<Animator>();

    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        animator.CrossFade("GetHit", 0f);

        Instantiate(blood[Random.Range(0, blood.Length)], bloodPoints[Random.Range(0, bloodPoints.Length)]);
    }
}
    