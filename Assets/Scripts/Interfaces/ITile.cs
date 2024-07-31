using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITile
{
    public List<ChanceTile> getNeighbor(Vector3Int direction = new Vector3Int());
}

