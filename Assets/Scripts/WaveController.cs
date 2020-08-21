using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    public Text wave;
    public GameObject[] enemies;
    private float nextWaveTime = 0f;
    private int enemyNumber=0;
    public float waveRate=15;
    private float timeleft;
    // Start is called before the first frame update
    void Start()
    {
        timeleft = waveRate;
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        wave.text = "next Wave:" + (timeleft.ToString("F2"));
        if ( Time.time >= nextWaveTime)
        {
            nextWaveTime = Time.time + waveRate;
            Spawn(enemyNumber);
            enemyNumber++;
            if (enemyNumber == enemies.Length) enemyNumber = 0;
            if (waveRate >= 5)
            {
                timeleft = waveRate;
                waveRate = waveRate * 0.75f;   
            }
            else
            {
                timeleft = waveRate;
                waveRate = 6.66f;
            }
        }
    }

    void Spawn(int enemy)
    {
        GameObject hazard = enemies[Random.Range(0, enemies.Length)];
        //Vector3[] spawnPositions = new[] { new Vector3(20, 5, 0), new Vector3(20, 3, 0), new Vector3(20, 1, 0), new Vector3(20, -1, 0), new Vector3(20, -3, 0), new Vector3(20, -5, 0) };
        Quaternion spawnRotation = Quaternion.identity;
        for (int i = 1; i < 6; i++)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], RandomSpawnLocation(), spawnRotation);
        }
    }

     Vector3 RandomSpawnLocation()
    {
        Vector3 v = new Vector3(Random.Range(-22, 22), 1, Random.Range(-22, 22));
        return v;
    }
}
