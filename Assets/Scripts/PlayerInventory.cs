using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    WeaponSlotManager weaponSlotManager;
    public WeaponItem leftWeapon;
    public WeaponItem rightWeapon;
    public WeaponItem Unarmed;
    public WeaponHolderSlot slot;

    private void Awake()
    {
        weaponSlotManager = GetComponent<WeaponSlotManager>();
    }

    private void Start()
    {
        weaponSlotManager.LoadWeaponOnSlot(Unarmed, false);
        //weaponSlotManager.LoadWeaponOnSlot(leftWeapon, true);

    }

    public void Unsheathe()
    {
        weaponSlotManager.LoadWeaponOnSlot(rightWeapon, false);
    }
    public void Sheathe()
    {
        slot.UnloadWeaponAndDestroy();
    }
}
