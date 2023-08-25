using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private GameManager _gameManager;
    public float forwardSpeed;
    private float firstTouchX;


    public List<GameObject> coffees;

    // Start is called before the first frame update
    void Start()
    {
        coffees = new List<GameObject>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.currentGameState != GameState.Start)
        {
            return;
        }

        for (int i = 0; i < coffees.Count; i++)
        {
            coffees[i].transform.position = new Vector3(transform.position.x, transform.position.y,
                Mathf.Lerp(transform.position.z, coffees[i].transform.position.z, 0.1f * Time.deltaTime));
        }

        Vector3 moveVector = new Vector3(-1 * forwardSpeed * Time.deltaTime, 0, 0);
        float diff = 0;
        if (Input.GetMouseButtonDown(0))
        {
            firstTouchX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            float lastTouchX = Input.mousePosition.x;
            diff = lastTouchX - firstTouchX;
            moveVector += new Vector3(0, 0, diff * Time.deltaTime);
            firstTouchX = lastTouchX;
        }

        //transform.position += moveVector;

        transform.position = transform.position + moveVector;
        var z = Mathf.Clamp(transform.position.z, -3, 3);

        transform.position = new Vector3(transform.position.x, transform.position.y, z);

        print(diff);
        print(firstTouchX);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            other.transform.SetParent(transform);
            coffees.Add(other.gameObject);
        }
        else if (other.CompareTag("Finish"))
        {
            foreach (var coffee in coffees)
            {
                Destroy(coffee);
            }

            _gameManager.EndGame();

            coffees = new();
        }
    }
}