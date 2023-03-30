using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    Transform targetDestination;
    GameObject targetGameObject;
    Character targetCharacter;
    [SerializeField] float speed = 5f;
    Rigidbody rb;
    [SerializeField] int hp = 4;
    [SerializeField] int damage = 1;
    [SerializeField] int experience_reward = 400;
    // Start is called before the first frame update
    void Start()
    {
        targetDestination = FindObjectOfType<PlayerMovement>().transform;
        targetGameObject = targetDestination.gameObject;
        targetCharacter = targetGameObject.GetComponent<Character>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        transform.LookAt(targetDestination.position);
        rb.velocity = direction * speed;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == targetGameObject) Attack();
    }

    void Attack()
    {
        targetCharacter.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0){
            targetGameObject.GetComponent<Level>().AddExperience(experience_reward);
            Destroy(this); 
        }
    }
}
