using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private int index = 0;
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;

    // animation controller    
    private int animSpeed = 1;
    private int animCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Animate), 0.15f, 0.15f);
    }
    public void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Animate(){
        index++;

        if(index >= sprites.Length){
            index = 0;
        }

        spriteRenderer.sprite = sprites[index];
    }
}
