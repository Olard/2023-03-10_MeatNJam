using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public float speedUp = 1f;

    public float fadeSpeed = 4f;

    private void Update()
    {
        GetComponent<Light>().intensity = 1f + (float) Math.Sin(Time.timeSinceLevelLoadAsDouble * fadeSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        PlayerController player = other.gameObject.GetComponentInParent<PlayerController>();
        if (player != null)
        {
            player.speed += speedUp;
            Destroy(gameObject);
        }
    }
}
