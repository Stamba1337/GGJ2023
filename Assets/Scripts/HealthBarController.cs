using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider HealthBar;
    public Stats playerStats;

    public void Update()
    {
        HealthBar.value = playerStats.health;
    }
}
