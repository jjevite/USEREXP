using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2 dir = Vector2.right;
    public float gameSpeed;

    [SerializeField] private List<Transform> segments = new List<Transform>();

    public Transform segmentPrefab;

    public int initialSize = 3;

    public GameObject venom;
    private Direction snakeVenomDirection;

    private bool isInvicible;

    private Direction moveDir;

    public float food = 0;

    private GameObject[] allPoachers;

    [SerializeField] SpriteRenderer sprite;
    
    private void Start()
    {
        // Grab all poeachers in Scene
        allPoachers = GameObject.FindGameObjectsWithTag("Poacher");

        // Game Speed 
        Time.fixedDeltaTime = gameSpeed;

        // To offset Rotation of Player Head Do not Edit
        transform.localEulerAngles = new Vector3(0, 0, 90);
        ResetState();
    }

    void Update()
    {
        // Add Restrictions on Going to the opposite direction 
        if(Input.GetKeyDown(KeyCode.W) && moveDir != Direction.South)
        {
            moveDir = Direction.North;
            dir = Vector2.up;
            snakeVenomDirection = Direction.North;
            transform.localEulerAngles = new Vector3(0, 0, 180);
        }
        else if (Input.GetKeyDown(KeyCode.S) && moveDir != Direction.North)
        {
            moveDir = Direction.South;
            dir = Vector2.down;
            snakeVenomDirection = Direction.South;
            transform.localEulerAngles = new Vector3(0, 0, 360);
        }
        else if (Input.GetKeyDown(KeyCode.A) && moveDir != Direction.East)
        {
            moveDir = Direction.West;
            dir = Vector2.left;
            snakeVenomDirection = Direction.West;
            transform.localEulerAngles = new Vector3(0, 0, 270);
        }
        else if (Input.GetKeyDown(KeyCode.D) && moveDir != Direction.West)
        {
            moveDir = Direction.East;
            dir = Vector2.right;
            snakeVenomDirection = Direction.East;
            transform.localEulerAngles = new Vector3(0, 0, 90);
        }

        if(Input.GetKeyDown(KeyCode.Space) && segments.Count > 2 && food >= 1)//from Sean:I added food >=1 here in order to prevent it from firing until score is -1 since we get -1 everytime we fire a bullet.
        {
            removeIns();
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        for(int i = segments.Count -1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x + dir.x),
                                                Mathf.Round(this.transform.position.y + dir.y),
                                                0.0f);
    }

    public void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;

        segments.Add(segment);
    }

    private void Shoot()
    {
        food = food - 1;
        GameObject bullet = Instantiate(venom, this.transform.position + new Vector3(dir.x, dir.y, 0.0f), Quaternion.identity);
        bullet.GetComponent<Venom>().venomDirection = snakeVenomDirection;
    }

    private void removeIns()
    {
        Destroy(segments[segments.Count - 1].gameObject);
        segments.RemoveAt(segments.Count - 1);
    }

    private void ResetState()
    {

        food = 0;
        moveDir = Direction.East;
        dir = Vector2.right;
        snakeVenomDirection = Direction.East;
        transform.localEulerAngles = new Vector3(0, 0, 90);

        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(this.transform);

        for(int i = 1; i < initialSize; i++)
        {
            segments.Add(Instantiate(segmentPrefab));
        }
        this.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            ResetState();
        }
        else if (collision.CompareTag("Poacher") && isInvicible != true)//collision with Poacher
        {//note:it does not destroy the rest of the body since when the other body parts are cloned they are not set/under the snake as its child I think?
            ResetState();
            //for (int i = 0; i < allPoachers.Length; i++)
            //{
            //    allPoachers[i].transform.position = allPoachers[i].transform.GetComponent<PoacherAgent>().originalTransform;
            //}
        }
    }

    public void Invicibility()
    {
        StartCoroutine(InvicibilityTimer());
    }

    IEnumerator InvicibilityTimer()
    {
        Color orig = sprite.color;
        Color tmp = sprite.color;
        tmp.r = 200;
        tmp.g = 0;
        tmp.b = 0;
        sprite.color = tmp;

        isInvicible = true;
        
        Debug.Log(isInvicible);
        yield return new WaitForSeconds(4);
        isInvicible = false;
        Debug.Log(isInvicible);

        sprite.color = orig;
    }
}
