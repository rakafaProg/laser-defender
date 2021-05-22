using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    List<Vector2> enemyRoute;
    WaveConfig waveConfig;
    int routePointPos = 0;
    Vector3 currentTarget;

    [SerializeField] AudioClip destructionSound;

    GameManager gameManager;

    int health;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();



    }

    IEnumerator InifinateShoot ()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(Random.Range(0.7f, 1.7f));
            GameObject enemyLaser = Instantiate<GameObject>(waveConfig.GetLaserPrefab(), transform.position, Quaternion.identity);
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    DamageDealer damager = collision.GetComponent<DamageDealer>();
    //    if (damager != null)
    //    {
    //        health -= damager.GetDamage();
    //        damager.OnHit();
    //        if (health <= 0)
    //        {
    //            gameManager.AddScore();
    //            AudioSource.PlayClipAtPoint(destructionSound, transform.position);
    //            Destroy(gameObject);
    //        }
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        if (waveConfig == null) return;
        float speed = waveConfig.GetEnemySpeed() * Time.deltaTime;
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

    public void SetWaveConfig (WaveConfig wave)
    {
        waveConfig = wave;
        enemyRoute = waveConfig.GetWayPoints();
        transform.position = enemyRoute[routePointPos];
        health = wave.GetEnemyHealth();
        SetNextTarget();
        StartCoroutine(InifinateShoot()); 
    }

}
