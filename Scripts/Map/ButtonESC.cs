using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonESC : MonoBehaviour
{
    private SaveControl theSave;
    public GameObject dialog;

    void Start()
    {
        theSave = FindObjectOfType<SaveControl>();
    }

    public void option()
    {
        if (GameController.option.Equals(1))
        {
            GameController.option = 0;
        }
        else if (GameController.option.Equals(0))
        {
            GameController.option = 1;
        }
    }

    public void pc()
    {
        GameController.pcmobile = 0;
        GameController.option = 0;
    }

    public void mobile()
    {
        GameController.pcmobile = 1;
        GameController.option = 0;
    }

    public void saveDelete()
    {
        theSave.CallDelete();
        GameController.option = 0;
    }

    public void Exit()
    {
        Application.Quit();
    }        

    public void Load()
    {
        theSave.CallLoad();
        dialog.SetActive(false);
    }

    public void StartS()
    {
        GameController.start = 1;        
        dialog.SetActive(false);
    }
}
