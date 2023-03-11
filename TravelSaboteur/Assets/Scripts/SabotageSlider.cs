using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SabotageSlider : MonoBehaviour
{
    private Slider slider;
    private SabotageConsole lastTrigger;

    void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = 0f;
    }

    public void PerformSabotage(SabotageConsole trigger, float value)
    {
        slider.value += value;

        if (slider.value >= slider.maxValue)
        {
            SceneManager.LoadScene("Win");
        }

        if (lastTrigger != null)
        {
            lastTrigger.resetSabotage();
        }
        lastTrigger = trigger;
    }
}
