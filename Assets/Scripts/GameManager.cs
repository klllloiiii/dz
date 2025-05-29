using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Color[] _color;
    [SerializeField] private Sprite[] _playerTextures;

    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _player;

    private Player _playerScript;
    private SpriteRenderer _playerSprite;

    private void Start()
    {
        _playerScript = _player.GetComponent<Player>();
        _playerSprite = _player.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        if (_playerScript._IsGrounded == true && Input.GetKeyDown(KeyCode.W)) // костыль, но работает))
        {
            _camera.backgroundColor = _color[Random.Range(0, _color.Length)];
            _playerSprite.sprite = _playerTextures[Random.Range(0, _playerTextures.Length)];
        }
    }


}
