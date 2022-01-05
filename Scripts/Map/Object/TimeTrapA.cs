using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrapA : MonoBehaviour
{
    [SerializeField] private Transform Pos;

    public float GoSpeed = 2f;
    public bool MoveA = false;
    public bool Move = true;
    private Vector3 orgPos;

    GameObject trapA;
    GameObject trapB;
    
    void Start()
    {
        trapA = transform.Find("trapA").gameObject;
        trapB = transform.Find("trapB").gameObject;

        orgPos = Pos.localPosition;
        Move = true;
    }

    void FixedUpdate()
    {
        if (Move)
        {
            if (MoveA)
            {
                trapA.transform.Translate(Vector3.down * GoSpeed * Time.deltaTime);
                trapB.transform.Translate(Vector3.down * GoSpeed * Time.deltaTime);

                if (Vector3.Distance(trapA.transform.localPosition, orgPos) >= 1f)
                {
                    MoveA = false;  //trapA와 orgPos의 거리가 1보다 크면 MoveA를 false
                }
            }
            else if (!MoveA)
            {
                trapA.transform.Translate(Vector3.up * GoSpeed * Time.deltaTime);
                trapB.transform.Translate(Vector3.up * GoSpeed * Time.deltaTime);

                if (Vector3.Distance(trapA.transform.localPosition, orgPos) <= 0.1f)
                {
                    Move = false;           //trapA와 orgPos의 거리가 0.1보다 작으면 Move를 false
                    StartCoroutine(startA());
                }
            }
        }        
    }

    IEnumerator startA()
    {     
        yield return new WaitForSeconds(1); //코루틴 실행 1초 뒤에 아래 명령어 실행

        Move = true;
        MoveA = true;
    }
}
