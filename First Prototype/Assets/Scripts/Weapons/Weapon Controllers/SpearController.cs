using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : WeaponController
{
    // Start is called before the first frame update
    PlayerMovement movement;
    GameObject spear;
    protected override void Start()
    {
        base.Start();
        movement = FindObjectOfType<PlayerMovement>();
    }

    protected override void Attack()
    {
        base.Attack();
        //GameObject spawnedSpear = Instantiate(weaponData.Prefab, transform.position, transform.rotation, transform);
    }
}
