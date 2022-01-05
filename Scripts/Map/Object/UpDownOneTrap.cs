using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownOneTrap : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform Pos;

    public float MoveSpeed = 1.5f;
    private Vector3 orgPos;
    public bool Move = true;

    GameObject Trap;

    void Start()
    {
        Trap = transform.Find("Trap").gameObject;

        orgPos = Pos.localPosition;
    }

    void FixedUpdate()
    {
        if (Move)
        {
            Trap.transform.Translate(Vector2.up * MoveSpeed * Time.deltaTime);

            if (Vector3.Distance(Trap.transform.localPosition, orgPos) <= 0.05f)
            {
                Move = false;  //trapA와 orgPos의 거리가 1보다 크면 MoveA를 false
            }
        }

        if (!Move)
        {
            Trap.transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);

            if (Vector3.Distance(Trap.transform.localPosition, orgPos) >= 0.4f)
            {
                Move = true;  //trapA와 orgPos의 거리가 1보다 크면 MoveA를 false
            }
        }
    }
}
