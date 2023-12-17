using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PickableManager : MonoBehaviour
{
    [SerializeField]

private ScoreManager _scoreManager;
    
    [SerializeField] private Player _player;
    private List<Pickable> _pickableList = new List<Pickable>();

    private void Start()
    {
        InitPickableList();
    }

    private void InitPickableList()
    {
         _pickableList.Clear();
       
       Pickable[] pickableObjects = GameObject.FindObjectsOfType<Pickable>();

        foreach (Pickable pickableObject in pickableObjects)
        {
            _pickableList.Add(pickableObject);
            pickableObject.OnPicked += OnPickablePicked;
        }

        // Set max score after populating pickable list
        if (_scoreManager != null)
        {
            _scoreManager.SetMaxScore(_pickableList.Count);
        }

        Debug.Log("Pickable List: " + _pickableList.Count);
    }
    

    private void OnPickablePicked(Pickable pickable)
{
    if (_scoreManager != null)

{

_scoreManager.AddScore(1);

}
    pickable.OnPicked -= OnPickablePicked;

    _pickableList.Remove(pickable);
    Destroy(pickable.gameObject);

    Debug.Log("Pickable List: " + _pickableList.Count);

    if (_pickableList.Count <= 0)
    {
       

Cursor.lockState = CursorLockMode.None;
Cursor.visible = true;
        SceneManager.LoadScene("WinScreen");
        Debug.Log("Win");
        // Trigger a win condition or any action you need upon collecting all pickable objects
    }

    // Access the ItemType of the picked object
    if (pickable.ItemType == PickableType.PowerUp)
    {
        _player?.PickPowerUp();
    }
}
}
