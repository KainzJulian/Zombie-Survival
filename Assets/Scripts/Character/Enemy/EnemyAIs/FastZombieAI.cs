using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class FastZombieAI : CoreZombieAI
{

    private void Start()
    {
        setNewPositionToMove();
    }

    private void Update()
    {
        performAFK();
    }

    public override void goAFK()
    {
        isAFK = true;
        setNewPositionToMove();
        // waitExecute(2f, performAFK);
    }
}
