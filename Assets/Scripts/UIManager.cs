using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Vector3 launchBallVector = new Vector3(0, 0, 1500);
    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnLaunchButtonClick()
    {
        FindObjectOfType<Ball>().Launch(launchBallVector);
    }
}