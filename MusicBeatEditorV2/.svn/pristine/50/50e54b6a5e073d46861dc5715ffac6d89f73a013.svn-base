using UnityEngine;
using System.Collections;
using UnityEditor;
using JSON;
using System.Collections.Generic;
public class MusicBeatDataHelper
{

    public static float FixedBtnW = 40f;
    public static float FixedBtnH = 40f;
    public static float GUIBtnWScale = 1;
    public static float BtnH{get{ return FixedBtnH;}}
	public static float BtnW{get{ return FixedBtnW*GUIBtnWScale;}}
    public static float BeatWidth{get { return BtnW*8; }}

    public static float FixedTextFieldW = 60f;
    public static float FixedTextFieldH = 0f;
    public static float TextH{get { return FixedTextFieldH; }}
	public static float TextW{get { return FixedTextFieldW; }}

	public static GUILayoutOption GUIBtnH{get{ return GUILayout.Height(BtnH);}}
	public static GUILayoutOption GUIBtnW{get{ return GUILayout.Width(BtnW);}}
	
	public static GUILayoutOption GUITextH{get{ return GUILayout.Height(TextH);}}
	public static GUILayoutOption GUITextW{get{ return GUILayout.Width(TextW);}}


    public static void PlaySouce(AudioSource audio, string name, bool loop = false)
	{
		AudioClip clip = Resources.Load<AudioClip> ("Music/Sound/" + name);
		PlaySouce(audio, clip, loop);
	}


    public static void PlaySouce(AudioSource audio, AudioClip clip, bool loop = false)
    {
        audio.clip = clip;
        audio.loop = loop;
        audio.time = 0;
        audio.Play();
    }
}
