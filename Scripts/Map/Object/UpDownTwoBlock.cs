using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownTwoBlock : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform Pos;
    [SerializeField] private bool MoveA = false;
    [SerializeField] private bool Move = true;
    [SerializeField] private float GoSpeed = 2f;

    private Vector3 orgPos;

    GameObject trapA;

    void Start()
    {
        trapA = transform.Find("TimeTrap").gameObject;

        orgPos = Pos.localPosition;
        Move = true;
    }

    void FixedUpdate()
    {
        if (!GameController.StopA)
        {
            if (Move)
            {
                if (MoveA)
                {
                    trapA.transform.Translate(Vector3.down * GoSpeed * Time.deltaTime);

                    if (Vector3.Distance(trapA.transform.localPosition, orgPos) <= 1f)
                    {
                        MoveA = false;  //trapA와 orgPos의 거리가 1보다 크면 MoveA를 false
                    }
                }
                else if (!MoveA)
                {
                    trapA.transform.Translate(Vector3.up * GoSpeed * Time.deltaTime);

                    if (Vector3.Distance(trapA.transform.localPosition, orgPos) >= 2.4f)
                    {
                        Move = false;           //trapA와 orgPos의 거리가 0.1보다 작으면 Move를 false
                        StartCoroutine(startA());
                    }
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
