using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaruControl : MonoBehaviour {

	public Vector2 posTop;
	public Vector2 posMid;
	public Vector2 posBot;

	enum Lanes {
		Top,
		Mid,
		Bot
	}

	Lanes currentLane = Lanes.Mid;

	public void SwipeUp(){

		Vector2 pos = transform.position;
		switch (currentLane) {
		case Lanes.Bot:
				pos.y = posMid.y;
			currentLane = Lanes.Mid;
			break;

		case Lanes.Mid:
				pos.y = posTop.y;
			currentLane = Lanes.Top;
			break;
		}

		transform.position = pos;

	}

	public void SwipeDown(){
		Vector2 pos = transform.position;
		switch (currentLane) {
		case Lanes.Top:
			pos.y = posMid.y;
			currentLane = Lanes.Mid;
			break;

		case Lanes.Mid:
			pos.y = posBot.y;
			currentLane = Lanes.Bot;
			break;
		}

		transform.position = pos;
	}
}
