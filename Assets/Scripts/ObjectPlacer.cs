using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField]
    private Transform _objectPlace;
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private GameObject _container;
    private ARRaycastManager _arRaycastManager;
    private GameObject _instaledObject;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    private void Start()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        
    }

    public void SetInstaledObject(ItemData itemData)
    {
        if (_instaledObject != null)
        {
            Destroy(_instaledObject);
        }
        _instaledObject = Instantiate(itemData.Template, _objectPlace);
    }

    private void SetObjectPosition(Vector3 position)
    {
        _objectPlace.position = position;
        Vector3 cameraForward = _camera.transform.forward;
        Vector3 cameraRotation = new Vector3(cameraForward.x, 0, cameraForward.z);
        _objectPlace.rotation = Quaternion.Euler(cameraRotation);
    }

    private void UpdatePlacementPos()
    {
        Vector3 screenCenter = _camera.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        var ray = _camera.ScreenPointToRay(screenCenter);
    }
}
