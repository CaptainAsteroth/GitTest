using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBehaviour : MonoBehaviour
{
    private bool death;
    private GameObject Player;
    private Canvas CanvasVis;
    // Start is called before the first frame update
    void Start()
    {
        CanvasVis = GetComponent<Canvas>();
        Player = GameObject.Find("Player");
        CanvasVis.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.GetComponent<PlayerMovement>().death == true) {
            CanvasVis.enabled = true;
        }
    }
}
