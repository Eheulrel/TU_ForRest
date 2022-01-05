using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Transform transformB;
    [SerializeField] private bool switchck = false;

    public GameObject door;
    public bool check = false;

    public Sprite[] sprites;
    public SpriteRenderer spr;

    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nexPos;

    void Start()
    {
        posA = door.transform.localPosition;
        posB = transformB.localPosition;
        nexPos = posB;

        spr = transform.Find("Switch").GetComponent<SpriteRenderer>();
        spr.sprite = sprites[0];
    }

    void FixedUpdate()
    {
        if (switchck)
        {
            if (MoveControl.inputZ)
            {
                check = true;
                spr.sprite = sprites[1];
            }

            if (check)
            {
                Move();
            }                
        }       
    }

    private void Move()
    {
        door.transform.localPosition = Vector3.MoveTowards(door.transform.localPosition, nexPos, speed * Time.deltaTime);

        if (Vector3.Distance(door.transform.localPosition, nexPos) <= 0.05f)
        {
            switchck = false;
            spr.sprite = sprites[0];
        }
    }  

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switchck = true;
        }
    }
}
