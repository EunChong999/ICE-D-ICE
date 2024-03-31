using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class CutoffMaskUI : Image
{
    private void LateUpdate()
    {
        SetMaterialForRendering();
    }

    // materialForRendering �Ӽ� �������̵�
    public override Material materialForRendering
    {
        get
        {
            // �θ� Ŭ������ materialForRendering �Ӽ� ��ȯ
            return base.material;
        }
    }

    // SetMaterialForRendering �޼���
    private void SetMaterialForRendering()
    {
        // �θ� Ŭ������ materialForRendering�� �����Ͽ� ���ο� Material ����
        Material material = new Material(base.materialForRendering);
        // ���ٽ� �� �Լ��� NotEqual�� ����
        material.SetInt("_StencilComp", (int)CompareFunction.NotEqual);
        // ���� ������ ������ �⺻ ������ ����
        base.material = material;
    }
}
