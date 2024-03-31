using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    public string[] mapNames;

    public Button[] levelButtons;
    public GameObject[] lockImgs;
    public int PlainWorldHighestLevel;
    public int ForestWorldHighestLevel;
    public int MountWorldHighestLevel;

    void Start()
    {
        // ���� �� �̸��� ����
        textMeshProUGUI.text = mapNames[SceneManager.instance.currentMapIndex - 1];

        // �� ������ �ְ� ������ �ε�
        PlainWorldHighestLevel = PlayerPrefs.GetInt("PlainWorldHighestLevel", 1);
        ForestWorldHighestLevel = PlayerPrefs.GetInt("ForestWorldHighestLevel", 0);
        MountWorldHighestLevel = PlayerPrefs.GetInt("MountWorldHighestLevel", 0);

        // ���� �ʿ� ���� ���� ��ư���� ��ȣ�ۿ��� ����
        switch (SceneManager.instance.currentMapIndex)
        {
            case 1:
                // ��� ���� ��
                for (int i = 0; i < levelButtons.Length; i++)
                {
                    int levelNum = i + 1;
                    if (levelNum > PlainWorldHighestLevel)
                    {
                        // �ְ� �������� ���� ���� ��ư ��Ȱ��ȭ �� ��� �̹��� Ȱ��ȭ
                        levelButtons[i].interactable = false;
                        lockImgs[i].SetActive(true);
                    }
                    else
                    {
                        // �ְ� ���� ������ ���� ��ư Ȱ��ȭ �� ��� �̹��� ��Ȱ��ȭ
                        levelButtons[i].interactable = true;
                        lockImgs[i].SetActive(false);
                    }
                }
                break;
            case 2:
                // �� ���� ��
                for (int i = 0; i < levelButtons.Length; i++)
                {
                    int levelNum = i + 1;
                    if (levelNum > ForestWorldHighestLevel)
                    {
                        // �ְ� �������� ���� ���� ��ư ��Ȱ��ȭ �� ��� �̹��� Ȱ��ȭ
                        levelButtons[i].interactable = false;
                        lockImgs[i].SetActive(true);
                    }
                    else
                    {
                        // �ְ� ���� ������ ���� ��ư Ȱ��ȭ �� ��� �̹��� ��Ȱ��ȭ
                        levelButtons[i].interactable = true;
                        lockImgs[i].SetActive(false);
                    }
                }
                break;
            case 3:
                // ��� ���� ��
                for (int i = 0; i < levelButtons.Length; i++)
                {
                    int levelNum = i + 1;
                    if (levelNum > MountWorldHighestLevel)
                    {
                        // �ְ� �������� ���� ���� ��ư ��Ȱ��ȭ �� ��� �̹��� Ȱ��ȭ
                        levelButtons[i].interactable = false;
                        lockImgs[i].SetActive(true);
                    }
                    else
                    {
                        // �ְ� ���� ������ ���� ��ư Ȱ��ȭ �� ��� �̹��� ��Ȱ��ȭ
                        levelButtons[i].interactable = true;
                        lockImgs[i].SetActive(false);
                    }
                }
                break;
        }
    }
}
