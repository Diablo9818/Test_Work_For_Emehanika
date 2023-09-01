using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _sensetivity;
    [SerializeField] private FlameTorch _flameTorch;
    private TorchIndicator _torchIndicator;

    private GameManager _gameManager;
    private float _oldMousePositionX;
    private float _borderX = 2.8f;

    void Start()
    {
        _torchIndicator = GetComponent<TorchIndicator>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (_gameManager.isGameActive)
        {
            Move();
        }
    }

    private void Move()
    {
        float deltaX = Input.mousePosition.x - _oldMousePositionX;
        _oldMousePositionX = Input.mousePosition.x;

        if (deltaX < 0 && transform.position.x > -_borderX)
        {
            transform.Translate(new Vector3(-_sensetivity, 0, 0) * Time.deltaTime * _speed);
        }

        if (deltaX > 0 && transform.position.x < _borderX)
        {
            transform.Translate(new Vector3(_sensetivity, 0, 0) * Time.deltaTime * _speed);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.TryGetComponent(out Flame flame))
        {
            Destroy(collision.gameObject);
            Light torchLight = _flameTorch.GetComponent<Light>();
            torchLight.intensity += 1;
            _torchIndicator.IncreaseTorchValue(1);
            _gameManager.UpdateScore(1);
        }
        if (collision.TryGetComponent(out Water water))
        {
            Light torchLight = _flameTorch.GetComponent<Light>();
            torchLight.intensity -= 1;
            _torchIndicator.DecreaseTorchValue(1);
            _gameManager.UpdateScore(-1);

            if(torchLight.intensity <= 0)
            {
                _gameManager.GameOver();
            }
        }
    }
}
