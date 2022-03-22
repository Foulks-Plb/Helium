using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Baloon : MonoBehaviour
{

    public GameObject FloatingText;
    public int ScorePlus;
    public bool OkForAction;
    public GameObject ParticuleExplosion;
    public Color ColorBalloon;

  
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Projectile" && OkForAction)
        {
            GameObject ParticuleGameobject = Instantiate(ParticuleExplosion, transform.position, Quaternion.Euler(0, 0, 0));
            var main = ParticuleGameobject.GetComponent<ParticleSystem>().main;
            main.startColor = ColorBalloon;

            ScoreScript.ScoreValue += ScorePlus;
            Destroy(gameObject);
            SoundFx.PlaySound("BalloonPop");

            SoundFx.RandomCoinPlusSound(Random.Range(0, 3));

            ShowFloatingText();
        }
    }

    void ShowFloatingText()
    {
        var go = Instantiate(FloatingText, transform.position, transform.rotation);
        go.GetComponent<TextMesh>().text = "+" + ScorePlus.ToString();
    }

}

