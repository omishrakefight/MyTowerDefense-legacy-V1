﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class SaveAndLoad : MonoBehaviour {

     public bool[] towerList;

    SaveSerializedObject saver;
    // create a new serializable object and then just import / export into it THEN serialize it here.
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GetReferences()
    {
        PlayerTowerLog towerListObj = FindObjectOfType<PlayerTowerLog>();

        towerList = towerListObj.SaveTowers();

        //saver = SaveSerializedObject(towerListObj.SaveTowers());
        saver = GetComponent<SaveSerializedObject>();
        saver.towerList = towerListObj.SaveTowers();

    }
    public void Save()
    {
        GetReferences();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/TowerInformation.dat");

        //PlayerTowerLog towersAvailable = new PlayerTowerLog();
        // initialize or w/e i want to do be4 sving

        bf.Serialize(file, saver.towerList); // this is whats serialized.
        file.Close();

    }

    public void Load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        // ?????????????????????????????? openWrite?
        FileStream file = File.Open(Application.persistentDataPath + "/TowerInformation.dat", FileMode.Open);
        //SaveAndLoad towerLog = (SaveAndLoad)bf.Deserialize(file);
        //SaveSerializedObject towerLog = (SaveSerializedObject)bf.Deserialize(file);
        bool[] bools = (bool[])bf.Deserialize(file);
        file.Close();
        //towerList = towerLog.towerList; // initializing off of new object.
        foreach(bool tower in bools)
        {
            print(tower);
        }
        // initialize or create whatever wiht information now.
    }
}
