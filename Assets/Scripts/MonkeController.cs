using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeController : MonoBehaviour
{
    public int monkeLife = 3;
    public float monkeDamage = .5f;
    public float bananaSpeed;
    private bool isDieing = false;

    [SerializeField] public Transform enemyPos;
    public Animator anim;
    public Transform hitLoc;
    public GameObject ammo;
    public GameObject gamecontroller;

    public bool isShoting;
    private float currentTime = 0;
    [SerializeField] private float timeToShot = 0;
    private float instantiateNow = .8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(monkeLife <= 0)
        {
            die();
            Invoke("DestroyBody", 1f);
            gamecontroller.GetComponent<GameController>().qntMamacos--;
        }
        attack();
    }

    void DestroyBody()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        monkeLife -= damage;
    }

    void die()
    {
        isDieing = true;
        anim.SetTrigger("Died");
        
    }

    void attack()
    {
        if (isShoting && !isDieing)
        {
            if (currentTime >= instantiateNow)
            {
                Transform shotPoint = hitLoc.transform;
                Vector2 direction = (Vector2)(enemyPos.position - transform.position);
                direction.Normalize();
                GameObject Banana;

                Banana = Instantiate(ammo, shotPoint.position, transform.rotation);
                Banana.GetComponent<Rigidbody2D>().velocity = direction * bananaSpeed;
                currentTime = 0;
                isShoting = false;
                anim.SetBool("isAttacking", false);
            }
            else
            {
                currentTime += Time.deltaTime;
            }

        }
        if (!isShoting && !isDieing)
        {
            if (currentTime < timeToShot)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                anim.SetBool("isAttacking",true);
                isShoting = true;
                currentTime = 0;
            }
        }
        
    }
}
