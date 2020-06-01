using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject virus;
    public Transform[] spawnPoints;
    public float minDelay = .1f;
    public float maxDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnVirus());
    }

    IEnumerator spawnVirus ()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject spawnedVirus = Instantiate(virus, spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedVirus, 5f);
        }
    }

   
}
