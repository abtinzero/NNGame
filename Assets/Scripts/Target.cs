using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Target : MonoBehaviour
{
    public float moneydrop = 100;
    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        FindObjectOfType<RigidbodyFirstPersonController>().GetComponent<Playerstats>().AddMoney(moneydrop);
        FindObjectOfType<RigidbodyFirstPersonController>().GetComponent<Playerstats>().AddScore(moneydrop);
        Destroy(gameObject);
    }
}
