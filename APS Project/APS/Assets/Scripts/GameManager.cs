using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Canvas mainCanvas;
    public GameObject guestPrefab;



    public void Awake()
    {
        StartCoroutine(MakeGuestRoutine());
    }

    IEnumerator MakeGuestRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 5f));
            GameObject obj = Instantiate(guestPrefab, mainCanvas.transform);
            Guest script = obj.GetComponent<Guest>();
            script.Init(GuestTable.Items[0]);
            script.SetPosition(new Vector3(1132, Random.Range(-400f, 400f), 0));
        }
    }
}
