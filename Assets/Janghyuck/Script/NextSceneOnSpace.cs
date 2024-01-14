using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneOnSpace : MonoBehaviour
{
    void Update()
    {
        // �����̽��ٸ� ������ ���� ������ ��ȯ�մϴ�.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        // ���� ���� ���� �ε����� �����ɴϴ�.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ���� ���� ���� �ε����� ����մϴ�.
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

        // ���� ������ ��ȯ�մϴ�.
        SceneManager.LoadScene(nextSceneIndex);
    }
}
