
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject finalText;
    public int health = 100;

    public GameObject deathFX;

    public void takeDamage (int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            die();
            finalText.SetActive(true);
        }
    }

    void die() 
    {
        Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
