using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed = 10f;

    private Vector3 movementDirection = Vector3.zero;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movementDirection = Vector3.right * Input.GetAxisRaw("Horizontal") + Vector3.forward * Input.GetAxisRaw("Vertical");
    }
    void OnDrawGizmos()
    {
        if (rb != null)
        {
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            Gizmos.DrawLine(transform.position, transform.position + rb.velocity);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movementDirection.normalized * speed;
    }
}
