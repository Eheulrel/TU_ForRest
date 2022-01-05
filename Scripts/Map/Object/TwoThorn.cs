using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoThorn : MonoBehaviour
{
    [SerializeField] private Transform orgPos;
    [SerializeField] private Transform orgPos2;

    public float Speed = 2f;

    GameObject first;
    GameObject seconds;

    private Vector3 posA;
    private Vector3 posAA;
    private Vector3 posB;
    private Vector3 posBB;
    private Vector3 nexPos;
    private Vector3 nexPos2;

    void Start()
    {
        first = transform.Find("first").gameObject;
        seconds = transform.Find("seconds").gameObject;

        posA = first.transform.localPosition;
        posAA = seconds.transform.localPosition;
        posB = orgPos.localPosition;
        posBB = orgPos2.localPosition;
        nexPos = posB;
        nexPos2 = posBB;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        first.transform.localPosition = Vector3.MoveTowards(first.transform.localPosition, nexPos, Speed * Time.deltaTime);

        if (Vector3.Distance(first.transform.localPosition, nexPos) <= 0.05f)
        {
            ChangeDestination();
        }

        seconds.transform.localPosition = Vector3.MoveTowards(seconds.transform.localPosition, nexPos2, Speed * Time.deltaTime);

        if (Vector3.Distance(seconds.transform.localPosition, nexPos2) <= 0.05f)
        {
            ChangeDestination2();
        }
    }

    private void ChangeDestination()
    {
        nexPos = nexPos != posA ? posA : posB;
    }

    private void ChangeDestination2()
    {
        nexPos2 = nexPos2 != posAA ? posAA : posBB;
    }
}
