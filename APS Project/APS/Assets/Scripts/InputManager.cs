using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Camera mainCam;

    public enum eMap
    {
        PositionShop,
        Harvest,
    }

    public eMap currentMap = eMap.PositionShop;

    [HideInInspector]
    public List<eMap> mapList = new List<eMap>() { eMap.PositionShop, eMap.Harvest };

    public Dictionary<eMap, Vector3> mapPositionDataDic = new Dictionary<eMap, Vector3>()
    {
        {eMap.PositionShop, new Vector3(358,211,-10) },
        {eMap.Harvest, new Vector3(1112,211,-10) }
    };

    private Vector3 startMousePos;
    private Vector3 lastMousePos;
    bool isDrag = false;


    private void Awake()
    {
        mainCam.transform.position = CalcMapMovement();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDrag == false && Input.GetMouseButtonDown(0))
        {
            isDrag = true;
            startMousePos = Input.mousePosition;
            lastMousePos = startMousePos;
        }

        if(isDrag == true)
        {
            mainCam.transform.position += Input.mousePosition - lastMousePos;
            lastMousePos = Input.mousePosition;
        }

        if(Input.GetMouseButtonUp(0))
        {
            isDrag = false;
            mainCam.transform.position = CalcMapMovement();
        }
    }

    /// <summary>
    /// 마우스 드레그에 의해서 카메라 설정 계산
    /// </summary>
    private Vector3 CalcMapMovement()
    {
        //최종방향
        Vector3 dir = lastMousePos - startMousePos;

        if (dir.sqrMagnitude > 10)
        {
            var curIdx = mapList.IndexOf(currentMap);

            if (dir.x > 0)
            {
                if (curIdx != mapList.Count - 1)
                {
                    currentMap = mapList[curIdx + 1];
                }
            }
            else if (dir.x < 0)
            {
                if (curIdx != 0)
                {
                    currentMap = mapList[curIdx - 1];
                }
            }
        }

        return mapPositionDataDic[currentMap];
    }
}
