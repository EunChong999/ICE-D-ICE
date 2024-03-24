using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class CutoffMaskUI : Image
{
    private bool materialNeedsUpdate = true;

    // LateUpdate�� �� �����Ӹ��� Update �Ŀ� ȣ��˴ϴ�.
    private void LateUpdate()
    {
        // ������ ������Ʈ�Ǿ�� �ϴ��� Ȯ���մϴ�.
        if (materialNeedsUpdate)
        {
            SetMaterialForRendering();
            materialNeedsUpdate = false;
        }
    }

    // materialForRendering �Ӽ� �������̵�
    public override Material materialForRendering
    {
        get
        {
            // ���⼭�� �⺻ materialForRendering�� �������� �ʰ� ��ȯ�մϴ�.
            return base.material;
        }
    }

    // SetMaterialForRendering �޼���
    private void SetMaterialForRendering()
    {
        Material material = new Material(base.materialForRendering);
        material.SetInt("_StencilComp", (int)CompareFunction.NotEqual);

        // ���ο� ������ �⺻ ���� �Ӽ��� �Ҵ��մϴ�.
        base.material = material;
    }

    // Ŭ���� �ܺο��� ���� ������Ʈ�� Ʈ�����ϴ� �޼���
    public new void UpdateMaterial()
    {
        materialNeedsUpdate = true;
    }
}
