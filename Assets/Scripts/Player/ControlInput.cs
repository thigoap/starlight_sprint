using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInput : MonoBehaviour
{
    SkinController skinController;
    KitController kitController;

    string skinName;
    string kitName;

    void Awake()
    {
        skinName = GameManager.Instance.DefineSkinName();
        skinController = GameObject.Find("Player " + skinName + "(Clone)").GetComponent<SkinController>();
        kitName = GameManager.Instance.DefineKitName();
        kitController = GameObject.Find("Player " + kitName + "(Clone)").GetComponent<KitController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Slide();
        }
    }

    public void Jump()
    {
        skinController.Jump();
        kitController.Jump();
    }

    public void Slide()
    {
        skinController.Slide();
        kitController.Slide();
    }
}
