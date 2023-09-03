using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    bool live = true;
    // Start is called before the first frame update
    SpriteRenderer sr;
    Rigidbody2D rb;
    Animator animator;

     public GameObject bala; 
     public GameManagerController gameManagerController;
    // Estados del personaje
    
    const int IDLE = 1; 
    const int RUN = 2;
    const int JUMP = 3;
    
    const int vStop = 0;
    const int vRun = 10;
    const int jumForce = 5;

    public int hongo=0;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameManagerController = FindObjectOfType<GameManagerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(live) {
                        
            if(Input.GetKeyDown(KeyCode.RightArrow)) {
                Derecha();
            }
            if(Input.GetKeyUp(KeyCode.RightArrow)) {
                DetenerDerecha();
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow)) {
                Izquierda();
            }
             if(Input.GetKeyUp(KeyCode.LeftArrow)) {
                DetenerIzquierda();
            }            

            if(Input.GetKeyUp(KeyCode.Space)) {
                Saltar();
            }
            if(Input.GetKeyUp(KeyCode.F)) {
                Disparar();
            }
           
        }

       
    }
    void SetAnimacion(int animacion) {
        animator.SetInteger("estado",animacion);
    }

     void crearBala(float velocidad) {
        
        if(sr.flipX == false){
            var posicion =transform.position + new Vector3(1.5f,0,0);
            var gb = Instantiate(bala, posicion ,Quaternion.identity);
            var controlador = gb.GetComponent<BalaController>();
            controlador.darvelocidadx(5f);
        } else {
            var posicion =transform.position + new Vector3(-1.5f,0,0);
            var gb = Instantiate(bala,posicion,Quaternion.identity);
            var controlador = gb.GetComponent<BalaController>();
            controlador.darvelocidadx(-5f);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag ==  "Enemy") {
            gameManagerController.perderVidas();
        }
       
       
    }

    public void Saltar() {
        //sr.flipX = true ;
        rb.AddForce(new Vector2(0,jumForce),ForceMode2D.Impulse);
        //SetAnimacion(JUMP);
        
    }

    public void Derecha(){
        sr.flipX = false ;
        rb.velocity = new Vector2(vRun,rb.velocity.y);
        SetAnimacion(RUN);
    }

    public void DetenerDerecha(){
        sr.flipX = false ;
        rb.velocity = new Vector2(0,rb.velocity.y);
        SetAnimacion(IDLE);
    }
    public void Izquierda() {
        sr.flipX = true;
        rb.velocity = new Vector2(-vRun,rb.velocity.y);
        SetAnimacion(RUN);
    }

    public void DetenerIzquierda(){
        sr.flipX = false;
        rb.velocity = new Vector2(0,rb.velocity.y);
        SetAnimacion(IDLE);
    }

     public void Disparar() {        
        crearBala(vRun);        
    }
   
}
