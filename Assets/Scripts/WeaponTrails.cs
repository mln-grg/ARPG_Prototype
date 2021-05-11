using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrails : MonoBehaviour
{
    GameObject trails;

    private void Awake()
    {
        
    }

    private void Start()
    {
       

    }
    public void TrailOn()
    {
        if (trails == null)
        {
            trails = WeaponTrailInstance.instance.trail;
        }   
        trails.SetActive(true);
    }

    public void TrailOff()
    {
        trails.SetActive(false);
    }
}
