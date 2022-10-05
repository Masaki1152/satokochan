using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = System.Random;

public class ButtonMission : MonoBehaviour
{
    DateTime day;
    string[] eyes = { "�m�[�}��", "���", "�����", "�Ƃ��", "���Ɩ�" };
    string[] longhair = { "�����O�^�X�g���[�g", "�����O�^�p�[�}", "�����O�^��������", "�����O�^�c���[��", "�����O�^�P�J�b�g" };
    string[] semilonghair = { "�Z�~�����O�^�X�g���[�g" };
    string[] medium = { "�~�f�B�A���^�p�[�}", "�~�f�B�A���^�J�[���[" };
    string[] shorthair = { "�V���[�g�^�X�g���[�g", "�V���[�g�^�p�[�}", "�V���[�g�^�{�u", "�V���[�g�^�}�b�V���{�u", "�V���[�g�^�E���t�J�b�g", "�V���[�g�^�x���[�V���[�g" };
    string[] elsehair = { "������", "�|�j�[�e�[��", "�����T�C�h�A�b�v", "�n�[�t�A�b�v", "�T�C�h�e�[��", "�c�C���e�[��", "�V�j����", "�c�C�X�g�e�B�A��" };
    string[] addItem = { "�w�A�S��", "�w�A�s��", "�V���V��", "�w�A�o���h", "�o���b�^", "���{��" };
    string eyeTheme;
    string hairTheme;
    string addItemTheme;
    Random r;
    Text theme;
    char[] texts;
    [SerializeField] GameObject commentPanel;
    public Animator animator;
    public GameObject obj;
    Vector3 position;
    Vector3 eulerAngles;
    string latestButtonClick;    // �ŐV�̓��t
    string textline;   //�e�N�X�g�̕ۑ��p
    public Button btnM; //�������̓{�^���������Ȃ�����
    public Button btnF; //�������̓{�^���������Ȃ�����
    public Button btnW; //�������̓{�^���������Ȃ�����
    public Button btnP; //�������̓{�^���������Ȃ�����

    public static List<string> WorkStr;  //��i�̐������X�g�ŕ\���B�}�ӂƈႢ�A�ǉ����Ă������̂̂��߁B


