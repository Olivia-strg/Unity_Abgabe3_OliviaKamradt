
using UnityEngine;


public class CameraController : MonoBehaviour
{

    public float KameraSpeed = 2f;
    public Transform ziel;

    private void LateUpdate()
    {
        Vector3 neuePos = new Vector3(ziel.position.x, ziel.position.y, -2f); //lerp = interpoliert eine gerade Linie zwischen zwei Punkten 
        transform.position = Vector3.Lerp(transform.position, neuePos, KameraSpeed * Time.deltaTime);
    }


}
