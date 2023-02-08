using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public static partial class GF
{
    //! �ؽ�Ʈ�޽����� ������ ������Ʈ�� 
    public static void SetTextMeshPro(this GameObject obj_, string text_)
    {
        TMP_Text tmptext = obj_.GetComponent<TMP_Text>();
        if(tmptext == null || tmptext == default(TMP_Text))
        {
            return;
        }       // if: ������ �ؽ�Ʈ�޽� ������Ʈ�� ���� ���

        // ������ �ؽ�Ʈ�޽� ������Ʈ�� �����ϴ� ���
        tmptext.text = text_;
    }
}
