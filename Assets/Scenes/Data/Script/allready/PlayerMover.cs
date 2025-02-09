using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private InteractablePlayer _interactablePlayer;
    [SerializeField] private Camera _camera;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private CapsuleCollider2D _capsuleCollider2D;
    private Vector2 _moveVector;
    private Vector3 _rotate;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _particleSystem.Pause();
    }

    private void Update()
    {
        _moveVector.x = Input.GetAxis(Horizontal);
        _moveVector.y = Input.GetAxis(Vertical);

        _rigidbody2D.velocity = new Vector2(_moveVector.x * _speed * Time.deltaTime, _moveVector.y * _speed * Time.deltaTime);

        if(_moveVector.x != 0 || _moveVector.y != 0)
        {
            _particleSystem.Play();
        }
        else
        {
            _particleSystem.Stop();

        }

        FlipX();
    }

    private void FlipX()
    {
        if (_moveVector.x > 0)
        {
            _rotate = transform.eulerAngles;
            _rotate.y = 0;
            transform.rotation = Quaternion.Euler(_rotate);
        }
        else if (_moveVector.x < 0)
        {
            _rotate = transform.eulerAngles;
            _rotate.y = 180;
            transform.rotation = Quaternion.Euler(_rotate);
        }
        else
        {
            _rotate = transform.eulerAngles;
            transform.rotation = Quaternion.Euler(_rotate);
        }
    }

    public void UpSpeed()
    {
        _speed += 100;
        _interactablePlayer.ClouseLvlvImage();
    }

    public void AddRadiysVision()
    {
        _camera.orthographicSize += 4;
        _interactablePlayer.ClouseLvlvImage();
    }
}
