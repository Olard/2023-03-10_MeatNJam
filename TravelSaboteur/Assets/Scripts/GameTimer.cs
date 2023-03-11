using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = 0f;
    }

    void Update()
    {
        slider.value += Time.deltaTime;

        if (slider.value >= slider.maxValue)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
