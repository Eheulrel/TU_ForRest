using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCheck : MonoBehaviour
{
    [SerializeField] private LayerMask checkIn;
    [SerializeField] private Transform PlayerCheck;

    public float radius = 0.5f;
    public string robotName = "Robot";
    public Transform ProductLocate;

    public float ProductDelay;
    private bool RobotState = true;
    private bool isProduct = false;

    void Start()
    {
        RobotState = true;
    }

    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(PlayerCheck.position, radius, checkIn);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject) //범위 내의 레이어가 플레이어가 아닐때 발동
            {
                if (isProduct)
                {
                    Product();
                }
                else if (!isProduct)
                {
                    StartCoroutine(timer());
                }
            }
        }
    }

    private void Product()
    {
        if (RobotState)
        {
            StartCoroutine(ProductCycleControl());
            GameObject robot = ObjectPool.Instance.PopFromPool(robotName);

            robot.transform.position = ProductLocate.position;
            robot.SetActive(true);
        }
    }

    IEnumerator ProductCycleControl()
    {
        RobotState = false;

        yield return new WaitForSeconds(ProductDelay);

        RobotState = true;
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1f);

        isProduct = true;
    }
}
