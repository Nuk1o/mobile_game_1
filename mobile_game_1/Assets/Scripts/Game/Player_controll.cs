using UnityEngine;

public class Player_controll : MonoBehaviour
{
    private bool isMoving = false;
    private Vector3 targetPosition;
    private float speed = 1.8f;

    private Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction,Mathf.Infinity);          
            try
            {
                Debug.Log(hit.collider);
                Debug.Log(hit.collider.gameObject.tag);
                if (hit.collider.gameObject.tag == "map_ground")
                {
                    SetTargetPosition();
                }
                if (hit.collider.gameObject.tag == "map_block")
                {
                    Vector3 vec_pos_obj = hit.collider.transform.position;
                    SetTargetPosition1(vec_pos_obj, 1.2f,0);
                }
                if (hit.collider.gameObject.tag == "map_truck")
                {
                    Vector3 vec_pos_obj = hit.collider.transform.position;
                    SetTargetPosition1(vec_pos_obj,2.5f,0);
                }
                if (hit.collider.gameObject.tag == "map_dirt_row")
                {
                    Vector3 vec_pos_obj = hit.collider.transform.position;
                    SetTargetPosition1(vec_pos_obj, 0, 1.2f);
                }
                if (hit.collider.gameObject.tag == "block_dirt")
                {
                    Vector3 vec_pos_obj = hit.collider.transform.position;
                    SetTargetPosition1(vec_pos_obj, 0, 1.2f);
                }
                if (hit.collider.gameObject.tag == "btns")
                {
                    Debug.Log("������");
                }
            }
            catch
            {
                Debug.Log("�� ��������� �����");                
            }         
        }
        if (isMoving)
        {
            Move_p();
        }
    }

    private void SetTargetPosition()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;

        isMoving = true;
    }

    private void SetTargetPosition1(Vector3 vec_pos_obj, float dist, float dist2)
    {
        targetPosition = new Vector3(vec_pos_obj.x - dist, vec_pos_obj.y - dist2, vec_pos_obj.z);
        targetPosition.z = transform.position.z;
        isMoving = true;
    }

    private void Move_p()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }
}
