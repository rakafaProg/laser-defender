using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] Sprite[] levelSprites;
    [SerializeField] int level = 0;

    SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        UpgradeLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeLevel()
    {
        if (level < levelSprites.Length)
        {
            mySpriteRenderer.sprite = levelSprites[level];
        }
        level++;
    }
}
