using UnityEngine;

public class Map_raycast : MonoBehaviour
{
    private void Start()
    {
        transform.transform.position = new Vector3(transform.position.x,transform.position.y,0.12f);
        transform.localScale = new Vector3(20, 9, -1);
        Debug.Log(transform.localScale);
    }
}
