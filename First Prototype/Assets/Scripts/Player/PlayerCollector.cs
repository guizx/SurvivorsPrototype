using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    PlayerStats player;
    SphereCollider playerCollector;
    public float pullSpeed;
    private void Start()
    {
        player = GetComponentInParent<PlayerStats>();
        playerCollector = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        playerCollector.radius = player.currentMagnet;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out ICollectible collectible))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 forceDirection = (transform.position - other.transform.position).normalized;
            rb.AddForce(forceDirection * pullSpeed);
            collectible.Collect();
        }
    }
}
