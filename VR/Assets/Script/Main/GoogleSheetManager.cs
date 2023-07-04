using UnityEngine;
using UnityEngine.UI;
using BackEnd;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class GoogleSheetManager : MonoBehaviour
{
    public GameObject TeamA;
    public GameObject TeamB;
    public GameObject Main;
    public GameObject Touch;
    public GameObject Login_canvas;
    public GameObject check;
    public GameObject VRcontrol;
    public InputField idinput;
    public InputField checkinput;
    
    public InputField painput;

    public int random = 0;
    int judge = 0;


    public void OnClickSingUp()
    {
        string temp = idinput.text.Substring(idinput.text.Length - 9);
        if (!temp.Equals("dgu.ac.kr")) {
            Debug.Log("동국대학교 메일이 아닙니다.");
            return;
        }
            
        Debug.Log("인증 메일을 발송 했습니다.");
        SendEmail();
        check.SetActive(true);
         
    }
    public void OnClickLogin()
    {
        BackendReturnObject BRO = Backend.BMember.CustomLogin(idinput.text, painput.text);
      
        if (BRO.IsSuccess())
        {
            Debug.Log("성공");
            TeamA.SetActive(true);
            TeamB.SetActive(true);
            Main.SetActive(true);
            Touch.SetActive(true);
            Login_canvas.SetActive(false);
            VRcontrol.SetActive(true);
        }
       
        else
        {
            Debug.Log("실패");
        }
    }

    public void SendEmail()
    {
        MailMessage mail = new MailMessage();
        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.EnableSsl = true;
        smtpServer.Timeout = 10000;
        smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpServer.UseDefaultCredentials = false;
        smtpServer.Port = 587;


        mail.From = new MailAddress("qmal789@dgu.ac.kr");
        mail.To.Add(new MailAddress(idinput.text));
        random = UnityEngine.Random.Range(100000, 1000000);
        mail.Subject = "캠퍼스 VR 투어 회원가입 확인 메일입니다";
        mail.Body = "인증 번호는 " + random + "입니다. 입력해주세요.";
        smtpServer.Credentials = new System.Net.NetworkCredential("qmal789@dgu.ac.kr", "anzm5623!");
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };

        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        smtpServer.Send(mail);
    }
    public void Check()
    {
        if (random == int.Parse(checkinput.text)) {
            check.SetActive(false);
            Debug.Log("인증 성공");
            BackendReturnObject BRO = Backend.BMember.CustomSignUp(idinput.text, painput.text);
            if (!BRO.IsSuccess())  
            {
                string error = BRO.GetStatusCode();
                //회원가입 실패 시
                switch (error)
                {
                    case "409":
                        Debug.Log("이미 가입된 아이디 입니다.");
                        break;
                    default:
                        Debug.Log("서버 공통 에러 발생" + BRO.GetMessage());
                        break;
                }
            }
        }
        else{
            Debug.Log("인증 실패");
         }

    }
}