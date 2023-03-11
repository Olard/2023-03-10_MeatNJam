using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SabotageConsole : MonoBehaviour
{
    [SerializeField]
    public float fadeSpeed = 0.5f;

    private SabotageSlider sabotageSlider;
    private Boolean sabotaged = false;
    private Boolean playerIsInRange = false;
    private Light highlight;
    private float maxIntensity;

    public void resetSabotage()
    {
        sabotaged = false;
        highlight.color = Color.white;
    }

    void Awake()
    {
        sabotageSlider = GameObject.FindAnyObjectByType<SabotageSlider>();
        if (sabotageSlider == null)
        {
            Debug.LogError("No sabotage slider found.");
        }
        highlight = GetComponent<Light>();
        maxIntensity = highlight.intensity;
        highlight.intensity = 0f;
    }

    void Update()
    {
        if (!sabotaged && playerIsInRange && Input.GetButtonDown("Submit"))
        {
            sabotaged = true;
            sabotageSlider.PerformSabotage(this);
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
