using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRaycast : MonoBehaviour
{
    public RaycastHit SendRaycast(Transform spawnPoint, float range, int gunMask)
    {
        Ray ray = new Ray(spawnPoint.position, spawnPoint.forward);
        return Physics.Raycast(ray, out RaycastHit hit, range, gunMask) ? hit : default;
    }
}
