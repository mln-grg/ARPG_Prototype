using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    AnimatorManager animatorManager;
    string lastAttack;
    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
    }

    public void HandleLightAttack(WeaponItem weapon)
    {
        if(animatorManager.animator.GetBool("canCombo") && lastAttack == weapon.OH_Light_Attack_2)
        {
            animatorManager.PlayTargetAnimation(weapon.OH_Light_Attack_3, true,true);
            lastAttack = weapon.OH_Light_Attack_3;
        }
        else if (animatorManager.animator.GetBool("canCombo") && lastAttack == weapon.OH_Light_Attack_1)
        {
            animatorManager.PlayTargetAnimation(weapon.OH_Light_Attack_2, true,true);
            lastAttack = weapon.OH_Light_Attack_2;
        }
        else
        {
            animatorManager.animator.SetBool("canCombo", true);
            animatorManager.PlayTargetAnimation(weapon.OH_Light_Attack_1, true,true);
            lastAttack = weapon.OH_Light_Attack_1;
        }

    }
    public void HandleHeavyAttack(WeaponItem weapon)
    {
        if (lastAttack == weapon.OH_Heavy_Attack_2)
        {
            animatorManager.PlayTargetAnimation(weapon.OH_Heavy_Attack_3, true,true);
            lastAttack = weapon.OH_Heavy_Attack_3;
        }
        else if (lastAttack == weapon.OH_Heavy_Attack_1)
        {
            animatorManager.PlayTargetAnimation(weapon.OH_Heavy_Attack_2, true,true);
            lastAttack = weapon.OH_Heavy_Attack_2;
        }
        else
        {
            animatorManager.PlayTargetAnimation(weapon.OH_Heavy_Attack_1, true,true);
            lastAttack = weapon.OH_Heavy_Attack_1;
        }

    }
    public void ResetCombo()
    {
        animatorManager.animator.SetBool("canCombo", false);
    }

    
}
