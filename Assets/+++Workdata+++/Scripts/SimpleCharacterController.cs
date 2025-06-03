using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
   [SerializeField] private float speed;
   private Rigidbody2D body;

   private void Awake() //wird sofort aufgerufen wenn das Script gestartet wird
   {
      
      body = GetComponent<Rigidbody2D>(); //wird nachschauen ob es den Komponenten gibt und legt es in der Body Variable ab
      
   }

   private void Update()
   {
      body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed,body.linearVelocity.y);
      //wie schnell sich der Playerchara bewegt und in welcher Richtung
      
      if(Input.GetKey(KeyCode.Space))
         body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
   }
   
}
