using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public int bananaDamage = 1;
    public float distance;
    public float bananaSpeed;
    public LayerMask EnemyLayer;


    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D bananaHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(enemy.transform.position.x, enemy.transform.position.y), distance, EnemyLayer);
        if (bananaHit.collider != null)
        {
            if (bananaHit.collider.CompareTag("Player"))
            {
                bananaHit.collider.GetComponent<PlayerController>().TakeDamage(bananaDamage);
                Debug.Log("Player vida= " + bananaHit.collider.GetComponent<BoitataController>().monkeLife);
                destroyBanana();
            }

            destroyBanana();

        }
    }

    public void destroyBanana()
    {
        Destroy(gameObject);
    }



}
