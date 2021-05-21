using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] List<Transform> enemyRoute;
    [SerializeField] float enemySpeed = 2f; 

    int routePointPos = 0;

    Vector3 currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = enemyRoute[routePointPos].transform.position;
        SetNextTarget();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = enemySpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, currentTarget, speed);

        if (currentTarget == transform.position)
        {
            SetNextTarget();
        }
    }

    void SetNextTarget ()
    {
        routePointPos++;
        if (routePointPos >= enemyRoute.Count)
        {
            // Enemy finished his route
            Destroy(gameObject);
            return;
        }
        currentTarget = enemyRoute[routePointPos].transform.position;
    }
}
