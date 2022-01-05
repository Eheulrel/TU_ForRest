using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideTrapB : MonoBehaviour
{ 
    public float MoveSpeed = 2f;
    public float radius = 1f;
    public bool MoveA = false;
    public bool Move = true;
    public bool PlayerIn = false;
   
    [SerializeField] private Transform Pos;
    [SerializeField] private LayerMask checkIn;
    [SerializeField] private Transform PlayerCheck;

    private Vector3 orgPos;
    GameObject right;
    GameObject left;

    void Start()
    {
        Move = true;
        MoveA = false;

        right = transform.Find("right").gameObject;
        left = transform.Find("left").gameObject;

        orgPos = Pos.localPosition;
    }

    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(PlayerCheck.position, radius, checkIn);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject) //범위 내의 레이어가 플레이어가 아닐때 발동
            {
                PlayerIn = true;
            }            
        }
    }

    void FixedUpdate()
    {
        if (PlayerIn)
        {
            if (Move)
            {
                if (MoveA)
                {
                    left.transform.Translate(Vector3.up * MoveSpeed * Time.deltaTime);
                    right.transform.Translate(Vector3.up * MoveSpeed * Time.deltaTime);

                    if (Vector3.Distance(right.transform.localPosition, orgPos) >= 0.5f)
                    {
                        MoveA = false;  //trapA와 orgPos의 거리가 1보다 크면 MoveA를 false
                    }
                }
                else if (!MoveA)
                {
                    left.transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);
                    right.transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);

                    if (Vector3.Distance(right.transform.localPosition, orgPos) <= 0.05f)
                    {
                        Move = false;           //trapA와 orgPos의 거리가 0.1보다 작으면 Move를 false
                        StartCoroutine(startA());
                    }
                }
            }
        }        
    }

    IEnumerator startA()
    {
        yield return new WaitForSeconds(1); //코루틴 실행 1초 뒤에 아래 명령어 실행

        Move = true;
        MoveA = true;
    }
}
