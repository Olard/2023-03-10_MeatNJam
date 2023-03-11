using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private Slider slider;


    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value += Time.deltaTime;

        if (slider.value >= slider.maxValue)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
