using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRTrap : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform transformB;    

    bool go = true;

    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nexPos;

    void Start()
    {
        posA = transform.localPosition;
        posB = transformB.localPosition;
        nexPos = posB;
    }

    void Update()
    {
        if (!GameController.StopA)
        {
            Move();
        }
    }

    private void Move()
    {

        if (go)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (!go)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime * 0.5f);
        }             

        if (Vector3.Distance(transform.localPosition, nexPos) <= 1.0f)
        {
            ChangeDestination();

            if (go)
            {
                go = false;
            }
            else if (!go)
            {
                go = true;
            }
        }
    }

    private void ChangeDestination()
    {
        nexPos = nexPos != posA ? posA : posB;
    }
}
