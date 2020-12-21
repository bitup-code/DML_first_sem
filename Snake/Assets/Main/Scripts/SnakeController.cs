using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{
    public int appleOnLevel;
    private int apple = 0;
    public List<Transform> Tails;
    [Range(0,3)]
    public float BoneDistance;
    public GameObject BonePrefab;
    [Range(0,4)]
    public float Speed;
    private Transform _transform;

    public UnityEvent OnEat;

  
    public Text appleText;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        appleText = GetComponent<Text>();
        UpdateDisplay();

    }
    private void Update()
    {
        MoveSnake(_transform.position + _transform.forward*Speed);

        float angel = Input.GetAxis("Horizontal")*2;
        _transform.Rotate(0, angel, 0);
        
    }

    private void MoveSnake(Vector3 newPosition)
    {
        float sqrDistance = BoneDistance * BoneDistance;
        Vector3 previousPosition = _transform.position;

        foreach (var bone in Tails)
        {
            if ((bone.position-previousPosition).sqrMagnitude>sqrDistance)
            {
                var teamp = bone.position;
                bone.position = previousPosition;
                previousPosition = teamp;
            }
            else
            {
                break;
            }
        }
        _transform.position = newPosition;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Food")
        {
            Destroy(collision.gameObject);

            

            var bone = Instantiate(BonePrefab);
            Tails.Add(bone.transform);

            if (OnEat!=null)
            {
                OnEat.Invoke();
            }
            
            apple++;
            UpdateDisplay();
        }
        if (collision.gameObject.tag == "Wall")
        {
            SceneManager.LoadScene(1);
        }
        if (appleOnLevel==apple)
        {
            SceneManager.LoadScene(2);
        }
    }
    private void UpdateDisplay()
    {
        appleText.text = apple.ToString();
    }
}
