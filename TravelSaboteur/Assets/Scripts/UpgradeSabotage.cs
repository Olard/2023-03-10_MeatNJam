using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSabotage : MonoBehaviour
{
    [SerializeField]
    public float sabotageMultiplier;

    public float fadeSpeed = 4f;

    private void Update()
    {
        GetComponent<Light>().intensity = 1f + (float)Math.Sin(Time.timeSinceLevelLoadAsDouble * fadeSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponentInParent<PlayerController>();
        if (player != null)
        {
            player.sabotageMultiplier *= sabotageMultiplier;
            Destroy(gameObject);
        }
    }
}
