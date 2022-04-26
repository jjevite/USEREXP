using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelForwardToGoal : MonoBehaviour
{
    public Transform goal;
    float speed = 5;
    float rotSpeed = 4;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x, goal.position.y, this.transform.position.z);
        Vector3 direction = lookAtGoal - transform.position;
        //Vector2 lookAtGoal = new Vector2(goal.position.x, this.position.y);
        //Vector2 direction = lookAtGoal - transform.position;

        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0);

        if (Vector3.Distance(lookAtGoal, transform.position) > 1)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }

    }
}
