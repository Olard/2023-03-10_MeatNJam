using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] 
    private float rotationSpeed = 2f;

    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed);
    }
}