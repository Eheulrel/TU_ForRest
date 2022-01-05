using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField] Image progressBar;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation oper = SceneManager.LoadSceneAsync("Map"); //로딩 끝난 후 넘어갈 맵

        oper.allowSceneActivation = false; //allowSceneActivation가 true -> 씬이 넘어가는 시점

        float timer = 0.0f;
        while (!oper.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            if(oper.progress >= 0.9f)
            {
                //Slider는 progressBar.value로 간단히 구현되지만 이미지가 찌그러져서 Image 사용
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer); 

                if(progressBar.fillAmount == 1.0f)
                {
                    oper.allowSceneActivation = true;
                }
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, oper.progress, timer);
                if(progressBar.fillAmount >= oper.progress)
                {
                    timer = 0f;
                }
            }
        }
    }
}
