using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Update()
    {

    }

    public void ToIntro()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
        }
    }

    //���� ��ü ����
    public void Exit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
