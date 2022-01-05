using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkQuarter2 : MonoBehaviour
{
    [SerializeField] private LayerMask checkIn;
    [SerializeField] private Transform PlayerCheck;

    public GameObject orgBot;
    public GameObject newBot;

    public AudioClip Bang;
    AudioSource aSource;

    public float radius = 1f;

    bool num = false;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(PlayerCheck.position, radius, checkIn);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject) //범위 내의 레이어가 플레이어가 아닐때 발동
            {
                if (!num)
                {
                    aSource.Play();
                    num = true;
                }
                
                orgBot.SetActive(false);
                newBot.SetActive(true);                
            }
        }
    }
}
