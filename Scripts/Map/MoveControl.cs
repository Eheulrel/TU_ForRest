using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    public static bool inputUp = false;
    public static bool inputDown = false;
    public static bool inputRight = false;
    public static bool inputLeft = false;
    public static bool inputJump = false;
    public static bool inputZ = false;
    public static bool inputStop = false;
    public static bool inputDash = false;

    //upC = upClick, upD = upDefault

    private void Update()
    {
        if (GameController.pcmobile.Equals(0))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                inputUp = true;
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                inputUp = false;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                inputDown = true;
            }

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                inputDown = false;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                inputLeft = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                inputLeft = false;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                inputRight = true;
            }

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                inputRight = false;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                inputJump = true;
                StartCoroutine(stopJump());
            }
            
            if (Input.GetKeyUp(KeyCode.Space))
            {
                inputJump = false;
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                inputZ = true;
                StartCoroutine(stopZ());
            }

            if (Input.GetKeyUp(KeyCode.Z))
            {
                inputZ = false;
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                inputDash = true;
                StartCoroutine(stopDash());
            }

            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                inputDash = false;
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                inputStop = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                inputStop = false;
            }
        }
    }

    public void upC()
    {
        inputUp = true;
    }

    public void upD()
    {
        inputUp = false;
    }

    public void downC()
    {
        inputDown = true;
    }

    public void downD()
    {
        inputDown = false;
    }

    public void leftC()
    {
        inputLeft = true;
    }

    public void leftD()
    {
        inputLeft = false;
    }

    public void rightC()
    {
        inputRight = true;
    }

    public void rightD()
    {
        inputRight = false;
    }

    public void jumpC()
    {
        inputJump = true;
        StartCoroutine(stopJump());
    }

    public void jumpD()
    {
        inputJump = false;
    }

    public void ZC()
    {
        inputZ = true;
        StartCoroutine(stopZ());
    }

    public void ZD()
    {
        inputZ = false;
    }

    public void dashC()
    {
        inputDash = true;
        StartCoroutine(stopDash());
    }

    public void dashD()
    {
        inputDash = false;
    }

    public void stopC()
    {
        inputStop = true;
    }

    public void stopD()
    {
        inputStop = false;
    }

    IEnumerator stopZ()
    {
        yield return new WaitForSeconds(0.01f); //코루틴 실행 1초 뒤에 아래 명령어 실행

        inputZ = false;
    }

    IEnumerator stopJump()
    {
        yield return new WaitForSeconds(0.01f); //코루틴 실행 1초 뒤에 아래 명령어 실행

        inputJump = false;
    }

    IEnumerator stopDash()
    {
        yield return new WaitForSeconds(0.005f); //코루틴 실행 1초 뒤에 아래 명령어 실행

        inputDash = false;
    }
}

