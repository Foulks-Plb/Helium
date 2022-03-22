using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.25f, 0.4f);
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -3)
        {
            Destroy(this.gameObject);
        }
        
    }
}
