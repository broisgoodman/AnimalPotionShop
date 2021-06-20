using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guest : MonoBehaviour
{
    /// <summary>
    /// ¼Õ´Ô ¿ÜÇü
    /// </summary>
    public Image imageRenderer;
    public float moveSpeed = 1.0f;

    public Vector3 startPos;
    public Vector3 endPos;
    public float time = 0;
    public bool isRight = true;
    public bool isMoving = true;

    public void Init(GuestData data)
    {
        imageRenderer.sprite = Resources.Load<Sprite>($"GuestImage/{data.spriteName}");
        moveSpeed = data.moveSpeed;
    }
    public void SetPosition(Vector3 startPos)
    {
        this.startPos = startPos;
        this.endPos = new Vector3(-410, startPos.y, startPos.z);
    }

    public void Update()
    {
        if (isMoving == true)
        {
            if (isRight == true && time < 1)
            {
                transform.localPosition = Vector3.Lerp(startPos, endPos, time);
                time += (Time.deltaTime / 3);

                if(time >= 1)
                {
                    StartCoroutine(DelayCall());
                }
            }
            else if (isRight == false && time > 0)
            {
                transform.localPosition = Vector3.Lerp(startPos, endPos, time);
                time -= (Time.deltaTime / 3);
            }
        }
    }

    IEnumerator DelayCall()
    {
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        isRight = false;
    }
}



public class Position
{
    
}