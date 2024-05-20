using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace SmartWindowApp
{
    public partial class Form1 : Form
    {
        SerialPort serialPort;

        public Form1()
        {
            InitializeComponent();
            InitializeSerialPort();
        }

        private void InitializeSerialPort()
        {
            serialPort = new SerialPort("COM3", 9600); // 아두이노가 연결된 COM 포트 번호로 변경하세요.
            serialPort.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 폼 로드 시 필요한 초기화 작업을 여기에 추가할 수 있습니다.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SmartWindow window = new SmartWindow(serialPort);

            // 수동 조작: 창문 열기
            window.OpenWindow();

            // 수동 조작: 창문 닫기
            window.CloseWindow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 자동 조작 로직을 여기에 추가합니다.
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort.Write("R"); // 아두이노에 센서 데이터 요청

            System.Threading.Thread.Sleep(2000); // 데이터 수신을 기다리기 위해 잠시 대기
            string response = serialPort.ReadExisting();
            MessageBox.Show(response, "현재 온습도");
        }

        public class SmartWindow
        {
            private bool isOpen;
            private SerialPort serialPort;

            public SmartWindow(SerialPort port)
            {
                serialPort = port;
            }

            // 창문 열기
            public void OpenWindow()
            {
                isOpen = true;
                serialPort.Write("O"); // 아두이노에 창문 열기 명령 전송
                Console.WriteLine("창문이 열렸습니다.");
            }

            // 창문 닫기
            public void CloseWindow()
            {
                isOpen = false;
                serialPort.Write("C"); // 아두이노에 창문 닫기 명령 전송
                Console.WriteLine("창문이 닫혔습니다.");
            }
        }
    }
}

