using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRigidBody;

    public float speed = 0.3f;
    private Vector2 move;
    public SpriteRenderer spriteRenderer;
    public Sprite[] idleSprites;
    private int idleIndex = 0;
    public Sprite[] movingSprites;
    private int movementIndex = 0;

    //slow down the animation
    private int animSpeed = 3;
    private int animCounter = 0;

    

    public ProjectileBehaviour ProjectilePrefab;
    public Transform LaunchOffset;

    // Start is called before the first frame update
    void Start()
    {
       
    }
     public void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
     }
    // Update is called once per frame
    void Update()
    {

        //check if player is trying to shoot
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(ProjectilePrefab,LaunchOffset.position,transform.rotation);
        }

        

    }

    private void PlayerIdle(){
        if (animCounter == animSpeed)
        {
            idleIndex++;
            animCounter = 0;
        }
        else
        {
            animCounter++;
        }

        if(idleIndex >= idleSprites.Length){
            idleIndex = 0;
        }

        spriteRenderer.sprite = idleSprites[idleIndex];

        //animator.speed = animationSpeed;
    }
    private void PlayerMoving(){
        if(animCounter == animSpeed)
        {
            movementIndex++;
            animCounter=0;
        }
        else
        {
            animCounter++;
        }

        if(movementIndex >= movingSprites.Length){
            movementIndex = 0;
        }

        spriteRenderer.sprite = movingSprites[movementIndex];
        //animator.speed = animationSpeed;
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


        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right Arrow keys
        float moveY = Input.GetAxisRaw("Vertical"); // W/S or Up/Down Arrow keys

        //normalize to create snappy movement
        move = new Vector2(moveX, moveY).normalized;

        //animation
        if (moveX < 0f)
        {
            spriteRenderer.flipX = true;
            PlayerMoving();
        }
        else if (moveX > 0f)
        {
            spriteRenderer.flipX = false;
            PlayerMoving();
        }
        else if (moveY < 0f)
        {
            PlayerMoving();
        }
        else if (moveY > 0f)
        {
            PlayerMoving();
        }
        else if (move == Vector2.zero)
        {
            PlayerIdle();
        }




    }


    public void updateXP(int amount)
    {
        //This needs some work
        PlayerInfo.addXP(amount);
    }



    public void TakeDamage(float damageAmount)
    {
        //currently using an INT, will need to be updated to a float probably
        PlayerInfo.CurrentHealth -= (int)damageAmount;


    }


}
