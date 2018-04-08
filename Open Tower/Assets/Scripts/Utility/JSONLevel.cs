﻿using Scripts.LevelEditor.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONLevel : MonoBehaviour {

    [SerializeField]
    private TextAsset levelJson; // NOT upload

    [SerializeField]
    private int scoreID = 0;

    [SerializeField]
    private string stage;

    [SerializeField]
    private string levelName;

    [SerializeField]
    private string sceneOnVictory;

    [SerializeField]
    private string sceneOnExit = "Main_Menu";

    private Upload _upload;

    public int ScoreID {
        get {
            return scoreID;
        }
    }

    public string SceneOnVictory {
        get {
            return sceneOnVictory;
        }
    }

    public string SceneOnExit {
        get {
            return sceneOnExit;
        }
    }

    public Upload Upload {
        get {
            return new Upload(levelJson.text, levelName, int.MinValue, DateTime.MinValue.ToString());
        }
    }

    public string Stage {
        get {
            return stage;
        }
    }
}