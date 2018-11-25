using System;
using System.Collections.Generic;
using UnityEngine;

public class BeatItemProtypes : ScriptableObject
{
	public List<BeatItemProtype> beatItems = new List<BeatItemProtype>();
}

[Serializable]
public class BeatItemProtype
{
	public int _type;
	public string _obstacleName;
	public int _rightClickClip;
	public string _keyName;
	public int _isHold;
	public int _isMusicElement;
	public float _missStopTime;
	public float _missProtectTime;
	public int _hitHide;
	public int _missRoleEffect;
	public float[] _rightClickUIPos;
	public float _hitTime;
	public string[] _aniName;
	public int[] _aniState;
	public string[] _aniTrigger;
	public string[] _holdChangeAniName;
	public float _beatFirstStartTime;
	public float _beatFirstEndTime;
	public float _beatSecondStartTime;
	public float _beatSecondEndTime;
	public int _canFly;
	public int[] _speedReduce;
	public int _amazingAdd;
	public int _perfectAdd;
	public int _greateAdd;
	public int _badAdd;
	public int _musicEnergyAdd;
	public int _amazingAddLuck;
	public int _perfectAddLuck;
	public int _greateAddLuck;
	public float _frontAdjustTime;
	public float _backAdjustTime;
}
