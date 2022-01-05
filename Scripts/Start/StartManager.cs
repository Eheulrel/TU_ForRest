using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    bool Smenu = false;
    public GameObject Esc;

    // Start is called before the first frame update
    void Awake()
    {
        Smenu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Smenu)
            {
                Smenu = false;
                Esc.SetActive(false);
            }
            else if (!Smenu)
            {
                Esc.SetActive(true);
                Smenu = true;
            }
        }
    }

    public void startnew()
    {
        SceneManager.LoadScene("Loading");
    }
}
