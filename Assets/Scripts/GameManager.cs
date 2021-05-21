using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    const int MAX_LIFE = 10;
    [SerializeField] int score = 0;
    [SerializeField] int life = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject lifeSprite;

    [SerializeField] Vector3 firstLifePosition;
    [SerializeField] Vector3 distanceBetweenLifeSprites;
    [SerializeField] Vector3 lastSpawnedLifePosition;
    [SerializeField] GameObject[] livesGameObjects;

    [SerializeField] float shootingInterval = 0.25f;

    int toNextLevel = 1000;
    int level = 0;

    PlayerManager activePlayer;
    Laser laser;

    bool isShooting = false;
    Coroutine shootingCorotine;


    bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreUI();

        InitiateLifeState();

        activePlayer = FindObjectOfType<PlayerManager>();
        laser = FindObjectOfType<Laser>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted) return;

        HandlePlayerShooting();

        //if (Input.GetMouseButton(1))
        //{
        //    AddScore();
        //}
    }

    void AddScore()
    {
        score += 34;
        toNextLevel -= 34;
        UpdateScoreUI();
        if (toNextLevel <= 0)
        {
            level++;
            activePlayer.SetLevel(level);
            toNextLevel = 1000;
        }
    }

    void UpdateScoreUI ()
    {
        scoreText.text = score.ToString();
    }

    void AddLife()
    {
        if (life == MAX_LIFE - 1) return;
        Vector3 newPosition = firstLifePosition + (distanceBetweenLifeSprites * (life));
        livesGameObjects[life] = Instantiate(lifeSprite, newPosition, Quaternion.identity);
        life++;
    }

    void LooseLife()
    {
        life--;
        if (life < 0)
        {
            Debug.Log("LOSER !!");
            return;
        }

        Destroy(livesGameObjects[life]);
    }


    void HandlePlayerShooting () {
        if (Input.GetButtonDown("Fire1"))
        {
            isShooting = true;
            shootingCorotine = StartCoroutine(InifinetShooting());
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
            if (shootingCorotine != null)
            {
                StopCoroutine(shootingCorotine);
            }
        }
    }


    void InitiateLifeState ()
    {
        life = 0;
        for (int i = 0; i < livesGameObjects.Length; i++)
        {
            AddLife();
        }
        gameStarted = true;
    }

    IEnumerator InifinetShooting ()
    {
        while (isShooting) {
            laser.Shoot(level, activePlayer.transform.position);
            yield return new WaitForSeconds(shootingInterval);
        }
    }
}
