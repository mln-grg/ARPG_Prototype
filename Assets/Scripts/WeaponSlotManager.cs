using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    public WeaponHolderSlot leftHandSlot;
    public WeaponHolderSlot rightHandSlot;

    public void LoadWeaponOnSlot(WeaponItem weaponItem , bool isLeft)
    {
        if (isLeft)
        {
            //leftHandSlot.LoadWeapon(weaponItem) ;
            
        }
        else
        {
            rightHandSlot.LoadWeapon(weaponItem);
        }
    }
}
