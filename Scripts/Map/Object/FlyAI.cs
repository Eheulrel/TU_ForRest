using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAI : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float speed; 
    public bool Playerin = false;    

    void Update()
    {
        if (!GameController.StopA)
        {
            if (Playerin)
            {
                transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
            }
        }        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Playerin = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Playerin = false;
        }
    }
}
