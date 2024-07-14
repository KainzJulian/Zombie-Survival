using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemyAI
{
    void goAFK();
    void goToHuman(Transform position);
}