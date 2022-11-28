using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieController : MonoBehaviour
{
    public GameObject target;
    public GameObject zombie;
    public GameObject[] spawners;
    public int maxEnemies=10;
    public float spawnRate = 5f;
    float nextSpawn = 0f;
    int lastSpawnerUsed;
    

    // Start is called before the first frame update
 
    void Start()
    {
        //animatorZombie.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextSpawn<Time.time)
        {
            
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
            {
                int rand = Random.Range(0, spawners.Length); ;
                while (rand == lastSpawnerUsed)
                {
                    rand = Random.Range(0, spawners.Length);
                }
                Instantiate(zombie, spawners[rand].transform);
                lastSpawnerUsed = rand;
            }
            
            nextSpawn = Time.time + spawnRate;

        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void SetActiveAnimator() 
    {
        GameObject.Instantiate(zombie, target.transform);

        //animatorZombie.enabled = true;
    }
    public void DeactivateAnimator()
    {
        //animatorZombie.enabled = false;
        
    }
}
