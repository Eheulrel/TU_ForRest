using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTrap : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float radius = 0.2f;
    public float lifetime = 1f;
    public bool Playerin = false;
    public bool down = true;
    
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
            if (Playerin && down)
            {
                transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            down = false;
            StartCoroutine(timer());
        }        
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(lifetime);

        gameObject.SetActive(false);
    }
}

