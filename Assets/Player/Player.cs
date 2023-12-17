using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Player : MonoBehaviour

{
  [SerializeField]

private TMP_Text _healthText;
  [SerializeField]

private Transform _respawnPoint;

[SerializeField]

private int _health;
    private bool _isPowerUpActive;
    public Action OnPowerUpStart;
    public Action OnPowerUpStop;

    private Coroutine _powerupCoroutine;
    [SerializeField]
private void OnCollisionEnter(Collision collision)

{

if (_isPowerUpActive)

{

if (collision.gameObject.CompareTag("Enemy"))

{

collision.gameObject.GetComponent<Enemy>().Dead();

}

}

}
public float _powerupDuration;
  private IEnumerator StartPowerUp()

{

_isPowerUpActive = true;

if (OnPowerUpStart != null)

{

OnPowerUpStart();

}

yield return new WaitForSeconds(_powerupDuration);
_isPowerUpActive = false;
if (OnPowerUpStop != null)

{

OnPowerUpStop();

}

}

    [SerializeField]



   public void PickPowerUp()

{

if (_powerupCoroutine != null)

{

StopCoroutine(_powerupCoroutine);

}

_powerupCoroutine = StartCoroutine(StartPowerUp());

}

private Rigidbody _rigidBody;

[SerializeField]

private float _speed;

[SerializeField]

private Transform _camera;

private void Awake()

{

_rigidBody = GetComponent<Rigidbody>();

}
public void Dead()

{

_health -= 1;

if (_health > 0)

{

transform.position = _respawnPoint.position;

}

else

{
  Cursor.lockState = CursorLockMode.None;
Cursor.visible = true;
SceneManager.LoadScene("LoseScreen");
_health = 0;

Debug.Log("Lose");

}

UpdateUI();

}
private void Start()

{
    UpdateUI();

Cursor.lockState = CursorLockMode.Locked;

Cursor.visible = false;

}
private void UpdateUI()

{

_healthText.text = "Health: " + _health;

}
private void Update()

{

float horizontal = Input.GetAxis("Horizontal");

float vertical = Input.GetAxis("Vertical");

Vector3 horizontalDirection = horizontal * _camera.right;
Vector3 verticalDirection = vertical * _camera.forward;
verticalDirection.y = 0;
horizontalDirection.y = 0;
Vector3 movementDirection = horizontalDirection + verticalDirection;
_rigidBody.velocity = movementDirection * _speed * Time.fixedDeltaTime;
}

}