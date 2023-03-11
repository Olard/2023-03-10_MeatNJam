using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField]
    public LayerMask playerLayer;
    [SerializeField]
    public LayerMask levelLayer;


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
        if (currentWaypointIndex < waypoints.Length && waypoints[currentWaypointIndex] != null)
        {
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            Gizmos.DrawLine(transform.position, waypoints[currentWaypointIndex].transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if player is in collider
        if (other.GetComponentInParent<PlayerController>() != null)
        {
            // check if player can be seen
            if (Physics.Raycast(
                transform.position,
                (other.transform.position - transform.position).normalized,
                out RaycastHit raycastHit,
                100f,
                playerLayer | levelLayer,
                QueryTriggerInteraction.Ignore
            ))
            {
                if (raycastHit.collider.gameObject.GetComponentInParent<PlayerController>() == null)
                {
                    return;
                }

                // punish player
                var player = other.GetComponentInParent<PlayerController>();
                player.transform.position = Vector3.zero;
                // todo add some effect here and write a message or so
            }
        }
    }
}
