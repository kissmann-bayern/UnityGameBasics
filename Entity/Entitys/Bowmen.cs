using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Archero.Entity.Translation;
using Archero.Input;
using Archero.Item;
using Archero.AI;
using Archero.Entity;

public class Bowmen : Entity
{
    public Keyboard keyboard = null;

    public float speed = 2;

    public override void Start()
    {
    
    }

    public override void OnCollision(Collision collision)
    {
//        Debug.Log("OnGameObjectCollision");
    }


    public override void Update()
    {
        this.keyboardListener();
    }




}
