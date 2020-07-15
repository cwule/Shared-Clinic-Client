using UnityEngine;

public class ChangeParent : MonoBehaviour
{
    public void CalibrateSpace()
    {
        // make sure that avatar is not attached to calibration object
        if (GameObject.Find("HumanAnatomyCompleteNetSkel(Clone)"))
            GameObject.Find("HumanAnatomyCompleteNetSkel(Clone)").transform.parent = null;

        if (this.transform.parent == null)
        {
            this.transform.parent = Camera.main.transform;
            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else
        {
            this.transform.parent = null;
            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    public void CalibrationDone()
    {
        this.transform.parent = null;
        Transform _avatar = GameObject.Find("HumanAnatomyCompleteNetSkel(Clone)/WholeBody").transform.parent;
        _avatar.SetParent(transform);
    }

}
