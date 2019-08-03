using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private static int w = 10;
    private static int h = 20;

    private static Transform[,] grids = new Transform[w, h];

    private static HashSet<int> clearRow = new HashSet<int>();

    public static Vector2 Round(Vector2 v)                          //四舍五入
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }

    public void debug()
    {
        Debug.Log(1);
    }

    public static bool isRange(Vector2 v)                           //判断某个位置是否合法
    {
        return v.x > -1 &&
                v.x < w &&
                v.y > -1 &&
                grids[(int)v.x, (int)v.y] == null;
    }

    public static bool isAllRange(Transform parent)                 //判断所有的子对象都在合法范围内
    {
        foreach (Transform temp in parent)
            if (!isRange(Round(temp.position)))
                return false;
        return true;
    }

    public static void FillGrid(Transform transform, Vector2 v)     //填充某一格
    {
        grids[(int)v.x, (int)v.y] = transform;
    }

    public static int DestroyObject()       //销毁已满行
    {
        int lenght = clearRow.Count;
        Debug.Log("set memory " + clearRow.ToString());
        foreach(int y in clearRow)              //销毁行
            for(int x = 0; x < w; x ++)
            {
                if (x != 0) 
                    Debug.Log(y);
                //销毁对象
                Destroy(grids[x, y].gameObject);
                //位置清空
                grids[x, y] = null;
            }

        if(clearRow.Count > 0)
            Decrease(new SortedSet<int>(clearRow));         //将销毁行的上方物体下落

        clearRow.Clear();
        return lenght;
    }

    public static void Decrease(SortedSet<int> decrease)            //销毁已满的行后，把为上方的行往下降
    {
        int front = 0;
        foreach(int t in decrease)
        {
            front = t;
            break;
        }
        for (int y = 0; y < clearRow.Count; y++) 
        {
            Debug.Log(y);
            //将y行以上的行往下降
            DecreaseTop(front);
        }
    }

    public static void DecreaseTop(int y)               //将y行往上的往下降
    {
        for(int yy = y + 1; yy < h; yy++)
        {
            for(int x = 0; x < w;x++)
            {
                if (grids[x, yy] != null)
                {
                    //Debug.Log(x + "   " + yy);
                    grids[x, yy - 1] = grids[x, yy];
                    grids[x, yy] = null;
                    grids[x, yy - 1].position += new Vector3(0, -1, 0);
                }
            }
        }
    }

    public static bool isFull(Vector2 v)            //判断第v.y行是不是已经满了
    {
        int y = (int)v.y;
        for (int i = 0; i < w; i++)
            if (grids[i, y] == null)
                return false;
        Debug.Log("isFull " + y);
        clearRow.Add(y);                            //将要消除的行放入一个缓冲中等待所有的都确定再消除
        return true;
    }

    public static int FillAllGrid(Transform parent)
    {
        foreach(Transform temp in parent)
        {
            FillGrid(temp, Round(temp.position));           //填充temp的位置

            if (isFull(Round(temp.position)))               //判断temp的所在行是否已满
                ;// clearRow.Add((int)temp.position.y);         //将要消除的行放入一个缓冲中等待所有的都确定再消除
        }

        int points = 0;

        if(clearRow.Count > 0)
            points = DestroyObject();                       //销毁已满的行

        return points;
    }

}
