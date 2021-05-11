using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/WeaponItem")]
public class WeaponItem : Item
{
    public GameObject modelPrefab;

    [Header("Attack Animations")]
    public string OH_Light_Attack_1;
    public string OH_Light_Attack_2;
    public string OH_Light_Attack_3;
    public string OH_Heavy_Attack_1;
    public string OH_Heavy_Attack_2;
    public string OH_Heavy_Attack_3;

    [Header("Idle Animations")]
    public string right_hand_idle;
    public string left_hand_idle;

    [Header("Sheathe Unsheathe Animation")]
    public string sheathe;
    public string unSheathe;

    [Header("WeaponStats")]
    public float damage;


}
