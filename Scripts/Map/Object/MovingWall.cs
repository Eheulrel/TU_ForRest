using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float radius = 0.2f;
    public bool Playerin = false;
    public bool move = true;
    [SerializeField] private LayerMask checkIn;
    [SerializeField] private Transform PlayerCheck;

    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(PlayerCheck.position, radius, checkIn);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject) //범위 내의 레이어가 플레이어가 아닐때 발동
            {
                Playerin = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (!GameController.StopA)
        {
            if (Playerin && move)
            {
                transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            move = false;
        }
    }
}
