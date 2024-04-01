using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCheck : MonoBehaviour
{
    bool collected = false;

    public void IsCollected()
    {
        this.collected = true;
    }
}
