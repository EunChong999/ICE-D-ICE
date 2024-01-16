using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    Animator animator;
    [SerializeField] bool isFadeIn;
    [SerializeField] bool canFadeIn;
    [SerializeField] bool canFadeOut;
    WaitForSeconds fadeTime;

    public static FadeEffect instance = null;

    private void Awake()
    {
        if (instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            instance = this; //���ڽ��� instance�� �־��ݴϴ�.
            DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
        }
        else
        {
            if (instance != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ�
                Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();

        fadeTime = new WaitForSeconds(1);

        FadeIn();
    }

    //Scene�� ������ ��(Title����)
    public void FadeIn()
    {
        if (canFadeIn && !isFadeIn) 
        {
            animator.SetTrigger("FadeIn");
            StartCoroutine(ResetFadeIn());
            canFadeIn = false;
        }
    }

    IEnumerator ResetFadeIn()
    {
        yield return fadeTime;
        isFadeIn = true;
        canFadeIn = true;
    }

    public void FadeOut()
    {
        if (canFadeOut && isFadeIn)
        {
            animator.SetTrigger("FadeOut");
            StartCoroutine(ResetFadeOut());
            //Scene�̵�
            canFadeOut = false;
        }
    }

    IEnumerator ResetFadeOut()
    {
        yield return fadeTime;
        isFadeIn = false;
        canFadeOut = true;
    }
}
