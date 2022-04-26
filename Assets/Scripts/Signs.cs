using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Signs : MonoBehaviour
{
    [SerializeField] GameObject panel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;
            panel.SetActive(true);
        }
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }
}
