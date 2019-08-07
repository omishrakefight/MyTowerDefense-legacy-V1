﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_PlasmaHead : MonoBehaviour
{

    public CapsuleCollider laser;

    bool checkedInsideRange = false;
    private List<EnemyHealth> enemies = new List<EnemyHealth>();
    // Use this for initialization
    void Start()
    {

    }

    public List<EnemyHealth> getEnemies()
    {
        print("getting enemies " + enemies.Count);
        return enemies;
    }

    public void ClearEnemies()
    {
        enemies.Clear();
        //print("cleared! " + enemies.Count + " enemies left!");

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        //print(other + "found something to trigger on");
        if (other.gameObject.GetComponentInParent<EnemyHealth>())
        {
            print("in parent");
            if (!enemies.Contains(other.gameObject.GetComponentInParent<EnemyHealth>()))
            {
                //print("found someone");
                enemies.Add(other.gameObject.GetComponentInParent<EnemyHealth>());
                print("added them" + enemies.Count);
            }
        }
        if (other.gameObject.GetComponent<EnemyHealth>())
        {
            //print("not in parent :o");
        }
    }
}
