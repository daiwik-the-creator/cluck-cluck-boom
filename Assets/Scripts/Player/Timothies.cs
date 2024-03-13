using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Timothies : MonoBehaviour
{
    [SerializeField] GameObject beakley;
    public float speed = 5f; // Adjust this speed as needed
    public bool flip;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;

        if (beakley.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
            Vector3 pos = new Vector3(beakley.transform.localPosition.x + 2, beakley.transform.localPosition.y, beakley.transform.localPosition.z);
            transform.SetLocalPositionAndRotation(pos, beakley.transform.localRotation);
            //transform.Translate(speed * Time.deltaTime, y:0, z:0);
        } else
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
            //transform.Translate(speed * Time.deltaTime * -1, y:0, z: 0);
            Vector3 pos = new Vector3(beakley.transform.localPosition.x - 2, beakley.transform.localPosition.y, beakley.transform.localPosition.z);
            transform.SetLocalPositionAndRotation(pos, beakley.transform.localRotation);
        }

        transform.localScale = scale;

    }
}
