using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Door : MonoBehaviour
{
    [SerializeField] private int foodToOpen;
    [SerializeField] private int sceneToOpen;
    [SerializeField] private TextMeshProUGUI foodToOpenText;

    private void Start()
    {
        foodToOpenText.text = foodToOpen.ToString();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(collision.GetComponent<Snake>().food >= foodToOpen)
            {
                Debug.Log("Entering Next Level...");
                SceneManager.LoadScene(sceneToOpen);
            }
        }    
    }
}
