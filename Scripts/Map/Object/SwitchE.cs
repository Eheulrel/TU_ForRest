using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchE : MonoBehaviour
{
    public float speed = 2f;
    public float radius = 0.5f;
    public bool switchOn = false;
    public bool playerin = false;

    public bool check = false;

    public Sprite[] sprites;
    public SpriteRenderer spr;

    [SerializeField] private Transform transformB;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask checkIn;
    [SerializeField] private Transform PlayerCheck;

    GameObject plate;
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 orgPos;

    void Start()
    {
        switchOn = false;
        plate = transform.Find("plate").gameObject;

        spr = transform.Find("Switch").GetComponent<SpriteRenderer>();
        spr.sprite = sprites[0];

        posA = plate.transform.localPosition;
        posB = transformB.localPosition;
        orgPos = posB;
    }

    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(PlayerCheck.position, radius, checkIn);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject) //범위 내의 레이어가 플레이어가 아닐때 발동
            {
                if (!switchOn)
                {
                    Move();
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (switchOn)
        {
            if (MoveControl.inputZ)
            {
                check = true;
                spr.sprite = sprites[1];
            }

            if (check)
            {
                plate.transform.Translate(Vector2.left * speed * Time.deltaTime);

                if (Vector3.Distance(plate.transform.localPosition, orgPos) <= 0.05f)
                {
                    switchOn = false;
                    spr.sprite = sprites[0];
                }
            }                
        }      
    }

    private void Move()
    {
        plate.transform.localPosition = Vector3.MoveTowards(plate.transform.localPosition, orgPos, speed * Time.deltaTime);
        player.localPosition = Vector3.MoveTowards(player.localPosition, orgPos, speed * Time.deltaTime);        

        if (Vector3.Distance(plate.transform.localPosition, orgPos) <= 0.05f)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        orgPos = orgPos != posA ? posA : posB;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switchOn = true;            
        }
    }    
}
