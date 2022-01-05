using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightTwoBlock : MonoBehaviour
{
    [SerializeField] private Transform Pos;

    public float MoveSpeed = 1f;
    private Vector3 orgPos;
    public bool Move = true;

    GameObject left;
    GameObject right;

    void Start()
    {
        left = transform.Find("Block1").gameObject;
        right = transform.Find("Block2").gameObject;

        orgPos = Pos.localPosition;
    }

    void FixedUpdate()
    {
        if (Move)
        {
            left.transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
            right.transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);

            if (Vector3.Distance(left.transform.localPosition, orgPos) <= 0.15f)
            {
                Move = false;  //trapA와 orgPos의 거리가 1보다 크면 MoveA를 false
            }
        }

        if(!Move)
        {
            left.transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
            right.transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);

            if (Vector3.Distance(left.transform.localPosition, orgPos) >= 0.5f)
            {
                Move = true;  //trapA와 orgPos의 거리가 1보다 크면 MoveA를 false
            }
        }        
    }
}
