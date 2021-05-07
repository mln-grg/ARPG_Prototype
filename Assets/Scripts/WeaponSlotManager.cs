using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    public WeaponHolderSlot leftHandSlot;
    public WeaponHolderSlot rightHandSlot;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void LoadWeaponOnSlot(WeaponItem weaponItem , bool isLeft)
    {
        if (isLeft)
        {
            //leftHandSlot.LoadWeapon(weaponItem) ;
            /*if (weaponItem != null)
            {
                animator.CrossFade(weaponItem.left_hand_idle, 0.2f);
            }
            else
            {
                animator.CrossFade("Left Arm Empty", 0.2f);
            }*/
            
        }
        else
        {
            if(weaponItem.name!="Unarmed")
                rightHandSlot.LoadWeapon(weaponItem);
           
            if (weaponItem != null)
            {
                animator.CrossFade(weaponItem.right_hand_idle, 0.2f);
            }
            else
            {
                animator.CrossFade("Right Arm Empty", 0.2f);
            }

        }
    }
}
