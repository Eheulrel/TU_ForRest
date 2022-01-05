using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerManager : MonoBehaviour
{
    public string bulletName = "Bullet";
    public Transform FireLocate;

    public float FireDelay;
    private bool FireState;  

    // Start is called before the first frame update
    void Start()
    {
        FireState = true;       
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.StopA)
            Fire();
    }

    private void Fire()
    {
        if (FireState)
        {
            StartCoroutine(FireCycleControl());            
            GameObject bullet = ObjectPool.Instance.PopFromPool(bulletName);           

            bullet.transform.position = FireLocate.position;
            bullet.SetActive(true);
        }
    }

    IEnumerator FireCycleControl()
    {
        FireState = false;

        yield return new WaitForSeconds(FireDelay);

        FireState = true;
    }   
}