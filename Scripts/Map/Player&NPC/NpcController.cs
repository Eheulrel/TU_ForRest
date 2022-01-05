using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcController : MonoBehaviour
{
    [SerializeField] private LayerMask checkIn;
    [SerializeField] private Transform PlayerCheck;

    public float radius = 1f;

    public TypeWriterEffect twe;
    public GameObject dialog;
    public Rigidbody2D player;

    bool checkPoint = true;

    void Update()
    {        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(PlayerCheck.position, radius, checkIn);

        if (checkPoint)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject) //범위 내의 레이어가 플레이어가 아닐때 발동
                {
                    player.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation
               | RigidbodyConstraints2D.FreezePositionY;
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
                        player.constraints = RigidbodyConstraints2D.FreezeRotation;
                        checkPoint = false;
                    }
                }
            }
        }        
    }
}
