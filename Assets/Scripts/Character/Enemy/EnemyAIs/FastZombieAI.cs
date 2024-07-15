using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastZombieAI : CoreZombieAI
{
    bool doOnce = true;

    private void Update()
    {
        if (checkAFK() || !doOnce)
        {
            doOnce = true;
            return;
        }

        if (checkDistance())
        {
            doOnce = false;
            positionToMove = transform.position;
            waitSetPositionToMove(2f);
            rotateAttackPoint(positionToMove);
        }

        performAFK();
    }

    public override void goAFK()
    {
        isAFK = true;
        positionToMove = transform.position;
        waitSetPositionToMove(2f);
        performAFK();
    }
}
