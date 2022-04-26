using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class Venom : MonoBehaviour
{
    public Direction venomDirection = Direction.East;
    private Vector3 vDir;
    public float venomSpeed;

    private void Start()
    {
        if(venomDirection == Direction.North)
        {
            vDir = Vector3.up;
        }
        else if(venomDirection == Direction.South)
        {
            vDir = Vector3.down;
        }
        else if (venomDirection == Direction.West)
        {
            vDir = Vector3.left;
        }
        else if (venomDirection == Direction.East)
        {
            vDir = Vector3.right;
        }
    }
    private void Update()
    {
        transform.Translate(vDir * venomSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if(collision.CompareTag("Poacher"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Destroy(gameObject);
    //    if (collision.gameObject.CompareTag("Obstacle"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
