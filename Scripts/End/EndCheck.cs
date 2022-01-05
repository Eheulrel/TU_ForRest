using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCheck : MonoBehaviour
{
    public GameObject End1;
    public GameObject End2;
    public GameObject End3;
    public GameObject End4;

    // Update is called once per frame
    void Update()
    {
        if (GameController.saveit && !GameController.desobj)
        {
            End1.SetActive(true);
            End2.SetActive(false);
            End3.SetActive(false);
            End4.SetActive(false);
        }
        else if (GameController.desobj && !GameController.saveit)
        {
            End1.SetActive(false);
            End2.SetActive(true);
            End3.SetActive(false);
            End4.SetActive(false);
        }
        else if (!GameController.saveit && !GameController.desobj)
        {
            End1.SetActive(false);
            End2.SetActive(false);
            End3.SetActive(true);
            End4.SetActive(false);
        }
        else if (GameController.saveit && GameController.desobj)
        {
            End1.SetActive(false);
            End2.SetActive(false);
            End3.SetActive(false);
            End4.SetActive(true);
        }
    }
}
