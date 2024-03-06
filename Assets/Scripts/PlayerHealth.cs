using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100;
    public RectTransform valueRectTransform;
    public string scene;
    public GameObject GUI;
    public GameObject GameOver;

    private float _maxValue;
    private PlayerController _playerController;
    private CameraRotation _cameraRotation;
    private FireballCaster _fireballCaster;

    private void Start()
    {
        _maxValue = value;
        DrawHealthBar();
    }
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            GUI.SetActive(false);
            GameOver.SetActive(true);
            InitComponents();
            _playerController.enabled = false;
            _cameraRotation.enabled = false;
            _fireballCaster.enabled = false;
            if (GameOver.active == true)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                { 
                    ResetScene();
                }
                
            }
        }

        DrawHealthBar();
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(scene);
    }

    private void InitComponents()
    {
        _playerController = GetComponent<PlayerController>();
        _cameraRotation = GetComponent<CameraRotation>();
        _fireballCaster = GetComponent<FireballCaster>();
    }

    private void DrawHealthBar()
    {
        valueRectTransform.localScale = new Vector3(value / _maxValue, 1, 1);
    }
}
