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
    public AudioClip saltosound;
    public AudioClip balasound;
    private AudioSource audioSource;
    // Estados del personaje
    
    const int IDLE = 1; 
    const int RUN = 2;
    const int JUMP = 3;
    const int ATTACK = 4;
    
    
    const int vRun = 3;
    const int jumForce = 7;

    public int hongo=0;
    public bool enSuelo = true;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameManagerController = FindObjectOfType<GameManagerController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(live) {                         
            if(Input.GetKey(KeyCode.RightArrow)) {
                Derecha();
            }
            if(Input.GetKeyUp(KeyCode.RightArrow)) {
                DetenerDerecha();
            }
            if(Input.GetKey(KeyCode.LeftArrow)) {
                Izquierda();
            }
             if(Input.GetKeyUp(KeyCode.LeftArrow)) {
                DetenerIzquierda();
            }

            if(Input.GetKeyUp(KeyCode.F)) {
                Disparar();
            }
            if(Input.GetKeyUp(KeyCode.A)) {
               Saltar();
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
        } else {
            var posicion =transform.position + new Vector3(-1.5f,0,0);
            var gb = Instantiate(bala,posicion,Quaternion.identity);
            var controlador = gb.GetComponent<BalaController>();            
        }
    }
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag ==  "Enemy") {
            gameManagerController.perderVidas();
        }
        if (other.gameObject.tag == "Mapa"){
            enSuelo = true; // El jugador está en el suelo. 
            SetAnimacion(IDLE);           
        }
    }
    public void Saltar() {
        if (enSuelo) {         
            rb.AddForce(new Vector2(0,jumForce),ForceMode2D.Impulse);
             // El jugador ya no está en el suelo.
            SetAnimacion(JUMP); 
            audioSource.PlayOneShot(saltosound);
            enSuelo = false;                  
        }        
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
    public void Izquierda(){
        sr.flipX = true;
        rb.velocity = new Vector2(-vRun,rb.velocity.y);
        SetAnimacion(RUN);
    }

    public void DetenerIzquierda(){
        sr.flipX = true;
        rb.velocity = new Vector2(0,rb.velocity.y);
        SetAnimacion(IDLE);
    }

    public void Disparar(){  
        crearBala(vRun); 
        SetAnimacion(ATTACK);   
        audioSource.PlayOneShot(balasound);     
    } 
}
