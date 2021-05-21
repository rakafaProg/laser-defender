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

    int toNextLevel = 1000;

    Quaternion quaternion;
    PlayerManager activePlayer;

    bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        quaternion = new Quaternion();
        UpdateScoreUI();
        InitiateLifeState();

        activePlayer = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted) return;
        if (Input.GetMouseButtonDown(0))
        {
            LooseLife();
        }

        if (Input.GetMouseButton(1))
        {
            AddScore();
        }
    }

    void AddScore()
    {
        score += 34;
        toNextLevel -= 34;
        UpdateScoreUI();
        if (toNextLevel <= 0)
        {
            activePlayer.UpgradeLevel();
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
        livesGameObjects[life] = Instantiate(lifeSprite, newPosition, quaternion);
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

    void InitiateLifeState ()
    {
        life = 0;
        for (int i = 0; i < livesGameObjects.Length; i++)
        {
            AddLife();
        }
        gameStarted = true;
    }
}
