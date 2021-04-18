
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rigid;
    public int damage = 50;
    public GameObject impact;

    // Start is called before the first frame update
    void Start()
    {
        rigid.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
            Instantiate(impact, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        Boss boss = hitInfo.GetComponent<Boss>();
        if (boss != null)
        {
            boss.takeDamage(damage);
            Instantiate(impact, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }


}
