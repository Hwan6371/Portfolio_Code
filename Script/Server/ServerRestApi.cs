using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class ForceAcceptAll : CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        return true;
    }
}

public class ServerRestApi : MonoBehaviour
{
    private Coroutine timeoutCoroutine;

    private void Start()
    {
        JaeHwanUtils.Instance.serverRestApi = this;
    }

    public void SendRequest_GET(ApiAddressType _communicationType, ApiAddressType communicationTypeTail = ApiAddressType.NONE, List<AdditionalApiInfo> _additionalInfos = null, ServerResponse _callBack = null)
    {
        StartCoroutine(SendRequestCoroutine(_communicationType, HttpMethod.GET, null, _callBack, communicationTypeTail, _additionalInfos));
    }

    public void SendRequest_POST(ApiAddressType _communicationType, object _data = null, ServerResponse _callBack = null)
    {
        StartCoroutine(SendRequestCoroutine(_communicationType, HttpMethod.POST, _data, _callBack, ApiAddressType.NONE, null));
    }

    public void SendRequest_PUT(ApiAddressType _communicationType, ApiAddressType communicationTypeTail = ApiAddressType.NONE, List<AdditionalApiInfo> _additionalInfos = null, ServerResponse _callBack = null)
    {
        StartCoroutine(SendRequestCoroutine(_communicationType, HttpMethod.PUT, null, _callBack, communicationTypeTail, _additionalInfos));
    }

    private IEnumerator SendRequestCoroutine(ApiAddressType communicationType, HttpMethod restAPIType, object data = null, ServerResponse callBack = null, ApiAddressType communicationTypeTail = ApiAddressType.NONE, List<AdditionalApiInfo> _additionalInfos = null)
    {
        string address = ServerRestAddress.GetAddress(communicationType, communicationTypeTail, _additionalInfos);

        if (string.IsNullOrEmpty(address))
        {
            CallCallback(callBack, "", "No Address");
            yield break;
        }

        byte[] postBytes = null;
        if (data != null)
        {
            string json = JsonConvert.SerializeObject(data);
            Debug.Log(json);
            if (string.IsNullOrEmpty(json))
            {
                CallCallback(callBack, "", "Data parsing Error");
                yield break;
            }

            postBytes = Encoding.UTF8.GetBytes(json);
        }

        UnityWebRequest www = new UnityWebRequest(address, restAPIType.ToString());

        var cert = new ForceAcceptAll();
        if (communicationType == ApiAddressType.POST_ERROR_LOG)
            www.certificateHandler = cert;

        if (postBytes != null)
            www.uploadHandler = new UploadHandlerRaw(postBytes);

        www.downloadHandler = new DownloadHandlerBuffer();

        // if(communicationType != COMMUNICATION_TYPE.GET_GOOGLE_SHEET)

        www.timeout = 7;
        
        if(timeoutCoroutine != null)
            StopCoroutine(timeoutCoroutine);
        timeoutCoroutine = StartCoroutine(WaitForIt(()=> {
                            JaeHwanUtils.Instance.loadingManager.StartNetworkLoading();
                        }, 3f));

        www.SetRequestHeader("Content-Type", "application/json");

        if (string.IsNullOrEmpty(UserModel.Instance.AccessToken) == false)
            www.SetRequestHeader("Authorization", "Bearer " + UserModel.Instance.AccessToken);

        yield return www.SendWebRequest();
        
        StopCoroutine(timeoutCoroutine);
        JaeHwanUtils.Instance.loadingManager.StopNetworkLoading();

        cert?.Dispose();

        // 통신 실패
        if (www.result != UnityWebRequest.Result.Success)
        {
            CallCallback(callBack, "", www.error);            
            JaeHwanUtils.Instance.popupManager.OpenError();
        }
        else // 통신
        {
            CallCallback(callBack, www.downloadHandler.text, "");
        }
    }

    private void CallCallback(ServerResponse callback, string message, string errorMessage)
    {
        if (callback == null)
            return;

        callback(message, errorMessage);
    }

    IEnumerator WaitForIt(Action _action, float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        _action?.Invoke();
    }
}