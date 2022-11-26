using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    #region [variables]

    //Оголошуємо змінні
    private Transform _mainCamera;
    private Vector3 _camStartPos;
    private float _distance;

    private GameObject[] _bgLayers;
    private Material[] _mat;
    private float[] _backSpeed;

    private float _farthestBack;

    [Range(0f, 0.5f)]
    public float parallaxSpeed;

    #endregion

    #region [methods]

    private void Start()
    {
        _mainCamera = Camera.main.transform;
        _camStartPos = _mainCamera.position;

        int backCount = transform.childCount;
        _mat = new Material[backCount];
        _backSpeed = new float[backCount];
        _bgLayers = new GameObject[backCount];

        for (int i = 0; i < backCount; i++)
        {
            _bgLayers[i] = transform.GetChild(i).gameObject;
            _mat[i] = _bgLayers[i].GetComponent<Renderer>().material;
        }
        CalculateBackSpeed(backCount);
    }

    private void CalculateBackSpeed(int backCount)      /*Метод для обчислення швидкості кожного елементу паралакс-ефекту*/
    {
        for (int i = 0; i < backCount; i++)
        {
            if (_bgLayers[i].transform.position.z - _mainCamera.position.z > _farthestBack)
            {
                _farthestBack = _bgLayers[i].transform.position.z - _mainCamera.position.z;
            }
        }

        for (int i = 0; i < backCount; i++)
        {
            _backSpeed[i] = 1 - (_bgLayers[i].transform.position.z - _mainCamera.position.z) / _farthestBack;
        }
    }

    private void LateUpdate()
    {
        _distance = _mainCamera.position.x - _camStartPos.x;

        transform.position = new Vector3(_mainCamera.position.x, transform.position.y, 0);

        for (int i = 0; i < _bgLayers.Length; i++)
        {
            float speed = _backSpeed[i] * parallaxSpeed;

            _mat[i].SetTextureOffset("_MainTex", new Vector2(_distance, 0) * speed);
        }
    }

    #endregion
}
