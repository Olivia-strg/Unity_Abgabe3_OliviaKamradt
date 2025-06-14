using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private bool grounded; //behält den Überblick ob Spieler auf dem Boden ist
    private Animator animateur;

    private void Awake() //wird sofort aufgerufen wenn das Script gestartet wird
    {
        //wird nachschauen ob es den Komponenten gibt und legt es in der Body Variable ab
        body = GetComponent<Rigidbody2D>(); 
        
        animateur = GetComponent<Animator>();

    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
        //wie schnell sich der Playerchara bewegt und in welcher Richtung

        if (horizontalInput>0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1,1,1);

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        //legt animator parameters fest
        animateur.SetBool("Walk", horizontalInput != 0); //wenn wasd nicht gedrückt sind ist der input 0
        animateur.SetBool("grounded", grounded);

    }

    private void Jump() //wird aufgerufen wenn der Spieler springt
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        grounded = false;
        animateur.SetTrigger("Jump"); //bezogen auf Parameter Jump
    }

    private void OnCollisionEnter2D(Collision2D collision) //wird aufgerufen wenn der Spieler mit dem Boden kollidiert
    {
        if (collision.gameObject.tag == "Ground") //wenn der Spieler mit dem Boden kollidiert
            grounded = true; //setzt die Variable auf true
    }
}
