using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField] GameObject[] laserObjects;
    [SerializeField] AudioClip shootingSound;
    [SerializeField] float bulletSpeed = 10f;

    string worldBordersColiderName = "World Walls";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.ToString().Equals(worldBordersColiderName))
        {
            // destory lasers that got outside the world context
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public void Shoot(int level, Vector3 position)
    {
        if (laserObjects.Length <= 0) return;
        if (level >= laserObjects.Length)
        {
            level = laserObjects.Length - 1;
        }

        GameObject bullet = Instantiate(laserObjects[level], position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);

        AudioSource.PlayClipAtPoint(shootingSound, position);
    }
}
