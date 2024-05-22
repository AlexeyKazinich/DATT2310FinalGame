using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRigidBody;

    private Vector2 move;
    public SpriteRenderer spriteRenderer;
    public Sprite[] idleSprites;
    private int idleIndex = 0;
    public Sprite[] movingSprites;
    private int movementIndex = 0;
    
    //slow down the animation
    private int animSpeed = 3;
    private int animCounter = 0;

    // For player info when tab is hold
    public GameObject playerInfoPanel;
    //private bool isPlayerInfoVisible = false;

    public ProjectileBehaviour ProjectilePrefab;
    public Transform LaunchOffset;

    public bool invincible = false;


    //prevent spam
    private bool canShoot = true;
    private readonly float shootDelay = 0.25f; //0.25sec


    // Start is called before the first frame update
    void Start()
    {
       playerInfoPanel.SetActive(false);
    }
     public void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
     }
    // Update is called once per frame
    void Update()
    {
        Door door = FindObjectOfType<Door>();

        // For showing player info when tab is hold
        if(Input.GetKeyDown(KeyCode.Tab) && door.tabKeyEnabled){
            playerInfoPanel.SetActive(true);
        }
        else if(Input.GetKeyUp(KeyCode.Tab)){
            playerInfoPanel.SetActive(false);
        }

        //check if player is trying to shoot right click
        if (Input.GetButtonDown("Fire2")) 
        {
            if (canShoot)
            {
                Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
                canShoot = false;
                CoroutineRunner.Instance.RunCoroutine(ResetCanShootAfterDelay(shootDelay));


            }
        }

        

        //check if player trying to use abilities
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("pressing 1");
            if(PlayerInfo.ability1 != null)
            {
                print("ability is not null");
                PlayerInfo.ability1.TryActivate();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("pressing 2");
            if(PlayerInfo.ability2 != null)
            {
                print("ability is not null");
                PlayerInfo.ability2.TryActivate();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("pressing 3");
            if (PlayerInfo.ability3 != null)
            {
                print("ability is not null");
                PlayerInfo.ability3.TryActivate();
            }
        }


    }

    //reset shoot var after delay
    private IEnumerator ResetCanShootAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }

    public void AssignAbility(int index, Ability ability)
    {
        switch (index)
        {
            case 0:
                PlayerInfo.ability1 = ability;
                break;
            case 1:
                PlayerInfo.ability2 = ability;
                break;
            case 2:
                PlayerInfo.ability3 = ability;
                break;
            default:
                Debug.LogWarning("Ability index out of range.");
                break;
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
            playerRigidBody.velocity = move * PlayerInfo.PlayerSpeed; //set the player velocity to the move vector * the speed
        }
        else
        {
            playerRigidBody.velocity = Vector2.zero; //if player is not holding down movement keys, stop the player from moving
        }


        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right Arrow keys
        float moveY = Input.GetAxisRaw("Vertical"); // W/S or Up/Down Arrow keys

        Door door = FindObjectOfType<Door>();

        // checks if control keys are enabled
        if(door.controlKeysEnabled){
            //normalize to create snappy movement
            move = new Vector2(moveX, moveY).normalized;
        }
        

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
        if (!invincible)
        {
            PlayerInfo.CurrentHealth -= (int)((damageAmount) * (1.0f - PlayerInfo.DmgReduction));
            if (PlayerInfo.CurrentHealth < 0)
                Die();
        }


    }

    private void Die()
    {
        //player has died
        PlayerInfo.victory = false;
        SceneManager.LoadScene(5); //end scene
    }

    
}
