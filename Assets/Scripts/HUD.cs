using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] Snake player;
    [SerializeField] TextMeshProUGUI foodEatenText;
    void Update()
    {
        foodEatenText.text = player.food.ToString();
    }
}
