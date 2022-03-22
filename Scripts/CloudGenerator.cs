using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    public GameObject cloudW;
    public float respawnTime = 1.0f;
    public float MaxSpawnY = 3.0f;
    public float MinSpawnY = 1.0f;

    float minMaxDiff;
    int randomMaxStep;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cloudWave());

        minMaxDiff = MaxSpawnY - MinSpawnY;
        randomMaxStep = Mathf.RoundToInt( minMaxDiff / 0.32f);
    }

    private void spawnCloud()
    {
        GameObject a = Instantiate(cloudW) as GameObject;
        a.transform.position = new Vector2(3, Random.Range(MinSpawnY, MaxSpawnY));
      

    }

    private void StepedRandomCloud() // non overlapping cloud
    {
        GameObject a = Instantiate(cloudW) as GameObject;
        a.transform.position = new Vector2(3, MinSpawnY + (Random.Range(0, randomMaxStep) * .32f));
    }

    IEnumerator cloudWave(){
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            //spawnCloud();
            StepedRandomCloud();
        }

    }
    
}
