using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollableEnvironment : MonoBehaviour
{
    [SerializeField]
    float scrollSpeed = 0f;

    [SerializeField]
    float inputSway = 1f;
    Renderer renderer;

    void Start(){
        this.renderer = this.gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {   
        float input = Input.GetAxis("Horizontal");
        float modifiedSpeed = this.scrollSpeed + input * inputSway;
        
        float currentTextureOffsetY = this.renderer.material.mainTextureOffset.y;

        this.renderer.material.mainTextureOffset = new Vector2(0f, currentTextureOffsetY + Time.deltaTime * modifiedSpeed);
    }
}
