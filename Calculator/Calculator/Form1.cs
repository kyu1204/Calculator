﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 네트워크 통신에 필요한 변수
        /// </summary>
        /// 
        delegate void ListBoxUpdateDelegate(ListControl ctrl, string s);
        ListBoxUpdateDelegate _listupdate;
        Socket mainSock;
        IPAddress thisAddress;
        List<Socket> connectedClients = new List<Socket>();

        /// <summary>
        /// 계산기에 필요한 변수
        /// </summary>
        List<string> historys; //연산 기록;
        List<string> input; //계산 할 전체 연산 행
        string memory; //M 버튼에 의해 저장되고 로드되는 memory 값을 담는 변수
        string history; //현재 연산 기록 --> 텍스트박스(기록 모니터)와 링크되는 변수
        string view; //현재 입력된 숫자 --> 텍스트박스(모니터)와 링크되는 변수
        string total; //연산 완료된 숫자 --> view변수로 받아온 숫자를 여러 연산 기호 버튼에 따라 계산된 최종 값

        public Form1()
        {
            InitializeComponent();
            ///////////////////////////// 네트워킹 ///////////////////////////////////////////
            mainSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            _listupdate = new ListBoxUpdateDelegate(ListUpdate);

            ///////////////////////////// 계산기 ////////////////////////////////////////
            input = new List<string>(); //초기화
            historys = new List<string>();
            listBox1.DataSource = historys; //Listbox에 컬렉션 연결
            listBox1.Invalidate();
        }
 /// <summary>
 /// 네트워크 통신
 /// </summary>
 /// <param name="ctrl"></param>
 /// <param name="s"></param>
        void ListUpdate(ListControl ctrl, string s)
        {
            if (ctrl.InvokeRequired)
                ctrl.Invoke(_listupdate, ctrl, s);
            else
            {
                historys.Add(s);
                historys.Add("-------------------------------------------------");
                ctrl.DataSource = null;
                ctrl.DataSource = historys;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            IPHostEntry he = Dns.GetHostEntry(Dns.GetHostName());

            // 처음으로 발견되는 ipv4 주소를 사용한다.
            foreach (IPAddress addr in he.AddressList)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    thisAddress = addr;
                    break;
                }
            }

            // 주소가 없다면..
            if (thisAddress == null)
                // 로컬호스트 주소를 사용한다.
                thisAddress = IPAddress.Loopback;

            txt_IP.Text = thisAddress.ToString();
        }

        private void connected_Click(object sender, EventArgs e)
        {
            if (mainSock.Connected)
            {
                MsgBoxHelper.Error("이미 연결되어 있습니다!");
                return;
            }

            int port;
            if (!int.TryParse(txt_Port.Text, out port))
            {
                MsgBoxHelper.Error("포트 번호가 잘못 입력되었거나 입력되지 않았습니다.");
                txt_Port.Focus();
                txt_Port.SelectAll();
                return;
            }

            try
            {
                mainSock.Connect(txt_IP.Text, port);
            }
            catch (Exception ex)
            {
                MsgBoxHelper.Error("연결에 실패했습니다!\n오류 내용: {0}", MessageBoxButtons.OK, ex.Message);
                return;
            }

            // 연결 완료되었다는 메세지를 띄워준다.
            ListUpdate(listBox1, "서버와 연결되었습니다.");

            // 연결 완료, 서버에서 데이터가 올 수 있으므로 수신 대기한다.
            AsyncObject obj = new AsyncObject(4096);
            obj.WorkingSocket = mainSock;
            mainSock.BeginReceive(obj.Buffer, 0, obj.BufferSize, 0, DataReceived, obj);
        }
        void DataReceived(IAsyncResult ar)
        {
            // BeginReceive에서 추가적으로 넘어온 데이터를 AsyncObject 형식으로 변환한다.
            AsyncObject obj = (AsyncObject)ar.AsyncState;

            // 데이터 수신을 끝낸다.
            int received = obj.WorkingSocket.EndReceive(ar);

            // 받은 데이터가 없으면(연결끊어짐) 끝낸다.
            if (received <= 0)
            {
                obj.WorkingSocket.Close();
                return;
            }

            // 텍스트로 변환한다.
            string text = Encoding.UTF8.GetString(obj.Buffer);

            // 0x01 기준으로 짜른다.
            // tokens[0] - 보낸 사람 IP
            // tokens[1] - 보낸 메세지
            string[] tokens = text.Split('\x01');
            string ip = tokens[0];
            string msg = tokens[1];

            // 텍스트박스에 추가해준다.
            // 비동기식으로 작업하기 때문에 폼의 UI 스레드에서 작업을 해줘야 한다.
            // 따라서 대리자를 통해 처리한다.
            _listupdate(listBox1, string.Format("[ {0} ]: {1}", ip, msg));

            // 클라이언트에선 데이터를 전달해줄 필요가 없으므로 바로 수신 대기한다.
            // 데이터를 받은 후엔 다시 버퍼를 비워주고 같은 방법으로 수신을 대기한다.
            obj.ClearBuffer();

            // 수신 대기
            obj.WorkingSocket.BeginReceive(obj.Buffer, 0, 4096, 0, DataReceived, obj);
        }

        void OnSendData()
        {
            // 서버가 대기중인지 확인한다.
            if (!mainSock.IsBound)
            {
                MsgBoxHelper.Warn("서버가 실행되고 있지 않습니다!");
                return;
            }

            // 보낼 텍스트
            string tts = history.Trim();
            if (string.IsNullOrEmpty(tts))
            {
                MsgBoxHelper.Warn("연산기록이 없습니다!");
                return;
            }

            // 서버 ip 주소와 메세지를 담도록 만든다.
            IPEndPoint ip = (IPEndPoint)mainSock.LocalEndPoint;
            string addr = ip.Address.ToString();

            // 문자열을 utf8 형식의 바이트로 변환한다.
            byte[] bDts = Encoding.UTF8.GetBytes(addr + '\x01' + tts);

            // 서버에 전송한다.
            mainSock.Send(bDts);
        }
        /// <summary>
        /// Button Event 처리 부분
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)  //0~9 숫자 버튼 처리
        {
            view += "1";
            history += "1";
            ShowText(view);
            ShowHistory(history);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            view += "2";
            history += "2";

            ShowHistory(history);
            ShowText(view);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            view += "3";
            history += "3";

            ShowHistory(history);
            ShowText(view);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            view += "4";
            history += "4";

            ShowHistory(history);
            ShowText(view);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            view += "5";
            history += "5";

            ShowHistory(history);
            ShowText(view);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            view += "6";
            history += "6";

            ShowHistory(history);
            ShowText(view);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            view += "7";
            history += "7";

            ShowHistory(history);
            ShowText(view);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            view += "8";
            history += "8";

            ShowHistory(history);
            ShowText(view);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            view += "9";
            history += "9";

            ShowHistory(history);
            ShowText(view);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            view += "0";
            history += "0";

            ShowHistory(history);
            ShowText(view);
        }

        private void Plus_Click(object sender, EventArgs e) //+버튼 처리
        {
            if (view != null) //view 값이 null이 아님 즉 값이 입력 되었을때에 처리
            {
                if(view.EndsWith("."))
                {
                    view = view.Remove(view.LastIndexOf('.'));
                    history = history.Remove(history.LastIndexOf('.'));
                }
                history += "+"; //history --> '직전값' '+' 
                ShowHistory(history); //화면에 띄우기
                if (total == null) //total 값이 null 즉 첫번째로 입력된 숫자
                {
                    total = view; //첫 번째 입력 값이기 때문에 최종값 = 현재값
                    input.Add(view); //계산을 위한 연산식에 추가
                    input.Add("+"); //다음에 입력받을 숫자와 + 하려는 것이기 때문에 + 기호 추가
                    view = null; //값이 저장 되었으니 입력된 현재값은 제거
                    ShowText(total);
                }
                else //total 값이 null이 아님 즉 첫번째 값이 아님
                {
                    total = ResultValue(double.Parse(view)); //현재 값을 넘겨주어 기록된 연산기록에 의거해 최종값을 계산함
                    if (DivisionError(total) == 0) //중간에 0으로 나누는 에러가 있을시 에러 처리
                    {
                        ShowText(total);
                        view = null;
                        total = null;
                        history = null;
                        input.Clear();
                    }
                    else 
                    {
                        input.Add("+"); //에러가 없다면 이후 값과 + 하는것이기 때문에 + 연산기호 추가
                        view = null; 
                        ShowText(total); //화면에 계산된 최종값 띄워주기
                    }
                }
            }
            else //view값이 null 즉 아무숫자입력없이 +연산기호만 눌렸을 경우
            {
                if (total != null) //직전 연산값이 있을경우
                {
                    history += input[input.Count - 2]; //연산기호의 마지막 item(Count-1)은 연산기호 즉 직전 값을 계속 더하기위해 연산기호 전인 마지막 입력 값을 가져옴 (Count-2)
                    history += "+"; //다음 연산이 + 이기 때문에 기호 추가
                    ShowHistory(history); //연산 기록 화면의 띄움
                    total = ResultValue(double.Parse(input[input.Count - 2])); //값을 가져와서 실제로 계산 하는 작업 수행
                    input.Add("+"); //실제 연산기호에 + 추가
                    ShowText(total); //화면에 최종 연산 값 출력
                }
            }
        }

        private void Minus_Click(object sender, EventArgs e) //+와 동일
        {
            if (view != null)
            {
                if (view.EndsWith("."))
                {
                    view = view.Remove(view.LastIndexOf('.'));
                    history = history.Remove(history.LastIndexOf('.'));

                }
                history += "-";
                ShowHistory(history);
                if (total == null)
                {
                    total = view;
                    input.Add(view);
                    input.Add("-");
                    view = null;
                }
                else
                {
                    total = ResultValue(double.Parse(view));
                    if (DivisionError(total) == 0)
                    {
                        ShowText(total);
                        view = null;
                        total = null;
                        history = null;
                        input.Clear();
                    }
                    else
                    {
                        input.Add("-");
                        view = null;
                        ShowText(total);
                    }
                }
            }
            else
            {
                if (total != null)
                {
                    history += input[input.Count - 2];
                    history += "-";
                    ShowHistory(history);
                    total = ResultValue(double.Parse(input[input.Count - 2]));
                    input.Add("-");
                    ShowText(total);
                }
            }
        }

        private void Multi_Click(object sender, EventArgs e) //+와 동일
        {
            if (view != null)
            {
                if (view.EndsWith("."))
                {
                    view = view.Remove(view.LastIndexOf('.'));
                    history = history.Remove(history.LastIndexOf('.'));

                }
                history += "×";
                ShowHistory(history);
                if (total == null)
                {
                    total = view;
                    input.Add(view);
                    input.Add("*");
                    view = null;
                }
                else
                {
                    total = ResultValue(double.Parse(view));
                    if (DivisionError(total) == 0)
                    {
                        ShowText(total);
                        view = null;
                        total = null;
                        history = null;
                        input.Clear();
                    }
                    else
                    {
                        input.Add("*");
                        view = null;
                        ShowText(total);
                    }
                }
            }
            else
            {
                if (total != null)
                {
                    history += input[input.Count - 2];
                    history += "×";
                    ShowHistory(history);
                    total = ResultValue(double.Parse(input[input.Count - 2]));
                    input.Add("*");
                    ShowText(total);
                }
            }
        }

        private void Division_Click(object sender, EventArgs e) //+와 동일
        {
            if (view != null)
            {
                if (view.EndsWith("."))
                {
                    view = view.Remove(view.LastIndexOf('.'));
                    history = history.Remove(history.LastIndexOf('.'));

                }
                history += "÷";
                ShowHistory(history);
                if (total == null)
                {
                    total = view;
                    input.Add(view);
                    input.Add("/");
                    view = null;
                }
                else
                {
                    total = ResultValue(double.Parse(view));
                    if (DivisionError(total) == 0)
                    {
                        ShowText(total);
                        view = null;
                        total = null;
                        history = null;
                        input.Clear();
                    }
                    else
                    {
                        input.Add("/");
                        view = null;
                        ShowText(total);
                    }
                }
            }
            else
            {
                if (total != null)
                {
                    history += input[input.Count - 2];
                    history += "÷";
                    ShowHistory(history);
                    total = ResultValue(double.Parse(input[input.Count - 2]));
                    input.Add("÷");
                    ShowText(total);
                }
            }
        }

        private void Negative_Click(object sender, EventArgs e) //± 버튼 클릭 처리
        {
            if (view != null)
            {
                double temp = double.Parse(view);// 현재 입력된 값을 실수로 옮김
                temp = temp * -1; //그 후 -1을 곱함 (음수면 양수 양수면 음수)
                view = temp.ToString(); //다시 문자열화 시켜서 view에 저장
                history = temp.ToString();
                ShowHistory(history);
                ShowText(view);
            }
        }

        private void Cancel_Click(object sender, EventArgs e) //C 버튼 클릭 처리
        {
            view = null; //view, history total textbox1 textbox2 모두 클리어
            history = null;
            total = null;
            input.Clear();
            textBox1.Clear();
            textBox2.Clear();
            ShowHistory(history);
            ShowText(view);
        }

        private void ButtonDot_Click(object sender, EventArgs e) //.버튼 클릭 처리
        {
            if (!view.Contains(".")) //현재 값에 .이 없다면 
            {
                history += "."; //현재 값 끝에 . 추가
                view += ".";
                ShowHistory(history);
                ShowText(view);
            }
        }

        private void Result_Click(object sender, EventArgs e) // = 버튼 처리
        {
            if (view != null) //view가 null이 아니면 즉 입력값이 있다면
            {
                if (view.EndsWith("."))
                {
                    view = view.Remove(view.LastIndexOf('.'));
                    history += view;
                }
                if (total == null)
                {
                    ShowText(view);
                }
                else
                {
                    total = ResultValue(double.Parse(view)); //현재 값 까지 최종값 계산
                    if (DivisionError(total) == 0) //0 나누기 에러 처리
                    {
                        ShowText(total);
                        view = null;
                        total = null;
                        history = null;
                        input.Clear();
                    }
                    else
                    {
                        history += "="; //기록에 = 추가
                        history += total; //최종값 추가
                        ShowHistory(history);

                        view = null; //현재 입력값 초기화
                        ShowText(total); //최종값 화면에 보이기

                        total = null;
                        input.Clear(); //연산식 초기화

                        /////// Send //////
                        if (mainSock.IsBound)
                        {
                            OnSendData();
                        }
                        historys.Add(history); //현재 연산기록을 리스트 박스에 등록하기위해 List에 추가
                        historys.Add("-------------------------------------------------"); //구분선 추가
                        RebindingListBox(listBox1, historys); //Listbox 업데이트
                        history = null; //현재 연산기록 초기화

                    }
                }
            }
            else
            {
                ShowText(total); //현재 입력값이 없다면 최종값 화면에 보이기
            }
        }

        private void M_plus_Click(object sender, EventArgs e) //M+ 버튼 처리
        {
            if (memory == null) //memory 가 null 즉 현재값을 메모리에 등록할 때에
            {
                if (view != null) //view가 널이 아니면 즉 입력값이 존재 할때
                {
                    if (view.EndsWith("."))
                    {
                        view = view.Remove(view.LastIndexOf('.'));
                        history += view;
                    }
                    if (total == null) //total 이 null일때 즉 계산식이 없고 입력값만 존재할 때
                    {
                        memory = string.Copy(view); //현재 입력값을 memory에 등록
                        historys.Add("Memory에 값이 성공적으로 저장 되었습니다.");
                        historys.Add(string.Format("Memory: {0}", memory));
                        historys.Add("-------------------------------------------------");
                        RebindingListBox(listBox1, historys);
                        view = null;
                        history = null;
                    }
                    else //total이 존재 할 때 즉 계산식이 존재할때
                    {
                        total = ResultValue(double.Parse(view)); //현재값까지 추가해서 최종 연산값 추출
                        if (DivisionError(total) == 0) //0 나누기 에러 처리
                        {
                            ShowText(total);
                            view = null;
                            total = null;
                            history = null;
                            input.Clear();
                        }
                        else
                        {
                            view = null; //입력값 초기화
                            history = null; //기록 초기화
                            memory = string.Copy(total); //메모리에 최종연산값 등록
                            historys.Add("Memory에 값이 성공적으로 저장 되었습니다.");
                            historys.Add(string.Format("Memory: {0}", memory));
                            historys.Add("-------------------------------------------------");
                            RebindingListBox(listBox1, historys);
                            total = null; //최종값 초기화
                            input.Clear(); //연산식 초기화
                        }
                    }
                }
            }
            else //메모리에 값이 존재할 때 즉 기존 메모리값에 현재 값을 더할 때
            {
                if (view != null) //view가 null이 아닐때 즉 입력값이 존재할때
                {
                    if (view.EndsWith("."))
                    {
                        view = view.Remove(view.LastIndexOf('.'));
                        history += view;
                    }
                    if (total == null) //total이 null일때 즉 연산이 없고 첫번째 입력값일때
                    {
                        double tmp = double.Parse(memory); //메모리값을 읽어와서 double로 변경
                        tmp += double.Parse(view); //현재 입력값을 기존 메모리값에 더함
                        memory = tmp.ToString(); //더한 값을 memory에 저장
                        historys.Add("Memory에 값이 성공적으로 저장 되었습니다.");
                        historys.Add(string.Format("Memory: {0}", memory));
                        historys.Add("-------------------------------------------------");
                        RebindingListBox(listBox1, historys);
                        view = null; //현재값 초기화
                        history = null;
                    }
                    else //total이 null이 아닐때 즉 계산식이 존재할 때
                    {
                        total = ResultValue(double.Parse(view)); //현재값을 추가해서 최종연산값 추출
                        if (DivisionError(total) == 0) //0 나누기 에러 처리 (에러 발생시 0 리턴)
                        {
                            ShowText(total); //에러 발생시 모두 초기화
                            view = null;
                            total = null;
                            history = null;
                            input.Clear();
                        }
                        else
                        {
                            view = null; //입력값 초기화
                            history = null; //기록 초기화

                            double tmp = double.Parse(memory); //메모리값 읽어오기
                            tmp += double.Parse(total); //최종연산값 기존 메모리값에 더하기
                            memory = tmp.ToString(); //메모리에 저장
                            historys.Add("Memory에 값이 성공적으로 저장 되었습니다.");
                            historys.Add(string.Format("Memory: {0}", memory));
                            historys.Add("-------------------------------------------------");
                            RebindingListBox(listBox1, historys);
                            total = null; //최종값 날리기
                            input.Clear(); //연산식 날리기
                        }
                    }
                }
            }
        }

        private void MR_Click(object sender, EventArgs e) //MR 버튼 처리
        {
            history = null; //기록 초기화
            view = null; //입력값 초기화
            history += memory; //기록 -> 메모리에서 로드한 값으로 변경

            view += memory; //입력값 을 메모리에서 로드한 값으로 변경
            ShowHistory(history); //화면 띄우기
            ShowText(view);
        }

        private void MC_Click(object sender, EventArgs e) //MC 버튼 처리
        {
            memory = null; //memory값 초기화
        }

        private void M_minus_Click(object sender, EventArgs e) //M- 버튼 처리 (M+ 와 동일)
        {
            if (memory != null)
            {
                if (view != null)
                {
                    if (view.EndsWith("."))
                    {
                        view = view.Remove(view.LastIndexOf('.'));
                        history += view;
                    }
                    if (total == null)
                    {
                        total = view;
                        view = null;
                        history = null;
                        double tmp = double.Parse(memory);
                        tmp -= double.Parse(total);
                        memory = tmp.ToString();
                        historys.Add("Memory에 값이 성공적으로 저장 되었습니다.");
                        historys.Add(string.Format("Memory: {0}", memory));
                        historys.Add("-------------------------------------------------");
                        RebindingListBox(listBox1, historys);
                        total = null;
                    }
                    else
                    {
                        total = ResultValue(double.Parse(view));
                        if (DivisionError(total) == 0)
                        {
                            ShowText(total);
                            view = null;
                            total = null;
                            history = null;
                            input.Clear();
                        }
                        else
                        {
                            view = null;
                            history = null;

                            double tmp = double.Parse(memory);
                            tmp -= double.Parse(total);
                            memory = tmp.ToString();
                            historys.Add("Memory에 값이 성공적으로 저장 되었습니다.");
                            historys.Add(string.Format("Memory: {0}", memory));
                            historys.Add("-------------------------------------------------");
                            RebindingListBox(listBox1, historys);
                            total = null;
                            input.Clear();
                        }
                    }
                }
            }
        }
        //private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    this.Text = e.KeyChar.ToString();
        //    switch (e.KeyChar)
        //    {
        //        case '+':
        //            this.Plus_Click(sender, e);
        //            break;
        //        case '-':
        //            this.Minus_Click(sender, e);
        //            break;
        //        case '*':
        //            this.Multi_Click(sender, e);
        //            break;
        //        case '/':
        //            this.Division_Click(sender, e);
        //            break;
        //        case (char)Keys.Enter:
        //            this.Result_Click(sender, e);
        //            break;
        //        case (char)'.':
        //            this.ButtonDot_Click(sender, e);
        //            break;
        //        default:
        //            if (e.KeyChar >= 48 && e.KeyChar <= 57)
        //            {
        //                int value = int.Parse(e.KeyChar.ToString()) % 48;
        //                view += value.ToString();
        //                history += value.ToString();

        //                ShowText(view);
        //                ShowHistory(history);
        //            }
        //            break;
        //    }
        //}
        /// <summary>
        /// 내부에서 사용하는 사용자 메서드 부분
        /// </summary>
        /// <param name="v"></param>
        private void ShowHistory(string v) //textbox2 위 텍스트박스(기록 모니터)에 데이터 띄우는 함수
        {
            textBox2.Text = v;
            textBox2.Refresh();
        }
        private void ShowText(string v) //textbox1 아래 텍스트박스(값 모니터)에 데이터 띄우는 함수
        {
            textBox1.Text = v;
            textBox1.Refresh();
        }

        private string ResultValue(double view) //연산식 처리 함수 현재 입력값을 매개변수로 받아옴
        {
            double result = 0;
            input.Add(view.ToString()); //현재 입력값을 연산식 마지막에 등록

            for (int i = 0; i < input.Count-1; ++i) //반복문을 이용한 연산
            {
                if(i == 0) //첫 번째 숫자일때에 현재 값을 result에 등록
                {
                    result = double.Parse(input[i]);
                }
                else
                {
                    switch(input[i]) //switch로 연산기호에 따라 처리
                    {
                        case "+":
                            result += double.Parse(input[i + 1]); //input[i] -> 현재 연산기호 input[i+1] -> 다음 값
                            break;
                        case "-":
                            result -= double.Parse(input[i + 1]);
                            break;
                        case "*":
                            result *= double.Parse(input[i + 1]);
                            break;
                        case "/":
                            if (double.Parse(input[i + 1]) == 0) //0 나누기 에러 감지
                            {

                                return "0 으로는 나눌 수 없습니다."; //연산 강제종료 하면서 에러메세지 리턴
                            }
                            else
                            {
                                result /= double.Parse(input[i + 1]);
                            }
                            break;
                    }
                }
            }

            return result.ToString(); //최종 연산값 리턴
        }

        private int DivisionError(string total) //0 나누기 에러 처리
        {
            if(total.CompareTo("0 으로는 나눌 수 없습니다.") == 0) //리턴받은 값이 에러메세지일때
            {
                return 0; //0 리턴
            }
            else //정상 값이면 
            {
                return 1; //1 리턴
            }
        }

        private void RebindingListBox(ListBox listbox, List<string> list) //Listbox 업데이트 함수
        {
            listbox.DataSource = null;
            listbox.DataSource = list;
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            listBox1.SetSelected(listBox1.Items.Count - 1, false);
        }

        
    }
}
