using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Destroy",menuName ="Actions/Destroy")]
public class DestroyAction : ScriptableObject
{
   public void DestroyEnemy(Transform t)
    {
        Destroy(t.gameObject);
    }
}
