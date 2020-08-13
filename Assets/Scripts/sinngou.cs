using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinngou : MonoBehaviour
{
	public Light red;
	public Light green;
	private float timer;

	// Use this for initialization
	void Start()
	{
		//最初は全部消す
		red.enabled = false;
		green.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		//タイマーカウントアップ
		timer += Time.deltaTime;
		if (timer < 10f)
		{ //10秒未満は赤表示
			red.enabled = true;
			green.enabled = false;
		}
		
		if (timer >= 10f)
		{ //10秒以上は青色

			red.enabled = false;
			green.enabled = true;
		}
		if (timer > 20f)
		{ //20秒以上だったらタイマーリセット
			timer = 0f;
		}
	}
}
