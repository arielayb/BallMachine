using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    private float initialXPos_;
    private float initialYPos_;
    private float catapultPos;
    private bool pressed_;
    private GameObject gameObj; 

    public float speed;

    [Range(0.0f, 12.0f)]
    public float launchPos;

    // Start is called before the first frame update
    void Start()
    {
        gameObj = GameObject.Find("catapult");
        initialXPos_ = gameObj.transform.position.x;
        initialYPos_ = gameObj.transform.position.y;
    }

    void Update()
    {
        if (Input.GetKeyDown("space")) {
            pressed_ = true;
        }
    }

    void MoveCatapult() {
        Debug.Log("space bar pressed");
        float tempYPos = initialYPos_;
        initialYPos_ = launchPos;
        gameObj.transform.position = new Vector2(initialXPos_, launchPos * Time.deltaTime);
        new WaitForSeconds(2);
        initialYPos_ = tempYPos;
        gameObj.transform.position = new Vector2(initialXPos_ * Time.deltaTime, initialYPos_ * Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pressed_) {
            MoveCatapult();
            pressed_ = false;
        }
    }
}
