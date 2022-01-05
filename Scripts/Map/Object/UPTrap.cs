using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UPTrap : MonoBehaviour
{
    [SerializeField] private float speed;   
    [SerializeField] private Transform transformB;    

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
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, nexPos, speed * Time.deltaTime);

        if (Vector3.Distance(transform.localPosition, nexPos) <= 0.05f)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        nexPos = nexPos != posA ? posA : posB;
    }
}
