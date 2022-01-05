using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Outro : MonoBehaviour
{
    private new Renderer renderer;

    public float speed;
    public float offset;
    public float gotime = 15f;

    public void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    public void Update()
    {
        offset = Time.time * speed;
        renderer.material.SetTextureOffset("_MainTex", new Vector2(0, offset));

        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(gotime);

        SceneManager.LoadScene("Start");
    }
}
