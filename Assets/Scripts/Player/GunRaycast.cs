using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunRaycast : MonoBehaviour
{
    [SerializeField] SO_Weapon _currentWeapon;

    [SerializeField] LineRenderer _lineRenderer;

    public RaycastHit SendRaycast(Transform spawnPoint, int gunMask)
    {
        Ray ray = new Ray(spawnPoint.position, spawnPoint.forward);
        return Physics.Raycast(ray, out RaycastHit hit, _currentWeapon.range, gunMask) ? hit : default;
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

    private void LoadWeaponData(SO_Weapon _newWeapon) => _currentWeapon = _newWeapon; //Will be updated with inventory. 
}
