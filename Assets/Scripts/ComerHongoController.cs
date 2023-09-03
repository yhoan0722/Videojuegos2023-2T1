using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComerHongoController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    
    public GameManagerController gameManagerController;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManagerController = FindObjectOfType<GameManagerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag ==  "Player") {
            gameManagerController.comerHongos();
            Destroy(this.gameObject);
        }
    }
}
