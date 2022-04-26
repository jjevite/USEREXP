using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D grid;
    public  void RandomizePos()
    {
        Bounds bounds = this.grid.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RandomizePos();
            collision.GetComponent<Snake>().Grow();
            collision.GetComponent<Snake>().food += 1;
        }

        if (collision.CompareTag("Obstacle"))
        {
            Debug.Log("isCOlliding");
            RandomizePos();
        }
    }

}
