﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Controller : MonoBehaviour
{
	private Animator m_idol;
	[SerializeField] private GameObject m_ghostPrefab;
	[SerializeField] private float m_destroyTime;
	[SerializeField] float time;

	// Start is called before the first frame update
	private void Start()
	{
		m_idol = GameObject.Find("Idol").GetComponent<Animator>();
	}

	// Update is called once per frame
	private void Update()
	{
		time = m_idol.GetCurrentAnimatorStateInfo(0).normalizedTime;
	}
	public void GenerateGhost(GameManager._Evaluation eva)
	{
		string name = null;
		switch (eva)
		{
			case GameManager._Evaluation.Excellent:
				name = "SAK_Final";
				break;
			case GameManager._Evaluation.Good:
				name = "SIM_Final";
				break;
			case GameManager._Evaluation.Nice:
				name = "NOT_Final";
				break;
		}

		GameObject work;
		work = Instantiate(m_ghostPrefab, new Vector3(-1.2f, 0f, 1.2f), Quaternion.Euler(Vector3.up * 180f), GameObject.Find("Unit").transform);
		work.GetComponent<Animator>().Play(name, 0, m_idol.GetCurrentAnimatorStateInfo(0).normalizedTime);
		Destroy(work, m_destroyTime);
	}
}