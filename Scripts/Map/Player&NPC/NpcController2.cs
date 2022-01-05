using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController2 : MonoBehaviour
{
    [SerializeField] private LayerMask checkIn;
    [SerializeField] private Transform PlayerCheck;
    [SerializeField] private Transform PlayerCheck2;

    public float radius = 1f;
    public float MoveSpeed = 5f;

    public TypeWriterEffect twe;
    public TypeWriterEffect twe2;
    public GameObject dialog;
    public GameObject dialog2;

    public AudioClip Bang;
    AudioSource aSource;

    public Animator anim;

    Rigidbody2D rigid;  

    int pattern = 0;
    bool startAI = false;
    bool change = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();
        aSource.clip = Bang;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(PlayerCheck.position, radius, checkIn);
        Collider2D[] colliders2 = Physics2D.OverlapCircleAll(PlayerCheck2.position, radius, checkIn);

        if (startAI)
        {
            anim.SetBool("isRun", true);
            transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);

            if (pattern == 0)
            {
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject) //범위 내의 레이어가 플레이어가 아닐때 발동
                    {
                        anim.SetBool("isRun", false);
                        MoveSpeed = 0f;
                        dialog.SetActive(true);

                        if (!twe.text_exit)
                        {
                            if (MoveControl.inputZ)
                            {
                                twe.End_Typing();
                            }
                        }
                        else if (twe.text_exit)
                        {
                            dialog.SetActive(false);
                            pattern = 1;
                        }
                    }
                }
            }

            else if (pattern == 1)
            {
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject) //범위 내의 레이어가 플레이어가 아닐때 발동
                    {
                        anim.SetBool("isRun", false);

                        if (MoveControl.inputZ)
                            dialog2.SetActive(true);

                        if (!twe2.text_exit)
                        {
                            if (MoveControl.inputZ)
                            {
                                twe2.End_Typing();
                            }
                        }
                        else if (twe2.text_exit)
                        {
                            dialog2.SetActive(false);
                            pattern = 2;
                        }
                    }
                }
            }

            else if (pattern == 2)
            {
                anim.SetBool("isRun", false);
                //사운드 출력                
                //스프라이트 이미지 교체
                for (int i = 0; i < colliders2.Length; i++)
                {
                    if (colliders2[i].gameObject != gameObject) //범위 내의 레이어가 플레이어가 아닐때 발동
                    {                       
                        anim.SetBool("isFire", true);
                        aSource.Play();
                    }
                }                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            startAI = true;
        }
    }
}
