using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    Collider weaponCollider;
    public WeaponItem weapon;
    private void Awake()
    {
        weaponCollider = GetComponent<Collider>();
    }

    private void Start()
    {
        weaponCollider.isTrigger = true;
        weaponCollider.enabled = false;
    }

    public void EnableCollider()
    {
        weaponCollider.enabled = true;
    }

    public void DisableCollider()
    {
        weaponCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("hitting");
            EnemyDamage enemy = other.gameObject.GetComponent<EnemyDamage>();
            enemy.TakeDamage(weapon.damage);
            DisableCollider();
        }
    }
}
