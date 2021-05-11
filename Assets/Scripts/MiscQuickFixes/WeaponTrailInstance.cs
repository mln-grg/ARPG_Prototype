using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrailInstance : MonoBehaviour
{
    public static WeaponTrailInstance instance;
    public GameObject trail;
    private void Awake()
    {
        instance = this;
        trail = this.gameObject;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

}
