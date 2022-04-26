using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poacher : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;

    public Vector3 originalTransform;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Random.Range(3.0f, 5.0f);

        originalTransform = this.transform.position;

        rb = this.GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void Slow()
    {
        StartCoroutine(SlowTimer());
    }

    IEnumerator SlowTimer()
    {
        moveSpeed = 1.0f;

        yield return new WaitForSeconds(4);

        moveSpeed = 5.0f;
    }
}
//collision and movement works
