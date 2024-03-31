using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class CutoffMaskUI : Image
{
    private bool materialNeedsUpdate = true;

    private void LateUpdate()
    {
        // ������ ������Ʈ�Ǿ�� �ϴ��� Ȯ��
        if (materialNeedsUpdate)
        {
            // �������� ���� ���� ���� �޼��� ȣ��
            SetMaterialForRendering();
            // ������ ������Ʈ�Ǿ����� ǥ��
            materialNeedsUpdate = false;
        }
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

    // Ŭ���� �ܺο��� ���� ������Ʈ�� Ʈ�����ϴ� �޼���
    public new void UpdateMaterial()
    {
        // ���� ������Ʈ �ʿ� �÷��׸� ����
        materialNeedsUpdate = true;
    }
}
