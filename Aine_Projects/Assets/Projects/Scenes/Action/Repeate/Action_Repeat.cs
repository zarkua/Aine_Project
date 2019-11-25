﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MyBox;

public class Action_Repeat : Action_Mono
{
	[SerializeField] private Animator m_buttonAnim;
	// Start is called before the first frame update
	private void Start()
	{
		Debug.Log("Action_Repeate");
		Setup();
		m_type = GameManager._ACTION_TYPE.Repeate;
		ml_displayAnim.Add(transform.GetChild(2).GetComponent<Animator>());
		m_actDir = true;
		ResetValue();
	}
	protected override void ResetText()
	{
		string str = "      <size=80>" + (0) + "</size>\n    連打!!";
		ChangeCount(str);
	}

	// Update is called once per frame
	private void Update()
	{
		if (StartAction()) return;
		if (TimeCheck("Action_Repeate"))
		{
			InputRepeat();
			TimeDecrement();
		}
	}

	// 連打
	private void InputRepeat()
	{
		if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) && m_time > 0f)
		{
			string str = "      <size=80>" + (++m_cnt) + "</size>\n    連打!!";
			ChangeCount(str);
			m_buttonAnim.Play("Button");
			m_cutAnim.AnimSpeed(m_cnt, m_multiply);
		}
		if ((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp("joystick button 0")))
		{
			m_buttonAnim.Play("Button_Up");
		}
	}
}