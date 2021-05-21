using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    List<Vector2> enemyRoute;
    [SerializeField] float enemySpeed = 2f;

    [SerializeField] WaveConfig waveConfig;

    int routePointPos = 0;

    Vector3 currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        enemyRoute = waveConfig.GetWayPoints();
        transform.position = enemyRoute[routePointPos];
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
        currentTarget = enemyRoute[routePointPos];
    }
}
