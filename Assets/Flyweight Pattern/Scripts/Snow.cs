using UnityEngine;

public class Snow : MonoBehaviour
{
    #region Inspector
    public GameObject mesh;
    public Vector3 size;
    public string meshRendererAddress;
    public string materialAddress;
    #endregion

    private static MeshRenderer _treeMeshRenderer = null;
    /// <summary>
    /// �޽� ����
    /// </summary>
    private static MeshRenderer GetMeshRenderer(string address)
    {
        if (_treeMeshRenderer == null)
        {
            _treeMeshRenderer = Resources.Load<MeshRenderer>(address);
        }

        return _treeMeshRenderer;
    }

    private static Material _material = null;
    /// <summary>
    /// ���͸��� ����
    /// </summary>
    private static Material GetMaterial(string address)
    {
        if (_material == null)
        {
            _material = Resources.Load<Material>(address);
        }

        return _material;
    }

    private void Awake()
    {
        // mesh GameObject�� MeshRenderer�� �߰�
        MeshRenderer meshRenderer = mesh.AddComponent<MeshRenderer>();

        // ���͸��� �Ҵ�
        meshRenderer.material = GetMaterial(materialAddress);

        // mesh GameObject�� MeshFilter�� �߰�
        MeshFilter meshFilter = mesh.AddComponent<MeshFilter>();

        // �޽� �Ҵ�
        meshFilter.sharedMesh = GetMeshRenderer(meshRendererAddress).GetComponent<MeshFilter>().sharedMesh;

        // ũ�� ����
        mesh.transform.localScale = size;
    }
}
