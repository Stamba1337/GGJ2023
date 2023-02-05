using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public float health = 100f;

    private void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("DeathScreenScene");
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
