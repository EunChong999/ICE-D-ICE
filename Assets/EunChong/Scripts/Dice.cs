using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public int speed = 300;
    bool isMoving = false;
    bool canReveal = false;
    bool isRevealing = false;

    [HideInInspector] public bool isRolled = false;
    [HideInInspector] public float order = -1;

    [SerializeField] float delay;
    WaitForSeconds waitForSeconds;

    [SerializeField] Image[] hiddenImages;
    [SerializeField] Sprite[] diceFaces;
    [SerializeField] GameObject hiddenFaces;
    public Checker[] checkers;
    public Point[] xPoints;
    public Point[] yPoints;
    public Point[] zPoints;

    [SerializeField] CinemachineVirtualCamera virtualCamera;
    private SwipeDetection swipeDetection;

    private void Start()
    {
        waitForSeconds = new WaitForSeconds(delay);
        swipeDetection = FindObjectOfType<SwipeDetection>();

        swipeDetection.dice = this;
    }

    private void Update()
    {
        CheckHiddenFaces();

        if (Input.GetKeyUp(KeyCode.Space))
        {
            InitState();

            RegulateDamping(2);
        }

        if (!isMoving)
        {
            if (!canReveal)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    StartCoroutine(CoolTime());
                    canReveal = true;
                }
            }

            if (isRevealing)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    hiddenFaces.SetActive(true);

                    RegulateDamping(1);
                }
            }

            if (order == 0 && checkers[0].isCollisioning) // Z������ ������ ��
            {
                StartCoroutine(Roll(Vector3.forward));
                ChangeAxis(ref yPoints, ref zPoints, ref xPoints);
                order = -1;
            }
            else if (order == 1 && checkers[1].isCollisioning) // X������ ������ ��
            {
                StartCoroutine(Roll(Vector3.left));
                ChangeAxis(ref xPoints, ref yPoints, ref zPoints);
                order = -1;
            }
            else if (order == 2 && checkers[2].isCollisioning) // Z������ ������ ��
            {
                StartCoroutine(Roll(Vector3.back));
                ChangeAxis(ref yPoints, ref zPoints, ref xPoints);
                order = -1;
            }
            else if (order == 3 && checkers[3].isCollisioning) // X������ ������ ��
            {
                StartCoroutine(Roll(Vector3.right));
                ChangeAxis(ref xPoints, ref yPoints, ref zPoints);
                order = -1;
            }
        }
        else
        {
            InitState();
        }
    }

    void CheckHiddenFaces()
    {
        foreach (var x in xPoints)
        {
            if (x.isHidden)
            {
                hiddenImages[1].sprite = diceFaces[x.num - 1];
            }
        }

        foreach (var y in yPoints)
        {
            if (y.isHidden)
            {
                hiddenImages[2].sprite = diceFaces[y.num - 1];
            }
        }

        foreach (var z in zPoints)
        {
            if (z.isHidden)
            {
                hiddenImages[0].sprite = diceFaces[z.num - 1];
            }
        }
    }

    void InitState()
    {
        hiddenFaces.SetActive(false);
        canReveal = false;
        isRevealing = false;
    }

    void RegulateDamping(float damping)
    {
        virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_XDamping = damping;
        virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_YDamping = damping;
        virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_ZDamping = damping;
    }

    IEnumerator CoolTime()
    {
        yield return waitForSeconds;
        isRevealing = true;
    }

    IEnumerator Roll(Vector3 direction)
    {
        // �����̰� �ִ�.
        isMoving = true;

        float remainingAngle = 90;
        Vector3 rotationCenter = transform.position + direction / 2 + Vector3.down / 2;
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);

        // ���� ������ ���� ������ ��� ȸ����Ų��.
        while (remainingAngle > 0) 
        {
            float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
            transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
            remainingAngle -= rotationAngle;
            yield return null;
        }

        // ��ġ ������ ���� �ݿø��� �Ѵ�.
        Round();

        // �����̰� ���� �ʴ�.
        isMoving = false;
    }

    void Round()
    {
        // ���� ������Ʈ�� �������� ù ��° �Ҽ������� �ݿø��Ѵ�.
        Vector3 roundedPosition = new Vector3(
            Mathf.Round(transform.position.x * 10.0f) / 10.0f,
            Mathf.Round(transform.position.y * 10.0f) / 10.0f,
            Mathf.Round(transform.position.z * 10.0f) / 10.0f
        );

        // �ݿø��� �������� ���� ������Ʈ�� �����Ѵ�.
        transform.position = roundedPosition;

        // ���� ������Ʈ�� ȸ���� ù ��° �Ҽ������� �ݿø��Ѵ�.
        Vector3 roundedRotation = new Vector3(
            Mathf.Round(transform.rotation.eulerAngles.x * 10.0f) / 10.0f,
            Mathf.Round(transform.rotation.eulerAngles.y * 10.0f) / 10.0f,
            Mathf.Round(transform.rotation.eulerAngles.z * 10.0f) / 10.0f
        );

        // �ݿø��� ȸ���� ���� ������Ʈ�� �����Ѵ�.
        transform.rotation = Quaternion.Euler(roundedRotation);
    }

    void ChangeAxis(ref Point[] firstPoints, ref Point[] secondPoints, ref Point[] thirdPoints)
    {
        Point[] firstPointTemps = firstPoints;
        Point[] secondPointTemps = secondPoints;

        foreach (var thirdPoint in thirdPoints)
        {
            thirdPoint.isShapeChanged = !thirdPoint.isShapeChanged;
        }

        firstPoints = secondPointTemps;
        secondPoints = firstPointTemps;
    }
}

