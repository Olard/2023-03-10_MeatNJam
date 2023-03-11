using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField]
    public GameObject[] waypoints;
    [SerializeField]
    public int currentWaypointIndex = 0;
    [SerializeField]
    public float speed = 4f;
    [SerializeField]
    public float waitTimeAtWaypoint = 1f;

    private Vector3 movementDirection = Vector3.zero;
    private Rigidbody rb;
    private float waitCountdown = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitCountdown > 0)
        {
            waitCountdown -= Time.deltaTime;
            return;
        }

        var target = waypoints[currentWaypointIndex].transform.position;
        movementDirection = target - transform.position;
        movementDirection.y = 0;
        transform.forward = movementDirection.normalized;
        rb.velocity = movementDirection.normalized * speed;

        if (movementDirection.magnitude < 0.2f)
        {
            // start timer to wait here for a second
            waitCountdown = waitTimeAtWaypoint;
            currentWaypointIndex = (currentWaypointIndex + 1) % (waypoints.Length);
            rb.velocity = Vector3.zero;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawLine(transform.position, waypoints[currentWaypointIndex].transform.position);
    }
}
