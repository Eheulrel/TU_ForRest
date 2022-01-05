using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public TypeWriterEffect twe;
    public GameObject dialog;
    public GameObject text;
    public Rigidbody2D player;

    private SaveControl theSave;
    bool saveOn = false;
    bool saveadmit = true;
    
    // Start is called before the first frame update
    void Start()
    {
        theSave = FindObjectOfType<SaveControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (saveOn)
        {
            if (MoveControl.inputZ)
            {
                if (saveadmit)
                {
                    dialog.SetActive(true);

                    theSave.CallSave();

                    if (GameController.first.Equals(0))
                    {
                        GameController.saveit = true;
                    }

                    saveadmit = false;
                }

                if (!twe.text_exit)
                {                  
                    twe.End_Typing();
                }               
            }

            if (twe.text_exit)
            {
                dialog.SetActive(false);
                twe.text_exit = false;
            }
        }        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            saveOn = true;
            saveadmit = true;
        }        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            saveOn = false;
            dialog.SetActive(false);            
        }
    }
}
