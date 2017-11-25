using System;
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

namespace Server
{
    public partial class Calculator_Server : Form
    {
        delegate void AppendTextDelegate(Control ctrl, string s);
        AppendTextDelegate _textAppender;
        Socket server;
        IPAddress thisAddress;
        List<Socket> connectedClients = new List<Socket>();

        public Calculator_Server()
        {
            InitializeComponent();
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            _textAppender = new AppendTextDelegate(AppendText);

        }

        void AppendText(Control ctrl, string s)
        {
            if (ctrl.InvokeRequired)
                ctrl.Invoke(_textAppender, ctrl, s);
            else
            {
                string source = ctrl.Text;
                ctrl.Text = source + Environment.NewLine + s;
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

        private void start_Click(object sender, EventArgs e)
        {
            int port;
            if (!int.TryParse(txt_Port.Text, out port))
            {
                MsgBoxHelper.Error("포트 번호가 잘못 입력되었거나 입력되지 않았습니다.");
                txt_Port.Focus();
                txt_Port.SelectAll();
                return;
            }
            AppendText(txt_history, string.Format("==========================================="));
            AppendText(txt_history, string.Format("서버가 구동 되었습니다."));
            AppendText(txt_history, string.Format("IP: {0} 포트: {1}", thisAddress, port));
            AppendText(txt_history, string.Format("==========================================="));


            // 서버에서 클라이언트의 연결 요청을 대기하기 위해
            // 소켓을 열어둔다.
            IPEndPoint serverEP = new IPEndPoint(thisAddress, port);
            server.Bind(serverEP);
            server.Listen(10);

            // 비동기적으로 클라이언트의 연결 요청을 받는다.
            server.BeginAccept(AcceptCallback, null);
        }

        void AcceptCallback(IAsyncResult ar)
        {
            // 클라이언트의 연결 요청을 수락한다.
            Socket client = server.EndAccept(ar);

            // 또 다른 클라이언트의 연결을 대기한다.
            server.BeginAccept(AcceptCallback, null);

            AsyncObject obj = new AsyncObject(4096);
            obj.workingsocket = client;

            // 연결된 클라이언트 리스트에 추가해준다.
            connectedClients.Add(client);

            // 텍스트박스에 클라이언트가 연결되었다고 써준다.
            AppendText(txt_history, string.Format("클라이언트 (@ {0})가 연결되었습니다.", client.RemoteEndPoint));

            // 클라이언트의 데이터를 받는다.
            client.BeginReceive(obj.buffer, 0, 4096, 0, DataReceived, obj);
        }
        void DataReceived(IAsyncResult ar)
        {
            // BeginReceive에서 추가적으로 넘어온 데이터를 AsyncObject 형식으로 변환한다.
            AsyncObject obj = (AsyncObject)ar.AsyncState;
            // 데이터 수신을 끝낸다.
            try
            {
                int received = obj.workingsocket.EndReceive(ar);
                if (received <= 0)
                {
                    obj.workingsocket.Close();
                    return;
                }
            }
            catch
            {
                AppendText(txt_history, string.Format("클라이언트 (@ {0})가 연결이 종료 되었습니다.",obj.workingsocket.RemoteEndPoint));
                obj.workingsocket.Close();
                return;
            }

            // 받은 데이터가 없으면(연결끊어짐) 끝낸다.
            

            // 텍스트로 변환한다.
            string text = Encoding.UTF8.GetString(obj.buffer);

            // 0x01 기준으로 짜른다.
            // tokens[0] - 보낸 사람 IP
            // tokens[1] - 보낸 메세지
            string[] tokens = text.Split('\x01');
            string ip = tokens[0];
            string msg = tokens[1];

            // 텍스트박스에 추가해준다.
            // 비동기식으로 작업하기 때문에 폼의 UI 스레드에서 작업을 해줘야 한다.
            // 따라서 대리자를 통해 처리한다.
            AppendText(txt_history, string.Format("[받음]{0}: {1}", ip, msg));

            // for을 통해 "역순"으로 클라이언트에게 데이터를 보낸다.
            for (int i = connectedClients.Count - 1; i >= 0; i--)
            {
                Socket socket = connectedClients[i];
                if (socket != obj.workingsocket)
                {
                    try
                    {
                        socket.Send(obj.buffer);
                    }
                    catch
                    {
                        // 오류 발생하면 전송 취소하고 리스트에서 삭제한다.
                        try
                        {
                            socket.Dispose();
                        }
                        catch
                        {
                        }
                        connectedClients.RemoveAt(i);
                    }
                }
            }

            // 데이터를 받은 후엔 다시 버퍼를 비워주고 같은 방법으로 수신을 대기한다.
            obj.ClearBuffer();

            // 수신 대기
            obj.workingsocket.BeginReceive(obj.buffer, 0, 4096, 0, DataReceived, obj);
        }
    }
}
