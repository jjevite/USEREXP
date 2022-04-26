using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelDirection : MonoBehaviour
{
    public Vector3 Direction = new Vector3(5, 0, 8);
    float movementSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.Translate(Direction.normalized * movementSpeed * Time.deltaTime);

    }
}
