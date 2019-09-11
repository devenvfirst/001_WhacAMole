using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 总管理类
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 一个洞口的数据
    /// </summary>
    public class Hole
    {
        public bool isAppear;
        public int holeX;
        public int holeY;
    }

    /// <summary>
    /// 数据和引用
    /// </summary>
    public GameObject holeGo;
    public GameObject gophersGo;

    /// <summary>
    /// 放在洞口的父物体
    /// </summary>
    private Transform holesParent;

    /// <summary>
    /// 3D Text
    /// </summary>
    public TextMesh timeTxt;
    public TextMesh scoreTxt;


    
    /// <summary>
    /// 分数和时间
    /// </summary>
    private int score = 0;

    public float time = 10f;

    /// <summary>
    /// 存储所有洞口的数组
    /// </summary>
    public Hole[] holes;

    private void Start()
    {
        InitHole();
        InvokeRepeating("CanAppear", 0, 10);
    }

    private void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = "剩余时间：" + time.ToString("0.00");
        if(time<=0)
        {
            GameOver();
        }  
    }

    /// <summary>
    /// 初始化洞口并保存数据
    /// </summary>
    private void InitHole()
    {
        holes = new Hole[9];
        holesParent = new GameObject("Hols").transform;

        int tempIndex = 0;
        for (int i = -2; i < 3; i++)
        {
            for (int j = 0; j > -3; j--)
            {
                if (i == -1 || i == 1)
                {
                    break;
                }
                else
                {
                    GameObject go = Instantiate(holeGo);
                    go.transform.SetParent(holesParent);
                    go.transform.localPosition = new Vector3(i, j);
                    go.transform.localScale = Vector3.one;

                    Hole h = new Hole();
                    h.isAppear = false;
                    h.holeX = i;
                    h.holeY = j;
                    holes[tempIndex] = h;
                    tempIndex++;
                }
            }
        }
    }


    /// <summary>
    /// 随机地鼠
    /// </summary>
    private void Appear()
    {
        int i = Random.Range(0,9);
        while(holes[i].isAppear)
        {
            i = Random.Range(0, 9);
        }
        GameObject go = Instantiate(gophersGo, new Vector3(holes[i].holeX, holes[i].holeY+0.4f, 0), Quaternion.identity);
        go.GetComponent<Gophers>().id=i;
        holes[i].isAppear = true;
    }

    /// <summary>
    /// 重复调用，时间越短，出现次数越多
    /// </summary>
    private void CanAppear()
    {
        InvokeRepeating("Appear",0,1);
    }

    /// <summary>
    /// 游戏结束
    /// </summary>
    private void GameOver()
    {
        time = 0;
        timeTxt.text = "剩余时间: " + time.ToString();
        CancelInvoke();
        Gophers[] gop = FindObjectsOfType<Gophers>();
        if(gop!=null)
        {
            for (int i = 0; i < gop.Length; i++)
            {
                Destroy(gop[i].gameObject);
            }
        }
    }

    /// <summary>
    /// 增加分数
    /// </summary>
    public void AddScore()
    {
        score += 1;
        scoreTxt.text = "分数： " + score.ToString();
    }
}
