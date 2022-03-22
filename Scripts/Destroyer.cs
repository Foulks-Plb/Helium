using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour
{

    public static int LifeNumber;
    public Text LifeText;
    public GameObject GameOverPopup;
    public Gameplay ScriptGameplay;

    // Start is called before the first frame update
    void Start()
    {

     

    }

    // Update is called once per frame
    void Update()
    {
        LifeText.text = LifeNumber.ToString();
        

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("enter collider");
        if ((col.gameObject.tag == "Balloonred" || col.gameObject.tag == "Balloonblue" || col.gameObject.tag == "Balloongreen" || col.gameObject.tag == "Balloonyellow" || col.gameObject.tag == "Balloonpink") && LifeNumber > 0)
        {
            LifeNumber -= 1;
            Destroy(col.gameObject);
            SoundFx.PlaySound("LooseLife");
        }
        else if ((col.gameObject.tag == "Balloonred" || col.gameObject.tag == "Balloonblue" || col.gameObject.tag == "Balloongreen" || col.gameObject.tag == "Balloonyellow" || col.gameObject.tag == "Balloonpink" ) && LifeNumber <= 0)
        {
            Destroy(col.gameObject);

        }
        else if ( col.gameObject.tag == "Balloonblack" || col.gameObject.tag == "Balloonwhitel" || col.gameObject.tag == "Balloonwhitea")
        {
            Destroy(col.gameObject);
        }


    }


}
