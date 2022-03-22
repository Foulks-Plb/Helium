using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonRescue : MonoBehaviour
{
    public GameObject[] enemies;

    public float spawnWait;

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
            if (Destroyer.LifeNumber <= 2 && !toggle)
            {
                StartCoroutine(LifeRescue());
                toggle = true;                
            }
            else if (Gameplay.AmmoNumberStart <= 5 && !toggle)
            {               
                StartCoroutine(AmmoRescue());
                toggle = true;
            }
        }
        else
        {
            toggle = false;
        }
    }


    IEnumerator LifeRescue()
    {
        if (gameplayInfos.Playing)
        {
            yield return new WaitForSeconds(Random.Range(2, 5));

            while (true)
            {
                if (Destroyer.LifeNumber >= 3)
                {
                    toggle = false;
                    yield break;
                }
                
                GameObject test = Instantiate(enemies[0], transform.position, transform.rotation);
                SoundFx.RandomPopSound(Random.Range(0, 4));

                test.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * Random.Range(150, 200), Random.Range(0, 1)));
               
                yield return new WaitForSeconds(Random.Range(4, 5));
            }
        }
    }

    IEnumerator AmmoRescue()
    {
        if (gameplayInfos.Playing)
        {
            yield return new WaitForSeconds(Random.Range(2, 5));

            while (true)
            {
                if (Gameplay.AmmoNumberStart >= 5)
                {
                    toggle = false;
                    yield break;
                }

                GameObject test = Instantiate(enemies[1], transform.position, transform.rotation);
                SoundFx.RandomPopSound(Random.Range(0, 4));

                test.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * Random.Range(150, 200), Random.Range(0, 1)));

                yield return new WaitForSeconds(Random.Range(3, 5));
            }
        }
    }


}
