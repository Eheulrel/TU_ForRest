using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    [SerializeField] private Transform Pos;
    [SerializeField] private float MoveSpeed = 2f;
    [SerializeField] private bool switchOn = false;
    [SerializeField] private bool check = false;

    private Vector3 orgPos;

    GameObject top;
    GameObject bottom;

    void Start()
    {
        switchOn = false;

        top = transform.Find("top").gameObject;
        bottom = transform.Find("bottom").gameObject;

        orgPos = Pos.localPosition;
    }

    void FixedUpdate()
    {
        if (!GameController.StopA)
        {
            if (check)
            {
                if (switchOn)
                {
                    top.transform.Translate(Vector2.up * MoveSpeed * Time.deltaTime);
                    bottom.transform.Translate(Vector2.up * MoveSpeed * Time.deltaTime);

                    if (Vector3.Distance(top.transform.localPosition, orgPos) <= 0.1f)
                    {
                        switchOn = false;  //trapA와 orgPos의 거리가 1보다 크면 MoveA를 false
                    }
                }

                if (!switchOn)
                {
                    top.transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);
                    bottom.transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);

                    if (Vector3.Distance(top.transform.localPosition, orgPos) >= 2f)
                    {
                        check = false;  //trapA와 orgPos의 거리가 1보다 크면 MoveA를 false
                    }
                }
            }
        }        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (check)
            {
                switchOn = true;
            }
            else if (!check)
            {
                check = true;
                switchOn = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            switchOn = false;
        }   
    }
}
