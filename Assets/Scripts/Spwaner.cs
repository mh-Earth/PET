using System.Collections;
using UnityEngine;

// A class for spawning rocks
public class Spwaner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] SpawnerList;

    [SerializeField]
    private GameObject[] Rocks;
    public static float SpawnDelay;
    [SerializeField]
    private float maxSpawnDelay = .5f;
    private bool isFirst = true;

    private void OnEnable()
    {

        // SpawnDelay = GameManager.SpawnDelay;
        if (!isFirst){

            StartCoroutine(spawnRocks());
        }
    }

    private void Start() {
        isFirst = false;
        SpawnDelay = GameManager.SpawnDelay;
        StartCoroutine(spawnRocks());
        
    }


    IEnumerator spawnRocks()
    {

        while (true)
        {
            Vector3 pos = SpawnerList[Random.Range(0, SpawnerList.Length)].transform.position;
            GameObject rock = Rocks[Random.Range(0, Rocks.Length)];


            if (SpawnDelay > maxSpawnDelay)
            {

                SpawnDelay = SpawnDelay - .01f;

            }
            

            Instantiate(rock, pos, Quaternion.identity);
            yield return new WaitForSeconds(SpawnDelay);
        }


    }


}
