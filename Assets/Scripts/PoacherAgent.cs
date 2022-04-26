using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoacherAgent : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] BoxCollider2D patrolArea;
    public Vector3 originalTransform;

    private void Awake()
    {
        GameObject area = GameObject.FindGameObjectWithTag("PatrolArea");
        patrolArea = area.GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //originalTransform = this.transform.position;

        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        setNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 2)
        {
            setNewDestination();
        }
    }

    public void setNewDestination()
    {
        Bounds bounds = patrolArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        agent.SetDestination(new Vector3(x, y));
    }

    public void Slow()
    {
        StartCoroutine(SlowTimer());
    }

    IEnumerator SlowTimer()
    {
        agent.speed = 1.0f;

        yield return new WaitForSeconds(4);

        agent.speed = 3.5f;
    }
}
