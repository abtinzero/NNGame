using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Playerstats : MonoBehaviour
{
    public float health=100;
    public float sordi=0;
    public float score = 0;
    public float collisionTime;
    public Text money;
    public Text helth;
    public TMP_Text scoretext;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MenuScene");
        }
        money.text = "sordi " + sordi;
        helth.text = "helth " + health.ToString("F0");
        scoretext.text = "Score: " + score;
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
    public void AddScore(float punteggio)
    {
        score += punteggio;

    }
    public float GetMoney()
    {
        return sordi;
    }
    void GameOver()
    {
        SceneManager.LoadScene("MainScene");
    }
}
