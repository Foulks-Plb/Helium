using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public static Collider Collider2D { get; internal set; }
    public int SpeedRotate;
    public int LifeTime;
    public GameObject ParticuleExplosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, SpeedRotate * Time.deltaTime);
        Destroy(gameObject, LifeTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Balloonblack")
        {
            GameObject ParticuleGameobject = Instantiate(ParticuleExplosion, other.transform.position, Quaternion.Euler(0, 0, 0));
            var main = ParticuleGameobject.GetComponent<ParticleSystem>().main;
            main.startColor = new Color (0,0,0);

            Destroy(other.gameObject);
            Destroyer.LifeNumber -= 1;
            SoundFx.PlaySound("BalloonPop");
        }

        if (other.gameObject.tag == "Balloonwhitel")
        {
            GameObject ParticuleGameobject = Instantiate(ParticuleExplosion, other.transform.position, Quaternion.Euler(0, 0, 0));
            var main = ParticuleGameobject.GetComponent<ParticleSystem>().main;
            main.startColor = new Color(0.91f, 0.91f, 0.91f);

            Destroy(other.gameObject);
            Destroyer.LifeNumber += 1;
            SoundFx.PlaySound("BalloonPop");
            SoundFx.PlaySound("LifePlus");
        }

        if (other.gameObject.tag == "Balloonwhitea")
        {
            GameObject ParticuleGameobject = Instantiate(ParticuleExplosion, other.transform.position, Quaternion.Euler(0, 0, 0));
            var main = ParticuleGameobject.GetComponent<ParticleSystem>().main;
            main.startColor = new Color(0.91f, 0.91f, 0.91f);

            Destroy(other.gameObject);
            Gameplay.AmmoNumberStart += 3;
            SoundFx.PlaySound("BalloonPop");
            SoundFx.PlaySound("AmmoPlus");
        }

        if (other.gameObject.tag == "Floor")
        {
            SpeedRotate = 0;
            SoundFx.PlaySound("CutInFloor");
        }
        
            if (other.gameObject.tag == "Spawner")
        {
            Destroy(gameObject);
        }

    }


}
