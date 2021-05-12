using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    private void Start()
    {
        Destroy(this, 3);
    }
}
