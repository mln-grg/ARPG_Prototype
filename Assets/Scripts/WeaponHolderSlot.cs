using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolderSlot : MonoBehaviour
{
    public Transform parentOverride;
    public Transform parent;
    public bool isLeftHandSlot;
    public bool isRightHandSlot;

    public GameObject currentWeaponModel;
    public GameObject Scythe;
    public WeaponSlotManager slot;
    public WeaponItem unarmed;
    private GameObject model;

    public Vector3 offset;
    private void Start()
    {
        model = Instantiate(Scythe) as GameObject;
        model.transform.parent = parent;
        model.transform.localPosition = Vector3.zero;
        model.transform.localRotation = Quaternion.identity;
    }
    public void UnloadWeapon()
    {
        if (currentWeaponModel != null)
        {
            currentWeaponModel.SetActive(false);
        }
    }
    public void UnloadWeaponAndDestroy()
    {
        if (currentWeaponModel != null)
        {
            //Destroy(currentWeaponModel);
            model.transform.parent = parent;
            model.transform.localPosition = Vector3.zero;
            model.transform.localRotation = Quaternion.identity;
            slot.LoadWeaponOnSlot(unarmed, false);
            
        }
    }
    public void LoadWeapon(WeaponItem weaponItem)
    {
        //UnloadWeaponAndDestroy();
        if(weaponItem == null)
        {
            UnloadWeapon();
            return;
        }
        //GameObject model = Instantiate(weaponItem.modelPrefab) as GameObject;
        if (model != null)
        {
            if (parentOverride != null)
            {

                //parentOverride.localPosition += offset;
                model.transform.parent = parentOverride;
                //model.transform.localPosition = new Vector3(0.820865f, -0.41220f, -0.959670f);
                //model.transform.localRotation = new Quaternion(-158.692f, -10.91f, -4.164978f);
            }
            else
            {

                model.transform.parent = transform;

            }
            //model.transform.localPosition = Vector3.zero;
            //model.transform.localRotation = Quaternion.identity;
        } 
        currentWeaponModel = model; 
    }

    public void DisableCurrentWeaponCollider()
    {
        WeaponCollider wCollider = currentWeaponModel.GetComponent<WeaponCollider>();
        wCollider.DisableCollider();
    }
    public void EnableCurrentWeaponCollider()
    {
        WeaponCollider wCollider = currentWeaponModel.GetComponent<WeaponCollider>();
        wCollider.EnableCollider();
    }
}
