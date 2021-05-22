using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int scoreOnDeath = 0;
    [SerializeField] bool destroyOnDeath;
    [SerializeField] bool looseShieldOnDeath;
    [SerializeField] AudioClip soundOnDestruction;

    GameManager game;
    int initialHealth;

    private void Start()
    {
        game = FindObjectOfType<GameManager>();
        initialHealth = health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision ME: " + gameObject.name + " THEM: " + collision.gameObject.name);

        DamageDealer damage = collision.gameObject.GetComponent<DamageDealer>();
        if (damage != null)
        {

            health -= damage.GetDamage();
            damage.OnHit();
            if (health <= 0)
            {
                OnDeath();
            }
        }
    }

    private void OnDeath()
    {
        game.AddScore(scoreOnDeath);
        if (looseShieldOnDeath)
        {
            game.LooseLife();
            health = initialHealth;
        }
        
        DestorySelf();
    }

    private void DestorySelf()
    {
        if (destroyOnDeath)
        {
            if (soundOnDestruction != null)
            {
                AudioSource.PlayClipAtPoint(soundOnDestruction, gameObject.transform.position);
            }
            Destroy(gameObject);
        }
    }
}
