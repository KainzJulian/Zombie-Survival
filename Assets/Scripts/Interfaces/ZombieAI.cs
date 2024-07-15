using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ZombieAI
{
    void goAFK();
    void goToHuman(Transform position);
}