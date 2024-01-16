using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void Update()
    {
        ToTitle();
    }

    //ESC�� ������ �� Title�� �̵��ϴ� �Լ�
    public void ToTitle()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != 0)
            {
                FadeEffect.instance.FadeOut();

                if (FadeEffect.instance.isFadeIn)
                    StartCoroutine(SceneLoad(0));
            }
            else
            {
                Application.Quit();
            }
        }
    }

    public void ToStage(int index)
    {
        FadeEffect.instance.FadeOut();

        if (FadeEffect.instance.isFadeIn)
            StartCoroutine(SceneLoad(index + 1));
    }

    IEnumerator SceneLoad(int index)
    {
        yield return new WaitForSeconds(1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
        FadeEffect.instance.FadeIn();
    }
}
