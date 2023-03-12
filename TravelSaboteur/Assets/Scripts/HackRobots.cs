using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackRobots : MonoBehaviour
{
    [SerializeField]
    public List<Robot> robots;
    [SerializeField]
    public float hackDuration = 3f;
    public float fadeSpeed = 4f;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Light>().intensity = 1f + (float)Math.Sin(Time.timeSinceLevelLoadAsDouble * fadeSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        robots.ForEach(robots => robots.setHacked(hackDuration));
    }
}
