// AliyerEdon@mail.com Christmas 2022
// Destroy game objects based on the specific life time
// *** Useful for explosion particle system or projectiles


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float destroyDelay = 5f;

    IEnumerator Start()
    {        
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
}
