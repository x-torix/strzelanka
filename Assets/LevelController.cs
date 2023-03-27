using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelController : MonoBehaviour
{

    GameObject ZombiePrefab;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length < 3)
        {
            Instantiate(ZombiePrefab, GetRandomSpawnPosition(), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPoint;
        do
        {
            Vector3 spawnPoint = Random.insideUnitSphere;
            spawnPoint.y = 0f;
            spawnPoint = spawnPoint.normalized;
            spawnPoint *= Random.Range(10f, 20f);
        } while Physics.CheckSphere(new Vector3(spawnPoint.x, 1, spawnPoint.z), 0.9f);
        
        return spawnPoint;  

    }
}




//        Vector3 position = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
//position = position.normalized * Random.Range(10, 15);
//return position;