    // Start is called before the first frame update
    void Start()
    {
        position =  obj.transform.position;
        eulerAngles =  obj.transform.eulerAngles;
        r = new Random();
        theme = GameObject.FindGameObjectWithTag("Comment").GetComponent<Text>();
        commentPanel.SetActive(false);
        WorkStr = new List<string>();
        day = DateTime.Now;   //�����̓��t���擾
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�{�^���������ꂽ���̏���
    public void ButtonClicked()
    {
        //�P���ɂP�񂵂������Ȃ�����
        //if(isClicked()==false)
        //{
            btnM.interactable = false;  //�������̓{�^���������Ȃ�����
            btnF.interactable = false;  //�������̓{�^���������Ȃ�����
            btnW.interactable = false;  //�������̓{�^���������Ȃ�����
            btnP.interactable = false;  //�������̓{�^���������Ȃ�����

            SatokoAction();
            commentShow();  //�R�����g�p�l����\������
            theme.text = null;

            Debug.Log("first");

            int eyeNum = r.Next(0,5);  //�ڂ̃e�[�}�̌���
            eyeTheme = eyes[eyeNum];
            int hairNum = r.Next(0,5);  //���̃e�[�}�̌���
            hairTheme = todayHair(hairNum);
            int itemNum = r.Next(0,6);
            addItemTheme = addItem[itemNum];
            //�e�L�X�g�ւ̏�������
            textline = "�����̃e�[�}��...\n�ڂ�<color=#008000>" + eyeTheme + "</color>�A���^��<color=#0000ff>" + hairTheme + "</color>�ŁA�w�A�A�N�Z�T���[��<color=#ff4500>" + addItemTheme + "</color>�̃L�����N�^�[�ł���I\n�������`�������΂���";

            StartCoroutine(Communication(textline));

            //�ߋ��̃e�[�}�Ɋi�[���邽�߂ɗv�f�����X�g�ɒǉ�
            string ws = eyeTheme + "," + hairTheme + "," + addItemTheme + "," + day.ToString("yyyy/MM/dd");
            WorkStr.Add(ws);
            int hold = WorkStr.Count - 1;
            PlayerPrefs.SetString("WorkRefer" + hold, ws);
            Debug.Log("ws=" + ws);
         //}
        /*else  //���ɉ����Ă�����
        {
            btnM.interactable = false;  //�������̓{�^���������Ȃ�����
            btnF.interactable = false;  //�������̓{�^���������Ȃ�����
            btnW.interactable = false;  //�������̓{�^���������Ȃ�����
            btnP.interactable = false;  //�������̓{�^���������Ȃ�����

            SatokoAction();
            commentShow();  //�R�����g�p�l����\������
            StartCoroutine(Communication(textline));

            Debug.Log("second");
        }*/
    }

    //�ꕶ�����\�����郁�\�b�h
    IEnumerator Communication(string line)
    {
        texts = line.ToCharArray();
        int flag = 0;
        string preserve = null;
        int num = 0;

        //<color>�Ȃǂ��e�L�X�g�ɕ\�������Ȃ����߂ɑJ�ڂ𗘗p
        for (int i = 0; i < texts.Length; i++)
        {
            switch(flag)
            {
                case 0:
                    theme.text += texts[i].ToString();
                    yield return new WaitForSeconds(0.1f);
                    if(texts[i + 1] == '<')
                    {
                        flag = 1;
                    }
                    break;
                case 1:
                    preserve += texts[i].ToString();
                    if (texts[i - 1] == '>')
                    {
                        num++;
                    }
                    if (num == 2)
                    {
                        theme.text += preserve;
                        preserve = null;
                        flag = 2;
                        num = 0;
                    }
                    break;
                case 2:
                    theme.text += texts[i].ToString();
                    yield return new WaitForSeconds(0.1f);
                    if (texts[i + 1] == '<')
                    {
                        flag = 3;
                    }
                    break;
                case 3:
                    preserve += texts[i].ToString();
                    if (texts[i - 1] == '>')
                    {
                        num++;
                    }
                    if(num==2)
                    {
                        theme.text += preserve;
                        preserve = null;
                        flag = 4;
                        num = 0;
                    }
                    break;
                case 4:
                    theme.text += texts[i].ToString();
                    yield return new WaitForSeconds(0.1f);
                    if (texts[i + 1] == '<')
                    {
                        flag = 5;
                    }
                    break;
                case 5:
                    preserve += texts[i].ToString();
                    if (texts[i - 1] == '>')
                    {
                        num++;
                    }
                    if(num==2)
                    {
                        theme.text += preserve;
                        preserve = null;
                        flag = 6;
                        num = 0;
                    }
                    break;
                case 6:
                    theme.text += texts[i].ToString();
                    yield return new WaitForSeconds(0.1f);
                    break;
            }
            
        }
        flag = 0;

        yield return new WaitForSeconds(10.0f);
        theme.text = "";
        commentPanel.SetActive(false);    //��b��ɃR�����g�p�l��������
        latestButtonClick = DateTimeString(System.DateTime.Now);
        btnM.interactable = true;  //������̓{�^����������
        btnF.interactable = true;  //������̓{�^����������
        btnW.interactable = true;  //������̓{�^����������
        btnP.interactable = true;  //������̓{�^����������
    }

    public string todayHair(int num)   //���̒������Ƃɏڍׂȏ���\�����邽�߂̃��\�b�h
    {
        string hair = null;
        int randNum;

        switch (num)
        {
            case 0:  //�����O�̎�
                randNum = r.Next(0, 5);
                hair = longhair[randNum];
                break;
            case 1:  //�Z�~�����O�̎�
                hair = semilonghair[0];
                break;
            case 2:  //�~�f�B�A���̎�
                randNum = r.Next(0, 2);
                hair = medium[randNum];
                break;
            case 3:
                randNum = r.Next(0, 6);
                hair = shorthair[randNum];
                break;
            case 4:
                randNum = r.Next(0, 8);
                hair = elsehair[randNum];
                break;
        }
        return hair;
    }

    public void commentShow()
    {
        commentPanel.SetActive(true);
    }

    //�ȉ��A�j���[�V�����ݒ�
    public void SatokoAction()
    {
        
        Random r = new Random();
        int rnd = r.Next(1, 6);
        switch (rnd)
        {
            case 1:
                animator.SetBool("Head_Lean", true);
                StartCoroutine("IEHead_Lean");
                break;
            case 2:
                animator.SetBool("Kizoku", true);
                StartCoroutine("IEKizoku");
                break;
            case 3:
                animator.SetBool("Koshiate", true);
                StartCoroutine("IEKoshiate");
                break;
            case 4:
                animator.SetBool("Poster", true);
                StartCoroutine("IEPoster");
                break;
            case 5:
                animator.SetBool("Yubisashi", true);
                StartCoroutine("IEYubisashi");
                break;
        }

        Debug.Log("Yes," + rnd);
    }

    IEnumerator IEHead_Lean()
    {
        yield return new WaitForSeconds(15.0f);
        animator.SetBool("Head_Lean", false);
    }

    IEnumerator IEKizoku()
    {
        yield return new WaitForSeconds(15.0f);
        animator.SetBool("Kizoku", false);
    }

    IEnumerator IEKoshiate()
    {
        yield return new WaitForSeconds(15.0f);
        animator.SetBool("Koshiate", false);
    }

    IEnumerator IEPoster()
    {
        yield return new WaitForSeconds(15.0f);
        animator.SetBool("Poster", false);
        obj.transform.eulerAngles = eulerAngles;
        obj.transform.position = position;
    }

    IEnumerator IEYubisashi()
    {
        yield return new WaitForSeconds(15.0f);
        animator.SetBool("Yubisashi", false);
    }

    //�P���ɂP�񂵂��{�^���������Ȃ��悤�ɂ���
    //�{���{�^��������������Ԃ�
    public bool isClicked()
    {
        string today = DateTimeString(System.DateTime.Now);

        Debug.Log(today);
        Debug.Log(latestButtonClick);
        //���߂ĂȂ�false,�Q��ڈȍ~�Ȃ�true
        if (today == latestButtonClick)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    
    //DateTime�ϐ���YYYY/MM/DD�`���ŕԂ�
    public string DateTimeString(DateTime date)
    {
        return date.Year.ToString() + "/" + date.Month.ToString() + "/" + date.Day.ToString();
    }
}
