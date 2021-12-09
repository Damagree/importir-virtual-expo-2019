using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
