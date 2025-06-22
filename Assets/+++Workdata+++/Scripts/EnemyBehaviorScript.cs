using UnityEngine;

public class EnemyBehaviorScript : MonoBehaviour
{
    [SerializeField] private Transform linkeSeite;
    [SerializeField] private Transform rechteSeite;

    [SerializeField] private Transform gegner;

    [SerializeField] private float schnelligkeit;
    private Vector3 initScale;
    private bool linksBewegen;

    [SerializeField] private Animator animateur;


    private void Awake()
    {
        initScale = gegner.localScale; 
    }

    private void Update()
    {
        if (linksBewegen)
        {
            if(gegner.position.x > linkeSeite.position.x)
               InRichtungBewegen(-1);
            else
            
                RichtungsWechsel();
            

        }
        else
        {
            if (gegner.position.x < rechteSeite.position.x)
                InRichtungBewegen(1);
            else
            
                RichtungsWechsel();
            
        }
        
    }

    private void RichtungsWechsel()
    {

        animateur.SetBool("moving", false); //beim Stillstand
        linksBewegen = !linksBewegen; // ! = hebt den Value von linksBewgen auf
    }

    private void InRichtungBewegen(int direction)
    {
        animateur.SetBool("moving", true); //beim bewegen


        //Gegner schaut in die Richtung
        gegner.localScale = new Vector3(initScale.x * -direction, initScale.y, initScale.z);


        //bewegt sich in der Richtung
        gegner.position = new Vector3(gegner.position.x + Time.deltaTime * direction * schnelligkeit,
            gegner.position.y,gegner.position.z);

    }
}
