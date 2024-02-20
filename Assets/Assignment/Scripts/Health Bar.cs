using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
   
    public Slider slider;

    void Start()
    {
        InitializeHealth(PlayerPrefs.GetFloat("currentHealth", 5));
    }

    void InitializeHealth(float initialHealth)
    {
        SetHealth(initialHealth);
    }

    void UpdateHealthUI(float newHealth)
    {
        SetHealth(newHealth);
    }

    void SetHealth(float healthValue)
    {
        slider.value = healthValue;
    }
}
