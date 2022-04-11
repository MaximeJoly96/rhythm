using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;
using Zenyth.Game;

[Serializable]
public class SongMetadata
{
    public string name;
    public string artist;
    public float bpm;
    public int duration;
    public float offset;
    public AudioClip audio;
}

public class SongScrollData : Selectable, IPointerDownHandler
{
    [SerializeField]
    private Text _songName;
    [SerializeField]
    private Text _artist;
    [SerializeField]
    private Text _bpm;
    [SerializeField]
    private Text _length;
    [SerializeField]
    private Text _rankAchieved;

    [SerializeField]
    private SongMetadata _metadata;

    private void Start()
    {
        _songName.text = _metadata.name;
        _artist.text = _metadata.artist;
        _bpm.text = "BPM: " + _metadata.bpm.ToString("0");
        _length.text = FormatTime(_metadata.duration);
    }

    public void OnPointerDown(PointerEventData point)
    {
        SceneManager.LoadScene("Game");
    }

    private static string FormatTime(int seconds)
    {
        int minutes = seconds / 60;
        int remaining = seconds % 60;

        return "Length: " + minutes + ":" + (remaining > 9 ? remaining.ToString() : ("0" + remaining.ToString()));
    }
}
