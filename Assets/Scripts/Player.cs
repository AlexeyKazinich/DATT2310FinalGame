using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRigidBody;

    public float speed = 0.3f;
    private Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right Arrow keys
        float moveY = Input.GetAxisRaw("Vertical"); // W/S or Up/Down Arrow keys

        //normalize to create snappy movement
        move = new Vector2(moveX, moveY).normalized;
        
    }

    //called at a fixed interval and is independent of frame rate. physics code here
    private void FixedUpdate()
    {
        //if player holding movement keys
        if(move != Vector2.zero)
        {
            playerRigidBody.velocity = move * speed; //set the player velocity to the move vector * the speed
        }
        else
        {
            playerRigidBody.velocity = Vector2.zero; //if player is not holding down movement keys, stop the player from moving
        }
    }
}
