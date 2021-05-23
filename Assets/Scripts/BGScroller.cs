using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.5f;
    Material bgRenderer;
    Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        bgRenderer = GetComponent<Renderer>().material;
        offset = new Vector2(0, scrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        bgRenderer.mainTextureOffset += offset * Time.deltaTime;
    }
}
