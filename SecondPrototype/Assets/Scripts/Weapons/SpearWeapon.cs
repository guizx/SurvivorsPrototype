using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearWeapon : MonoBehaviour
{
    public float timeToAttack = 4f, timer, spearRadius;
    public GameObject spearObject;
    PlayerMovement playerMove;
    public Transform attackPoint, tipPoint;
    public int spearDamage;
    private void Start()
    {
        playerMove = GetComponentInParent<PlayerMovement>();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f) Attack();
    }

    void Attack()
    {
        timer = timeToAttack;
        spearObject.SetActive(true);
        Collider[] colliders = Physics.OverlapCapsule(attackPoint.position, tipPoint.position, spearRadius);
        ApplyDamage(colliders);
    }

    void ApplyDamage(Collider[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            IDamageable e = colliders[i].GetComponent<IDamageable>();
            if(e != null) e.TakeDamage(spearDamage);
        }
    }
}
