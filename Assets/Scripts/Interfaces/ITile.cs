using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITile
{
    public List<ChanceTile> getTopNeighbor();
    public List<ChanceTile> getRightNeighbor();
    public List<ChanceTile> getBottomNeighbor();
    public List<ChanceTile> getLeftNeighbor();
}

