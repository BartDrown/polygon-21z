using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    const int firstWeaponID = 1;
    const int secondWeaponID = 2;
    const UnityEngine.KeyCode keyForFirstWeapon = KeyCode.Alpha1;
    const UnityEngine.KeyCode keyForSecondWeapon = KeyCode.Alpha2;
    [SerializeField] private GameObject bulletPrefab1;
    [SerializeField] private GameObject bulletPrefab2;

    Weapon shootScript;

    private void Awake() // Awake automatically starts from unity, it gets started before start().
    {
        shootScript = GetComponent<Weapon>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This sucks
        // I tried: Array of Tuples (Not supported by Unity)
        // Two arrays: couldn't do it so that remain constant/readonly
        if(Input.GetKeyDown(keyForFirstWeapon))
        {
            SetWeapon(firstWeaponID);
        }
        else if(Input.GetKeyDown(keyForSecondWeapon))
        {
            SetWeapon(secondWeaponID);
        }
    }

    void SetWeapon(int weaponID)
    {
        switch(weaponID)
        {
            case firstWeaponID:
                shootScript.setBulletType(bulletPrefab1);
                break;
            case secondWeaponID:
                shootScript.setBulletType(bulletPrefab2);
                break;
            default:
                Debug.Log("No weapon for this ID was found!");
                break;
            
        }
    }
}
