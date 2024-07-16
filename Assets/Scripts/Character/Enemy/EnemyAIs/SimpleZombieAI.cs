using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleZombieAI : CoreZombieAI
{
    private void Update()
    {
        if (!isAFK)
            return;

        if (checkDistance())
        {
            setNewPositionToMove();
            rotateAttackPoint(positionToMove);
        }

        performAFK();
    }
}
