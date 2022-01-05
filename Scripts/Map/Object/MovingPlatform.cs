using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform transformB;
    [SerializeField] private Transform player;

    public bool playerin = false;

    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nexPos;

    void Start()
    {
        posA = transform.localPosition;
        posB = transformB.localPosition;
        nexPos = posB;

        playerin = false;
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

        if (playerin)
        {
            player.localPosition = Vector3.MoveTowards(player.localPosition, nexPos, speed * Time.deltaTime * 1.2f);
        }        

        if (Vector3.Distance(transform.localPosition, nexPos) <= 0.05f)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        nexPos = nexPos != posA ? posA : posB;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerin = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerin = false;
        }
    }
}
