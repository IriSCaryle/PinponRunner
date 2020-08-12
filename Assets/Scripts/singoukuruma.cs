using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singoukuruma : MonoBehaviour
{
	public Light red;
	public Light yellow;
	public Light green;
	private float timer;

	// Use this for initialization
	void Start()
	{
		//最初は全部消す
		red.enabled = false;
		yellow.enabled = false;
		green.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		//タイマーカウントアップ
		timer += Time.deltaTime;
		if (timer < 10f)
		{ //5秒未満は赤表示
			red.enabled = true;
			yellow.enabled = false;
			green.enabled = false;
		}
		if (timer >= 10f && timer < 18f)
		{ //5秒以上、10秒未満はグリーン表示
			green.enabled = true;
			yellow.enabled = false;
			red.enabled = false;
		}
		if (timer >= 18f)
		{ //10秒以上は黄色
			yellow.enabled = true;
			red.enabled = false;
			green.enabled = false;
		}
		if (timer > 20f)
		{ //12秒以上だったらタイマーリセット
			timer = 0f;
		}
	}
}
