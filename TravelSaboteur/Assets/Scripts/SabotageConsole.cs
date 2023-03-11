using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SabotageConsole : MonoBehaviour
{
    [SerializeField]
    public float fadeSpeed = 0.5f;

    private Boolean playerIsInRange = false;
    private Light highlight;
    private float maxIntensity;

    void Awake()
    {
        highlight = GetComponent<Light>();
        maxIntensity = highlight.intensity;
        highlight.intensity = 0f;
    }

    private void Update()
    {
        if (playerIsInRange && Input.GetButtonDown("Submit"))
        {
            Debug.Log("Sabotaged");
            highlight.color = Color.red;
        }


        if (playerIsInRange && highlight.intensity < maxIntensity)
        {
            highlight.intensity = Math.Min(highlight.intensity + Time.deltaTime * fadeSpeed, maxIntensity);
        }

        if (!playerIsInRange && highlight.intensity > 0f)
        {
            highlight.intensity = Math.Max(highlight.intensity - Time.deltaTime * fadeSpeed, 0f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerController>() != null)
        {
            playerIsInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<PlayerController>() != null)
        {
            playerIsInRange = false;
        }
    }
}
