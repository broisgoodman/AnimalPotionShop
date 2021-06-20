using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GuestTable
{
    public static Dictionary<int, GuestData> Items = new Dictionary<int, GuestData>()
    {
        {
            0, new GuestData()
           {
            id = 0,
            spriteName = "Hero",
            moveSpeed = 100,
            needPostionList = new List<Position>()
            {

            }

           }
        
        
        }
    };
}


/// <summary>
/// 게스트를 만들기위한 데이터
/// </summary>
public class GuestData
{
    public int id;
    public string spriteName;
    public float moveSpeed = 1.0f;
    public List<Position> needPostionList;
}
