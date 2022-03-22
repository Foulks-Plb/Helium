using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpringJoint2D sj;

    private float releaseDelay;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sj = GetComponent<SpringJoint2D>();
        rb.isKinematic = true;

        releaseDelay = 1 / (sj.frequency * 4);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            switch ( touch.phase )
            {
                case TouchPhase.Moved :
                    rb.position = touch.position;
                    rb.isKinematic = true;
                    break;

                case TouchPhase.Ended :
                    rb.isKinematic = false;
                    StartCoroutine(Release());
                    break;
            }

        }

    }

    private IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDelay);
        sj.enabled = false;
    }
}
