using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class TravelToGoal : MonoBehaviour
{
    public Transform goal;
    float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(goal);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = goal.position = this.transform.position;

        if (direction.magnitude > 1)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }
}
