using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerstats : MonoBehaviour
{
    public float health=100;
    public float sordi=0;
    public float collisionTime;
    public Text money;
    public Text helth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        money.text = "sordi " + sordi;
        helth.text = "helth " + health.ToString("F0");
        if (health <= 0)
        {
            GameOver();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    public void AddMoney(float money)
    {
        sordi += money;
    }
    public float GetMoney()
    {
        return sordi;
    }
    void GameOver()
    {
        
    }
}
