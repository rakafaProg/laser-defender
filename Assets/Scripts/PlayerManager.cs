using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] Sprite[] levelSprites;

    float minXPos;
    float minYPos;
    float maxXPos;
    float maxYPos;

    [SerializeField] float screenUnitsWidth = 6f;
    [SerializeField] float screenUnitsHeight = 10f;

    [SerializeField] float movmentSpeed = 20f;

    SpriteRenderer mySpriteRenderer;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();

        SetLevel(0);
        SetMovemntBoundries();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    DamageDealer damager = collision.GetComponent<DamageDealer>();
    //    if (damager != null)
    //    {
    //        gameManager.LooseHealth(damager.GetDamage());
    //        damager.OnHit();
    //    }
    //}

    void SetMovemntBoundries()
    {
        Camera gameCamera = Camera.main;
        minXPos = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + 0.8f;
        maxXPos = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - 0.8f;

        minYPos = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + 1f;
        maxYPos = gameCamera.ViewportToWorldPoint(new Vector3(0, 0.6f, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        // SetPlayerPosition(new Vector3(ToScreenWUnits(Input.mousePosition.x), ToScreenHUnits(Input.mousePosition.y)));
        Vector3 newPos = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        SetPlayerPosition(transform.position + (newPos * Time.deltaTime * movmentSpeed));
    }


    float ToScreenWUnits(float value)
    {
        float val = value / Screen.width * screenUnitsWidth;
        val -= screenUnitsWidth / 2;
        return val;
    }

    float ToScreenHUnits(float value)
    {
        float val = value / Screen.height * screenUnitsHeight;
        val -= screenUnitsHeight / 2;
        return val;
    }

    private void SetPlayerPosition (Vector3 newPosition)
    {
        float newX = Mathf.Clamp(newPosition.x, minXPos, maxXPos);
        float newY = Mathf.Clamp(newPosition.y, minYPos, maxYPos);

        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    public void SetLevel(int level)
    {
        if (level < levelSprites.Length)
        {
            mySpriteRenderer.sprite = levelSprites[level];
        }
    }


   
}
