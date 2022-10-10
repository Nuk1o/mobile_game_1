using System.Collections;
using UnityEngine;

public class Seedlings : MonoBehaviour
{
    [SerializeField] SpriteRenderer _rost_img;
    [SerializeField] SpriteRenderer _rost_img2;
    [SerializeField] SpriteRenderer _rost_img3;
    public string rost_txt;
    private Rigidbody2D rb2D;
    private bool isMoving = false;
    private Vector3 targetPosition;
    private float speed = 1.4f;
    bool _isBuild = false;
    private GameObject _rost_go;

    private SpriteRenderer _SR;    

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        _isBuild = false;
    }

    void Update()
    {
        switch (rost_txt)
        {
            case "Potatoes":
                _isBuild = true;
                break;
            case "Aubergine":
                _isBuild = true;
                break;
            case "Pumpkin":
                _isBuild = true;
                break;
            case "Strawberries":
                _isBuild = true;
                break;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            _isBuild = false;
        }

        if (_isBuild)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
                try
                {
                    if (hit.collider.gameObject.tag == "block_dirt")
                    {
                        Vector3 vec_pos_obj = hit.collider.transform.position;
                        SetTargetPosition1(vec_pos_obj, 0, 1.2f);
                        SpriteRenderer _spriteRenderer = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                        _rost_go = hit.collider.gameObject;
                        _SR = _spriteRenderer;
                        StartCoroutine(TestCoroutine());
                    }
                }
                catch
                {
                }                
            }
        }

        if (isMoving)
        {
            Move_p();
        }

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

    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(1);
        _SR.sprite = _rost_img.sprite;
        GameObject gp = new GameObject();
        gp.transform.position = _rost_go.transform.position;        
        SpriteRenderer _rr = gp.AddComponent<SpriteRenderer>();
        Debug.Log("������");
        yield return new WaitForSeconds(10);
        //_SR.sprite = _rost_img2.sprite;
        _rr.sprite = _rost_img2.sprite;
        
    }
}

