using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 修改鼠标
/// </summary>
public class ChangeCursor : MonoBehaviour {

    /// <summary>
    /// 正常和击打的2D贴图
    /// </summary>
    public Texture2D cursor_nromal;
    public Texture2D cursor_down;

    /// <summary>
    /// 是否点击鼠标的标志位
    /// </summary>
    private bool isClick;
	


	void Update () {

        //检测鼠标点击
        if(Input.GetMouseButton(0))
        {
            isClick = true;
        }
        else
        {
            isClick = false;
        }
	}

    /// <summary>
    /// 绘制指针处的木锤
    /// </summary>
    private void OnGUI()
    {
        Vector2 pos = Input.mousePosition;

        if(isClick)
        {
            GUI.DrawTexture(new Rect(pos.x-40f, Screen.height - pos.y - 60f, 100, 100), cursor_nromal);
        }
        else
        {
            GUI.DrawTexture(new Rect(pos.x-40f, Screen.height-pos.y-60f, 100, 100), cursor_down);
        }
    }
}
