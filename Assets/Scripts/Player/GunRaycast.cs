using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunRaycast : MonoBehaviour
{
    [SerializeField] SO_Weapon _currentWeapon;

    [SerializeField] LineRenderer _lineRenderer;

    [SerializeField] Transform _bulletSpawnPoint;

    int _enemyLayerMask;

    private void Awake()
    {
        _enemyLayerMask = 1 << LayerMask.NameToLayer("Enemy");
    }

    public RaycastHit SendRaycast()
    {
        Ray ray = new Ray(_bulletSpawnPoint.position, _bulletSpawnPoint.forward);
        return Physics.Raycast(ray, out RaycastHit hit, _currentWeapon.range, _enemyLayerMask) ? hit : default;
    }

    public void EnableLineRenderer() => _lineRenderer.enabled = true;

    public void DisableLineRenderer() => _lineRenderer.enabled = false;

    public void SetLineRenderer(Vector3 lastPoint)
    {
        // --Opt
        _lineRenderer.SetPosition(0, _bulletSpawnPoint.position);
        _lineRenderer.SetPosition(1, lastPoint);
    }

    public IEnumerator Laser()
    {
        EnableLineRenderer();
        Debug.Log("Hit");
        yield return new WaitForSeconds(0.1f);
        DisableLineRenderer();
    }

    private void LoadWeaponData(SO_Weapon _newWeapon) => _currentWeapon = _newWeapon; //Will be updated with inventory. 
}
