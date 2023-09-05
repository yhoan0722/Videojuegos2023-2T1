using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{
   Rigidbody2D rb;
    public float velocidadx = 5f;
    public float velocidady = 0f;
    public GameObject bala; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();       
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocidadx,velocidady);
        
    }
    void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag ==  "Enemy" || other.gameObject.tag ==  "Mapa") {
            Destroy(this.gameObject);
        }
    }
}
