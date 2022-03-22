using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TransitionContact : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.GetComponent<SpriteRenderer>().bounds.Intersects()
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "CloudContact")
        {
            if (transform.GetComponent<SpriteRenderer>().bounds.Intersects(col.transform.GetComponent<SpriteMask>().bounds))
            {
                //print("true");
                transform.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "CloudContact")
        {
            //print("false");
            transform.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
