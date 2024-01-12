using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Blink : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        // TextMeshProUGUI ������Ʈ�� �����ɴϴ�.
        textMeshPro = GetComponent<TextMeshProUGUI>();

        // �����̴� �ڷ�ƾ�� �����մϴ�.
        StartCoroutine(BlinkText());
    }

    IEnumerator BlinkText()
    {
        while (true)
        {
            // �ؽ�Ʈ�� ��Ȱ��ȭ�մϴ�.
            textMeshPro.enabled = false;

            // 0.5�� ���� ����մϴ�.
            yield return new WaitForSeconds(0.5f);

            // �ؽ�Ʈ�� Ȱ��ȭ�մϴ�.
            textMeshPro.enabled = true;

            // 0.5�� ���� ����մϴ�.
            yield return new WaitForSeconds(0.5f);
        }
    }
}
