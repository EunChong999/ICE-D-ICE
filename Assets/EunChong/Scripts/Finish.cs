using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public bool isCompleted;
    [SerializeField] int index;
    [SerializeField] Ice[] ices;
    [SerializeField] new ParticleSystem particleSystem;

    public bool isLoading;

    bool CheckAllTrue(Ice[] array)
    {
        // �迭 �ȿ� �ִ� ��� ���� true���� Ȯ��
        foreach (Ice value in array)
        {
            if (!value.isCleared)
            {
                // �ϳ��� false�� ������ false ��ȯ
                return false;
            }
        }
        // ��� ���� true�� ��� true ��ȯ
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point"))
        {
            // �迭 �ȿ� �ִ� ��� bool ���� true���� Ȯ��
            if (CheckAllTrue(ices))
            {
                isCompleted = true;
            }
            else
            {
                isCompleted = false;
            }
        }

        if (other.CompareTag("Point") && isCompleted && !isLoading)
        {
            other.GetComponent<Point>().FinSound();

            if (index == 0) 
            {
                SceneManager.instance.ToTitle();
            }
            else
            {
                SceneManager.instance.ToStage(index);
            }

            particleSystem.Play();
            SceneManager.instance.isTutorialCompleted = true;
            isLoading = true;
        }
    }
}
