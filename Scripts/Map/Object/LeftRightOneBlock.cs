using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightOneBlock : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform Pos;

    public float MoveSpeed = 1.5f;
    private Vector3 orgPos;
    public bool Move = true;

    GameObject Trap;

    void Start()
    {
        Trap = transform.Find("Block").gameObject;
        
        orgPos = Pos.localPosition;
    }

    void FixedUpdate()
    {
        if (Move)
        {
            Trap.transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
            
            if (Vector3.Distance(Trap.transform.localPosition, orgPos) <= 0.1f)
            {
                Move = false;  //trapA와 orgPos의 거리가 1보다 크면 MoveA를 false
            }
        }

        if (!Move)
        {
            Trap.transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);

            if (Vector3.Distance(Trap.transform.localPosition, orgPos) >= 1.6f)
            {
                Move = true;  //trapA와 orgPos의 거리가 1보다 크면 MoveA를 false
            }
        }
    }
}
