﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConditionScript : MonoBehaviour {

    public Button MainMenuButton;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ExitPress()
    {
        Application.LoadLevel("UIScene");
    }
}
