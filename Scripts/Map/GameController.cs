using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static int Apoint = 0; //능력포인트(AbilityPoint)
    public static bool StopA = false; //StopAbility
    public static int start = 0; //0 = 시작메뉴on, 1 = 시작메뉴off
    public static int first = 0; //0 = 1번맵o , 1 = 1번맵x
    public static int pcmobile = 0; //0 = pc, 1 = mobile
    public static int option = 0; //0 = no show, 1 = show

    public static bool saveit = false;
    public static bool desobj = false;

    public GameObject powerA;
    public GameObject powerB;
    public GameObject powerC;
    public GameObject StopE;
    public GameObject Esc;
    public GameObject options;
    public GameObject ui;
    public GameObject Pad;

    public GameObject map1;
    public GameObject Quarter1;
    public GameObject Quarter2;
    public GameObject Quarter3;
    public GameObject Quarter4;

    Image abilityA;
    Image abilityB;
    Image abilityC;

    bool menu = false;

    void Awake()
    {
        StopE.SetActive(false);
        StopA = false;

        abilityA = powerA.GetComponent<Image>();
        abilityB = powerB.GetComponent<Image>();
        abilityC = powerC.GetComponent<Image>();

        abilityA.color = new Color32(86, 86, 82, 255);
        abilityB.color = new Color32(86, 86, 82, 255);
        abilityC.color = new Color32(86, 86, 82, 255);

        Apoint = 0;
        start = 0;
        saveit = false;
        desobj = false;
        first = 0;

        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if (Apoint.Equals(0))
        {
            abilityA.color = new Color32(86, 86, 82, 255);
            abilityB.color = new Color32(86, 86, 82, 255);
            abilityC.color = new Color32(86, 86, 82, 255);
        }
        else if (Apoint.Equals(1))
        {
            abilityA.color = new Color32(255, 255, 255, 255);
            abilityB.color = new Color32(86, 86, 82, 255);
            abilityC.color = new Color32(86, 86, 82, 255);
        }
        else if (Apoint.Equals(2))
        {
            abilityA.color = new Color32(255, 255, 255, 255);
            abilityB.color = new Color32(255, 255, 255, 255);
            abilityC.color = new Color32(86, 86, 82, 255);
        }
        else if (Apoint.Equals(3))
        {
            abilityA.color = new Color32(255, 255, 255, 255);
            abilityB.color = new Color32(255, 255, 255, 255);
            abilityC.color = new Color32(255, 255, 255, 255);
        }

        if (StopA)
        {
            StopE.SetActive(true);
            StartCoroutine(StopTimer());
        }
        else
        {
            StopE.SetActive(false);
            StopCoroutine(StopTimer());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //menu = true : 켜져있음, false : 꺼져있음
            if (start.Equals(0) && menu)
            {
                menu = false;
                Esc.SetActive(false);
                start = 1;
            }
            else if (start.Equals(1) && !menu)
            {
                Esc.SetActive(true);                
                start = 0;
                menu = true;
            }            
        }

        if (option.Equals(0))
        {
            options.SetActive(false);
        }
        else if(option.Equals(1))
        {
            options.SetActive(true);
        }

        if (pcmobile.Equals(0))
        {
            Pad.SetActive(false);
        }
        else if (pcmobile.Equals(1))
        {
            Pad.SetActive(true);
        }

        if (start.Equals(0))
        {
            Time.timeScale = 0f;
            ui.SetActive(false);
        }

        else if (start.Equals(1))
        {
            Time.timeScale = 1f;
            ui.SetActive(true);
        }

        if (first.Equals(0))
        {
            map1.SetActive(true);           
        }
        else if (first.Equals(1))
        {
            map1.SetActive(false);            
        }

        if (saveit && !desobj)
        {
            Quarter1.SetActive(true);
            Quarter2.SetActive(false);
            Quarter3.SetActive(false);
            Quarter4.SetActive(false);
        }
        else if (desobj && !saveit)
        {
            Quarter1.SetActive(false);
            Quarter2.SetActive(true);
            Quarter3.SetActive(false);
            Quarter4.SetActive(false);
        }
        else if (!saveit && !desobj)
        {
            Quarter1.SetActive(false);
            Quarter2.SetActive(false);
            Quarter3.SetActive(true);
            Quarter4.SetActive(false);
        }
        else if (saveit && desobj)
        {
            Quarter1.SetActive(false);
            Quarter2.SetActive(false);
            Quarter3.SetActive(false);
            Quarter4.SetActive(true);
        }
    }

    IEnumerator StopTimer()
    {
        yield return new WaitForSeconds(5);

        StopA = false;      
    }
}
