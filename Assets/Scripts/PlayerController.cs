using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public int life = 0;
    public int playerDamage;
    [SerializeField] private float bananaSpeed;

    

    public Rigidbody2D rig;
    public Animator anim;
    public GameObject ammo;
    public GameObject characterPosition;
    public GameObject characterPosition2;
    public GameObject enemy;
    public SpriteRenderer sprite;

    private bool isShooting = false;
    private Vector2 moveDirection;
    [SerializeField]private Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    [SerializeField]float timeToShot;
    [SerializeField]float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        idle();
        shot();
        Die();
}

    private void FixedUpdate()
    {
        Movement();
    }


    void Movement()
    {
        rig.velocity = moveDirection * speed;
        if (isShooting == false && moveDirection.x != 0 || moveDirection.y != 0)
        {
            anim.SetInteger("Transition", 1);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            movingLeft();
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            sprite.flipX = false;
        }
        
        
    }

    void movingLeft()
    {
        if(moveDirection.x < 0)
        {
            sprite.flipX = true;
        }
    }

    void shot()
    {
        if (isShooting)
        {
            if (currentTime >= timeToShot)
            {
                Transform shotPoint = characterPosition.transform;
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = (Vector2)(mousePos - transform.position);
                direction.Normalize();
                GameObject Banana;



                if (mousePos.x < 0)                    
                {
                    shotPoint = characterPosition2.transform;
                    Banana = Instantiate(ammo, shotPoint.position, transform.rotation);
                }
                else
                {
                    Banana = Instantiate(ammo, shotPoint.position, transform.rotation);

                }
                Banana.GetComponent<Rigidbody2D>().velocity = direction * bananaSpeed;
                currentTime = 0;
                isShooting = false;
            }
            else
            {
                currentTime += Time.deltaTime;
            }
        }
        if (Input.GetButtonDown("Fire2") && !isShooting)
            {
           
                anim.SetTrigger("Banana");
                isShooting = true;
                currentTime = 0;
            }
        
    }

    void idle()
    {
        if(moveDirection.x == 0 && moveDirection.y == 0 && isShooting == false)
        {
            anim.SetInteger("Transition", 0);
        }
        
    }

    /*void Hit()
    {
        if (isHitting)
        {
            if (currentTimeHit >= timeToHit)
            {
                enemy.GetComponent<MonkeController>().TakeDamage(playerDamage);
                currentTimeHit = 0;
                
                isHitting = false;
            }
            else
            {
                currentTimeHit += Time.deltaTime;
            }
        }
        if (Input.GetButtonDown("Fire1") && !isHitting)
        {
            anim.SetTrigger("IsAttacking");
            isHitting = true;
            currentTimeHit = 0;
        }
    }*/

    void Die()
    {
        if(life <= 0)
        {
           
            Debug.Log("GAME OVER");
        }
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
    }
}
