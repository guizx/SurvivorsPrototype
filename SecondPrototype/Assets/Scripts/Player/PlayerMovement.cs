using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed, rotationSpeed;
    public Vector3 moveDir, lookPos, lookDir;
    //Refs
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }

    private void FixedUpdate()
    {
        Move();
        Look();
    }

    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(moveX, 0, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector3(moveDir.x * moveSpeed, 0, moveDir.z * moveSpeed);
    }

    void Look()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            lookPos = hit.point;
        }
        lookDir = lookPos - transform.position;
        lookDir.y = 0;
        //transform.LookAt(transform.position + lookDir, Vector3.up);
        var targetRotation = Quaternion.LookRotation(lookDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
