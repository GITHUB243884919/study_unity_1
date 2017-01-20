using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class download_many : MonoBehaviour {

	// Use this for initialization
    private int totalFiles = 2;
    private int totalLine = 2;
    private int perLine   = 0;
	void Start ()
	{

	    perLine = (totalFiles + (totalLine - 1)) / totalLine;
	    Debug.LogFormat("perLine = {0}", perLine);
        for (int i = 0; i < totalLine; i++)
	    {
            StartCoroutine(DownloadSingleLine(i));
	    }
	}

    IEnumerator DownloadSingleLine(int lineID)
    {
        int begin = perLine * lineID;
        int end = begin + perLine - 1;
        if (end > (totalFiles - 1))
        {
            end = totalFiles - 1;
        }

        for (int i = begin; i <= end; i++)
        {
            yield return null;
            Debug.LogFormat("lineID={0}, begin={1},end={2}, file={3}", lineID, begin, end,  i);
            //string path = i.ToString();
            //using (WWW www = new WWW(path))
            //{
            //    yield return www;
            //    if (www.isDone)
            //    {
            //    }
            //}
        }

    }
}
