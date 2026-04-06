using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RotationAtPoint : MonoBehaviour
{
    [SerializeField] private Vector3 _startLeftRotation;
    [SerializeField] private Vector3 _startRghtRotation;
    [SerializeField] float _rotationSpeed;
    private Quaternion _leftRotation;
    private Quaternion _rightRotation;
    private Quaternion _currentRotation;

    private void Start()
    {
        _leftRotation = Quaternion.Euler(_startLeftRotation);
        _rightRotation = Quaternion.Euler(_startRghtRotation);
    }

    private void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, _currentRotation, Time.deltaTime * _rotationSpeed);
    }
    
    public void RotationRigth()
    {
        _currentRotation = _rightRotation;
    }

    public void RotationLeft()
    {
        _currentRotation = _leftRotation;
    }
}
