using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunRaycast : MonoBehaviour
{
    [SerializeField] LineRenderer _lineRenderer;

    public RaycastHit SendRaycast(Transform spawnPoint, float range, int gunMask)
    {
        Ray ray = new Ray(spawnPoint.position, spawnPoint.forward);
        return Physics.Raycast(ray, out RaycastHit hit, range, gunMask) ? hit : default;
    }

    public void EnableLineRenderer() => _lineRenderer.enabled = true;

    public void DisableLineRenderer() => _lineRenderer.enabled = false;

    public void SetLineRenderer(Vector3 firstPoint, Vector3 lastPoint)
    {
        // --Opt
        _lineRenderer.SetPosition(0, firstPoint);
        _lineRenderer.SetPosition(1, lastPoint);
    }

    public IEnumerator Laser()
    {
        EnableLineRenderer();
        yield return new WaitForSeconds(0.05f);
        DisableLineRenderer();
    }
}
