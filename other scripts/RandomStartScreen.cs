using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStartScreen : MonoBehaviour
{
	public List<Sprite> backgrounds;
    void Awake()
    {
       GetComponent<SpriteRenderer>().sprite = backgrounds[(int)Random.Range(0,backgrounds.Count - 1)];
    }
    void Update(){
    	if(Input.anyKey || Input.touchCount >= 1)
    	Destroy(gameObject);
} }
