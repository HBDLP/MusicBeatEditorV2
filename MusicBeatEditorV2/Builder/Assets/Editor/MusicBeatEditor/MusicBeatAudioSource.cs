using UnityEngine;
using System.Collections;

public class MusicBeatAudioSource
{
    static public string PathBGM = "Music/BGM/";
    static public string PathSubBGM = "Music/SubBGM/";
    public AudioSource _source;

    private string _clipname;
    public float length
    {
        get
        {
            if (_source == null || _source.clip == null)
                return 1;
            return _source.clip.length;
        }
    }

    public void LoadClip(string clipname)
    {
        if (_clipname != clipname)
        {
            AudioClip clip = Resources.Load<AudioClip>(PathBGM + clipname);
            if(clip == null)
            {
                clip = Resources.Load<AudioClip>(PathSubBGM + clipname); 
            }
            _source.clip = clip;
            Stop();
            time = 0f;
            _clipname = clipname;
        }
    }

    public float time
    {
        get
        {
            if (_eState == EnumState.ePlaying)
            {
                float t = _timeline + (Time.realtimeSinceStartup - _timeStartPlaying);
                if (t >= _source.clip.length)
                {
                    t = _source.clip.length;
                    Stop();
                }
                return t;
            }

            return _timeline;
        }
        set
        {
            _timeline = value;
            _timeline = Mathf.Clamp(_timeline, 0, _source.clip.length);
            _source.time = _timeline;

            if(_eState == EnumState.ePlaying)
                _timeStartPlaying = Time.realtimeSinceStartup;
            else if (_eState == EnumState.ePausing)
                _timeStartPlaying = 0f;
        }
    }

    enum EnumState
    {
        eNone,
        ePlaying,
        ePausing,
        eStop
    }
    EnumState _eState = EnumState.eNone;

    private float _timeStartPlaying;
    private float _timePaused;
    private float _timeline;

    public void PlayOrPause()
    {
        if (_eState == EnumState.ePlaying)
        {
            Pause();
        }
        else
        {
            Play();
        }
    }
    
    public void Play()
    {
        _eState = EnumState.ePlaying;
        _timeStartPlaying = Time.realtimeSinceStartup;
        _source.time = _timeline;
        _source.Play();
    }

    public void Pause()
    {
        if (_eState == EnumState.ePlaying)
        {
            _timeline = _timeline + (Time.realtimeSinceStartup - _timeStartPlaying);
            _timeline = Mathf.Clamp(_timeline, 0, _source.clip.length);
            _timeStartPlaying = 0;
        }

        _eState = EnumState.ePausing;
        _source.Pause();
    }

    public void Stop()
    {
        if (_eState == EnumState.ePlaying)
        {
            _timeline = _timeline + (Time.realtimeSinceStartup - _timeStartPlaying);
            _timeline = Mathf.Clamp(_timeline, 0, _source.clip.length);
            _timeStartPlaying = 0f;
        }
        else if (_eState == EnumState.ePausing)
        {
            
        }

        _eState = EnumState.eStop;
        _source.Stop();
    }

    public bool IsHaveClip()
    {
        if(_source!=null && _source.clip != null)
        {
            return true;
        }
        return false;
    }

    public bool IsPlaying()
    {
        if(_eState == EnumState.ePlaying)
        {
            return true;
        }
        return false;
    }
}
