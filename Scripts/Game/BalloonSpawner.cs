using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject[] enemies;

    public float spawnWait;
    public float Timer;

    Gameplay gameplayInfos;
    public GameObject Player;

    bool toggle = false;

    // Start is called before the first frame update
    void Start()
    {
        gameplayInfos = Player.GetComponent<Gameplay>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameplayInfos.Playing)
        {

            Timer += Time.deltaTime;
            
            

            if (!toggle)
            {
                Timer = 0;
                StartCoroutine(waitSpawner());
                toggle = true;              
            }

            else if (Timer < 5f)
            {
                spawnWait = Random.Range(1.5f, 2.5f);
                
            }

            else if (Timer > 5f && Timer < 10f)
            {
                spawnWait = Random.Range(1.5f, 2f);
                
            }

            else if (Timer > 10f && Timer < 20f)
            {
                spawnWait = Random.Range(1.4f, 1.8f);
                
                
            }

            else if (Timer > 20f && Timer < 30f)
            {
                spawnWait = Random.Range(1.3f, 1.7f);
                
            }

            else if (Timer > 30f && Timer < 40f)
            {
                spawnWait = Random.Range(1.2f, 1.6f);
                
            }

            else if (Timer > 40f && Timer < 50f)
            {
                spawnWait = Random.Range(1f, 1.4f);               
            }

            else if (Timer > 50f && Timer < 80f)
            {
                spawnWait = Random.Range(0.6f, 1f);
            }

            else if (Timer > 80f && Timer < 110f)
            {
                spawnWait = Random.Range(0.4f, 0.8f);
            }
            else if (Timer > 110f && Timer < 125f)
            {
                spawnWait = Random.Range(0.2f, 0.5f);
            }
            else if (Timer > 125f && Timer < 150f)
            {
                spawnWait = Random.Range(0.2f, 0.4f);
            }
            else if (Timer > 150f && Timer < 170f)
            {
                spawnWait = Random.Range(0.15f, 0.3f);
            }
            else if (Timer > 170f && Timer < 180f)
            {
                spawnWait = Random.Range(0.1f, 0.25f);
            }
            else if (Timer > 180f && Timer < 200f)
            {
                spawnWait = Random.Range(0.1f, 0.2f);
            }
            else if (Timer > 200f && Timer < 220f)
            {
                spawnWait = Random.Range(0.05f, 0.15f);
            }
            else if (Timer > 220f && Timer < 240f)
            {
                spawnWait = Random.Range(0.04f, 0.1f);
            }
            else if (Timer > 240f && Timer < 260f)
            {
                spawnWait = Random.Range(0.02f, 0.05f);
            }
            else if (Timer > 260f && Timer < 400f)
            {
                spawnWait = Random.Range(0.01f, 0.02f);
            }
            else if (Timer > 400f)
            {
                spawnWait = 0;
            }
        }
        else
        {
            toggle = false;
        }
    }

    IEnumerator waitSpawner()
    {
        if (gameplayInfos.Playing)
        {
            yield return new WaitForSeconds(0);

            while (true)
            {
                GameObject Balloon = Instantiate(enemies[Random.Range(0, 8)], transform.position, transform.rotation);
                SoundFx.RandomPopSound(Random.Range(0, 4));

                Balloon.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * Random.Range(150, 200), Random.Range(0, 1)));

                yield return new WaitForSeconds(spawnWait);
            }
        }
    }

   
}
