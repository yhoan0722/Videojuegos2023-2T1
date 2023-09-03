using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{
   Rigidbody2D rb;
    public float velocidadx = 5f;
    public float velocidady = 0f;
    public GameObject bala; 
    public bool partirse = true;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocidadx,velocidady);
        if(Input.GetKeyDown(KeyCode.Z) && partirse == true) {
            var posicion1 =transform.position + new Vector3(0,-1,0);
            var gb1 = Instantiate(bala,posicion1,Quaternion.identity);
            var controlador1 = gb1.GetComponent<BalaController>();
            controlador1.darvelocidady(-2f);
            controlador1.quitarPartirse();
            quitarPartirse();
        }
    }
    
    public void darvelocidadx(float _nuevaVelocidad) {
        velocidadx = _nuevaVelocidad;        
    }
    public void darvelocidady(float _nuevaVelocidad) {
        velocidady = _nuevaVelocidad;       
    }
    public void quitarPartirse() {
        partirse = false;
    }

    void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag ==  "Enemy" || other.gameObject.tag ==  "Mapa") {
            Destroy(this.gameObject);
        }
    }
}
