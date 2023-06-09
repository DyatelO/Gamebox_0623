using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoardItem 
{
    bool IsFree { get; set; }
    Type ItemType { get; }
    int MaxItemsInBoardSlot { get; }
    int AmountItems { get; set; }

    IBoardItem Clone();
}
