using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypes
{
    Haste,
    Slow,
    Invicibility
}
public class Items : MonoBehaviour
{
    public ItemTypes itemType;

    private GameObject[] poacherInLevel;
 
    private void Start()
    {
        Invoke("GrabAllPoachers", 2);
    }

    void GrabAllPoachers()
    {
        poacherInLevel = GameObject.FindGameObjectsWithTag("Poacher");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(itemType == ItemTypes.Invicibility)
            {
                collision.GetComponent<Snake>().Invicibility();
                Destroy(gameObject);
            }
            if (itemType == ItemTypes.Slow)
            {
                for (int i = 0; i < poacherInLevel.Length; i++)
                {
                    poacherInLevel[i].GetComponent<PoacherAgent>().Slow();
                }
                Destroy(gameObject);
            }
        }
    }
}
