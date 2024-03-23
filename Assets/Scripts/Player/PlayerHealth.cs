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
    public Animator animator;

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
        var death = 0;
        value -= damage;
        if (value <= 0)
        {
            death = 1;
            GUI.SetActive(false);
            GameOver.SetActive(true);
            InitComponents();
            _playerController.enabled = false;
            _cameraRotation.enabled = false;
            _fireballCaster.enabled = false;
            animator.SetInteger("Death", death);
            if (GameOver.active == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
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

    

    public void AddHealth(float amount)
    {
        value += amount;
        value = Mathf.Clamp(value, 0, _maxValue);
        DrawHealthBar();
    }

}
